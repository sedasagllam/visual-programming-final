using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projem
{
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }
        cSiparis cs = new cSiparis();
        private void frmBill_Load(object sender, EventArgs e)
        {
            if (cGenel._ServisTurNo ==1)
            {
                label2.Text = cGenel._AdisyonId;
                textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
                cs.getByOrder(listView1, Convert.ToInt32(label2.Text));
                if (listView1.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < listView1.Items.Count; i++)
                    { 
                        toplam+=Convert.ToDecimal(listView1.Items[i].SubItems[3]);
                    }
                    label9.Text = String.Format("0:0.000",toplam);
                    label10.Text = String.Format("0:0.000", toplam);
                }
                groupBox2.Visible = true;
                textBox1.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(label7.Text) < Convert.ToDecimal(label9))
                {
                    try
                    {
                        label7.Text = String.Format("0:0.000", Convert.ToDecimal(textBox1.Text));
                    }
                    catch (Exception)
                    {
                        label7.Text = String.Format("0:0.000", 0);
                    }
                }
                else
                {
                    MessageBox.Show("İndirim tutarı toplam tutardan fazla olamaz !!!");
                }
            }
            catch (Exception)
            {
                label7.Text = String.Format("0:0.000", 0);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox2.Visible = true;
            }
            else
            {
                groupBox2.Visible = false;
            }
        }
    }
}
