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
        private List<ConnectionReferenceModel> ownedConnectionReferences = new List<ConnectionReferenceModel>();

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


        private void cmb_SolutionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SetupConnectionReferenceGrid(List<ConnectionReferenceModel> data, List<string> replacementOptions)
        {
            
        }

        private void dgv_ConnectionReferenceList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_ConnectionReferenceList.Columns[e.ColumnIndex].Name == "Reassign")
            {
                e.CellStyle.BackColor = Color.LightGray;
            }
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

        private void tree_SolutionFlowExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (node == null) return;

            var orchestrator = new FlowDefinitionOrchestrator(Service);
            var enricher = new DataEnricher(Service);

            List<FlowActionModel> actions = new List<FlowActionModel>();
            List<ConnectionReferenceModel> connectionReferences = new List<ConnectionReferenceModel>();

            if (node.Tag is SolutionModel solution)
            {
                var flowService = new FlowMetadataService(Service);
                var flows = flowService.GetFlowsInSolution(solution.SolutionId);

                foreach (var flow in flows)
                {
                    var (flowActions, flowConnectionReferences) = orchestrator.GetParsedFlowDefinition(flow.FlowId);
                    enricher.EnrichFlowActionsWithFlowMetadata(flowActions, flow.Name, flow.FlowId);

                    actions.AddRange(flowActions);
                    connectionReferences.AddRange(flowConnectionReferences);
                }
            }
            else if (node.Tag is FlowMetadataModel flowMetadata)
            {
                var (flowActions, flowConnectionReferences) = orchestrator.GetParsedFlowDefinition(flowMetadata.FlowId);
                enricher.EnrichFlowActionsWithFlowMetadata(flowActions, flowMetadata.Name, flowMetadata.FlowId);
                
                
                actions = flowActions;
                connectionReferences = flowConnectionReferences;
            }
            else if (node.Tag is FlowActionModel flowAction)
            {
                actions = new List<FlowActionModel> { flowAction };
                connectionReferences = new List<ConnectionReferenceModel>();
            }

            dgv_FlowActionList.DataSource = null;
            dgv_FlowActionList.DataSource = actions;

            dgv_ConnectionReferenceList.DataSource = null;
            SetConnectionReferenceControlColumnConfiguration(connectionReferences);
            dgv_ConnectionReferenceList.DataSource= connectionReferences;
        }

        private void SetConnectionReferenceControlColumnConfiguration(List<ConnectionReferenceModel> connectionReferences)
        {
            dgv_ConnectionReferenceList.AutoGenerateColumns = false;
            dgv_ConnectionReferenceList.Columns.Clear();

            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                DataPropertyName = "Reassign",
                HeaderText = "Reassign?"
            });

            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                ReadOnly = true,
                DataPropertyName = "DisplayName",
                HeaderText = "Display Name"
            });
            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                ReadOnly = true,
                DataPropertyName = "Name",
                HeaderText = "Name"
            });
            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                ReadOnly = true,
                DataPropertyName = "LogicalName",
                HeaderText = "Logical Name"
            });

            ownedConnectionReferences = new ConnectionReferenceService(Service).GetConnectionReferencesOwnedByUser();

            var comboColumn = new DataGridViewComboBoxColumn()
            {
                DataPropertyName = "ReplacementConnectionReference",
                HeaderText = "Replacement Connection Reference",
                Name = "ReplacementConnectionReference",
                ValueType = typeof(string),
                DataSource = ownedConnectionReferences,
                ValueMember = "Name",
                DisplayMember = "DisplayName"
            };

            dgv_ConnectionReferenceList.Columns.Add(comboColumn);

            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                ReadOnly = true,
                DataPropertyName = "ReplacementLogicalName",
                HeaderText = "Replacement Logical Name"
            });

            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                ReadOnly = true,
                DataPropertyName = "ValidReassignment",
                HeaderText = "Valid Reassignment"
            });
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
                    var actionNode = new TreeNode(action.ActionName)
                    {
                        Tag = action,
                        ImageKey = "treeicon_action.png",
                        SelectedImageKey = "treeicon_action.png"
                    };
                    node.Nodes.Add(actionNode);
                }
            }
        }

        private void dgv_ConnectionReferenceList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_ConnectionReferenceList.Columns[e.ColumnIndex].Name == "ReplacementConnectionReference")
            {
                var row = dgv_ConnectionReferenceList.Rows[e.RowIndex];
                var selectedName = row.Cells["ReplacementConnectionReference"].Value as string;

                if (selectedName != null)
                {
                    var match = ownedConnectionReferences.FirstOrDefault(c => c.Name == selectedName);
                    if (match != null)
                    {
                        var boundItem = row.DataBoundItem as ConnectionReferenceModel;
                        if (boundItem != null)
                        {
                            boundItem.ReplacementConnectionReferenceLogicalName = match.LogicalName;

                            dgv_ConnectionReferenceList.Refresh();
                        }
                    }
                }
            }
        }

        private void dgv_ConnectionReferenceList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_ConnectionReferenceList.IsCurrentCellDirty)
            {
                dgv_ConnectionReferenceList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}