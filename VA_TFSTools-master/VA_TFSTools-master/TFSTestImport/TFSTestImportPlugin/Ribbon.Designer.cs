namespace TFSTestImportPlugin
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon));
            this.TFSImportTab = this.Factory.CreateRibbonTab();
            this.TFSImportGroup = this.Factory.CreateRibbonGroup();
            this.TFSImportButton = this.Factory.CreateRibbonButton();
            this.TFSImportTab.SuspendLayout();
            this.TFSImportGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // TFSImportTab
            // 
            this.TFSImportTab.Groups.Add(this.TFSImportGroup);
            this.TFSImportTab.Label = "TFS TC Import";
            this.TFSImportTab.Name = "TFSImportTab";
            // 
            // TFSImportGroup
            // 
            this.TFSImportGroup.Items.Add(this.TFSImportButton);
            this.TFSImportGroup.Label = "Import TC";
            this.TFSImportGroup.Name = "TFSImportGroup";
            // 
            // TFSImportButton
            // 
            this.TFSImportButton.Image = ((System.Drawing.Image)(resources.GetObject("TFSImportButton.Image")));
            this.TFSImportButton.Label = "Import TC";
            this.TFSImportButton.Name = "TFSImportButton";
            this.TFSImportButton.ShowImage = true;
            this.TFSImportButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.TFSImportButton_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TFSImportTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.TFSImportTab.ResumeLayout(false);
            this.TFSImportTab.PerformLayout();
            this.TFSImportGroup.ResumeLayout(false);
            this.TFSImportGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TFSImportTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup TFSImportGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton TFSImportButton;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
