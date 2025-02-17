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
    public partial class appBasicInfoForm : Form
    {
        public delegate void AppFormSubmitHandler();
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
            bool isDataValid = true;

            string appName = tbAppNameForm.Text.Trim();
            string friendlyFolderName = appName.Replace(" ", "_").Replace("-", "_").Replace(".", "_");
            string appAuthorName = tbAuthorName.Text.Trim();
            string lastVersion = tbLastVersion.Text.Trim();
            string appPath = tbAppPathForm.Text.Trim();
            string repoPath = tbAppRepoForm.Text.Trim();
            string localImagePath = lblIMGPath.Text.Trim();
            string localImage2Path = lblIMGPath2.Text.Trim();
            string localGuidePath = lblGuidePath.Text.Trim();
            string appDescription = rtbAppDesForm.Text.Trim();
            string imagePath = "";
            string image2Path = "";
            string guidePath = "";
            int userID = User.userID;




            if (string.IsNullOrEmpty(appName))
            {
                lblNameRequired.ForeColor = Color.Crimson;
                isDataValid = false;
            }
            if (string.IsNullOrEmpty(lastVersion))
            {
                lblRequiredVersion.ForeColor = Color.Crimson;
                isDataValid = false;
            }
            if (string.IsNullOrEmpty(appPath))
            {
                lblPathRequired.ForeColor = Color.Crimson;
                isDataValid = false;
            }
            if (string.IsNullOrEmpty(localImagePath))
            {
                lblIMGRequired.ForeColor = Color.Crimson;
                isDataValid = false;
            }
            if (string.IsNullOrEmpty(appDescription))
            {
                lblDesRequired.ForeColor = Color.Crimson;
                isDataValid = false;
            }

            if (isDataValid) 
            {
                try
                {

                    if (Service.isNameRepeated(appName))
                    {
                        MessageBox.Show($"El nombre '{appName}' ya está registrado en la aplicación");
                        return;
                    }
                    else
                    {

                        try
                        {
                            imagePath = Service.saveImage(localImagePath, friendlyFolderName);
                            image2Path = string.IsNullOrEmpty(image2Path) ? image2Path : Service.saveImage2(localImage2Path, friendlyFolderName);
                            guidePath = string.IsNullOrEmpty(guidePath) ? guidePath : Service.saveGuide(localGuidePath, friendlyFolderName);
                        }
                        catch (Exception exc)
                        {

                            MessageBox.Show($"Ocurrió un error al tratar de guardar uno o más de los archivos\n {exc}");
                            return;
                        }


                        bool isProcessOK = Service.addApp(appName, appAuthorName, appPath, guidePath, imagePath, image2Path, repoPath, appDescription, userID, lastVersion);
                        if (isProcessOK)
                        {
                            MessageBox.Show("Se agregó la información con éxito");
                            onSubmit?.Invoke();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al querer guardar la información en la base de datos");
                        }
                    }
                }
                catch (Exception exc)
                {

                    MessageBox.Show(exc.ToString());
                }
                
                
                
            }

            

            //
            
            


            
        }


    }
}
