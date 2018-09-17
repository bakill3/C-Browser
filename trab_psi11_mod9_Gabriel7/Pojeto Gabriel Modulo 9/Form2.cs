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
    public partial class Form2 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        public Form2()
        {
            s.SelectVoiceByHints(VoiceGender.Female);

            InitializeComponent();
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            NavigateToAddress(homePage);
            s.Speak("Hi, my name is Gabriel Chrome");
            textBox1.Text = homePage;
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            this.ControlBox = true;
            this.AcceptButton = button1;
            button5.BackColor = Color.LightGreen;
            button5.ForeColor = Color.Green;
            button5.FlatStyle = FlatStyle.Flat;
            button8.BackColor = Color.LightBlue;
            button8.ForeColor = Color.Blue;
            button8.FlatStyle = FlatStyle.Flat;
            button6.BackColor = Color.Red;
            button6.ForeColor = Color.LightSteelBlue;
            button6.FlatStyle = FlatStyle.Flat;
        }

        private string homePage = Properties.Settings.Default.HomePage;

        private void button1_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (textBox1.Text == "andreruivinho.com")
            {
                s.Speak("GAY.........GAY............GAY");
            }
            if (textBox1.Text == "redtube.com")
            {
                s.Speak("FUCKING NOOB");
            }
            s.Speak("Going to URL");
            if (web != null)
                NavigateToAddress(textBox1.Text);
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if (web.CanGoBack)
                    s.Speak("Go back");
                web.GoBack();
            }
            else
            {
                s.Speak("You can't go back");
                MessageBox.Show("Está o máximo para trás!!!");
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        WebBrowser webTab = null;
        private void button3_Click_1(object sender, EventArgs e)
        {
            s.Speak("New tab");
            TabPage tabpage = new TabPage();
            tabpage.Text = "New Tab";
            textBox1.Text = homePage;
            tabControl.Controls.Add(tabpage);
            tabControl.SelectTab(tabControl.TabCount - 1);
            webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
            webTab.Parent = tabpage;
            webTab.Dock = DockStyle.Fill;
            webTab.Navigate(homePage);
            webTab.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webTab_DocumentCompleted);
            textBox1.Text = homePage;
        }

        void webTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl.SelectedTab.Text = webTab.DocumentTitle;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            s.Speak("Goodbye!");
            Application.Exit();
        }

        private void NavigateToAddress(string textBox1)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;

            if (String.IsNullOrEmpty(textBox1)) return;
            if (textBox1.Equals("about:blank")) return;
            if (!textBox1.StartsWith("http://") &&
                !textBox1.StartsWith("https://"))
            {
                textBox1 = "http://" + textBox1;
            }
            try
            {
                web.Navigate(new Uri(textBox1));
            }
            catch (System.UriFormatException)
            {
                return;
            }
            web.Navigate(textBox1);
        }

        private void button5_Click1(object sender, EventArgs e)
        {

            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
                NavigateToAddress(textBox1.Text);
        }


        private void button8_Click(object sender, EventArgs e)
        {
            s.Speak("Going to Twitter.com");
            NavigateToAddress("www.twitter.com");
            textBox1.Text = "http://www.twitter.com/";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            s.Speak("Going to ~yahoo.com");
            NavigateToAddress("www.Yahoo.com");
            textBox1.Text = "http://www.Yahoo.com/";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            s.Speak("Going to youtube.com");
            NavigateToAddress("www.youtube.com");
            textBox1.Text = "http://www.youtube.com/";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            s.Speak("Going to facebook.com");
            NavigateToAddress("www.facebook.com");
            textBox1.Text = "http://www.facebook.com/";
        }


        private void button11_Click(object sender, EventArgs e)
        {
            s.Speak("Minimizing");
            this.WindowState = FormWindowState.Minimized;
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if (web.CanGoForward)
                    s.Speak("Go forward");
                web.GoForward();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl.SelectedTab.Text = webBrowser1.DocumentTitle;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Speak("Goodbye");
            Application.Exit();
        }

        private void sobreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este trabalho foi feito para a disciplina de PSI", "Sobre o Gabriel Browser",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
                if (web != null)
                {
                    web.Navigate(textBox1.Text);
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            s.Speak("Going to your homepage");
            NavigateToAddress(homePage);
        }


        private void web_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            textBox1.Text = web.Url.ToString();
            tabControl.SelectedTab.Text = webBrowser1.DocumentTitle;
        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            textBox1.Text = web.Url.ToString();
            tabControl.SelectedTab.Text = webBrowser1.DocumentTitle;
        }

        private void webBrowser1_Navigated_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            textBox1.Text = web.Url.ToString();

        }

        private void vídeoDeApresentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Video ok = new Video();
            ok.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            web.Refresh();
        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Speak("Camera");
            Form3 camera = new Form3();
            camera.ShowDialog();
        }

        private void saveAndOpenFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Speak("Save and open files");
            Form4 files = new Form4();
            files.ShowDialog();
        }
    }
}


