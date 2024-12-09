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
	public partial class FormTambahUbahSampah : Form
	{
		public bool EditMode { get; set; }
		public Sampah NewEditSampah { get; set; }
		public static ApplicationDbContext db = new ApplicationDbContext();

		public FormTambahUbahSampah()
		{
			InitializeComponent();
			SampahComboBox();
		}

		private void SampahComboBox()
		{
			comboBox1.Items.Add("Plastik");
			comboBox1.Items.Add("Kertas");
			comboBox1.Items.Add("Besi dan Aluminium");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			// Validate input
			int iD = 0;
			if (int.TryParse(textBox1.Text, out iD) == false)
			{
				MessageBox.Show("ID Harus Angka", "Ada Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBox1.Focus();
				return;
			}
			if (comboBox1.SelectedIndex == -1)
			{
				MessageBox.Show("Jenis Sampah Harus Dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				comboBox1.Focus();
				return;
			}
			if (string.IsNullOrEmpty(textBox3.Text) || textBox3.Text.Trim().Length == 0)
			{
				MessageBox.Show("Kategori harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBox3.Focus();
				return;
			}
			if (string.IsNullOrEmpty(textBox4.Text) || textBox4.Text.Trim().Length == 0)
			{
				MessageBox.Show("Keterangan harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBox4.Focus();
				return;
			}
			if (!decimal.TryParse(textBox5.Text, out decimal harga))
			{
				MessageBox.Show("Harga harus berupa angka.", "Ada Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBox5.Focus();
				return;
			}

			if (EditMode == false)
			{
				NewEditSampah = new Sampah
				{
					ID = iD
				};
				db.TblSampah.Add(NewEditSampah);
			}

			NewEditSampah.Jenis = comboBox1.SelectedItem.ToString();
			NewEditSampah.KategoriSampah = textBox3.Text;
			NewEditSampah.Keterangan = textBox4.Text;
			NewEditSampah.HargaPerKg = harga;

			db.SaveChanges();
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FormTambahUbahSampah_Shown(object sender, EventArgs e)
		{
			if (EditMode == false)
			{
				labelJudul.Text = "Tambah Jenis Sampah";
				textBox1.Enabled = true;
				ClearFormFields();
			}
			else
			{
				labelJudul.Text = "Ubah Data Sampah";
				textBox1.Enabled = false;

				// Set form fields with NewEditSampah properties
				textBox1.Text = NewEditSampah.ID.ToString();
				comboBox1.SelectedItem = NewEditSampah.Jenis;
				textBox3.Text = NewEditSampah.KategoriSampah;
				textBox4.Text = NewEditSampah.Keterangan;
				textBox5.Text = NewEditSampah.HargaPerKg.ToString();
			EnableFormControls();
			}

			// Ensure all controls are enabled
		}

		private void ClearFormFields()
		{
			textBox1.Clear();
			comboBox1.SelectedIndex = -1;
			textBox3.Clear();
			textBox4.Clear();
			textBox5.Clear();
		}

		private void EnableFormControls()
		{
			textBox1.Enabled = false;
		}
	}
}
