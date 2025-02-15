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
using MESInfoCenter.Models;
using static System.Windows.Forms.LinkLabel;

namespace MESInfoCenter
{
    public partial class Form1 : Form
    {
        List<Apps> appsList = new List<Apps>();
        

        bool isValidUser = false;
        //string userName;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void LoginForm_OnLogin()
        {
            lblUserName.Text = User.userName;
            this.isValidUser = true;
            unHideContent();
        }

        private void unHideContent()
        {

            btnAddSolution.Visible = true;
            btnAppRegister.Visible = true;

        }

        private void cerrarForm()
        {

        }

        private void appBasicInfoForm_OnSubmit()
        {
            int lastID;

            
            updateAppsList();
            //se filtra de la lista el ultimo ID de la tabla apps
            lastID = appsList.Max(u => u.appID);
            //se muestran los datos de la ultima aplicacion registrada
            showContent(lastID);
            

        }

        //Se actualiza lista de aplicaciones para generar de nuevo los botones
        public void updateAppsList()
        {
            int buttonWidth;
            
            appsList.Clear();
            flowAppsList.Controls.Clear();

            appsList = Service.getAppList();
            appsList.Sort();
            buttonWidth = appsList.Count < 13 ? 280 : 257;
   
            foreach (Apps app in appsList) 
            {
                
                Button btn = new Button
                {
                    Text = app.appName,
                    ForeColor = Color.White,
                    BackColor = Color.DodgerBlue,
                    //Dock = DockStyle.Fill,
                    Width = buttonWidth,
                    Height = 54,
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(0, 0, 0, 0),
                    

                };

                btn.Click += (s, e) => showContent(app.appID);
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font(btn.Font.FontFamily, 14, btn.Font.Style);
  
                flowAppsList.Controls.Add(btn);
                //showContent(data);
            }
        }
        private int getRichTextBoxHeight(RichTextBox rtb)
        {
            int emptyLines = 0;
            foreach (string line in rtb.Lines)
            {
                if (line == "")
                {
                    emptyLines++;
                }
            }
            using (Graphics g = rtb.CreateGraphics())
            {
                int offsetSize = 50 + emptyLines * 2;
                SizeF sizeText = g.MeasureString(rtb.Text, rtb.Font, rtb.Width);
                return (int)sizeText.Height + offsetSize;
            }
        }

        private void RichTextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            // Verifica que el padre tenga AutoScroll activado
            if (flowContainerControls.AutoScroll)
            {
                // Desplaza el Panel manualmente
                flowContainerControls.AutoScrollPosition = new Point(
                    flowContainerControls.AutoScrollPosition.X,
                    -flowContainerControls.AutoScrollPosition.Y - e.Delta // Mueve en función de la rueda del mouse
                );
            }
        }


        public void showContent(int ID)
        {
            Apps app = new Apps();
            List<TroubleShooting> troubleShootingList = new List<TroubleShooting>();

            int imageWidth; 
            int imageHeight;
            int marginLeft;
            //Se elimina todo el contenido antes de generar más
            flowContainerControls.Controls.Clear();

            app = appsList.FirstOrDefault(c => c.appID == ID);

            lblTitleApp.Text = app.appName;

            //Todos los controles usados aquí están en Controls.Designer.cs

            Image image = Image.FromFile(app.appPath);

            //Condiciones ternarias para ajustar el ancho y alto en caso de que se pase
            imageWidth = image.Width > 900 ? 900 : image.Width;
            imageHeight = image.Height > 500 ? 500 : image.Height;

          
            //Dependiendo del ancho hago un margen para que la imagen se vea centrada
            marginLeft = getMarginLeft(imageWidth);

            pictureBox.Image = image;
            pictureBox.Size = new System.Drawing.Size(imageWidth, imageHeight);
            pictureBox.Margin = new Padding(marginLeft, 0, 0, 0);

            lblAppPath.Text += app.appPath;
            lblRepoPath.Text += app.repoPath;

            btnCopyAppPath.Click += (e, s) => copyAppPath(app.appPath);
            btnCopyRepoPath.Click += (e, s) => copyRepoPath(app.repoPath);
            


            //saveImage(pictureBox);
            //saveGuideFile(appGuidePath);
            rtbDescription.Clear();

            addCenterText(rtbDescription, "Descripción", 21);
            //Se generan dos saltos de linea después del titulo Descripción
            rtbDescription.AppendText("\n\n");
            // Restablece alineación para siguientes textos
            rtbDescription.SelectionAlignment = HorizontalAlignment.Left;
            rtbDescription.AppendText(app.appDescription);
            rtbDescription.AppendText("\n\n\n");
            //Titulo que debe aparecer justamente arriba de el campo de solución de problemas
            addCenterText(rtbDescription, "Solución de problemas", 21);

            rtbDescription.Height = getRichTextBoxHeight(rtbDescription);

            //La rueda del ratón dispara un evento para mover la página si el cursor está dentro del RichTextBox
            rtbDescription.MouseWheel += RichTextBox_MouseWheel;

            troubleShootingList = Service.getTroubleShootingList(app.appID);
            genTroubleShootingButtons(troubleShootingList);

            btnAddSolution.Click += (e, s) => btnTroubleShootingRegister_Click(app.appID);


            flowContentButtons.Controls.Add(btnCopyAppPath);
            flowContentButtons.Controls.Add(btnCopyRepoPath);
            flowContentButtons.Controls.Add(btnDownloadGuide);

            


            panelTroubleShooting.Controls.Add(flowTroubleShooting);
            panelTroubleShooting.Controls.Add(btnAddSolution);
            flowTroubleShooting.Controls.Add(flowTroubleShootingButtons);
            flowTroubleShooting.Controls.Add(rtbTSSolution);

            flowContainerControls.Controls.Add(pictureBox);
            flowContainerControls.Controls.Add(flowContentButtons);
            flowContainerControls.Controls.Add(lblAppPath);
            flowContainerControls.Controls.Add(lblRepoPath);
            flowContainerControls.Controls.Add(rtbDescription);
            flowContainerControls.Controls.Add(panelTroubleShooting);
            




        }

        private void copyRepoPath(string path)
        {
            Clipboard.SetText(path);
            lblRepoPath.BackColor = Color.Cyan;
            lblAppPath.BackColor = ColorTranslator.FromHtml("#F2F2F2");
        }

        private void copyAppPath(string path)
        {
            Clipboard.SetText(path);

            lblAppPath.BackColor = Color.Cyan;
            lblRepoPath.BackColor = ColorTranslator.FromHtml("#F2F2F2");

        }

        public void genTroubleShootingRTBContent(TroubleShooting troubleShooting)
        {
            rtbTSSolution.Clear();

            addCenterText(rtbTSSolution, "Nombre del problema", 18);
            rtbTSSolution.AppendText("\n");
            rtbTSSolution.AppendText(troubleShooting.tsTitle);

            if (!string.IsNullOrEmpty(troubleShooting.tsErrorTag))
            {
                addCenterText(rtbTSSolution, "Error mostrado", 18);
                rtbTSSolution.AppendText("\n");
                rtbTSSolution.AppendText(troubleShooting.tsErrorTag);
            }
            

            addCenterText(rtbTSSolution, "Problema", 18);
            rtbTSSolution.AppendText("\n");
            rtbTSSolution.AppendText(troubleShooting.tsDescription);
            addCenterText(rtbTSSolution, "Solución", 18);
            rtbTSSolution.AppendText("\n");
            rtbTSSolution.AppendText(troubleShooting.tsSolution);


        }

        public void genTroubleShootingButtons(List<TroubleShooting> troubleShootingList)
        {
            flowTroubleShootingButtons.Controls.Clear();
            if (troubleShootingList.Count != 0)
            {
                foreach (TroubleShooting troubleShooting in troubleShootingList)
                {
                    Button btnTroubleShooting = new Button
                    {
                        Text = troubleShooting.tsTitle,
                        Width = 300,
                        Height = 80,

                    };
                    btnTroubleShooting.Click += (e, s) => genTroubleShootingRTBContent(troubleShooting);
                    flowTroubleShootingButtons.Controls.Add(btnTroubleShooting);
                }
            }
        }

        
        private int getMarginLeft(int width)
        {
            int marginLeft;
            marginLeft = (1400 - width) / 2;
            return marginLeft;
        }

        private void addCenterText(RichTextBox rtb, string text, int fontSize)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;

            // Asegura que solo esta línea sea centrada
            rtb.SelectionAlignment = HorizontalAlignment.Center;
            rtb.SelectionFont = new Font(rtb.Font.FontFamily, fontSize);

            //rtb.SelectionColor = Color.Indigo;

            rtb.AppendText(text);

        }
        private void btnAppRegister_Click(object sender, EventArgs e)
        {
            appBasicInfoForm infoForm = new appBasicInfoForm();
            infoForm.StartPosition = FormStartPosition.Manual;
            infoForm.Location = new System.Drawing.Point(this.Location.X + 400, this.Location.Y + 100);
            infoForm.onSubmit += appBasicInfoForm_OnSubmit;
            infoForm.ShowDialog();
        }

        private void btnTroubleShootingRegister_Click(int ID)
        {
            TroubleShootingForm troubleShootingForm = new TroubleShootingForm(ID);
            troubleShootingForm.StartPosition = FormStartPosition.Manual;
            troubleShootingForm.Location = new System.Drawing.Point(this.Location.X + 400, this.Location.Y + 100);
            troubleShootingForm.onSubmit += genTroubleShootingButtons;
            troubleShootingForm.ShowDialog();
        }
        private void pbLoginIcon_Click(object sender, EventArgs e)
        {
            //Si ya hay un usuario registrado ya no muestra la ventana de login
            if (isValidUser)
            {
                return;
            }
            else
            {

                LoginForm loginForm = new LoginForm();
                loginForm.StartPosition = FormStartPosition.Manual;
                loginForm.Location = new System.Drawing.Point(this.Location.X + 700, this.Location.Y + 350);
                loginForm.onLogin += LoginForm_OnLogin;
                loginForm.ShowDialog();

            }
            
        }
    }


}
