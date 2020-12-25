using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ServerConfig_045_RafidFahar
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonOFF.Enabled = false;
            buttonON.Enabled = true;
        }

        private void buttonON_Click(object sender, EventArgs e)
        {
            buttonON.Enabled = false;
            buttonOFF.Enabled = true;
            label3.Text = "Klik OFF Untuk Mematikan Server";
            label2.Text = "Server ON";

            Program.Server server = new Program.Server();
            server.OnServer();
        }

        private void buttonOFF_Click(object sender, EventArgs e)
        {
            buttonON.Enabled = true;
            buttonOFF.Enabled = false;
            label3.Text = "Klik ON Untuk Menjalankan Server";
            label2.Text = "Server OFF";

            Program.Server server = new Program.Server();
            server.OffServer();
        }
    }
}
