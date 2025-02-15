using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MESInfoCenter
{
    partial class Form1

    {
        PictureBox pictureBox = new PictureBox
        {

            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,

        };


        FlowLayoutPanel flowContentButtons = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.LeftToRight,
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 50, 0, 0),

        };


        Button btnCopyAppPath = new Button
        {
            Text = "Copiar Ruta",
            ForeColor = Color.White,
            BackColor = Color.DodgerBlue,
            Width = 200,
            Height = 54,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(250, 0, 0, 0),
        };

        Button btnCopyRepoPath = new Button
        {
            Text = "Copiar Repositorio",
            ForeColor = Color.White,
            BackColor = Color.DodgerBlue,
            Width = 200,
            Height = 54,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(140, 0, 0, 0),
        };

        Button btnDownloadGuide = new Button
        {
            Text = "Descargar Guía",
            ForeColor = Color.White,
            BackColor = Color.DodgerBlue,
            Width = 200,
            Height = 54,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(140, 0, 0, 0),
        };


        FlowLayoutPanel flowContentPath1 = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.LeftToRight,
            Dock = DockStyle.Fill,
            Margin = new Padding(200, 0, 0, 0),
        };

        FlowLayoutPanel flowContentPath2 = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.LeftToRight,
            Dock = DockStyle.Fill,
            Margin = new Padding(200, 0, 0, 0),
        };

        Label lblAppPath = new Label
        {
            Text = "Ruta: ",
            AutoSize = true,
            ForeColor = Color.Black,
            Font = new Font("Arial", 11),
            Dock = DockStyle.Fill,
            Margin = new Padding(200, 0, 0, 0)

        };

        Label lblRepoPath = new Label
        {
            Text = "Repositorio: ",
            AutoSize = true,
            ForeColor = Color.Black,
            Font = new Font("Arial", 11),
            Dock = DockStyle.Fill,
            Margin = new Padding(200, 0, 0, 50)
,
        };

        RichTextBox rtbDescription = new RichTextBox
        {
            BackColor = ColorTranslator.FromHtml("#F2F2F2"),
            ForeColor = Color.Black,
            ScrollBars = RichTextBoxScrollBars.None,
            Margin = new Padding(200, 0, 0, 0),
            Width = 1000,
            BorderStyle = BorderStyle.None,
            Multiline = true,
            Cursor = Cursors.Default,
            Font = new Font("Arial", 14),

        };

        Panel panelTroubleShooting = new Panel
        {
            BackColor = Color.BlanchedAlmond,
            Margin = new Padding(200, 0, 0, 100),
            Padding = new Padding(10, 10, 0, 0),
            Dock = DockStyle.Fill,
            Height = 670,
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
            Width = 340,
        };
            
        RichTextBox rtbTSSolution = new RichTextBox
        {
            Multiline = true,
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            Font = new Font("Arial", 13),
            Width = 600,
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
            Margin = new Padding(0, 70, 0, 0),
            Font = new Font("Arial", 13)
        };
    }
}
