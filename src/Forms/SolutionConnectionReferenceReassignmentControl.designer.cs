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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsb_Close = new System.Windows.Forms.ToolStripButton();
            this.tsb_About = new System.Windows.Forms.ToolStripButton();
            this.cmb_SolutionList = new System.Windows.Forms.ToolStripComboBox();
            this.tsb_RefreshSolutionList = new System.Windows.Forms.ToolStripButton();
            this.tsb_YouTube = new System.Windows.Forms.ToolStripButton();
            this.dgv_Flows = new System.Windows.Forms.DataGridView();
            this.dgv_FlowActionList = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Flows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FlowActionList)).BeginInit();
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
            this.cmb_SolutionList,
            this.tsb_RefreshSolutionList,
            this.tsb_YouTube});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripMenu.Size = new System.Drawing.Size(756, 31);
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
            // dgv_Flows
            // 
            this.dgv_Flows.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Flows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Flows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Flows.Location = new System.Drawing.Point(3, 3);
            this.dgv_Flows.Name = "dgv_Flows";
            this.dgv_Flows.RowHeadersWidth = 51;
            this.dgv_Flows.RowTemplate.Height = 24;
            this.dgv_Flows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Flows.Size = new System.Drawing.Size(379, 397);
            this.dgv_Flows.TabIndex = 8;
            this.dgv_Flows.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Flows_CellContentDoubleClick);
            // 
            // dgv_FlowActionList
            // 
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
            this.dgv_FlowActionList.Location = new System.Drawing.Point(388, 3);
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
            this.dgv_FlowActionList.Size = new System.Drawing.Size(365, 397);
            this.dgv_FlowActionList.TabIndex = 9;
            this.dgv_FlowActionList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.92593F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.07407F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_Flows, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv_FlowActionList, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.5575F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.4425F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 513);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // SolutionConnectionReferenceReassignmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SolutionConnectionReferenceReassignmentControl";
            this.Size = new System.Drawing.Size(756, 544);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Flows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FlowActionList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.DataGridView dgv_Flows;
        private System.Windows.Forms.ToolStripButton tsb_Close;
        private System.Windows.Forms.ToolStripButton tsb_About;
        private System.Windows.Forms.DataGridView dgv_FlowActionList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripComboBox cmb_SolutionList;
        private System.Windows.Forms.ToolStripButton tsb_RefreshSolutionList;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsb_YouTube;
    }
}
