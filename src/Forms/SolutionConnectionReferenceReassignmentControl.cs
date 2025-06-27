using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SolutionConnectionReferenceReassignment.Models;
using SolutionConnectionReferenceReassignment.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace SolutionConnectionReferenceReassignment
{
    public partial class SolutionConnectionReferenceReassignmentControl : PluginControlBase
    {
        private Settings mySettings;

        public SolutionConnectionReferenceReassignmentControl()
        {
            InitializeComponent();
            cmb_SolutionList.SelectedIndexChanged += cmb_SolutionList_SelectedIndexChanged;
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetAccounts);
        }

        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void btn_LoadSolution_Click(object sender, EventArgs e)
        {
            if (Service == null)
            {
                MessageBox.Show("Please connect to an environment first.", "No Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading solutions...",
                Work = (worker, args) =>
                {
                    var solutionService = new SolutionService(Service);
                    var solutionList = solutionService.GetUnmanagedSolutions();
                    args.Result = solutionList;
                },
                PostWorkCallBack = args =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show("Error: " + args.Error.Message);
                        return;
                    }

                    var solutions = (List<SolutionModel>)args.Result;

                    cmb_SolutionList.Items.Clear();
                    cmb_SolutionList.Items.AddRange(solutions.ToArray());

                    if (cmb_SolutionList.Items.Count > 0)
                        cmb_SolutionList.SelectedIndex = 0;

                    LogInfo($"Loaded {solutions.Count} solutions.");
                }

                
            });
        }

        private void cmb_SolutionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cmb_SolutionList.SelectedItem as SolutionModel;
            if (selected == null)
                return;

            dgv_Flows.DataSource = null;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading flows...",
                Work = (worker, args) =>
                {
                    var flowService = new FlowService(Service);
                    args.Result = flowService.GetFlowsInSolution(selected.SolutionId);
                },
                PostWorkCallBack = args =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show("Error loading flows: " + args.Error.Message);
                        return;
                    }

                    var flows = (List<FlowModel>)args.Result;
                    dgv_Flows.DataSource = flows;
                    LogInfo($"Loaded {flows.Count} flows from solution: {selected.FriendlyName}");
                }
            });
        }
        private void dgv_Flows_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}