using BankSampah_Revisi.Entitas;
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
	public partial class FormKasir : Form
	{
		private decimal hargaPerKg;

		public FormKasir()
		{
			InitializeComponent();
			InitializeDataGridView();
			LoadNasabahNames();
			LoadSampahCategories();
			numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
		}

		private void InitializeDataGridView()
		{
			// Add columns to DataGridView
			dataGridView1.Columns.Add("NamaNasabah", "Nama Nasabah");
			dataGridView1.Columns.Add("KategoriSampah", "Kategori Sampah");
			dataGridView1.Columns.Add("Berat", "Berat (kg)");
			dataGridView1.Columns.Add("TanggalTransaksi", "Tanggal Transaksi");
			dataGridView1.Columns.Add("HargaPerKg", "Harga per Kg");
			dataGridView1.Columns.Add("TotalHarga", "Total Harga");

			// Adjust column settings if needed
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		}

		private void LoadSampahCategories()
		{
			using (var db = new ApplicationDbContext())
			{
				var sampahCategories = db.TblSampah.Select(s => s.KategoriSampah).Distinct().ToList();
				comboBoxSampah.DataSource = sampahCategories;

				// Set up ComboBox for auto-complete
				comboBoxSampah.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				comboBoxSampah.AutoCompleteSource = AutoCompleteSource.ListItems;
				comboBoxSampah.DropDownStyle = ComboBoxStyle.DropDown;
			}
		}

		private void LoadNasabahNames()
		{
			using (var db = new ApplicationDbContext())
			{
				var nasabahNames = db.TblNasabah.Select(n => n.Nama).ToList();
				comboBoxNasabah.DataSource = nasabahNames;

				// Set up ComboBox for auto-complete
				comboBoxNasabah.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				comboBoxNasabah.AutoCompleteSource = AutoCompleteSource.ListItems;
				comboBoxNasabah.DropDownStyle = ComboBoxStyle.DropDown;
			}
		}

		private void comboBoxNasabah_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxNasabah.SelectedItem != null)
			{
				string selectedNama = comboBoxNasabah.SelectedItem.ToString();
				using (var db = new ApplicationDbContext())
				{
					var nasabah = db.TblNasabah.FirstOrDefault(n => n.Nama.Equals(selectedNama, StringComparison.OrdinalIgnoreCase));
					if (nasabah == null)
					{
						MessageBox.Show($"Nasabah dengan nama {selectedNama} tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
		}

		private void comboBoxSampah_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxSampah.SelectedItem != null)
			{
				string selectedKategori = comboBoxSampah.SelectedItem.ToString();
				using (var db = new ApplicationDbContext())
				{
					var sampah = db.TblSampah.FirstOrDefault(s => s.KategoriSampah.Equals(selectedKategori, StringComparison.OrdinalIgnoreCase));
					if (sampah != null)
					{
						hargaPerKg = sampah.HargaPerKg; // Simpan harga per Kg ke variabel global
						labelHarga.Text = hargaPerKg.ToString("C");
						UpdateTotalHarga(); // Update total harga ketika kategori sampah berubah
					}
					else
					{
						hargaPerKg = 0; // Set harga per Kg ke 0 jika tidak ditemukan
						labelHarga.Text = "Harga tidak ditemukan";
						labelTotal.Text = "Total: 0";
						textBoxTotal.Text = "Total: 0";
					}
				}
			}
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			UpdateTotalHarga();
		}

		private void UpdateTotalHarga()
		{
			decimal jumlah = numericUpDown1.Value;
			decimal totalHarga = hargaPerKg * jumlah;
			textBoxTotal.Text = totalHarga.ToString("C");
		}

		private void buttonTambahKeDataGrid_Click(object sender, EventArgs e)
		{
			if (comboBoxNasabah.SelectedItem != null && comboBoxSampah.SelectedItem != null && numericUpDown1.Value > 0)
			{
				string namaNasabah = comboBoxNasabah.SelectedItem.ToString();
				string kategoriSampah = comboBoxSampah.SelectedItem.ToString();
				decimal berat = numericUpDown1.Value;
				DateTime tanggal = dateTimePicker1.Value;
				decimal totalHarga = hargaPerKg * berat;

				// Menambahkan baris ke DataGridView
				dataGridView1.Rows.Add(
					namaNasabah,
					kategoriSampah,
					berat.ToString(),
					tanggal.ToString("yyyy-MM-dd"),
					hargaPerKg.ToString("C"),
					totalHarga.ToString("C")
				);

				// Reset input fields setelah menambahkan
				comboBoxNasabah.SelectedIndex = -1;
				comboBoxSampah.SelectedIndex = -1;
				numericUpDown1.Value = 0;
				labelHarga.Text = "Harga";
				labelTotal.Text = "Total: ";
				textBoxTotal.Text = "Total";

			}
			else
			{
				MessageBox.Show("Harap pilih Nasabah dan Kategori Sampah terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void buttonSimpanKeDatabase_Click(object sender, EventArgs e)
		{
			using (var db = new ApplicationDbContext())
			{
				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					if (row.Cells[0].Value != null && row.Cells[1].Value != null)
					{
						string namaNasabah = row.Cells[0].Value.ToString();
						string kategoriSampah = row.Cells[1].Value.ToString();
						decimal berat = decimal.Parse(row.Cells[2].Value.ToString());
						DateTime tanggalTransaksi = DateTime.Parse(row.Cells[3].Value.ToString());
						decimal totalHarga = decimal.Parse(row.Cells[5].Value.ToString(), System.Globalization.NumberStyles.Currency);

						var nasabah = db.TblNasabah.FirstOrDefault(n => n.Nama == namaNasabah);
						var sampah = db.TblSampah.FirstOrDefault(s => s.KategoriSampah == kategoriSampah);

						if (nasabah != null && sampah != null)
						{
							var transaksi = new Transaksi
							{
								NasabahID = nasabah.ID,
								Nama = namaNasabah,
								SampahID = sampah.ID,
								KategoriSampah = kategoriSampah,
								Berat = berat,
								TanggalTransaksi = tanggalTransaksi,
								TotalHarga = totalHarga
							};

							db.TblTransaksi.Add(transaksi);

							// Update saldo nasabah
							nasabah.Saldo += totalHarga;
						}
					}
				}
				db.SaveChanges();
				MessageBox.Show("Data berhasil disimpan ke database dan saldo nasabah diperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
				dataGridView1.Rows.Clear();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
