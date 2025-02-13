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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // form2.Click += (snd, evet) => cerrarForm();



            //int buttonWidth;
            //if (list.Count < 13)
            //{
            //    buttonWidth = 278;
            //}
            //else
            //{
            //    buttonWidth = 257;
            //}
            //PictureBox pictureBox = new PictureBox();
            //pictureBox.Image = global::MESInfoCenter.Properties.Resources.Screenshot_2025_02_08_184652;
            //pictureBox.Size = new System.Drawing.Size(500, 500);
            //pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //flowContainerControls.Controls.Add(pictureBox);
            //foreach (var item in list) 
            //{
            //    Label label = new Label();

            //    label.Text = item;
            //    label.Width = 100;
            //    label.Height = 100;
            //    label.Font = new Font(label.Font.FontFamily, 14);

            //    Button btn = new Button();
            //    btn.Text = item;
            //    btn.ForeColor = Color.White;
            //    btn.BackColor = Color.Indigo;
            //    btn.Width = buttonWidth;
            //    btn.Height = 54;
            //    btn.FlatStyle = FlatStyle.Flat;
            //    btn.FlatAppearance.BorderSize = 0;
            //    btn.Margin = new Padding(0, 0, 0, 0);
            //    btn.Font = new Font(btn.Font.FontFamily, 14);


            //    flowAppsList.Controls.Add(btn);
            //    flowContainerControls.Controls.Add(label);


            //    btn.Click += (s, ev) => btnAction(item);
            //}


        }

        private void cerrarForm()
        {

        }

        private void appBasicInfoForm_OnSubmit(List<string> data)
        {



            Button btn = new Button
            {
                Text = data[0],
                ForeColor = Color.White,
                BackColor = Color.DodgerBlue,
                //Dock = DockStyle.Fill,
                Width = 280,
                Height = 54,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(0, 0, 0, 0),

            };

            Panel panelButtonContainer = new Panel
            {
                Dock = DockStyle.Fill,
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font(btn.Font.FontFamily, 14, btn.Font.Style);
            btn.Click += (s, ev) => btnAction(data[0]);
            flowAppsList.Controls.Add(btn);
            showContent(data);

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

        private void btnAction(string texto)
        {

            lblTitleMESApp.Text = texto;

        }

        public void showContent(List<string> data)
        {

            string appName = data[0];
            string appPath = data[1];
            string appRepoPath = data[2];
            string appIMGPath = data[3];
            string appGuidePath = data[4];
            string appDes = data[5];
            int marginLeft;
            int imageWidth;
            int imageHeight;

            //Todos los controles usados aquí están en Controls.Designer.cs

            Image image = Image.FromFile(appIMGPath);



            if (image.Width > 900)
            {
                imageWidth = 900;
            }
            else
            {
                imageWidth = image.Width;
            }

            if (image.Height > 500)
            {
                imageHeight = 500;
            }
            else
            {
                imageHeight = image.Height;
            }

            marginLeft = getMarginLeft(imageWidth);

            pictureBox.Image = image;
            pictureBox.Size = new System.Drawing.Size(imageWidth, imageHeight);
            pictureBox.Margin = new Padding(marginLeft, 0, 0, 0);

            lblAppPath.Text += appPath;
            lblRepoPath.Text += appRepoPath;

            btnCopyAppPath.Click += (e, s) => copyAppPath(appPath);
            btnCopyRepoPath.Click += (e, s) => copyRepoPath(appRepoPath);
            


            //saveImage(pictureBox);
            //saveGuideFile(appGuidePath);
            rtbDescription.Clear();

            addCenterText(rtbDescription, "Descripción");
            rtbDescription.AppendText("\n\n");
            // Restablece alineación para siguientes textos
            rtbDescription.SelectionAlignment = HorizontalAlignment.Left;
            rtbDescription.AppendText(appDes);
            rtbDescription.AppendText("\n\n\n");
            addCenterText(rtbDescription, "Solución de problemas");

            rtbDescription.Height = getRichTextBoxHeight(rtbDescription);

            rtbDescription.MouseWheel += RichTextBox_MouseWheel;

            List<string> lines = new List<string> { "Boton1" };//, "Boton2", "Boton3", "Boton4", "Boton5", "Boton6", "Boton7", "Boton8", };
            int panelHeight = lines.Count * 30;
            foreach (string line in lines)
            {
                Button btnTroubleShooting = new Button
                {
                    Text = line,
                    Width = 300,
                    Height = 80,

                };
                flowTroubleShootingButtons.Controls.Add(btnTroubleShooting);
            }

            tbTSSolution.Text = "Hola, la solucion es... blablablabvla";


            flowContentButtons.Controls.Add(btnCopyAppPath);
            flowContentButtons.Controls.Add(btnCopyRepoPath);
            flowContentButtons.Controls.Add(btnDownloadGuide);

            


            panelTroubleShooting.Controls.Add(flowTroubleShooting);
            panelTroubleShooting.Controls.Add(btnaddSolution);
            flowTroubleShooting.Controls.Add(flowTroubleShootingButtons);
            flowTroubleShooting.Controls.Add(tbTSSolution);

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

        private void saveGuideFile(string path)
        {
            string destinoCarpeta = @"C:\Users\danier94\OneDrive - kochind.com\Desktop\RecursosAplicacionesMolex\"; // Carpeta de destino
            string fileExtension = Path.GetExtension(path);
            string fileName = "guia123" + fileExtension;
            string destinoArchivo = Path.Combine(destinoCarpeta, fileName);
            File.Copy(path, destinoArchivo, true);
        }

        private void saveImage(PictureBox image)
        {
            string ruta = $@"C:\Users\danier94\OneDrive - kochind.com\Desktop\RecursosAplicacionesMolex\nombre.jpg"; // Ruta donde se guardará la imagen
            image.Image.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("Imagen guardada en: " + ruta);
        }
        private int getMarginLeft(int width)
        {
            int marginLeft;
            marginLeft = (1400 - width) / 2;
            return marginLeft;
        }

        private void addCenterText(RichTextBox rtb, string text)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;

            // Asegura que solo esta línea sea centrada
            rtb.SelectionAlignment = HorizontalAlignment.Center;
            rtb.SelectionFont = new Font(rtb.Font.FontFamily, 21);

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

        
    }


}
