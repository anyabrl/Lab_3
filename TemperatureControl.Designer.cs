namespace Lab3
{
    partial class TemperatureControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLoad = new Button();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            btnExport = new Button();
            btnForecast = new Button();
            txtN = new TextBox();
            label1 = new Label();
            plotView = new OxyPlot.WindowsForms.PlotView();
            lblResult = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Dock = DockStyle.Top;
            btnLoad.Location = new Point(0, 0);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(150, 40);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Открыть файл с температурой";
            btnLoad.Click += btnLoad_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(0, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(150, 150);
            dataGridView1.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExport);
            panel1.Controls.Add(btnForecast);
            panel1.Controls.Add(txtN);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 190);
            panel1.Name = "panel1";
            panel1.Size = new Size(150, 40);
            panel1.TabIndex = 2;
            // 
            // btnExport
            // 
            btnExport.Dock = DockStyle.Left;
            btnExport.Location = new Point(260, 0);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(110, 40);
            btnExport.TabIndex = 0;
            btnExport.Text = "Экспорт";
            btnExport.Click += btnExport_Click;
            // 
            // btnForecast
            // 
            btnForecast.Dock = DockStyle.Left;
            btnForecast.Location = new Point(160, 0);
            btnForecast.Name = "btnForecast";
            btnForecast.Size = new Size(100, 40);
            btnForecast.TabIndex = 1;
            btnForecast.Text = "Прогноз";
            btnForecast.Click += btnForecast_Click;
            // 
            // txtN
            // 
            txtN.Dock = DockStyle.Left;
            txtN.Location = new Point(120, 0);
            txtN.Name = "txtN";
            txtN.Size = new Size(40, 23);
            txtN.TabIndex = 2;
            txtN.Text = "5";
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 40);
            label1.TabIndex = 3;
            label1.Text = " Прогноз N дней:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // plotView
            // 
            plotView.Dock = DockStyle.Fill;
            plotView.Location = new Point(0, 230);
            plotView.Name = "plotView";
            plotView.PanCursor = Cursors.Hand;
            plotView.Size = new Size(150, 0);
            plotView.TabIndex = 0;
            plotView.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.LightGray;
            lblResult.Dock = DockStyle.Bottom;
            lblResult.Location = new Point(0, 110);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(150, 40);
            lblResult.TabIndex = 1;
            lblResult.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TemperatureControl
            // 
            Controls.Add(plotView);
            Controls.Add(lblResult);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(btnLoad);
            Name = "TemperatureControl";
            Load += TemperatureControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnForecast;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label label1;
        private OxyPlot.WindowsForms.PlotView plotView;
        private System.Windows.Forms.Label lblResult;
    }
}