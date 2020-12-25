using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceRest_045_RafidFahar;


namespace ServerConfig_045_RafidFahar
{
    public partial class Form1 : Form
    {
        ServiceHost hostObject;
        public Form1()
        {
            InitializeComponent();
            buttonOFF.Enabled = false;
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
            hostObject = null;

            try
            {
                Task.Factory.StartNew(() =>
                {
                    hostObject = new ServiceHost(typeof(TI_UMY));
                    hostObject.Open();
                });
                label2.Text = "Server ON";
                label3.Text = "Klik OFF untuk menonaktifkan server";
                buttonON.Enabled = false;
                buttonOFF.Enabled = true;
            }
            catch (Exception ex)
            {
                hostObject = null;
                label2.Text = "Server Error";
            }
        }

        private void buttonOFF_Click(object sender, EventArgs e)
        {
            try
            {
                hostObject.Abort();
                label2.Text = "Server OFF";
                label3.Text = "Klik ON untuk menghidupkan server";
                buttonOFF.Enabled = false;
                buttonON.Enabled = true;
            }
            catch (Exception ex)
            {
                buttonON.Enabled = false;
                buttonOFF.Enabled = true;
                label2.Text = "Server Error";
            }
        }
    }
}
