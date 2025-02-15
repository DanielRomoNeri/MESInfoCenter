using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MESInfoCenter.Models;

namespace MESInfoCenter
{
    public partial class TroubleShootingForm : Form
    {
        public delegate void TroubleShootingFormSubmitHandler(List<TroubleShooting> troubleShootingList);
        public event TroubleShootingFormSubmitHandler onSubmit;
        int appID;
        public TroubleShootingForm(int appID)
        {
            InitializeComponent();
            this.appID = appID;
        }

        private void btnSubmitForm_Click(object sender, EventArgs e)
        {
            List<TroubleShooting> troubleShootingList = new List<TroubleShooting>();
            bool isDataValid = true;
            string tsTitle = tbProblemNameForm.Text.Trim();
            string tsErrorTag = tbTagError.Text.Trim();
            string tsDescription = tbProblemDescription.Text.Trim();
            string tsSolution = tbProblemSolution.Text.Trim();

            if (string.IsNullOrEmpty(tsTitle))
            {
                lblRequiredName.ForeColor = Color.Crimson;
                isDataValid = false;
            }
            if (string.IsNullOrEmpty(tsDescription))
            {
                lblRequiredDes.ForeColor = Color.Crimson;
                isDataValid = false;
            }
            if (string.IsNullOrEmpty(tsSolution))
            {
                lblRequiredSolution.ForeColor = Color.Crimson;
                isDataValid = false;
            }
            if (isDataValid)
            {
                bool isProcessOK = Service.addTroubleShooting(this.appID, tsTitle, tsErrorTag, tsDescription, tsSolution);
                if (isProcessOK) 
                {
                    MessageBox.Show("Se agregó correctamente la solución");
                    troubleShootingList = Service.getTroubleShootingList(this.appID);
                    onSubmit?.Invoke(troubleShootingList);

                }


            }

        }

        private void btnCancelForm_Click(object sender, EventArgs e)
        {

        }
    }
}
