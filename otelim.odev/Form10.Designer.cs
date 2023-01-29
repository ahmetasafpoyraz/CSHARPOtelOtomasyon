namespace otelim.odev
{
    partial class Form10
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            this.rezervasyonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new otelim.odev.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.musteribilgileriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.musteribilgileriTableAdapter = new otelim.odev.DataSet1TableAdapters.musteribilgileriTableAdapter();
            this.rezervasyonTableAdapter = new otelim.odev.DataSet1TableAdapters.rezervasyonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.rezervasyonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musteribilgileriBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rezervasyonBindingSource
            // 
            this.rezervasyonBindingSource.DataMember = "rezervasyon";
            this.rezervasyonBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 36;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.rezervasyonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "otelim.odev.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1034, 471);
            this.reportViewer1.TabIndex = 0;
            // 
            // musteribilgileriBindingSource
            // 
            this.musteribilgileriBindingSource.DataMember = "musteribilgileri";
            this.musteribilgileriBindingSource.DataSource = this.DataSet1;
            // 
            // musteribilgileriTableAdapter
            // 
            this.musteribilgileriTableAdapter.ClearBeforeFill = true;
            // 
            // rezervasyonTableAdapter
            // 
            this.rezervasyonTableAdapter.ClearBeforeFill = true;
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 471);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REZERVASYON VERİLERİ RAPORU";
            this.Load += new System.EventHandler(this.Form10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rezervasyonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musteribilgileriBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet1 DataSet1;
        private System.Windows.Forms.BindingSource musteribilgileriBindingSource;
        private DataSet1TableAdapters.musteribilgileriTableAdapter musteribilgileriTableAdapter;
        private System.Windows.Forms.BindingSource rezervasyonBindingSource;
        private DataSet1TableAdapters.rezervasyonTableAdapter rezervasyonTableAdapter;
    }
}