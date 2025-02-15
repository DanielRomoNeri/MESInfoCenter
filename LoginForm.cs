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
    public partial class LoginForm : Form
    {

        public delegate void LoginFormHandler();
        public event LoginFormHandler onLogin;
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            string userName = tbUser.Text.Trim();
            string password = tbPassword.Text.Trim();
            if (string.IsNullOrEmpty(userName)) 
            {
                lblRequiredUser.ForeColor = Color.Crimson;
            }
            else if (string.IsNullOrEmpty(password))
            { 
                lblRequiredPassword.ForeColor= Color.Crimson;
            }
            else
            {
                if(Service.validateUser(userName, password))
                {
                    onLogin?.Invoke();
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("El usuario o la contraseña con incorrectas");
                    tbUser.Text = "";
                    tbPassword.Text = "";
                    lblRequiredUser.ForeColor = Color.Crimson;
                    lblRequiredPassword.ForeColor = Color.Crimson;
                }
            }

           

           
        }
    }
}
