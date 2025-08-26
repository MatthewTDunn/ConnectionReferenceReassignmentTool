using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SolutionConnectionReferenceReassignment.Models;
using SolutionConnectionReferenceReassignment.Services;
using SolutionConnectionReferenceReassignment.Utilities;
using SolutionConnectionReferenceReassignment.Orchestrators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.Services.Description;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using NuGet.Protocol.Plugins;
using System.DirectoryServices.AccountManagement;
using System.Security.Cryptography.Xml;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json; // MATT TO REMOVE AT SOME POINT - LOGIC SHOULDN'T EXIST IN FORM

namespace SolutionConnectionReferenceReassignment
{
    public partial class SolutionConnectionReferenceReassignmentControl : PluginControlBase
    {
        private Settings mySettings;
        private List<ConnectionReferenceModel> ownedConnectionReferences = new List<ConnectionReferenceModel>();
        private List<ConnectionReferenceModel> filteredConnectionReferences = new List<ConnectionReferenceModel>();


        public SolutionConnectionReferenceReassignmentControl()
        {
            InitializeComponent();
            
            // Event subscriber list
            tree_SolutionFlowExplorer.BeforeExpand += tree_SolutionFlowExplorer_BeforeExpand;
            dgv_ConnectionReferenceList.CellFormatting += dgv_ConnectionReferenceList_CellFormatting;
            dgv_ConnectionReferenceList.EditingControlShowing += dgv_ConnectionReferenceList_EditingControlShowing; // New connection reference colour


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

            SetupConnectionReferenceFilterCombo(); // Looking to setup appropriate defaults
        }
        private void SetupConnectionReferenceFilterCombo()
        {
            cmb_ConnectionReferenceFilter.DropDownStyle = ComboBoxStyle.DropDownList;

            cmb_ConnectionReferenceFilter.Items.Clear();
            cmb_ConnectionReferenceFilter.Items.AddRange(new string[]
            {
                "My Connection References",
                "All User Connection References",
                "Service Principal Connections",
                "All References (User + Service Principal)"
            });

            if (cmb_ConnectionReferenceFilter.Items.Count > 0)
                cmb_ConnectionReferenceFilter.SelectedIndex = 0;
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
            var grid = sender as DataGridView;

            if (grid.Columns[e.ColumnIndex].Name == "ReplacementConnectionReference")
            {
                var row = grid.Rows[e.RowIndex];
                bool reassignChecked = Convert.ToBoolean(row.Cells["Reassign"].Value ?? false);

                if (reassignChecked)
                {
                    e.CellStyle.BackColor = Color.White; // cell background when editable
                }
                else
                {
                    e.CellStyle.BackColor = Color.LightGray; // cell background when locked
                }
            }
        }

        private void dgv_ConnectionReferenceList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Only operate when the ReplacementConnectionReference column is editing
            if (dgv_ConnectionReferenceList.CurrentCell?.ColumnIndex != dgv_ConnectionReferenceList.Columns["ReplacementConnectionReference"].Index)
                return;

            if (e.Control is ComboBox combo)
            {
                // color the editing control to match Reassign state
                var row = dgv_ConnectionReferenceList.CurrentRow;
                bool reassignChecked = Convert.ToBoolean(row?.Cells["Reassign"].Value ?? false);
                combo.BackColor = reassignChecked ? Color.White : Color.LightGray;

                // avoid double-subscribe
                combo.SelectedIndexChanged -= ReplacementCombo_SelectedIndexChanged;
                combo.SelectedIndexChanged += ReplacementCombo_SelectedIndexChanged;
            }
        }
        private void ReplacementCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ComboBox combo)) return;

            // current row being edited
            var row = dgv_ConnectionReferenceList.CurrentRow;
            if (row == null) return;

            // Only populate if Reassign is checked for this row
            bool reassignChecked = Convert.ToBoolean(row.Cells["Reassign"].Value ?? false);
            if (!reassignChecked)
            {
                // if not allowed to change, make sure fields are blanked
                row.Cells["ReplacementLogicalName"].Value = "";
                row.Cells["ConnectionType"].Value = "";
                return;
            }

            // Try to get the selected ConnectionReferenceModel object
            ConnectionReferenceModel selectedRef = null;

            // Preferred: the SelectedItem is the object (your DataSource is a List<ConnectionReferenceModel>)
            if (combo.SelectedItem is ConnectionReferenceModel obj)
            {
                selectedRef = obj;
            }
            else
            {
                // Fallback: SelectedValue contains the ValueMember (you use "Name"), so look it up in the cached list
                var selVal = combo.SelectedValue?.ToString();
                if (!string.IsNullOrEmpty(selVal))
                {
                    selectedRef = filteredConnectionReferences
                        .FirstOrDefault(r => string.Equals(r.Name, selVal, StringComparison.OrdinalIgnoreCase));
                }
            }

            if (selectedRef != null)
            {
                row.Cells["ReplacementLogicalName"].Value = selectedRef.Name;        // connectionreferencelogicalname
                //TODO: REPLACE THIS WITH STANDARD VS SERVICE PRINCIPAL LOGIC
                row.Cells["ConnectionType"].Value = "Standard" ?? selectedRef.ConnectorId;
            }
            else
            {
                row.Cells["ReplacementLogicalName"].Value = "";
                row.Cells["ConnectionType"].Value = "";
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


        private void cmb_ConnectionReferenceFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterOption = cmb_ConnectionReferenceFilter.SelectedItem?.ToString() ?? "My Connection References";
            filteredConnectionReferences = new ConnectionReferenceService(Service).GetFilteredConnectionReferences(/*filterOption*/);

            // Update the DataGridView ComboBox column
            var comboColumn = dgv_ConnectionReferenceList.Columns["ReplacementConnectionReference"] as DataGridViewComboBoxColumn;
            if (comboColumn != null)
            {
                comboColumn.DataSource = filteredConnectionReferences;
            }
        }

        private void cmb_SolutionList_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tree_SolutionFlowExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (node == null) return;


            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Flow Actions and Associated Connection References",
                Work = (worker, args) =>
                {
                    var coordinator = new FlowUiOrchestrator(Service);
                    var (actions, uniqueReferences) = coordinator.GetDataForNode(node);

                    args.Result = (actions, uniqueReferences);
                },
                PostWorkCallBack = args =>
                {
                    if (args.Error != null) {
                        MessageBox.Show("Error: " + args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var (actions, uniqueReferences) = ((List<FlowActionModel>, List<ConnectionReferenceModel>))args.Result;

                    dgv_FlowActionList.DataSource = null;
                    dgv_FlowActionList.DataSource = actions;

                    dgv_ConnectionReferenceList.DataSource = null;
                    // How does the user want to filter the connection references
                    string filterOption = cmb_ConnectionReferenceFilter.SelectedItem?.ToString() ?? "My Connection References";
                    SetConnectionReferenceControlColumnConfiguration(uniqueReferences, filterOption);

                    dgv_ConnectionReferenceList.DataSource = uniqueReferences;


                    //Here we need to iterate over each row entry to align it with the logicalname of the connectionreference to be replaced
                    foreach (DataGridViewRow row in dgv_ConnectionReferenceList.Rows)
                    {
                        if (row.DataBoundItem is ConnectionReferenceModel rowData)
                        {
                            string nameToMatch = rowData.Name;

                            var filtered = filteredConnectionReferences
                                .Where(x => x.ConnectorId.Equals(nameToMatch, StringComparison.OrdinalIgnoreCase))
                                .ToList();

                            var comboCell = new DataGridViewComboBoxCell
                            {
                                DataSource = filtered,
                                ValueMember = null,           // not needed when storing the object
                                DisplayMember = "DisplayName",
                                Value = null                  // initially no selection
                            };

                            row.Cells["ReplacementConnectionReference"] = comboCell;
                        }
                    }


                }
            });
        }

        private void SetConnectionReferenceControlColumnConfiguration(List<ConnectionReferenceModel> connectionReferences, string filterOption)
        {
            dgv_ConnectionReferenceList.AutoGenerateColumns = false;
            dgv_ConnectionReferenceList.Columns.Clear();

            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                DataPropertyName = "Reassign",
                HeaderText = "Reassign?",
                Name = "Reassign",

            });

            dgv_ConnectionReferenceList.Columns["Reassign"].DefaultCellStyle.BackColor = Color.White;

            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                ReadOnly = true,
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "Name"
            });
            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                ReadOnly = true,
                DataPropertyName = "LogicalName",
                HeaderText = "Logical Name",
                Name = "LogicalName"
            });

            var filteredConnectionReferences = new ConnectionReferenceService(Service)
                .GetFilteredConnectionReferences(/*filterOption*/);

            var comboColumn = new DataGridViewComboBoxColumn()
            {
                ReadOnly = true,
                DataPropertyName = "ReplacementConnectionReference",
                Name = "ReplacementConnectionReference",
                HeaderText = "Replacement Connection Reference",
                ValueMember = "Name",           // what gets stored in the cell
                DisplayMember = "DisplayName",  // what the user sees
                DataSource = filteredConnectionReferences, 
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    BackColor = Color.LightGray // default background color
                }
            };

            dgv_ConnectionReferenceList.Columns.Add(comboColumn);

            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                ReadOnly = true,
                DataPropertyName = "ReplacementLogicalName",
                Name = "ReplacementLogicalName",
                HeaderText = "Replacement Logical Name"
            });
            dgv_ConnectionReferenceList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                ReadOnly = true,
                DataPropertyName = "ConnectionType",
                Name = "ConnectionType",
                HeaderText = "Connection Type"
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
            if (e.RowIndex < 0) return;

            var grid = sender as DataGridView;
            var row = grid.Rows[e.RowIndex];

            // --- Handle Reassign checkbox toggle ---
            if (grid.Columns[e.ColumnIndex].Name == "Reassign")
            {
                bool reassignChecked = Convert.ToBoolean(row.Cells["Reassign"].Value);

                var comboCell = row.Cells["ReplacementConnectionReference"] as DataGridViewComboBoxCell;

                if (reassignChecked)
                {
                    comboCell.ReadOnly = false;
                    comboCell.Style.BackColor = Color.White;
                }
                else
                {
                    comboCell.ReadOnly = true;
                    comboCell.Style.BackColor = Color.LightGray;
                    row.Cells["ReplacementLogicalName"].Value = null; // reset logical name
                    comboCell.Value = null; // reset combo selection
                }
            }

            // --- Handle ReplacementConnectionReference selection ---
            if (grid.Columns[e.ColumnIndex].Name == "ReplacementConnectionReference")
            {
                var comboCell = row.Cells["ReplacementConnectionReference"] as DataGridViewComboBoxCell;
                if (comboCell?.Value != null)
                {
                    string selectedName = comboCell.Value.ToString(); // this is the logical name stored in ValueMember
                    var selectedRef = filteredConnectionReferences.FirstOrDefault(r => r.Name == selectedName);
                    if (selectedRef != null)
                    {
                        row.Cells["ReplacementLogicalName"].Value = selectedRef.Name;
                        row.Cells["ConnectionType"].Value = "Standard";
                    }
                }
                else
                {
                    // If nothing is selected, clear the fields
                    row.Cells["ReplacementLogicalName"].Value = "";
                    row.Cells["ConnectionType"].Value = "";
                }
            }

        }


        // to ensure that the logical name of the replacement connection reference is immediately populated when the user clicks
        private void dgv_ConnectionReferenceList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_ConnectionReferenceList.IsCurrentCellDirty)
            {
                dgv_ConnectionReferenceList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgv_ConnectionReferenceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_executeflowclientdataupdate_Click(object sender, EventArgs e)
        {
            // --- Step 0: Validate replacement fields for reassign rows ---
            foreach (DataGridViewRow row in dgv_ConnectionReferenceList.Rows)
            {
                if (!row.IsNewRow && row.Cells["Reassign"] is DataGridViewCheckBoxCell chkCell)
                {
                    bool isChecked = chkCell.Value != null && (bool)chkCell.Value;
                    if (isChecked)
                    {
                        var replacementRef = row.Cells["ReplacementConnectionReference"].Value?.ToString();
                        var replacementLogical = row.Cells["ReplacementLogicalName"].Value?.ToString();
                        var connectionType = row.Cells["ConnectionType"].Value?.ToString();

                        if (string.IsNullOrWhiteSpace(replacementRef) ||
                            string.IsNullOrWhiteSpace(replacementLogical) ||
                            string.IsNullOrWhiteSpace(connectionType))
                        {
                            MessageBox.Show(
                                "One or more selected connection references are missing required replacement values.\n\n" +
                                "Please ensure that Replacement Connection Reference, Replacement Logical Name, and Connection Type are all populated.\n\n" +
                                "Occasionally, the comboBox in the 'Replacement Connection Reference' column may not register correctly and may need to be reselected if this error persists.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            return; // stop execution
                        }
                    }
                }
            }

            // --- Step 1: Build connection mapping (LogicalName -> ReplacementLogicalName) ---
            Dictionary<string, string> connectionMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (DataGridViewRow row in dgv_ConnectionReferenceList.Rows)
            {
                if (row.IsNewRow) continue;
                if (!(row.Cells["Reassign"] is DataGridViewCheckBoxCell chkCell)) continue;

                bool isChecked = chkCell.Value != null && (bool)chkCell.Value;
                if (!isChecked) continue;

                var existingLogical = row.Cells["LogicalName"].Value?.ToString()?.Trim();
                var replacementLogical = row.Cells["ReplacementLogicalName"].Value?.ToString()?.Trim();

                if (!string.IsNullOrWhiteSpace(existingLogical) && !string.IsNullOrWhiteSpace(replacementLogical))
                {
                    if (!connectionMap.ContainsKey(existingLogical))
                        connectionMap[existingLogical] = replacementLogical;
                }
            }

            // --- Step 2: Gather unique affected flows based on ConnectionReferenceLogicalName ---
            HashSet<string> affectedFlows = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            int affectedActionCount = 0;

            foreach (DataGridViewRow row in dgv_FlowActionList.Rows)
            {
                if (row.IsNewRow) continue;

                var flowIdObj = row.Cells["FlowId"]?.Value;
                if (flowIdObj == null) continue;

                string flowId = flowIdObj.ToString()?.Trim();
                if (string.IsNullOrWhiteSpace(flowId)) continue;

                // Always prefer ConnectionReferenceLogicalName from the action grid
                string actionLogical = row.Cells["ConnectionReferenceLogicalName"]?.Value?.ToString()?.Trim();
                if (string.IsNullOrWhiteSpace(actionLogical)) continue;

                if (connectionMap.ContainsKey(actionLogical))
                {
                    affectedFlows.Add(flowId);   // flow counted only once
                    affectedActionCount++;       // action count still increments per match
                }
            }

            // --- Step 3: Confirmation message ---
            int connectionRefsToReassign = connectionMap.Count;         // number of checked logical names
            int flowCount = affectedFlows.Count;                        // unique impacted flows
            string message = $"You are looking to update {connectionRefsToReassign} unique connection reference(s) " +
                             $"across {flowCount} unique flow(s) (total impacted actions: {affectedActionCount}) - are you sure you wish to proceed?";

            if (MessageBox.Show(message, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            // --- Step 4: Perform the single-flow update for debugging ---
            // --- Step 4: Perform batch updates across affectedFlows ---
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Updating flow connection references...",
                Work = (worker, args) =>
                {
                    var perFlowMessages = new List<string>();

                    foreach (string flowId in affectedFlows)
                    {
                        int connRefsChanged = 0;
                        int triggersAuthRemoved = 0;
                        int actionsAuthRemoved = 0;
                        int actionsHostUpdated = 0;

                        var flowEntity = Service.Retrieve("workflow", new Guid(flowId), new ColumnSet("clientdata"));
                        string clientDataJson = flowEntity.GetAttributeValue<string>("clientdata");
                        if (string.IsNullOrWhiteSpace(clientDataJson))
                        {
                            perFlowMessages.Add($"{flowId}: skipped (no clientdata)");
                            continue;
                        }

                        JObject clientData = JObject.Parse(clientDataJson);

                        // --- Update connectionReferences (and record which property names we updated) ---
                        var connectionRefs = clientData["properties"]?["connectionReferences"] as JObject;
                        var updatedPropNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                        if (connectionRefs != null)
                        {
                            foreach (var prop in connectionRefs.Properties().ToList())
                            {
                                // existing logical name
                                var oldLogical = prop.Value?["connection"]?["connectionReferenceLogicalName"]?.ToString();
                                if (string.IsNullOrWhiteSpace(oldLogical)) continue;

                                // If we have a mapping from the existing logical name to a replacement, perform change
                                if (connectionMap.TryGetValue(oldLogical, out var newLogical))
                                {
                                    if (!string.Equals(oldLogical, newLogical, StringComparison.OrdinalIgnoreCase))
                                    {
                                        // update the logical name in the object
                                        var connObj = prop.Value["connection"] as JObject;
                                        if (connObj != null)
                                        {
                                            connObj["connectionReferenceLogicalName"] = newLogical;
                                            updatedPropNames.Add(prop.Name);
                                            connRefsChanged++;
                                        }
                                    }
                                }
                            }
                        }

                        // If nothing updated, still add a message and continue (or you may prefer to skip saving)
                        if (connRefsChanged == 0)
                        {
                            // still may want to remove auth for actions matching replacement by key -> but if nothing changed then nothing to do
                        }

                        // --- Triggers: remove authentication only if the trigger is related to changed connection refs ---
                        var triggers = clientData["properties"]?["definition"]?["triggers"] as JObject;
                        if (triggers != null)
                        {
                            foreach (var triggerProp in triggers.Properties())
                            {
                                var triggerInputs = triggerProp.Value?["inputs"] as JObject;
                                if (triggerInputs == null) continue;

                                var host = triggerInputs["host"] as JObject;
                                bool triggerIsRelated = false;

                                if (host != null && host["connectionName"] != null)
                                {
                                    string hostConnName = host["connectionName"].ToString();

                                    // direct property key match
                                    if (updatedPropNames.Contains(hostConnName))
                                        triggerIsRelated = true;
                                    else if (connectionRefs != null)
                                    {
                                        // or hostConnName equals an existing connectionReferenceLogicalName for a prop we updated
                                        var matching = connectionRefs.Properties()
                                            .FirstOrDefault(p =>
                                                string.Equals(p.Value?["connection"]?["connectionReferenceLogicalName"]?.ToString(), hostConnName, StringComparison.OrdinalIgnoreCase)
                                                && updatedPropNames.Contains(p.Name));
                                        if (matching != null) triggerIsRelated = true;
                                    }
                                }

                                if (triggerIsRelated)
                                {
                                    var authProp = triggerInputs.Property("authentication");
                                    if (authProp != null)
                                    {
                                        authProp.Remove();
                                        triggersAuthRemoved++;
                                    }
                                }
                            }
                        }

                        // --- Actions: remove authentication only for related actions and set connectionReferenceName if needed ---
                        var actions = clientData["properties"]?["definition"]?["actions"] as JObject;
                        if (actions != null)
                        {
                            foreach (var actionProp in actions.Properties())
                            {
                                var actionObj = actionProp.Value as JObject;
                                if (actionObj == null) continue;

                                var inputs = actionObj["inputs"] as JObject;
                                if (inputs == null) continue;

                                var host = inputs["host"] as JObject;
                                if (host == null) continue;

                                string hostConnName = host["connectionName"]?.ToString();
                                if (string.IsNullOrEmpty(hostConnName)) continue;

                                bool actionIsRelated = false;
                                string resolvedHostKey = hostConnName;

                                if (updatedPropNames.Contains(hostConnName))
                                {
                                    actionIsRelated = true; // host connectionName is the property key we changed
                                }
                                else if (connectionRefs != null)
                                {
                                    // maybe hostConnName equals the old logical name; find the corresponding prop that we updated
                                    var matching = connectionRefs.Properties()
                                        .FirstOrDefault(p =>
                                            string.Equals(p.Value?["connection"]?["connectionReferenceLogicalName"]?.ToString(), hostConnName, StringComparison.OrdinalIgnoreCase)
                                            && updatedPropNames.Contains(p.Name));
                                    if (matching != null)
                                    {
                                        actionIsRelated = true;
                                        resolvedHostKey = matching.Name; // use prop name for connectionReferenceName
                                    }
                                }

                                if (actionIsRelated)
                                {
                                    var authProp = inputs.Property("authentication");
                                    if (authProp != null)
                                    {
                                        authProp.Remove();
                                        actionsAuthRemoved++;
                                    }

                                    // set or update host.connectionReferenceName to point to the flow-level connectionReferences key
                                    var existingConnRefNameProp = host.Property("connectionReferenceName");
                                    if (existingConnRefNameProp == null || existingConnRefNameProp.Value.ToString() != resolvedHostKey)
                                    {
                                        host["connectionReferenceName"] = resolvedHostKey;
                                        actionsHostUpdated++;
                                    }
                                }
                            }
                        }

                        // --- Save updated flow clientdata ---
                        flowEntity["clientdata"] = clientData.ToString(Formatting.None);
                        Service.Update(flowEntity);

                        // --- Add per-flow summary message ---
                        perFlowMessages.Add($"{flowId}: connRefsChanged={connRefsChanged}, triggersAuthRemoved={triggersAuthRemoved}, actionsAuthRemoved={actionsAuthRemoved}, actionsHostUpdated={actionsHostUpdated}");
                    }

                    // Return the list of per-flow messages to PostWorkCallBack
                    args.Result = perFlowMessages;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show("Error: " + args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var results = args.Result as List<string>;
                    if (results != null && results.Count > 0)
                    {
                        var sb = new System.Text.StringBuilder("Update results per flow:\n");
                        foreach (var line in results) sb.AppendLine(line);
                        MessageBox.Show(sb.ToString(), "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No flows updated.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            });

        }







    }
}