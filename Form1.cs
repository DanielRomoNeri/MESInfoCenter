using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESInfoCenter
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string> 
            {"Boton1", "Boton2", "Boton3", "Boton4", "Boton5","Boton1"};

        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // form2.Click += (snd, evet) => cerrarForm();
            
           

            int buttonWidth;
            if (list.Count < 13)
            {
                buttonWidth = 278;
            }
            else
            {
                buttonWidth = 257;
            }
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = global::MESInfoCenter.Properties.Resources.Screenshot_2025_02_08_184652;
            pictureBox.Size = new System.Drawing.Size(500, 500);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            flowContainerControls.Controls.Add(pictureBox);
            foreach (var item in list) 
            {
                Label label = new Label();

                label.Text = item;
                label.Width = 100;
                label.Height = 100;
                label.Font = new Font(label.Font.FontFamily, 14);

                Button btn = new Button();
                btn.Text = item;
                btn.ForeColor = Color.White;
                btn.BackColor = Color.Indigo;
                btn.Width = buttonWidth;
                btn.Height = 54;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Margin = new Padding(0, 0, 0, 0);
                btn.Font = new Font(btn.Font.FontFamily, 14);


                flowAppsList.Controls.Add(btn);
                flowContainerControls.Controls.Add(label);
                

                btn.Click += (s, ev) => btnAction(item);
            }
            

        }

        private void cerrarForm()
        {
            
        }
        private void btnAction(string texto)
        {
            appBasicInfoForm infoForm = new appBasicInfoForm();
            lblTitleApp.Text = texto;
            infoForm.StartPosition = FormStartPosition.Manual;
            infoForm.Location = new System.Drawing.Point(this.Location.X + 400, this.Location.Y + 150);
            infoForm.ShowDialog();
        }


    }


}
