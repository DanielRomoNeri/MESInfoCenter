namespace MESInfoCenter
{
    partial class Form1
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
            this.sidePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowAppsList = new System.Windows.Forms.FlowLayoutPanel();
            this.sideBarHeaderPanel = new System.Windows.Forms.Panel();
            this.molexLogo = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.headerSearchPanel = new System.Windows.Forms.Panel();
            this.tbContentSearch = new System.Windows.Forms.TextBox();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.containerHeaderPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitleApp = new System.Windows.Forms.Label();
            this.flowContainerControls = new System.Windows.Forms.FlowLayoutPanel();
            this.sidePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.sideBarHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.molexLogo)).BeginInit();
            this.headerSearchPanel.SuspendLayout();
            this.containerPanel.SuspendLayout();
            this.containerHeaderPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.Indigo;
            this.sidePanel.Controls.Add(this.panel1);
            this.sidePanel.Controls.Add(this.sideBarHeaderPanel);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(2);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(230, 705);
            this.sidePanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowAppsList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 125);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 580);
            this.panel1.TabIndex = 3;
            // 
            // flowAppsList
            // 
            this.flowAppsList.AutoScroll = true;
            this.flowAppsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowAppsList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowAppsList.Location = new System.Drawing.Point(0, 0);
            this.flowAppsList.Margin = new System.Windows.Forms.Padding(2);
            this.flowAppsList.Name = "flowAppsList";
            this.flowAppsList.Size = new System.Drawing.Size(230, 580);
            this.flowAppsList.TabIndex = 2;
            this.flowAppsList.WrapContents = false;
            // 
            // sideBarHeaderPanel
            // 
            this.sideBarHeaderPanel.Controls.Add(this.molexLogo);
            this.sideBarHeaderPanel.Controls.Add(this.textBox1);
            this.sideBarHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.sideBarHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.sideBarHeaderPanel.Margin = new System.Windows.Forms.Padding(2);
            this.sideBarHeaderPanel.Name = "sideBarHeaderPanel";
            this.sideBarHeaderPanel.Size = new System.Drawing.Size(230, 125);
            this.sideBarHeaderPanel.TabIndex = 3;
            // 
            // molexLogo
            // 
            this.molexLogo.Image = global::MESInfoCenter.Properties.Resources.molexLogoTranparente;
            this.molexLogo.Location = new System.Drawing.Point(10, 17);
            this.molexLogo.Margin = new System.Windows.Forms.Padding(2);
            this.molexLogo.Name = "molexLogo";
            this.molexLogo.Size = new System.Drawing.Size(204, 36);
            this.molexLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.molexLogo.TabIndex = 1;
            this.molexLogo.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(10, 72);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 30);
            this.textBox1.TabIndex = 1;
            // 
            // headerSearchPanel
            // 
            this.headerSearchPanel.BackColor = System.Drawing.Color.Black;
            this.headerSearchPanel.Controls.Add(this.tbContentSearch);
            this.headerSearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerSearchPanel.Location = new System.Drawing.Point(230, 0);
            this.headerSearchPanel.Margin = new System.Windows.Forms.Padding(2);
            this.headerSearchPanel.Name = "headerSearchPanel";
            this.headerSearchPanel.Size = new System.Drawing.Size(1198, 63);
            this.headerSearchPanel.TabIndex = 1;
            // 
            // tbContentSearch
            // 
            this.tbContentSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContentSearch.Location = new System.Drawing.Point(364, 17);
            this.tbContentSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbContentSearch.Name = "tbContentSearch";
            this.tbContentSearch.Size = new System.Drawing.Size(455, 30);
            this.tbContentSearch.TabIndex = 0;
            // 
            // containerPanel
            // 
            this.containerPanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.containerPanel.Controls.Add(this.flowContainerControls);
            this.containerPanel.Controls.Add(this.containerHeaderPanel);
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.containerPanel.Location = new System.Drawing.Point(230, 63);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(1198, 642);
            this.containerPanel.TabIndex = 2;
            // 
            // containerHeaderPanel
            // 
            this.containerHeaderPanel.Controls.Add(this.tableLayoutPanel1);
            this.containerHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.containerHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.containerHeaderPanel.Name = "containerHeaderPanel";
            this.containerHeaderPanel.Size = new System.Drawing.Size(1198, 81);
            this.containerHeaderPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitleApp, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1198, 81);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitleApp
            // 
            this.lblTitleApp.AutoSize = true;
            this.lblTitleApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleApp.ForeColor = System.Drawing.Color.White;
            this.lblTitleApp.Location = new System.Drawing.Point(3, 0);
            this.lblTitleApp.Name = "lblTitleApp";
            this.lblTitleApp.Size = new System.Drawing.Size(1192, 81);
            this.lblTitleApp.TabIndex = 0;
            this.lblTitleApp.Text = "MES Info Center";
            this.lblTitleApp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowContainerControls
            // 
            this.flowContainerControls.AutoScroll = true;
            this.flowContainerControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowContainerControls.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowContainerControls.Location = new System.Drawing.Point(0, 81);
            this.flowContainerControls.Name = "flowContainerControls";
            this.flowContainerControls.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.flowContainerControls.Size = new System.Drawing.Size(1198, 561);
            this.flowContainerControls.TabIndex = 2;
            this.flowContainerControls.WrapContents = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1428, 705);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.headerSearchPanel);
            this.Controls.Add(this.sidePanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "MES Info Center";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.sidePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.sideBarHeaderPanel.ResumeLayout(false);
            this.sideBarHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.molexLogo)).EndInit();
            this.headerSearchPanel.ResumeLayout(false);
            this.headerSearchPanel.PerformLayout();
            this.containerPanel.ResumeLayout(false);
            this.containerHeaderPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel headerSearchPanel;
        private System.Windows.Forms.TextBox tbContentSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox molexLogo;
        private System.Windows.Forms.FlowLayoutPanel flowAppsList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel sideBarHeaderPanel;
        private System.Windows.Forms.Panel containerPanel;
        private System.Windows.Forms.Label lblTitleApp;
        private System.Windows.Forms.Panel containerHeaderPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowContainerControls;
    }
}

