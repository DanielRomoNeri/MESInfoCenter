using System;
using System.Drawing;
using System.Windows.Forms;
using MESInfoCenter.Models;

namespace MESInfoCenter
{
    public partial class appBasicInfoForm : Form
    {
        private Form1 _form;
        public delegate void AppFormSubmitHandler(int appID);
        public event AppFormSubmitHandler onSubmit;
        bool isUpdate = false;
        int appID = -1;

        string _imagePath;
        string _image2Path;
        string _guidePath;
        public appBasicInfoForm()
        {
            InitializeComponent();
        }
        public appBasicInfoForm(Apps app, Form1 form)
        {
            this._form = form;
            InitializeComponent();
            setInfo(app);
        }

        private void setInfo(Apps app)
        {
            tbAppNameForm.Text = app.appName;
            tbAuthorName.Text = app.appAuthorName;
            tbLastVersion.Text = app.lastVersion;
            tbAppPathForm.Text = app.appPath;
            tbAppRepoForm.Text = app.repoPath;
            lblIMGPath.Text = app.imagePath;
            lblIMGPath2.Text = app.image2Path;
            lblGuidePath.Text = app.guidePath;
            rtbAppDesForm.Text = app.appDescription;

            this._imagePath = app.imagePath;
            this._image2Path = app.image2Path;
            this._guidePath = app.guidePath;

            this.appID = app.appID;
            this.isUpdate = true;
            


        }

        private void btnCancelForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIMGUploadForm_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Imágenes JPG o PNG (*.jpg;*.png)|*.jpg;*.jpeg;*.png";
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
            fd.Filter = "Imágenes JPG o PNG (*.jpg;*.png)|*.jpg;*.jpeg;*.png";
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

            int userID = User.userID;

            string imagePath = "";
            string image2Path = "";
            string guidePath = "";


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

                    if (Service.isNameRepeated(appName) && isUpdate == false)
                    {
                        MessageBox.Show($"El nombre '{appName}' ya está registrado en la aplicación");
                        return;
                    }
                    else
                    {

                        try
                        {
                            //los tres if siguientes validan si al modificar el formulario hubo un cambio en las rutas
                            //para guardas las nuevas imagenes
                            if (_imagePath != localImagePath)
                            {
                                if(_form != null)
                                {
                                    _form.releaseImage();
                                }
                                
                                imagePath = Service.saveImage(localImagePath, friendlyFolderName);
                            }
                            else
                            {
                                imagePath = localImagePath;
                            }
                            if (_image2Path != localImage2Path)
                            {
                                if (_form != null)
                                {
                                    _form.releaseImage2();
                                }
                                image2Path = string.IsNullOrEmpty(localImage2Path) ? image2Path : Service.saveImage2(localImage2Path, friendlyFolderName);
                            }
                            else
                            {
                                image2Path = localImage2Path;
                            }
                            if (_guidePath != localGuidePath)
                            {
                                guidePath = string.IsNullOrEmpty(localGuidePath) ? guidePath : Service.saveGuide(localGuidePath, friendlyFolderName);
                            }
                            else
                            {
                                guidePath = localGuidePath;
                            }

                        }
                        catch (Exception exc)
                        {

                            MessageBox.Show($"Ocurrió un error al tratar de guardar uno o más de los archivos\n {exc}");
                            return;
                        }


                        bool isProcessOK;

                        if (isUpdate == false)
                        {
                            isProcessOK = Service.addApp(
                                appName, appAuthorName, appPath, guidePath, imagePath,
                                image2Path, repoPath, appDescription, userID, lastVersion);

                        }
                        else
                        {
                            isProcessOK = Service.updateApp(
                                this.appID, appName, appAuthorName, appPath, guidePath, imagePath,
                                image2Path, repoPath, appDescription, userID, lastVersion);
                        }

                        if (isProcessOK)
                        {
                            MessageBox.Show("Se agregó la información con éxito");
                            onSubmit?.Invoke(appID);
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

          
        }

        private void tbAppNameForm_TextChanged(object sender, EventArgs e)
        {
            //int maxLimit = 20 - tbAppNameForm.Text.Length;


            //lblNameRequired.Text = $"* ({maxLimit})";
            //if (maxLimit > 0)
            //{
            //    maxLimit = 0;
            //    lblNameRequired.ForeColor = Color.Crimson;
            //}
            //else
            //{
            //    lblNameRequired.ForeColor = Color.White;
            //}
        }

        private void lblIMGPath2_Click(object sender, EventArgs e)
        {
            lblIMGPath2.Text = "";
        }

        private void lblGuidePath_Click(object sender, EventArgs e)
        {
            lblGuidePath.Text = "";
        }
    }
}
