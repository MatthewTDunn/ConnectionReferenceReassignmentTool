using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using SolutionConnectionReferenceReassignment.Models;
using SolutionConnectionReferenceReassignment.Services;
using SolutionConnectionReferenceReassignment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            dgv_ConnectionReferenceList.DataSource = null;

            LogInfo("This is a PluginLog");

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading flows and connection references...",
                Work = (worker, args) =>
                {
                    // Step 1: Get flow metadata list (unchanged)
                    var flowService = new FlowMetadataService(Service);
                    var flows = flowService.GetFlowsInSolution(selected.SolutionId);

                    // Step 2: Use orchestrator to get all connection references
                    var orchestrator = new FlowDefinitionOrchestrator(Service);
                    var (_, connectionReferences) = orchestrator.GetSolutionFlowDefinitionData(selected.SolutionId);

                    args.Result = new
                    {
                        Flows = flows,
                        ConnectionReferences = connectionReferences
                    };
                },
                PostWorkCallBack = args =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show("Error loading flows or references: " + args.Error.Message);
                        return;
                    }

                    dynamic result = args.Result;
                    var flows = (List<FlowMetadataModel>)result.Flows;
                    var connectionReferences = (List<FlowConnectionReferenceModel>)result.ConnectionReferences;

                    if (connectionReferences.Count == 0)
                    {
                        connectionReferences.Add(new FlowConnectionReferenceModel
                        {
                            Name = "test_name",
                            LogicalName = "test_logical",
                            RuntimeSource = "test_source",
                            DisplayName = "Test Display"
                        });
                    }

                    dgv_Flows.DataSource = flows;
                    dgv_ConnectionReferenceList.DataSource = connectionReferences;

                    LogInfo($"Loaded {flows.Count} flows and {connectionReferences?.Count} connection references from solution: {selected.FriendlyName}");
                }
            });
        }

        private void dgv_Flows_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Flows_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

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

                    cmb_SolutionList.SelectedIndexChanged -= cmb_SolutionList_SelectedIndexChanged; // temporarily remove the indexchanged event for the combo box as we don't want it to trigger immediately on solution list load

                    cmb_SolutionList.Items.Clear();
                    cmb_SolutionList.Items.AddRange(solutions.ToArray());

                    if (cmb_SolutionList.Items.Count > 0)
                        cmb_SolutionList.SelectedIndex = 0;

                    cmb_SolutionList.SelectedIndexChanged += cmb_SolutionList_SelectedIndexChanged; // re-attach

                    LogInfo($"Loaded {solutions.Count} solutions.");
                }


            });
        }

        private void cmb_SolutionList_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_Flows_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_ConnectionReferenceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}