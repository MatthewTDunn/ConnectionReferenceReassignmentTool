using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using SolutionConnectionReferenceReassignment.Models;
using SolutionConnectionReferenceReassignment.Services;
using System;
using System.Collections.Generic;
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

        private void dgv_Flows_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Flows.CurrentRow == null)
                return;

            var selectedFlow = dgv_Flows.CurrentRow.DataBoundItem as FlowModel;
            if (selectedFlow == null)
                return;

            var actionService = new FlowActionService(Service);
            var actions = actionService.GetActionsFromFlow(selectedFlow.FlowId);
            dgv_FlowActionList.DataSource = actions;
        }

        private void tsb_closetool_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MatthewTDunn/ConnectionReferenceReassignmentTool");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: your logic here
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tsb_RefreshSolutionList_Click(object sender, EventArgs e)
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

        private void cmb_SolutionList_Click(object sender, EventArgs e)
        {

        }

    }
}