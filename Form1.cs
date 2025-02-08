using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            int buttonWidth;
            if (list.Count < 13)
            {
                buttonWidth = 278;
            }
            else
            {
                buttonWidth = 257;
            }


                foreach (var item in list) 
            {
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

                

                btn.Click += (s, ev) => btnAction(item);
            }

        }

        private void btnAction(string texto)
        {
            lblTitleApp.Text = texto;
        }

    }


}
