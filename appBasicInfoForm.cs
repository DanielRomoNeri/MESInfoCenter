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
        public delegate void AppFormSubmitHandler(List<string> data);
        public event AppFormSubmitHandler onSubmit;
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
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Imágenes JPG (*.jpg)|*.jpg;*.jpeg";
            fd.FilterIndex = 1;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                string sFileName = fd.FileName;
                lblIMGPath.Text = sFileName;        
            }
        }

        private void btnIMGUploadForm2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Imágenes JPG (*.jpg)|*.jpg;*.jpeg";
            fd.FilterIndex = 1;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                string sFileName = fd.FileName;
                lblIMGPath2.Text = sFileName;
            }

        }

        private void btnGuideUploadForm_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Documento de Word (*.doc;*.docx)|*.doc;*.docx|Archivo de Excel (*.xls;*.xlsx)|*.xls;*.xlsx|Archivo de texto (*.txt)|*.txt";
            fd.FilterIndex = 1;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                string sFileName = fd.FileName;
                lblGuidePath.Text = sFileName;
            }
        }

        private void btnSubmitForm_Click(object sender, EventArgs e)
        {
           
            List<string> list = new List<string>();
            list.Add(tbAppNameForm.Text);
            list.Add(tbAppPathForm.Text);
            list.Add(tbAppRepoForm.Text);
            list.Add(lblIMGPath.Text);
            list.Add(lblGuidePath.Text);
            list.Add(rtbAppDesForm.Text);
            
            onSubmit?.Invoke(list);
            
            this.Close();


            
        }

        
    }
}
