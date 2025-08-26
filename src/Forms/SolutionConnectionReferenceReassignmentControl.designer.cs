using XrmToolBox.Extensibility;

namespace SolutionConnectionReferenceReassignment
{
    partial class SolutionConnectionReferenceReassignmentControl : PluginControlBase
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        private System.Windows.Forms.ToolStripComboBox tsb_cmb_SolutionList;

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionConnectionReferenceReassignmentControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsb_Close = new System.Windows.Forms.ToolStripButton();
            this.tsb_About = new System.Windows.Forms.ToolStripButton();
            this.cmb_ConnectionReferenceFilter = new System.Windows.Forms.ToolStripComboBox();
            this.tsb_RefreshSolutionList = new System.Windows.Forms.ToolStripButton();
            this.tsb_YouTube = new System.Windows.Forms.ToolStripButton();
            this.dgv_FlowActionList = new System.Windows.Forms.DataGridView();
            this.dgv_ConnectionReferenceList = new System.Windows.Forms.DataGridView();
            this.tbllay_ScreenContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tbllay_dgvcontrols = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_exportcurrentclientdata = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_executeflowclientdataupdate = new System.Windows.Forms.Button();
            this.tree_SolutionFlowExplorer = new System.Windows.Forms.TreeView();
            this.imgl_TreeViewIcons = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FlowActionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ConnectionReferenceList)).BeginInit();
            this.tbllay_ScreenContainer.SuspendLayout();
            this.tbllay_dgvcontrols.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsb_Close,
            this.tsb_About,
            this.cmb_ConnectionReferenceFilter,
            this.tsb_RefreshSolutionList,
            this.tsb_YouTube});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripMenu.Size = new System.Drawing.Size(890, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(140, 28);
            this.toolStripLabel1.Text = "Connection Source Filter:";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // tsb_Close
            // 
            this.tsb_Close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Close.Image = global::SolutionConnectionReferenceReassignment.Properties.Resources.close_tool;
            this.tsb_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Close.Name = "tsb_Close";
            this.tsb_Close.Size = new System.Drawing.Size(28, 28);
            this.tsb_Close.Text = "Close this tool";
            this.tsb_Close.Click += new System.EventHandler(this.tsb_closetool_Click);
            // 
            // tsb_About
            // 
            this.tsb_About.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_About.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_About.Image = global::SolutionConnectionReferenceReassignment.Properties.Resources.about_tool;
            this.tsb_About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_About.Name = "tsb_About";
            this.tsb_About.Size = new System.Drawing.Size(28, 28);
            this.tsb_About.Text = "About this tool";
            this.tsb_About.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // cmb_ConnectionReferenceFilter
            // 
            this.cmb_ConnectionReferenceFilter.BackColor = System.Drawing.Color.Wheat;
            this.cmb_ConnectionReferenceFilter.DropDownWidth = 300;
            this.cmb_ConnectionReferenceFilter.Name = "cmb_ConnectionReferenceFilter";
            this.cmb_ConnectionReferenceFilter.Size = new System.Drawing.Size(226, 31);
            this.cmb_ConnectionReferenceFilter.SelectedIndexChanged += new System.EventHandler(this.cmb_ConnectionReferenceFilter_SelectedIndexChanged);
            this.cmb_ConnectionReferenceFilter.Click += new System.EventHandler(this.cmb_SolutionList_Click);
            // 
            // tsb_RefreshSolutionList
            // 
            this.tsb_RefreshSolutionList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_RefreshSolutionList.Image = global::SolutionConnectionReferenceReassignment.Properties.Resources.refresh_tool;
            this.tsb_RefreshSolutionList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_RefreshSolutionList.Name = "tsb_RefreshSolutionList";
            this.tsb_RefreshSolutionList.Size = new System.Drawing.Size(28, 28);
            this.tsb_RefreshSolutionList.Text = "Refresh Solution List";
            this.tsb_RefreshSolutionList.Click += new System.EventHandler(this.tsb_RefreshSolutionList_Click);
            // 
            // tsb_YouTube
            // 
            this.tsb_YouTube.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_YouTube.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_YouTube.Image = global::SolutionConnectionReferenceReassignment.Properties.Resources.youtube_tool1;
            this.tsb_YouTube.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_YouTube.Name = "tsb_YouTube";
            this.tsb_YouTube.Size = new System.Drawing.Size(28, 28);
            this.tsb_YouTube.Text = "YouTube how to";
            // 
            // dgv_FlowActionList
            // 
            this.dgv_FlowActionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FlowActionList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_FlowActionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_FlowActionList.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_FlowActionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_FlowActionList.Location = new System.Drawing.Point(2, 2);
            this.dgv_FlowActionList.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_FlowActionList.Name = "dgv_FlowActionList";
            this.dgv_FlowActionList.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FlowActionList.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_FlowActionList.RowHeadersWidth = 51;
            this.dgv_FlowActionList.RowTemplate.Height = 24;
            this.dgv_FlowActionList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_FlowActionList.Size = new System.Drawing.Size(660, 271);
            this.dgv_FlowActionList.TabIndex = 9;
            this.dgv_FlowActionList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgv_ConnectionReferenceList
            // 
            this.dgv_ConnectionReferenceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ConnectionReferenceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ConnectionReferenceList.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_ConnectionReferenceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ConnectionReferenceList.Location = new System.Drawing.Point(2, 277);
            this.dgv_ConnectionReferenceList.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_ConnectionReferenceList.Name = "dgv_ConnectionReferenceList";
            this.dgv_ConnectionReferenceList.RowHeadersWidth = 51;
            this.dgv_ConnectionReferenceList.RowTemplate.Height = 24;
            this.dgv_ConnectionReferenceList.Size = new System.Drawing.Size(660, 271);
            this.dgv_ConnectionReferenceList.TabIndex = 13;
            this.dgv_ConnectionReferenceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ConnectionReferenceList_CellContentClick);
            this.dgv_ConnectionReferenceList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ConnectionReferenceList_CellValueChanged);
            // 
            // tbllay_ScreenContainer
            // 
            this.tbllay_ScreenContainer.ColumnCount = 2;
            this.tbllay_ScreenContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbllay_ScreenContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tbllay_ScreenContainer.Controls.Add(this.tbllay_dgvcontrols, 1, 0);
            this.tbllay_ScreenContainer.Controls.Add(this.tree_SolutionFlowExplorer, 0, 0);
            this.tbllay_ScreenContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbllay_ScreenContainer.Location = new System.Drawing.Point(0, 31);
            this.tbllay_ScreenContainer.Margin = new System.Windows.Forms.Padding(2);
            this.tbllay_ScreenContainer.Name = "tbllay_ScreenContainer";
            this.tbllay_ScreenContainer.RowCount = 1;
            this.tbllay_ScreenContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbllay_ScreenContainer.Size = new System.Drawing.Size(890, 617);
            this.tbllay_ScreenContainer.TabIndex = 11;
            // 
            // tbllay_dgvcontrols
            // 
            this.tbllay_dgvcontrols.ColumnCount = 1;
            this.tbllay_dgvcontrols.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbllay_dgvcontrols.Controls.Add(this.dgv_FlowActionList, 0, 0);
            this.tbllay_dgvcontrols.Controls.Add(this.dgv_ConnectionReferenceList, 0, 1);
            this.tbllay_dgvcontrols.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tbllay_dgvcontrols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbllay_dgvcontrols.Location = new System.Drawing.Point(224, 2);
            this.tbllay_dgvcontrols.Margin = new System.Windows.Forms.Padding(2);
            this.tbllay_dgvcontrols.Name = "tbllay_dgvcontrols";
            this.tbllay_dgvcontrols.RowCount = 3;
            this.tbllay_dgvcontrols.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tbllay_dgvcontrols.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tbllay_dgvcontrols.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tbllay_dgvcontrols.Size = new System.Drawing.Size(664, 613);
            this.tbllay_dgvcontrols.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btn_exportcurrentclientdata, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_executeflowclientdataupdate, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 553);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.87719F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(658, 57);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // btn_exportcurrentclientdata
            // 
            this.btn_exportcurrentclientdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_exportcurrentclientdata.Location = new System.Drawing.Point(3, 3);
            this.btn_exportcurrentclientdata.Name = "btn_exportcurrentclientdata";
            this.btn_exportcurrentclientdata.Size = new System.Drawing.Size(158, 51);
            this.btn_exportcurrentclientdata.TabIndex = 0;
            this.btn_exportcurrentclientdata.Text = "Export Current Flow Client Data";
            this.btn_exportcurrentclientdata.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(167, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 51);
            this.button2.TabIndex = 1;
            this.button2.Text = "Impact Summary";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(331, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 51);
            this.button3.TabIndex = 2;
            this.button3.Text = "Export Log";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btn_executeflowclientdataupdate
            // 
            this.btn_executeflowclientdataupdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_executeflowclientdataupdate.Location = new System.Drawing.Point(495, 3);
            this.btn_executeflowclientdataupdate.Name = "btn_executeflowclientdataupdate";
            this.btn_executeflowclientdataupdate.Size = new System.Drawing.Size(160, 51);
            this.btn_executeflowclientdataupdate.TabIndex = 3;
            this.btn_executeflowclientdataupdate.Text = "Execute Update";
            this.btn_executeflowclientdataupdate.UseVisualStyleBackColor = true;
            this.btn_executeflowclientdataupdate.Click += new System.EventHandler(this.btn_executeflowclientdataupdate_Click);
            // 
            // tree_SolutionFlowExplorer
            // 
            this.tree_SolutionFlowExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_SolutionFlowExplorer.ImageIndex = 0;
            this.tree_SolutionFlowExplorer.ImageList = this.imgl_TreeViewIcons;
            this.tree_SolutionFlowExplorer.Location = new System.Drawing.Point(2, 2);
            this.tree_SolutionFlowExplorer.Margin = new System.Windows.Forms.Padding(2);
            this.tree_SolutionFlowExplorer.Name = "tree_SolutionFlowExplorer";
            this.tree_SolutionFlowExplorer.SelectedImageIndex = 0;
            this.tree_SolutionFlowExplorer.Size = new System.Drawing.Size(218, 613);
            this.tree_SolutionFlowExplorer.TabIndex = 1;
            this.tree_SolutionFlowExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_SolutionFlowExplorer_AfterSelect);
            // 
            // imgl_TreeViewIcons
            // 
            this.imgl_TreeViewIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgl_TreeViewIcons.ImageStream")));
            this.imgl_TreeViewIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgl_TreeViewIcons.Images.SetKeyName(0, "treeicon_environment.png");
            this.imgl_TreeViewIcons.Images.SetKeyName(1, "treeicon_solution.png");
            this.imgl_TreeViewIcons.Images.SetKeyName(2, "treeicon_powerautomate.png");
            this.imgl_TreeViewIcons.Images.SetKeyName(3, "treeicon_action.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // SolutionConnectionReferenceReassignmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbllay_ScreenContainer);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "SolutionConnectionReferenceReassignmentControl";
            this.Size = new System.Drawing.Size(890, 648);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FlowActionList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ConnectionReferenceList)).EndInit();
            this.tbllay_ScreenContainer.ResumeLayout(false);
            this.tbllay_dgvcontrols.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsb_Close;
        private System.Windows.Forms.ToolStripButton tsb_About;
        private System.Windows.Forms.DataGridView dgv_FlowActionList;
        private System.Windows.Forms.ToolStripComboBox cmb_ConnectionReferenceFilter;
        private System.Windows.Forms.ToolStripButton tsb_RefreshSolutionList;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsb_YouTube;
        private System.Windows.Forms.DataGridView dgv_ConnectionReferenceList;
        private System.Windows.Forms.TableLayoutPanel tbllay_ScreenContainer;
        private System.Windows.Forms.TableLayoutPanel tbllay_dgvcontrols;
        private System.Windows.Forms.TreeView tree_SolutionFlowExplorer;
        private System.Windows.Forms.ImageList imgl_TreeViewIcons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btn_exportcurrentclientdata;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_executeflowclientdataupdate;
    }
}
