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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnMasa_Click(object sender, EventArgs e)
        {
            frmMasalar frm = new frmMasalar();
            this.Close();
            frm.Show();
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            frmRezervasyon frm2 = new frmRezervasyon();
            this.Close();
            frm2.Show();
        }

        private void btnPaketServis_Click(object sender, EventArgs e)
        {
            frmPaketSiparis frm3 = new frmPaketSiparis();
            this.Close();
            frm3.Show();
        }

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            frmMusteriler frm4 = new frmMusteriler();
            this.Close();
            frm4.Show();
        }

        private void btnKasa_Click(object sender, EventArgs e)
        {
            frmKasaIslemleri frm5 = new frmKasaIslemleri();
            this.Close();
            frm5.Show();
        }

        private void btnMutfak_Click(object sender, EventArgs e)
        {
            frmMutfak frm6 = new frmMutfak();
            this.Close();
            frm6.Show();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            frmRaporlar frm7 = new frmRaporlar();
            this.Close();
            frm7.Show();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            frmAyarlar frm8 = new frmAyarlar();
            this.Close();
            frm8.Show();
        }

        private void btnKilitle_Click(object sender, EventArgs e)
        {
            frmKilit frm9 = new frmKilit();
            this.Close();
            frm9.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { 
                Application.Exit();
            }
        }
    }
}
