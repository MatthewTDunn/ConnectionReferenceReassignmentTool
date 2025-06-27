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

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionConnectionReferenceReassignmentControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSample = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_LoadSolution = new System.Windows.Forms.Button();
            this.cmb_SolutionList = new System.Windows.Forms.ComboBox();
            this.dgv_Flows = new System.Windows.Forms.DataGridView();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Flows)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbSample});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(927, 27);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(107, 24);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbSample
            // 
            this.tsbSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSample.Name = "tsbSample";
            this.tsbSample.Size = new System.Drawing.Size(57, 24);
            this.tsbSample.Text = "Try me";
            this.tsbSample.Click += new System.EventHandler(this.tsbSample_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(995, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "This Tool is Designed to Bulk Update Connection References at the Action Level wi" +
    "thin Power Automate Flows to Reduce Some Overhead of Ownership Reassignmetn";
            // 
            // btn_LoadSolution
            // 
            this.btn_LoadSolution.Location = new System.Drawing.Point(16, 74);
            this.btn_LoadSolution.Name = "btn_LoadSolution";
            this.btn_LoadSolution.Size = new System.Drawing.Size(204, 23);
            this.btn_LoadSolution.TabIndex = 6;
            this.btn_LoadSolution.Text = "Load Environment Solution List";
            this.btn_LoadSolution.UseVisualStyleBackColor = true;
            this.btn_LoadSolution.Click += new System.EventHandler(this.btn_LoadSolution_Click);
            // 
            // cmb_SolutionList
            // 
            this.cmb_SolutionList.FormattingEnabled = true;
            this.cmb_SolutionList.Location = new System.Drawing.Point(226, 74);
            this.cmb_SolutionList.Name = "cmb_SolutionList";
            this.cmb_SolutionList.Size = new System.Drawing.Size(497, 24);
            this.cmb_SolutionList.TabIndex = 7;
            this.cmb_SolutionList.SelectedIndexChanged += new System.EventHandler(this.cmb_SolutionList_SelectedIndexChanged);
            // 
            // dgv_Flows
            // 
            this.dgv_Flows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Flows.Location = new System.Drawing.Point(16, 114);
            this.dgv_Flows.Name = "dgv_Flows";
            this.dgv_Flows.RowHeadersWidth = 51;
            this.dgv_Flows.RowTemplate.Height = 24;
            this.dgv_Flows.Size = new System.Drawing.Size(893, 150);
            this.dgv_Flows.TabIndex = 8;
            this.dgv_Flows.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Flows_CellContentClick);
            // 
            // SolutionConnectionReferenceReassignmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_Flows);
            this.Controls.Add(this.cmb_SolutionList);
            this.Controls.Add(this.btn_LoadSolution);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SolutionConnectionReferenceReassignmentControl";
            this.PluginIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PluginIcon")));
            this.Size = new System.Drawing.Size(927, 370);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Flows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbSample;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_LoadSolution;
        private System.Windows.Forms.ComboBox cmb_SolutionList;
        private System.Windows.Forms.DataGridView dgv_Flows;
    }
}
