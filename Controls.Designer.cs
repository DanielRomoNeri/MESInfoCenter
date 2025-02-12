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

        };


        Button btnCopyAppPath = new Button
        {
            Text = "Copiar Ruta",
            ForeColor = Color.White,
            BackColor = Color.Indigo,
            Width = 200,
            Height = 54,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(250, 0, 0, 0),
        };

        Button btnCopyAppRepoPath = new Button
        {
            Text = "Copiar Repositorio",
            ForeColor = Color.White,
            BackColor = Color.Indigo,
            Width = 200,
            Height = 54,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(140, 0, 0, 0),
        };

        Button btnDownloadGuide = new Button
        {
            Text = "Descargar Guía",
            ForeColor = Color.White,
            BackColor = Color.Indigo,
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

        TextBox tbAppPath = new TextBox
        {

            Multiline = true,
            BackColor = Color.LightSlateGray,
            ForeColor = Color.Black,
            Margin = new Padding(0, 0, 0, 0),
            Width = 800,
            Height = 40,
            Font = new Font("Arial", 11),
            Cursor = Cursors.Default
        };

        TextBox tbRepoPath = new TextBox
        {

            Multiline = true,
            BackColor = Color.LightSlateGray,
            ForeColor = Color.Black,
            Margin = new Padding(0, 0, 0, 0),
            Width = 800,
            Height = 40,
            Font = new Font("Arial", 11),
            Cursor = Cursors.Default

        };

        Label lblAppPath = new Label
        {
            Text = "Ruta: ",
            ForeColor = Color.White,
            Font = new Font("Arial", 12),
            Dock = DockStyle.Right,
        };

        Label lblappRepoPath = new Label
        {
            Text = "Repositorio: ",
            ForeColor = Color.White,
            Font = new Font("Arial", 12),
            Dock = DockStyle.Right,
        };

        RichTextBox rtb = new RichTextBox
        {
            BackColor = Color.LightSlateGray,
            ForeColor = Color.White,
            ScrollBars = RichTextBoxScrollBars.None,
            Margin = new Padding(200, 0, 0, 0),
            Width = 1000,
            BorderStyle = BorderStyle.None,
            Multiline = true,
            Cursor = Cursors.Default,
            Font = new Font("Arial", 17),

        };

        Panel panelTroubleShooting = new Panel
        {
            BackColor = Color.Gray,
            Margin = new Padding(200, 0, 0, 200),
            Dock = DockStyle.Fill,
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
        };

        TextBox tbTSSolution = new TextBox
        {
            Multiline = true,
            Dock = DockStyle.Fill,
        };
    }
}
