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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionConnectionReferenceReassignmentControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsb_Close = new System.Windows.Forms.ToolStripButton();
            this.tsb_About = new System.Windows.Forms.ToolStripButton();
            this.cmb_SolutionList = new System.Windows.Forms.ToolStripComboBox();
            this.tsb_RefreshSolutionList = new System.Windows.Forms.ToolStripButton();
            this.tsb_YouTube = new System.Windows.Forms.ToolStripButton();
            this.dgv_FlowActionList = new System.Windows.Forms.DataGridView();
            this.dgv_ConnectionReferenceList = new System.Windows.Forms.DataGridView();
            this.tbllay_ScreenContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tbllay_dgvcontrols = new System.Windows.Forms.TableLayoutPanel();
            this.tree_SolutionFlowExplorer = new System.Windows.Forms.TreeView();
            this.imgl_TreeViewIcons = new System.Windows.Forms.ImageList(this.components);
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FlowActionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ConnectionReferenceList)).BeginInit();
            this.tbllay_ScreenContainer.SuspendLayout();
            this.tbllay_dgvcontrols.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsb_Close,
            this.tsb_About,
            this.cmb_SolutionList,
            this.tsb_RefreshSolutionList,
            this.tsb_YouTube});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripMenu.Size = new System.Drawing.Size(1186, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(196, 28);
            this.toolStripLabel1.Text = "Select Unmanaged Solution:";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // tsb_Close
            // 
            this.tsb_Close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Close.Image = global::SolutionConnectionReferenceReassignment.Properties.Resources.close_tool;
            this.tsb_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Close.Name = "tsb_Close";
            this.tsb_Close.Size = new System.Drawing.Size(29, 28);
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
            this.tsb_About.Size = new System.Drawing.Size(29, 28);
            this.tsb_About.Text = "About this tool";
            this.tsb_About.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // cmb_SolutionList
            // 
            this.cmb_SolutionList.BackColor = System.Drawing.Color.Wheat;
            this.cmb_SolutionList.DropDownWidth = 300;
            this.cmb_SolutionList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmb_SolutionList.Name = "cmb_SolutionList";
            this.cmb_SolutionList.Size = new System.Drawing.Size(300, 31);
            this.cmb_SolutionList.SelectedIndexChanged += new System.EventHandler(this.cmb_SolutionList_SelectedIndexChanged);
            this.cmb_SolutionList.Click += new System.EventHandler(this.cmb_SolutionList_Click);
            // 
            // tsb_RefreshSolutionList
            // 
            this.tsb_RefreshSolutionList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_RefreshSolutionList.Image = global::SolutionConnectionReferenceReassignment.Properties.Resources.refresh_tool;
            this.tsb_RefreshSolutionList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_RefreshSolutionList.Name = "tsb_RefreshSolutionList";
            this.tsb_RefreshSolutionList.Size = new System.Drawing.Size(29, 28);
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
            this.tsb_YouTube.Size = new System.Drawing.Size(29, 28);
            this.tsb_YouTube.Text = "YouTube how to";
            // 
            // dgv_FlowActionList
            // 
            this.dgv_FlowActionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FlowActionList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_FlowActionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_FlowActionList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_FlowActionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_FlowActionList.Location = new System.Drawing.Point(3, 3);
            this.dgv_FlowActionList.Name = "dgv_FlowActionList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FlowActionList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_FlowActionList.RowHeadersWidth = 51;
            this.dgv_FlowActionList.RowTemplate.Height = 24;
            this.dgv_FlowActionList.Size = new System.Drawing.Size(878, 214);
            this.dgv_FlowActionList.TabIndex = 9;
            this.dgv_FlowActionList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgv_ConnectionReferenceList
            // 
            this.dgv_ConnectionReferenceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ConnectionReferenceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ConnectionReferenceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ConnectionReferenceList.Location = new System.Drawing.Point(3, 223);
            this.dgv_ConnectionReferenceList.Name = "dgv_ConnectionReferenceList";
            this.dgv_ConnectionReferenceList.RowHeadersWidth = 51;
            this.dgv_ConnectionReferenceList.RowTemplate.Height = 24;
            this.dgv_ConnectionReferenceList.Size = new System.Drawing.Size(878, 282);
            this.dgv_ConnectionReferenceList.TabIndex = 13;
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
            this.tbllay_ScreenContainer.Name = "tbllay_ScreenContainer";
            this.tbllay_ScreenContainer.RowCount = 1;
            this.tbllay_ScreenContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbllay_ScreenContainer.Size = new System.Drawing.Size(1186, 767);
            this.tbllay_ScreenContainer.TabIndex = 11;
            // 
            // tbllay_dgvcontrols
            // 
            this.tbllay_dgvcontrols.ColumnCount = 1;
            this.tbllay_dgvcontrols.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbllay_dgvcontrols.Controls.Add(this.dgv_FlowActionList, 0, 0);
            this.tbllay_dgvcontrols.Controls.Add(this.dgv_ConnectionReferenceList, 0, 1);
            this.tbllay_dgvcontrols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbllay_dgvcontrols.Location = new System.Drawing.Point(299, 3);
            this.tbllay_dgvcontrols.Name = "tbllay_dgvcontrols";
            this.tbllay_dgvcontrols.RowCount = 3;
            this.tbllay_dgvcontrols.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.25581F));
            this.tbllay_dgvcontrols.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.74419F));
            this.tbllay_dgvcontrols.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 252F));
            this.tbllay_dgvcontrols.Size = new System.Drawing.Size(884, 761);
            this.tbllay_dgvcontrols.TabIndex = 0;
            // 
            // tree_SolutionFlowExplorer
            // 
            this.tree_SolutionFlowExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_SolutionFlowExplorer.ImageIndex = 0;
            this.tree_SolutionFlowExplorer.ImageList = this.imgl_TreeViewIcons;
            this.tree_SolutionFlowExplorer.Location = new System.Drawing.Point(3, 3);
            this.tree_SolutionFlowExplorer.Name = "tree_SolutionFlowExplorer";
            this.tree_SolutionFlowExplorer.SelectedImageIndex = 0;
            this.tree_SolutionFlowExplorer.Size = new System.Drawing.Size(290, 761);
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
            // SolutionConnectionReferenceReassignmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbllay_ScreenContainer);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SolutionConnectionReferenceReassignmentControl";
            this.Size = new System.Drawing.Size(1186, 798);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FlowActionList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ConnectionReferenceList)).EndInit();
            this.tbllay_ScreenContainer.ResumeLayout(false);
            this.tbllay_dgvcontrols.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsb_Close;
        private System.Windows.Forms.ToolStripButton tsb_About;
        private System.Windows.Forms.DataGridView dgv_FlowActionList;
        private System.Windows.Forms.ToolStripComboBox cmb_SolutionList;
        private System.Windows.Forms.ToolStripButton tsb_RefreshSolutionList;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsb_YouTube;
        private System.Windows.Forms.DataGridView dgv_ConnectionReferenceList;
        private System.Windows.Forms.TableLayoutPanel tbllay_ScreenContainer;
        private System.Windows.Forms.TableLayoutPanel tbllay_dgvcontrols;
        private System.Windows.Forms.TreeView tree_SolutionFlowExplorer;
        private System.Windows.Forms.ImageList imgl_TreeViewIcons;
    }
}
