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
    public partial class TroubleShootingForm : Form
    {
        int appID;
        public TroubleShootingForm(int appID)
        {
            InitializeComponent();
            this.appID = appID;
        }

        private void btnSubmitForm_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelForm_Click(object sender, EventArgs e)
        {

        }
    }
}
