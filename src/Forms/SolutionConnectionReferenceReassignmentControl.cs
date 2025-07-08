using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SolutionConnectionReferenceReassignment.Models;
using SolutionConnectionReferenceReassignment.Services;
using SolutionConnectionReferenceReassignment.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.Services.Description;
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
            
            // Event subscriber list
            tree_SolutionFlowExplorer.BeforeExpand += tree_SolutionFlowExplorer_BeforeExpand;

            dgv_ConnectionReferenceList.CellFormatting += dgv_ConnectionReferenceList_CellFormatting;

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

        #region Solution Initialisation

        private void cmb_SolutionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cmb_SolutionList.SelectedItem as SolutionModel;
            if (selected == null)
                return;

            dgv_FlowActionList.DataSource = null;
            dgv_ConnectionReferenceList.DataSource = null;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading flows and connection references...",
                Work = (worker, args) =>
                {
                    var flowService = new FlowMetadataService(Service);
                    var flows = flowService.GetFlowsInSolution(selected.SolutionId);

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

                    dgv_FlowActionList.DataSource = flows;
                    dgv_ConnectionReferenceList.DataSource = connectionReferences;

                    LogInfo($"Loaded {flows.Count} flows and {connectionReferences?.Count} connection references from solution: {selected.FriendlyName}");

                    var replacementOptions = new List<string> { "connector a", "connector b" };
                    SetupConnectionReferenceGrid(connectionReferences, replacementOptions);

                }
            });
        }

        private void SetupConnectionReferenceGrid(List<FlowConnectionReferenceModel> data, List<string> replacementOptions)
        {
            dgv_ConnectionReferenceList.AutoGenerateColumns = false;
            dgv_ConnectionReferenceList.Columns.Clear();

            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Display Name",
                DataPropertyName = "DisplayName",
                ReadOnly = true
            });
            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                DataPropertyName = "Name",
                ReadOnly = true
            });
            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Logical Name",
                DataPropertyName = "LogicalName",
                ReadOnly = true
            });
            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Runtime Source",
                DataPropertyName = "RuntimeSource",
                ReadOnly = true
            });

            var comboColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Replacement Connection Reference",
                DataPropertyName = "ReplacementConnectionReference",
                DataSource = replacementOptions,
                FlatStyle = FlatStyle.Flat
            };
            dgv_ConnectionReferenceList.Columns.Add(comboColumn);

            var assignmentValidColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Assignment Valid",
                DataPropertyName = "AssignmentValid",
                ReadOnly = true
            };
            dgv_ConnectionReferenceList.Columns.Add(assignmentValidColumn);

            dgv_ConnectionReferenceList.DataSource = data;
        }

        private void dgv_ConnectionReferenceList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_ConnectionReferenceList.Columns[e.ColumnIndex].DataPropertyName == "AssignmentValid")
            {
                bool isValid = (bool)e.Value;
                e.CellStyle.BackColor = isValid ? Color.LightGreen : Color.LightCoral;
            }
        }


        #endregion


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

                    // ✅ Update TreeView
                    tree_SolutionFlowExplorer.BeginUpdate();
                    tree_SolutionFlowExplorer.Nodes.Clear();

                    var environmentNode = new TreeNode("Current Environment")
                    {
                        ImageKey = "treeicon_environment.png",
                        SelectedImageKey = "treeicon_environment.png"
                    }; 
                    foreach (var solution in solutions)
                    {
                        var solutionNode = new TreeNode(solution.FriendlyName)
                        {
                            Tag = solution, 
                            ImageKey = "treeicon_solution.png",
                            SelectedImageKey = "treeicon_solution.png"
                        };

                        // Optional placeholder node for lazy loading
                        solutionNode.Nodes.Add(new TreeNode("Loading..."));

                        environmentNode.Nodes.Add(solutionNode);
                    }

                    tree_SolutionFlowExplorer.Nodes.Add(environmentNode);
                    environmentNode.Expand();

                    tree_SolutionFlowExplorer.EndUpdate();
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

        private void tree_SolutionFlowExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (node == null) return;

            var actionService = new FlowActionService(Service);
            List<FlowActionModel> actions = new List<FlowActionModel>();

            if (node.Tag is SolutionModel solution)
            {
                // Get all flows in the solution
                var flowService = new FlowMetadataService(Service);
                var flows = flowService.GetFlowsInSolution(solution.SolutionId);

                foreach (var flow in flows)
                {
                    actions.AddRange(actionService.GetFlowActions(flow.FlowId));
                }
            }
            else if (node.Tag is FlowMetadataModel flowMetadata)
            {
                actions = actionService.GetFlowActions(flowMetadata.FlowId);
            }
            else if (node.Tag is FlowActionModel flowAction)
            {
                actions = new List<FlowActionModel> { flowAction };
            }

            dgv_FlowActionList.DataSource = null; // Clear existing
            dgv_FlowActionList.DataSource = actions;
        }


        private void tree_SolutionFlowExplorer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var node = e.Node;
            if (node == null) return;

            if (node.Tag is SolutionModel solution &&
                node.Nodes.Count == 1 && node.Nodes[0].Text == "Loading...")
            {
                node.Nodes.Clear();

                var flowService = new FlowMetadataService(Service);
                var flows = flowService.GetFlowsInSolution(solution.SolutionId);

                foreach (var flow in flows)
                {
                    var flowNode = new TreeNode(flow.Name)
                    {
                        Tag = flow,
                        ImageKey = "treeicon_powerautomate.png",
                        SelectedImageKey = "treeicon_powerautomate.png"
                    };

                    // Add placeholder for lazy loading actions
                    flowNode.Nodes.Add(new TreeNode("Loading..."));

                    node.Nodes.Add(flowNode);
                }
            }
            else if (node.Tag is FlowMetadataModel flowMetadata &&
                     node.Nodes.Count == 1 && node.Nodes[0].Text == "Loading...")
            {
                node.Nodes.Clear();

                var actionService = new FlowActionService(Service);
                var actions = actionService.GetFlowActions(flowMetadata.FlowId);

                foreach (var action in actions)
                {
                    var actionNode = new TreeNode(action.Name)
                    {
                        Tag = action,
                        ImageKey = "treeicon_action.png",
                        SelectedImageKey = "treeicon_action.png"
                    };
                    node.Nodes.Add(actionNode);
                }
            }
        }

    }
}