using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.HomePage = HomepageTextbox.Text;
            Properties.Settings.Default.Save();

            MessageBox.Show("Settings guardados. A sua homepage será definida quando reiniciar o Gabriel Browser.");
            this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            HomepageTextbox.Text = Properties.Settings.Default.HomePage;
        }

        private void SettingsForm_Load_1(object sender, EventArgs e)
        {
            HomepageTextbox.Text = Properties.Settings.Default.HomePage;
        }

        private void HomepageTextbox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}