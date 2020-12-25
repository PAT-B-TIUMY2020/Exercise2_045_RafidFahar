using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientRest_045_RafidFahar
{
    public partial class Form1 : Form
    {
        ClassData data = new ClassData();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtmhs.DataSource = data.getAllData();
            TampilData();

            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
        }

        public void TampilData()
        {
            var List = data.getAllData();
            dtmhs.DataSource = List;
        }

        private void buttoncreate_Click(object sender, EventArgs e)
        {
 

        }

        private void Clear()
        {
            textBoxNim.Clear();
            textBoxNama.Clear();
            textBoxProdi.Clear();
            textBoxAngkatan.Clear();

            textBoxNim.Enabled = true;

            buttoncreate.Enabled = true;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void buttoncreate_Click_1(object sender, EventArgs e)
        {
            string nim = textBoxNim.Text;
            string nama = textBoxNama.Text;
            string prodi = textBoxProdi.Text;
            string angkatan = textBoxAngkatan.Text;
            data.insertMahasiswa(nama, nim, prodi, angkatan);
            Clear();
            dtmhs.DataSource = data.getAllData();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxNim.Text != "")
            {
                string nim = textBoxNim.Text;
                List<Mahasiswa> mhs = new List<Mahasiswa>();
                mhs.Add(data.search(nim));
                Clear();
                dtmhs.DataSource = mhs;
            }
            else
            {
                dtmhs.DataSource = data.getAllData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Mahasiswa mhs = new Mahasiswa();
            mhs.nim = textBoxNim.Text;
            mhs.nama = textBoxNama.Text;
            mhs.prodi = textBoxProdi.Text;
            mhs.angkatan = textBoxAngkatan.Text;

            ClassData classData = new ClassData();
            classData.updateDatabase(mhs);
            Clear();
            dtmhs.DataSource = classData.getAllData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ClassData classData = new ClassData();
            classData.deleteMahasiswa(textBoxNim.Text);
            Clear();
            dtmhs.DataSource = classData.getAllData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var jmlh = data.Jumlahdata();
            label6.Text = jmlh;
        }

        private void dtmhs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtmhs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNim.Text = Convert.ToString(dtmhs.Rows[e.RowIndex].Cells[1].Value);
            textBoxNama.Text = Convert.ToString(dtmhs.Rows[e.RowIndex].Cells[0].Value);
            textBoxProdi.Text = Convert.ToString(dtmhs.Rows[e.RowIndex].Cells[2].Value);
            textBoxAngkatan.Text = Convert.ToString(dtmhs.Rows[e.RowIndex].Cells[3].Value);

            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;
            buttoncreate.Enabled = false;
        }
    }
}
