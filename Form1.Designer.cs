using System.Drawing;

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
            this.btnAppRegister = new System.Windows.Forms.Button();
            this.sideBarHeaderPanel = new System.Windows.Forms.Panel();
            this.molexLogo = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.headerSearchPanel = new System.Windows.Forms.Panel();
            this.pbLoginIcon = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblTitleMESApp = new System.Windows.Forms.Label();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.flowContainerControls = new System.Windows.Forms.FlowLayoutPanel();
            this.containerHeaderPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitleApp = new System.Windows.Forms.Label();
            this.sidePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.sideBarHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.molexLogo)).BeginInit();
            this.headerSearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoginIcon)).BeginInit();
            this.panel2.SuspendLayout();
            this.containerPanel.SuspendLayout();
            this.containerHeaderPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(50)))), ((int)(((byte)(91)))));
            this.sidePanel.Controls.Add(this.panel1);
            this.sidePanel.Controls.Add(this.btnAppRegister);
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
            this.panel1.Location = new System.Drawing.Point(0, 129);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 525);
            this.panel1.TabIndex = 3;
            // 
            // flowAppsList
            // 
            this.flowAppsList.AutoScroll = true;
            this.flowAppsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(50)))), ((int)(((byte)(91)))));
            this.flowAppsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowAppsList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowAppsList.Location = new System.Drawing.Point(0, 0);
            this.flowAppsList.Margin = new System.Windows.Forms.Padding(2);
            this.flowAppsList.Name = "flowAppsList";
            this.flowAppsList.Size = new System.Drawing.Size(228, 525);
            this.flowAppsList.TabIndex = 2;
            this.flowAppsList.WrapContents = false;
            // 
            // btnAppRegister
            // 
            this.btnAppRegister.BackColor = System.Drawing.Color.Green;
            this.btnAppRegister.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAppRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppRegister.ForeColor = System.Drawing.Color.White;
            this.btnAppRegister.Location = new System.Drawing.Point(0, 659);
            this.btnAppRegister.Name = "btnAppRegister";
            this.btnAppRegister.Size = new System.Drawing.Size(230, 46);
            this.btnAppRegister.TabIndex = 1;
            this.btnAppRegister.Text = "Registrar Aplicación";
            this.btnAppRegister.UseVisualStyleBackColor = false;
            this.btnAppRegister.Visible = false;
            this.btnAppRegister.Click += new System.EventHandler(this.btnAppRegister_Click);
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
            this.headerSearchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(31)))), ((int)(((byte)(64)))));
            this.headerSearchPanel.Controls.Add(this.pbLoginIcon);
            this.headerSearchPanel.Controls.Add(this.panel2);
            this.headerSearchPanel.Controls.Add(this.lblTitleMESApp);
            this.headerSearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerSearchPanel.Location = new System.Drawing.Point(230, 0);
            this.headerSearchPanel.Margin = new System.Windows.Forms.Padding(2);
            this.headerSearchPanel.Name = "headerSearchPanel";
            this.headerSearchPanel.Size = new System.Drawing.Size(1198, 63);
            this.headerSearchPanel.TabIndex = 1;
            // 
            // pbLoginIcon
            // 
            this.pbLoginIcon.Image = global::MESInfoCenter.Properties.Resources.userIcon;
            this.pbLoginIcon.Location = new System.Drawing.Point(1140, 12);
            this.pbLoginIcon.Name = "pbLoginIcon";
            this.pbLoginIcon.Size = new System.Drawing.Size(46, 36);
            this.pbLoginIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoginIcon.TabIndex = 1;
            this.pbLoginIcon.TabStop = false;
            this.pbLoginIcon.Click += new System.EventHandler(this.pbLoginIcon_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblUserName);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(874, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 27);
            this.panel2.TabIndex = 3;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(154, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(106, 17);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Iniciar Sesión";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserName.Click += new System.EventHandler(this.pbLoginIcon_Click);
            // 
            // lblTitleMESApp
            // 
            this.lblTitleMESApp.AutoSize = true;
            this.lblTitleMESApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleMESApp.ForeColor = System.Drawing.Color.White;
            this.lblTitleMESApp.Location = new System.Drawing.Point(452, 9);
            this.lblTitleMESApp.Name = "lblTitleMESApp";
            this.lblTitleMESApp.Size = new System.Drawing.Size(283, 39);
            this.lblTitleMESApp.TabIndex = 0;
            this.lblTitleMESApp.Text = "MES Info Center";
            this.lblTitleMESApp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // containerPanel
            // 
            this.containerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.containerPanel.Controls.Add(this.flowContainerControls);
            this.containerPanel.Controls.Add(this.containerHeaderPanel);
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.containerPanel.Location = new System.Drawing.Point(230, 63);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(1198, 642);
            this.containerPanel.TabIndex = 2;
            // 
            // flowContainerControls
            // 
            this.flowContainerControls.AutoScroll = true;
            this.flowContainerControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowContainerControls.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowContainerControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowContainerControls.Location = new System.Drawing.Point(0, 57);
            this.flowContainerControls.Name = "flowContainerControls";
            this.flowContainerControls.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.flowContainerControls.Size = new System.Drawing.Size(1198, 585);
            this.flowContainerControls.TabIndex = 2;
            this.flowContainerControls.WrapContents = false;
            // 
            // containerHeaderPanel
            // 
            this.containerHeaderPanel.Controls.Add(this.tableLayoutPanel1);
            this.containerHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.containerHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.containerHeaderPanel.Name = "containerHeaderPanel";
            this.containerHeaderPanel.Size = new System.Drawing.Size(1198, 57);
            this.containerHeaderPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(90)))), ((int)(((byte)(149)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitleApp, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1198, 57);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitleApp
            // 
            this.lblTitleApp.AutoSize = true;
            this.lblTitleApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(90)))), ((int)(((byte)(149)))));
            this.lblTitleApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleApp.ForeColor = System.Drawing.Color.White;
            this.lblTitleApp.Location = new System.Drawing.Point(3, 0);
            this.lblTitleApp.Name = "lblTitleApp";
            this.lblTitleApp.Size = new System.Drawing.Size(1192, 57);
            this.lblTitleApp.TabIndex = 1;
            this.lblTitleApp.Text = "[Titulo de app seleccionada]";
            this.lblTitleApp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
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
            ((System.ComponentModel.ISupportInitialize)(this.pbLoginIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.containerPanel.ResumeLayout(false);
            this.containerHeaderPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel headerSearchPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox molexLogo;
        private System.Windows.Forms.FlowLayoutPanel flowAppsList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel sideBarHeaderPanel;
        private System.Windows.Forms.Panel containerPanel;
        private System.Windows.Forms.Label lblTitleMESApp;
        private System.Windows.Forms.Panel containerHeaderPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowContainerControls;
        private System.Windows.Forms.Button btnAppRegister;
        private System.Windows.Forms.Label lblTitleApp;
        private System.Windows.Forms.PictureBox pbLoginIcon;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel panel2;
    }
}

