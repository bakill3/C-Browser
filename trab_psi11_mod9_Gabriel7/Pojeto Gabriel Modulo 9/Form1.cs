using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        public Form1()
        {
            this.WindowState = FormWindowState.Normal;
            s.SelectVoiceByHints(VoiceGender.Female);

            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;

            Label ola = new Label();
            ola.Size = new Size(50, 23);
            ola.Location = new Point(104, 20);
            ola.Text = "Bem-Vindo";
            this.Controls.Add(ola);
            ola.BackColor = Color.LightBlue;
            ola.ForeColor = Color.White;
            ola.FlatStyle = FlatStyle.Flat;
            ola.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

            Button b = new Button();
            b.Size = new Size(100, 0);
            b.Location = new Point(77, 89);
            b.Click += new EventHandler(abrirform2);
            b.Text = "Entrar";
            b.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            this.Controls.Add(b);

            Button sair = new Button();
            sair.Size = new Size(47, 37);
            sair.Location = new Point(240, -1);
            sair.MouseHover += new EventHandler(this.meuMetodo3);
            sair.Text = "X";
            this.Controls.Add(sair);
            sair.BackColor = Color.Red;
            sair.ForeColor = Color.White;
            sair.FlatStyle = FlatStyle.Flat;
            sair.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            s.Speak("Welcome");
        }

        private void abrirform2(object sender, EventArgs e)
        {

            s.Speak("Loading......Loading.......");
            Form2 Variavel = new Form2();
            Variavel.Show();
            this.Hide();
        }
        private void meuMetodo3(object sender, EventArgs e)
        {
            s.Speak("GoodBye");
            Application.Exit();
        }
    }
}