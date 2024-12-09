using BankSampah_Revisi.Entitas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSampah_Revisi
{
	public partial class FormListSampah : Form
	{
		FormTambahUbahSampah formTambahUbahSampah;
		public static ApplicationDbContext db = new ApplicationDbContext();
		public static List<Sampah> ListSampah = new List<Sampah>();

		public FormListSampah()
		{
			InitializeComponent();
			LoadData();
		}

		private void LoadData()
		{
			ListSampah = db.TblSampah.ToList();
			dataGridView1.DataSource = null; // Clear current binding
			dataGridView1.DataSource = ListSampah; // Bind updated list
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			if (formTambahUbahSampah == null || formTambahUbahSampah.IsDisposed)
			{
				formTambahUbahSampah = new FormTambahUbahSampah();
			}
			formTambahUbahSampah.NewEditSampah = new Sampah();
			formTambahUbahSampah.Show();
			formTambahUbahSampah.BringToFront();
			formTambahUbahSampah.FormClosed += (s, args) => LoadData();
		}

		private void buttonEdit_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				if (formTambahUbahSampah == null || formTambahUbahSampah.IsDisposed)
				{
					formTambahUbahSampah = new FormTambahUbahSampah();
				}
				int selectedId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
				var sampahToEdit = db.TblSampah.FirstOrDefault(n => n.ID == selectedId);
				if (sampahToEdit != null)
				{
					formTambahUbahSampah.EditMode = true;
					formTambahUbahSampah.NewEditSampah = sampahToEdit;
					formTambahUbahSampah.Show();
					formTambahUbahSampah.BringToFront();
					formTambahUbahSampah.FormClosed += (s, args) => LoadData();
				}
                else
                {
					MessageBox.Show("Sampah Tidak ditemukan","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
				MessageBox.Show("Pilih Baris yang ingin diubah.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count >0)
			{
				DialogResult result = MessageBox.Show("Apakah anda ingin menghapus Data Ini?","Konfirmasi Penghapusan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					int selectedId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

					var sampahToDelete = db.TblSampah.FirstOrDefault(n => n.ID == selectedId);
					if (sampahToDelete != null)
					{
						db.TblSampah.Remove(sampahToDelete);
						db.SaveChanges();

						LoadData();
					}
					else
					{
						MessageBox.Show("Sampah tidak ditemukan","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);	
					}
				}
			}
			else
			{
				MessageBox.Show("Pilih baris yang ingin dihapus.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonRef_Click(object sender, EventArgs e)
		{
			LoadData(); // Refresh data in DataGridView
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
