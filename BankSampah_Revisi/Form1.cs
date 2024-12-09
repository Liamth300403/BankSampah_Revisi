using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSampah_Revisi
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FormListNasabah formListNasabah = new FormListNasabah();
			formListNasabah.Show();
			formListNasabah.BringToFront();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			FormListSampah formListSampah = new FormListSampah();
			formListSampah.Show();
			formListSampah.BringToFront();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			FormKasir formKasir = new FormKasir();
			formKasir.Show();
			formKasir.BringToFront();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
			FormTransfer formTransfer = new FormTransfer();
			formTransfer.Show();
			formTransfer.BringToFront();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void button5_Click(object sender, EventArgs e)
		{
			FormCatatanKeuanganNasabah formCatatanKeuanganNasabah = new FormCatatanKeuanganNasabah();
			formCatatanKeuanganNasabah.Show();
			formCatatanKeuanganNasabah.BringToFront();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			FormLaporan formLaporan=new FormLaporan();
			formLaporan.Show();
			formLaporan.BringToFront();
		}
	}
}
