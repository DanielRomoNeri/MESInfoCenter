﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MESInfoCenter.Models;

namespace MESInfoCenter
{
    public partial class Form1 : Form
    {
        List<Apps> appsList = new List<Apps>();
        string version = "0.0.0.1";
        int scrollPositionTEMP = 0;
        bool isValidUser = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setVersion();
            eventSubscriber();
            updateAppsList();
        }

        private void setVersion()
        {
            Label lblVersion = new Label 
            {
                Text = this.version,
                ForeColor = Color.Black,
                Font = new Font("Arial", 8),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            lblVersion.Location = new Point(this.ClientSize.Width - lblVersion.Width,
                           this.ClientSize.Height - lblVersion.Height);
            this.Controls.Add(lblVersion);
            lblVersion.BringToFront();
        }

        private void eventSubscriber()
        {
            btnOpenPathFolder.Click += openAppPathFolder;
            btnCopyRepoPath.Click += copyRepoPath;
            btnOpenGuideFolder.Click += openGuideFolder;
            btnAddSolution.Click += btnTroubleShootingRegister_Click;
            rtbDescription.MouseWheel += RichTextBox_MouseWheel;
            rtbTSSolution.MouseWheel += RichTextBoxSolution_MouseWheel;
            btnUpdateApp.Click += openBasicInfoFormToModify;
            btnDeleteApp.Click += deleteAppFromDB;
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
            btnUpdateApp.Visible = true;
            btnDeleteApp.Visible = true;

        }

        //Elimina el contenido de todos los FlowLayoutPanel,
        //ya que por alguna razón no se eliminan en cascada al limpiar el padre
        private void clearFlowPanels()
        {
            flowContainerControls.Controls.Clear();
            flowContentButtons.Controls.Clear();
            flowTroubleShootingButtons.Controls.Clear();
            flowTroubleShooting.Controls.Clear();
        }

        private void appBasicInfoForm_OnSubmit(int appID)
        {
            int lastID;

            //se actualiza la lista de aplicaciones desde la DB
            updateAppsList();
            //Valida si el método fue llamado después de actualizar o de agregar
            if (appID == -1)
            {
                //se filtra de la lista el ultimo ID de la tabla apps en caso de que se haya agregado nueva app
                lastID = appsList.Max(u => u.appID);
            }
            else
            {
                //se asigna el ID de la aplicación actualizada en caso de modificación para que se muestren los cambios
                lastID = appID;
            }

            //se genera el contenido en la aplicación
            showContent(lastID);
            

        }

        //
        //Funciones para generar contenido en paneles
        //

        //Se actualiza lista de aplicaciones para generar de nuevo los botones
        public void updateAppsList()
        {
            int buttonWidth;
            
            //appsList.Clear();
            //flowAppsList.Controls.Clear();

            //appsList = Service.getAppList();
            //if(appsList == null)
            //{
            //    MessageBox.Show("No se pudo acceder o no se encontró ningúna aplicación registrada en la base de datos");
            //    return;
            //}

            //Se filtra la lista por orden alfabético 
            //appsList.Sort((a1, a2) => a1.appName.CompareTo(a2.appName));

            buttonWidth = appsList.Count < 13 ? 280 : 257;
            List<string> apps = new List<string> { "Hola", "Adios","Esto", "Es", "Una", "Prueba","123", "Para", "Validar","Estadio", "Perro", "Gato", "Más aplicaciones" };
            foreach (string item in apps)//(Apps app in appsList) 
            {
                
                Button btn = new Button
                {
                    Text = item,//app.appName,
                    ForeColor = Color.White,
                    BackColor = Color.DodgerBlue,
                    //Dock = DockStyle.Fill,
                    Width = buttonWidth,
                    Height = 54,
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(0, 0, 0, 0),
                    

                };
                btn.Tag = btn;
                //btn.Click += (s, e) => showContent(app.appID);
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font(btn.Font.FontFamily, 14, btn.Font.Style);
  
                flowAppsList.Controls.Add(btn);
           
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
            clearFlowPanels();
            
            app = appsList.FirstOrDefault(c => c.appID == ID);

            lblTitleApp.Text = app.appName;

            ////////////////////////////////////Todos los controles usados aquí están en Controls.Designer.cs

            //Se carga la imagen de la ruta que está en la base de datos
            Image image = Image.FromFile(app.imagePath);

            //Condiciones ternarias para ajustar el ancho y alto en caso de que se pase
            imageWidth = image.Width > 900 ? 900 : image.Width;
            imageHeight = image.Height > 500 ? 500 : image.Height;

          
            marginLeft = getMarginLeft(imageWidth);
            imageBorder(imageWidth, imageHeight, marginLeft);

            pictureBox.Image = image;
            pictureBox.Size = new System.Drawing.Size(imageWidth, imageHeight);
          

            

            lblAuthorName.Text = $"Desarrollador: {app.appAuthorName}";
            lblLastVersion.Text = $"Última versión: {app.lastVersion}";
            lblAppPath.Text = $"Ruta: {app.appPath}";
            lblRepoPath.Text = $"Repositorio: {app.repoPath}";

            btnOpenPathFolder.Tag = app.appPath;
            btnCopyRepoPath.Tag = app.repoPath;
            btnOpenGuideFolder.Tag = app.guidePath;

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

            

            troubleShootingList = Service.getTroubleShootingList(app.appID);
            genTroubleShootingButtons(troubleShootingList);

            btnAddSolution.Tag = app.appID;

            panelPictureBoxBorder.Controls.Add(pictureBox);
            flowContentButtons.Controls.Add(btnOpenPathFolder);
            //Validación de info opcional para saber si se va a mostrar o no
            if (!string.IsNullOrEmpty(app.repoPath))
            {
                flowContentButtons.Controls.Add(btnCopyRepoPath); 
            }
            //Validación de info opcional para saber si se va a mostrar o no
            if (!string.IsNullOrEmpty(app.guidePath))
            {
                flowContentButtons.Controls.Add(btnOpenGuideFolder); 
            }

            


            panelTroubleShooting.Controls.Add(flowTroubleShooting);
            panelTroubleShooting.Controls.Add(btnAddSolution);
            flowTroubleShooting.Controls.Add(flowTroubleShootingButtons);
            flowTroubleShooting.Controls.Add(rtbTSSolution);
                                                                                                                                                                                                                                                                                                              
            btnUpdateApp.Tag = app;
            btnDeleteApp.Tag = app;
            flowBottomButtonsContainer.Controls.Add(btnDeleteApp);
            flowBottomButtonsContainer.Controls.Add(btnUpdateApp);

            flowContainerControls.Controls.Add(panelPictureBoxBorder);
            flowContainerControls.Controls.Add(flowContentButtons);
            //Validación de info opcional para saber si se va a mostrar o no
            if (!string.IsNullOrEmpty(app.appAuthorName))
            {
                flowContainerControls.Controls.Add(lblAuthorName);
            }

            flowContainerControls.Controls.Add(lblLastVersion);
            flowContainerControls.Controls.Add(lblAppPath);
            //Validación de info opcional para saber si se va a mostrar o no
            if (!string.IsNullOrEmpty(app.repoPath))
            {
                flowContainerControls.Controls.Add(lblRepoPath); 
            }
            
            flowContainerControls.Controls.Add(rtbDescription);
            
            flowContainerControls.Controls.Add(panelTroubleShooting);
            flowContainerControls.Controls.Add(flowBottomButtonsContainer);



        }

        private void imageBorder(int imageWidth, int imageHeight, int marginLeft)
        {
            panelPictureBoxBorder.Width = imageWidth + 10;
            panelPictureBoxBorder.Height = imageHeight + 10;
            panelPictureBoxBorder.Margin = new Padding(marginLeft, 0, 0, 0);
            panelPictureBoxBorder.Padding = new Padding(5);


        }

        //General el texto según el tema seleccionado en los botones
        public void genTroubleShootingRTBContent(TroubleShooting troubleShooting)
        {
            rtbTSSolution.Clear();

            addCenterText(rtbTSSolution, "Tema", 18);
            rtbTSSolution.AppendText("\n\n");
            rtbTSSolution.AppendText(troubleShooting.tsTitle);
            rtbTSSolution.AppendText("\n\n\n");

            if (!string.IsNullOrEmpty(troubleShooting.tsErrorTag))
            {
                addCenterText(rtbTSSolution, "Error mostrado", 18);
                rtbTSSolution.AppendText("\n\n");
                rtbTSSolution.AppendText(troubleShooting.tsErrorTag);
                rtbTSSolution.AppendText("\n\n\n");
            }


            addCenterText(rtbTSSolution, "Problema", 18);
            rtbTSSolution.AppendText("\n\n");
            rtbTSSolution.AppendText(troubleShooting.tsDescription);
            rtbTSSolution.AppendText("\n\n\n");
            addCenterText(rtbTSSolution, "Solución", 18);
            rtbTSSolution.AppendText("\n\n");
            rtbTSSolution.AppendText(troubleShooting.tsSolution);


        }
        //Genera los botones según la cantidad de temas de Solución de Problemas
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
        

        //
        //Funciones que trabajan con rutas
        //
        private void openAppPathFolder(object sender, EventArgs e)
        {

            if (sender is Button btn && btn.Tag is string appPath)
            {
                string appFolder = Path.GetDirectoryName(appPath);
                if (!string.IsNullOrEmpty(appFolder))
                {
                    // Abrir appFolder en el explorador de archivos
                    Process.Start("explorer.exe", appFolder);
                }
                else
                {
                    Console.WriteLine("No se pudo obtener la carpeta. En caso de que se haya borrado, suba la guía de nuevo");
                }
            }
            //if (sender is Button btn && btn.Tag is string path)
            //{
            //    Clipboard.SetText(path);
            //    lblAppPath.BackColor = Color.Cyan;
            //    lblRepoPath.BackColor = ColorTranslator.FromHtml("#F2F2F2"); 
            //}
        }

        private void copyRepoPath(object sender, EventArgs e)
        {


            if (sender is Button btn && btn.Tag is string path)
            {
                Clipboard.SetText(path);
                lblRepoPath.BackColor = Color.Cyan;
                lblAppPath.BackColor = ColorTranslator.FromHtml("#F2F2F2");
            }

        }
        private void openGuideFolder(object sender, EventArgs e)
        {

            if (sender is Button btn && btn.Tag is string guidePath)
            {
                string guideFolder = Path.GetDirectoryName(guidePath);
                if (!string.IsNullOrEmpty(guideFolder))
                {
                    // Abrir la guideFolder en el explorador de archivos
                    Process.Start("explorer.exe", guideFolder);
                }
                else
                {
                    Console.WriteLine("No se pudo obtener la carpeta. En caso de que se haya borrado, suba la guía de nuevo");
                } 
            }
        }

        //
        //Calculos para mejorar apariencia
        //


        //Calcula el margen que va a tener la imagen dependiendo de su tamaño para que se vea siempre centrada
        private int getMarginLeft(int width)
        {
            int marginLeft;
            marginLeft = (1400 - width) / 2;
            return marginLeft;
        }
        //centra el texto de un richtextbox ingresado
        private void addCenterText(RichTextBox rtb, string text, int fontSize)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;

            // Asegura que solo esta línea sea centrada
            rtb.SelectionAlignment = HorizontalAlignment.Center;
            rtb.SelectionFont = new Font(rtb.Font.FontFamily, fontSize);

            rtb.AppendText(text);

        }

        //Se hace un cálculo del alto de richtextbox en base a su contenido para evitar que aparezca el scrollbar
        //y que el contenido siempre sea visible
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


        //
        // FUNCIONES PARA ABRIR FORMULARIOS
        //
        private void btnAppRegister_Click(object sender, EventArgs e)
        {
            appBasicInfoForm infoForm = new appBasicInfoForm();
            infoForm.StartPosition = FormStartPosition.Manual;
            infoForm.Location = new System.Drawing.Point(this.Location.X + 400, this.Location.Y + 100);
            infoForm.onSubmit += appBasicInfoForm_OnSubmit;
            infoForm.ShowDialog();
        }
        private void openBasicInfoFormToModify(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Apps app)
            {
                appBasicInfoForm infoForm = new appBasicInfoForm(app);
                infoForm.StartPosition = FormStartPosition.Manual;
                infoForm.Location = new System.Drawing.Point(this.Location.X + 400, this.Location.Y + 100);
                infoForm.onSubmit += appBasicInfoForm_OnSubmit;
                infoForm.ShowDialog();
            }
        }

        private void btnTroubleShootingRegister_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is int ID)
            {
                TroubleShootingForm troubleShootingForm = new TroubleShootingForm(ID);
                troubleShootingForm.StartPosition = FormStartPosition.Manual;
                troubleShootingForm.Location = new System.Drawing.Point(this.Location.X + 400, this.Location.Y + 100);
                troubleShootingForm.onSubmit += genTroubleShootingButtons;
                troubleShootingForm.ShowDialog(); 
            }
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

        private void deleteAppFromDB(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Apps app)
            {
                DialogResult dialogResult = MessageBox.Show(
                $"¿Estás totalmente seguro de eliminar {app.appName}? Se eliminará de la base de datos el contenido " +
                $"junto con sus problemas y soluciones", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) 
                {
                    if (Service.deleteApp(app.appID))
                    {
                        MessageBox.Show($"Se ha eliminado {app.appName}");
                        updateAppsList();
                        clearFlowPanels();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al tratar de borrar la aplicación");
                    }
                }

            }
        }

        //
        // EVENTOS PARA MOVER PANEL PADRE CON EL SCROLL DEL MOUSE
        //
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

        private void RichTextBoxSolution_MouseWheel(object sender, MouseEventArgs e)
        {

            bool vScrollVisible = rtbTSSolution.GetPositionFromCharIndex(rtbTSSolution.TextLength - 1).Y > rtbTSSolution.Height;

            // Verificar si el RichTextBox tiene scrollbar visible


            if (vScrollVisible)
            {
                // Obtener la posición actual del scroll

                int maxScroll = rtbTSSolution.ClientSize.Height - rtbTSSolution.GetPositionFromCharIndex(rtbTSSolution.TextLength - 1).Y;


                //Se valida si se ha repetido dos veces la misma posición
                //Si se repite significa que está en el tope del scroll, por lo que deja mover el scroll padre
                if (maxScroll != scrollPositionTEMP)
                {
                    scrollPositionTEMP = maxScroll;
                }
                else
                {
                    flowContainerControls.AutoScrollPosition = new Point(
                    flowContainerControls.AutoScrollPosition.X,
                    -flowContainerControls.AutoScrollPosition.Y - e.Delta // Mueve en función de la rueda del mouse
                );
                }
            }
            else
            {
                // Si no hay scrollbar en el RichTextBox, scrollear el padre directamente
                flowContainerControls.AutoScrollPosition = new Point(
                    flowContainerControls.AutoScrollPosition.X,
                    -flowContainerControls.AutoScrollPosition.Y - e.Delta
                    );// Mueve en función de la rueda del mouse
            }
        }

        private void tbSearchApps_TextChanged(object sender, EventArgs e)
        {
            string filter = tbSearchApps.Text.ToLower();
            foreach (Button btn in flowAppsList.Controls)
            {
                if(filter == "")
                {
                    btn.Visible = true;
                }
                else if (btn.Text.ToLower().Contains(filter))
                {
                    btn.Visible = true;
                }
                else
                {
                    btn.Visible = false;
                }
                
            }

            
        }
    }


}
