using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankSampah_Revisi.Entitas;

namespace BankSampah_Revisi
{
	public partial class FormTambahUbahNasabah : Form
	{
		public bool EditMode { get; set; }
		public Nasabah NewEditNasabah { get; set; }
		public static ApplicationDbContext db = new ApplicationDbContext();

		public FormTambahUbahNasabah()
		{
			InitializeComponent();
			PopulateGenderComboBox();
		}

		private void PopulateGenderComboBox()
		{
			comboBoxJeniskelamin.Items.Add("Laki-laki");
			comboBoxJeniskelamin.Items.Add("Perempuan");
		}

		private void button1_Click(object sender, EventArgs e)
		{ 
			int iD = 0;
			if (int.TryParse(textBoxid.Text, out iD) == false)
			{
				MessageBox.Show("Id harus angka.", "Ada Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBoxid.Focus();
				return;
			}
			if (string.IsNullOrEmpty(textBoxrek.Text) || textBoxrek.Text.Trim().Length == 0)
			{
				MessageBox.Show("Nomer Rekening Nasabah harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBoxrek.Focus();
				return;
			}
			if (string.IsNullOrEmpty(textBoxnama.Text) || textBoxnama.Text.Trim().Length == 0)
			{
				MessageBox.Show("Nama Nasabah harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBoxnama.Focus();
				return;
			}
			if (string.IsNullOrEmpty(textBoxalamat.Text) || textBoxalamat.Text.Trim().Length == 0)
			{
				MessageBox.Show("Alamat Nasabah harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBoxalamat.Focus();
				return;
			}

			if (comboBoxJeniskelamin.SelectedIndex == -1)
			{
				MessageBox.Show("Jenis Kelamin harus dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				comboBoxJeniskelamin.Focus();
				return;
			}

			if (string.IsNullOrWhiteSpace(textBoxnum.Text))
			{
				MessageBox.Show("Nomor Telepon harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBoxnum.Focus();
				return;
			}

			if (!decimal.TryParse(textBoxSaldo.Text, out decimal saldo))
			{
				MessageBox.Show("Saldo harus berupa angka.", "Ada Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBoxSaldo.Focus();
				return;
			}

			if (EditMode == false)
			{
				NewEditNasabah.ID = iD;
				db.TblNasabah.Add(NewEditNasabah);
			}

			NewEditNasabah.NoRekening = textBoxrek.Text;
			NewEditNasabah.Nama = textBoxnama.Text;
			NewEditNasabah.Alamat = textBoxalamat.Text;
			NewEditNasabah.JenisKelamin = comboBoxJeniskelamin.SelectedItem.ToString();
			NewEditNasabah.Telepon = textBoxnum.Text;
			NewEditNasabah.TanggalBergabung= dateTimePicker1.Value;
			NewEditNasabah.Saldo = saldo;

			db.SaveChanges();
			this.Close();
		}

		private void FormTambahUbahNasabah_Shown(object sender, EventArgs e)
		{
			if (EditMode == false)
			{
				labelJudul.Text = "Tambah Nasabah";
				textBoxid.Enabled = true;
				ClearFormFields(); // Clear the form fields for adding a new Nasabah
			}
			else
			{
				labelJudul.Text = "Ubah Data Nasabah";
				textBoxid.Enabled = false;

				// Set form fields with NewEditNasabah properties
				textBoxid.Text = NewEditNasabah.ID.ToString();
				textBoxrek.Text = NewEditNasabah.NoRekening;
				textBoxnama.Text = NewEditNasabah.Nama;
				textBoxalamat.Text = NewEditNasabah.Alamat;
				comboBoxJeniskelamin.SelectedItem = NewEditNasabah.JenisKelamin;
				textBoxnum.Text = NewEditNasabah.Telepon;
				dateTimePicker1.Value = NewEditNasabah.TanggalBergabung;
				textBoxSaldo.Text = NewEditNasabah.Saldo.ToString();
			}
		}

		private void ClearFormFields()
		{
			textBoxid.Clear();
			textBoxrek.Clear();
			textBoxnama.Clear();
			textBoxalamat.Clear();
			comboBoxJeniskelamin.SelectedIndex = -1;
			textBoxnum.Clear();
			dateTimePicker1.Value = DateTime.Today;
			textBoxSaldo.Clear();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
