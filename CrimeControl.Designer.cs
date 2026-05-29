namespace Lab3
{
    partial class CrimeControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnLoad = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.btnForecast = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(10, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(150, 30);
            this.btnLoad.Text = "Открыть файл";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(750, 150);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 18);
            this.label1.Text = "Прогноз на N лет:";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(160, 212);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(40, 25);
            this.txtN.Text = "5";
            // 
            // btnForecast
            // 
            this.btnForecast.Location = new System.Drawing.Point(210, 210);
            this.btnForecast.Name = "btnForecast";
            this.btnForecast.Size = new System.Drawing.Size(130, 30);
            this.btnForecast.Text = "Построить прогноз";
            this.btnForecast.Click += new System.EventHandler(this.btnForecast_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(350, 210);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(130, 30);
            this.btnExport.Text = "Экспорт графика";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // plotView
            // 
            this.plotView.Location = new System.Drawing.Point(10, 250);
            this.plotView.Name = "plotView";
            this.plotView.Size = new System.Drawing.Size(750, 180);
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(10, 440);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(750, 30);
            // 
            // CrimeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.plotView);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnForecast);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoad);
            this.Name = "CrimeControl";
            this.Load += new System.EventHandler(this.CrimeControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Button btnForecast;
        private System.Windows.Forms.Button btnExport;
        private OxyPlot.WindowsForms.PlotView plotView;
        private System.Windows.Forms.Label lblResult;
    }
}