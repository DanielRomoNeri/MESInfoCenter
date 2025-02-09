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
    public partial class appBasicInfoForm : Form
    {
        public appBasicInfoForm()
        {
            InitializeComponent();
        }

        private void btnCancelForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIMGUploadForm_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Imágenes JPG (*.jpg)|*.jpg;*.jpeg";
            choofdlog.FilterIndex = 1;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                lblIMGPath.Text = sFileName;        
            }
        }

        private void btnGuideUploadForm_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Archivos de texto (*.txt)|*.txt|Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx|Documentos de Word (*.doc;*.docx)|*.doc;*.docx";
            choofdlog.FilterIndex = 1;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                lblGuidePath.Text = sFileName;
            }
        }
    }
}
