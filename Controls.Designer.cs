using System.Drawing;
using System.Windows.Forms;

namespace MESInfoCenter
{
    partial class Form1

    {
        Label lblCreatedBy = new Label
        {

            ForeColor = Color.Black,
            Font = new Font("Arial", 7),
            Dock = DockStyle.Right,
            Margin = new Padding(0, 0, 0, 0),
            AutoSize = true
        };

        Label lblUpdatedBy = new Label
        {
            Text = "Última actualización por: ",
            ForeColor = Color.Black,
            Font = new Font("Arial", 7),
            Dock = DockStyle.Right,
            Margin = new Padding(0, 0, 0, 30),
            AutoSize = true

        };

        Panel panelPictureBoxBorder = new Panel
        {
            BackColor = Color.Black,
           
        };

        PictureBox pictureBox = new PictureBox
        {

            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
            Dock = DockStyle.Fill,
            //Margin = new Padding(0, 0, 0, 0)

        };

        Panel panelPictureBoxBorder2 = new Panel
        {
            BackColor = Color.Black,
            
        };

        PictureBox pictureBox2 = new PictureBox
        {

            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
            Dock = DockStyle.Fill,
            //Margin = new Padding(0, 0, 0, 0)

        };


        FlowLayoutPanel flowContentButtons = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.LeftToRight,
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 20, 0, 0),

        };


        Button btnOpenPathFolder = new Button
        {
            Text = "Abrir Ruta\n del Instalador",
            ForeColor = Color.White,
            BackColor = Color.DodgerBlue,
            Width = 150,
            Height = 60,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(170, 0, 0, 0),
            Font = new Font("Arial",10)
        };

        Button btnCopyRepoPath = new Button
        {
            Text = "Abrir Ruta\n del Repositorio",
            Visible = false,
            ForeColor = Color.White,
            BackColor = Color.DodgerBlue,
            Width = 150,
            Height = 60,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(160, 0, 0, 0),
            Font = new Font("Arial", 10)
        };

        Button btnOpenGuideFolder = new Button
        {
            Text = "Abrir Guía",
            ForeColor = Color.White,
            BackColor = Color.DodgerBlue,
            Width = 150,
            Height = 60,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(160, 0, 0, 0),
            Font = new Font("Arial", 10)
        };


        FlowLayoutPanel flowContentInfo = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            BorderStyle = BorderStyle.Fixed3D,
            WrapContents = false,
            Height = 140,
            Dock = DockStyle.Fill,
            Margin = new Padding(150, 0, 0, 0),
        };


        Label lblAuthorName = new Label
        {
            AutoSize = true,
            ForeColor = Color.Black,
            Font = new Font("Arial", 11),
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, 0, 0)

        };
        Label lblLastVersion = new Label
        {
            AutoSize = true,
            ForeColor = Color.Black,
            Font = new Font("Arial", 11),
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, 0, 30)

        };

        Label lblAppPath = new Label
        {
            AutoSize = true,
            ForeColor = Color.Black,
            Font = new Font("Arial", 11),
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, 0, 0)

        };

        Label lblRepoPath = new Label
        {
            AutoSize = true,
            Visible = false,
            ForeColor = Color.Black,
            Font = new Font("Arial", 11),
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, 0, 0)
,
        };

        RichTextBox rtbDescription = new RichTextBox
        {
            BackColor = ColorTranslator.FromHtml("#F2F2F2"),
            ForeColor = Color.Black,
            ScrollBars = RichTextBoxScrollBars.None,
            Margin = new Padding(150, 50, 0, 0),
            Width = 1000,
            BorderStyle = BorderStyle.None,
            Multiline = true,
            Cursor = Cursors.Default,
            Font = new Font("Arial", 14),

        };

        Panel panelTroubleShooting = new Panel
        {
            BackColor = Color.BlanchedAlmond,
            Margin = new Padding(100, 0, 50, 100),
            Padding = new Padding(10, 10, 0, 0),
            Dock = DockStyle.Fill,
            Height = 700,
        };

        FlowLayoutPanel flowTroubleShooting = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.LeftToRight,
            Dock = DockStyle.Fill,
          
        };

        FlowLayoutPanel flowTroubleShootingButtons = new FlowLayoutPanel
        {
            AutoScroll = true,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            BackColor = Color.Cornsilk,
            Height = 550,
            Width = 450,
        };
            
        RichTextBox rtbTSSolution = new RichTextBox
        {
            Multiline = true,
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            Padding = new Padding(10, 0, 10, 0),
            Font = new Font("Arial", 12),
            Width = 500,
        };

        Button btnAddSolution = new Button
        {
            Text = "Agregar nueva solución a problema",
            Visible = false,
            ForeColor = Color.White,
            BackColor = Color.DodgerBlue,
            Width = 300,
            Height = 54,
            Dock = DockStyle.Bottom,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(0, 30, 0, 0),
            Font = new Font("Arial", 13)
        };

        FlowLayoutPanel flowBottomButtonsContainer = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.LeftToRight,
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 10, 0, 0),

        };

        Button btnDeleteApp = new Button
        {
            Text = "Eliminar aplicación",
            Visible = false,
            ForeColor = Color.White,
            BackColor = Color.Crimson,
            Width = 300,
            Height = 54,
            //Dock = DockStyle.Bottom,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(150, 0, 0, 0),
            Font = new Font("Arial", 13)
        };

        Button btnUpdateApp = new Button
        {
            Text = "Modificar",
            Visible = false,
            ForeColor = Color.White,
            BackColor = Color.Green,
            Width = 300,
            Height = 54,
            //Dock = DockStyle.Bottom,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(150, 0, 0, 0),
            Font = new Font("Arial", 13)
        };
        Button btnDeleteTS = new Button
        {
            Text = "Eliminar problema seleccionado",
            Visible = false,
            Enabled = false,
            ForeColor = Color.White,
            BackColor = Color.Crimson,
            Width = 300,
            Height = 54,
            Dock = DockStyle.Bottom,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(0, 0, 0, 0),
            Font = new Font("Arial", 13)
        };
    }
}
