using BankSampah_Revisi.Entitas;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BankSampah_Revisi
{
	public partial class FormTransfer : Form
	{
		public FormTransfer()
		{
			InitializeComponent();
			LoadNasabahNames();
			comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
		}

		private void LoadNasabahNames()
		{
			using (var db = new ApplicationDbContext())
			{
				var nasabahNames = db.TblNasabah.Select(n => n.Nama).ToList();
				comboBox1.DataSource = nasabahNames;

				// Set up ComboBox for auto-complete
				comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
				comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedItem != null)
			{
				string selectedNama = comboBox1.SelectedItem.ToString();
				using (var db = new ApplicationDbContext())
				{
					var nasabah = db.TblNasabah.FirstOrDefault(n => n.Nama.Equals(selectedNama, StringComparison.OrdinalIgnoreCase));
					if (nasabah != null)
					{
						labelNomerRekening.Text = nasabah.NoRekening;
						labelSaldo.Text = nasabah.Saldo.ToString("C");
					}
					else
					{
						MessageBox.Show($"Nasabah dengan nama {selectedNama} tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
		}

		private void buttonConfirm_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedItem != null && decimal.TryParse(textBoxPenarikan.Text, out decimal jumlahPenarikan) && jumlahPenarikan > 0)
			{
				string selectedNama = comboBox1.SelectedItem.ToString();
				using (var db = new ApplicationDbContext())
				{
					var nasabah = db.TblNasabah.FirstOrDefault(n => n.Nama.Equals(selectedNama, StringComparison.OrdinalIgnoreCase));
					if (nasabah != null)
					{
						if (nasabah.Saldo >= jumlahPenarikan)
						{
							// Buat entitas penarikan baru
							var penarikan = new Penarikan
							{
								NasabahID = nasabah.ID,
								NamaNasabah = nasabah.Nama,
								NoRekening = nasabah.NoRekening,
								JumlahPenarikan = jumlahPenarikan,
								TanggalPenarikan = dateTimePicker1.Value
							};

							// Kurangi saldo nasabah
							nasabah.Saldo -= jumlahPenarikan;

							// Tambahkan penarikan ke database
							db.TblPenarikan.Add(penarikan);
							db.SaveChanges();

							MessageBox.Show("Penarikan berhasil dilakukan dan saldo nasabah diperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

							// Reset input fields
							comboBox1.SelectedIndex = -1;
							textBoxPenarikan.Clear();
							labelNomerRekening.Text = "NoREK";
							labelSaldo.Text = "Saldo Yang Ada:";
						}
						else
						{
							MessageBox.Show("Saldo nasabah tidak mencukupi untuk melakukan penarikan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Harap pilih Nasabah dan masukkan jumlah penarikan yang valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
