using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BankSampah_Revisi.Entitas;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace BankSampah_Revisi
{
	public partial class FormListNasabah : Form
	{
		FormTambahUbahNasabah formTambahUbahNasabah;
		public static ApplicationDbContext db = new ApplicationDbContext();
		public static List<Nasabah> ListNasabah = new List<Nasabah>();

		public FormListNasabah()
		{
			InitializeComponent();
			LoadData();
		}

		private void LoadData()
		{
			ListNasabah = db.TblNasabah.ToList();
			dataGridView1.DataSource = null; // Clear the current binding
			dataGridView1.DataSource = ListNasabah; // Bind the updated list
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			if (formTambahUbahNasabah == null || formTambahUbahNasabah.IsDisposed)
			{
				formTambahUbahNasabah = new FormTambahUbahNasabah();
			}

			formTambahUbahNasabah.EditMode = false;
			formTambahUbahNasabah.NewEditNasabah = new Nasabah();
			formTambahUbahNasabah.Show();
			formTambahUbahNasabah.BringToFront();

			// Refresh the data after closing the form
			formTambahUbahNasabah.FormClosed += (s, args) => LoadData();
		}

		private void buttonRef_Click(object sender, EventArgs e)
		{
			LoadData(); // Refresh the data in the DataGridView
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				// Show confirmation message box
				DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus nasabah ini?", "Konfirmasi Penghapusan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result == DialogResult.Yes)
				{
					// Assuming the first column is the ID column
					int selectedId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

					// Find the Nasabah object by ID
					var nasabahToDelete = db.TblNasabah.FirstOrDefault(n => n.ID == selectedId);
					if (nasabahToDelete != null)
					{
						// Remove the Nasabah from the database
						db.TblNasabah.Remove(nasabahToDelete);
						db.SaveChanges();

						// Refresh the DataGridView
						LoadData();
					}
					else
					{
						MessageBox.Show("Nasabah tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
			{
				MessageBox.Show("Pilih baris yang ingin dihapus.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonEdit_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				if (formTambahUbahNasabah == null || formTambahUbahNasabah.IsDisposed)
				{
					formTambahUbahNasabah = new FormTambahUbahNasabah();
				}

				// Assuming the first column is the ID column
				int selectedId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

				// Find the Nasabah object by ID
				var nasabahToEdit = db.TblNasabah.FirstOrDefault(n => n.ID == selectedId);
				if (nasabahToEdit != null)
				{
					formTambahUbahNasabah.EditMode = true;
					formTambahUbahNasabah.NewEditNasabah = nasabahToEdit;
					formTambahUbahNasabah.Show();
					formTambahUbahNasabah.BringToFront();

					// Refresh the data after closing the form
					formTambahUbahNasabah.FormClosed += (s, args) => LoadData();
				}
				else
				{
					MessageBox.Show("Nasabah tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Pilih baris yang ingin diubah.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				// Tentukan path untuk folder Documents dan subfolder Nasabah
				string documentsFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documents");
				string nasabahFolderPath = System.IO.Path.Combine(documentsFolderPath, "Nasabah");

				// Periksa apakah folder Nasabah sudah ada, jika tidak ada, buat folder baru
				if (!System.IO.Directory.Exists(nasabahFolderPath))
				{
					System.IO.Directory.CreateDirectory(nasabahFolderPath);
				}

				// Tentukan path file untuk menyimpan file Excel
				string fileName = $"DataNasabah_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.xlsx";
				string filePath = System.IO.Path.Combine(nasabahFolderPath, fileName);

				// Buat dokumen Excel baru
				using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
				{
					// Buat workbook part
					WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
					workbookPart.Workbook = new Workbook();

					// Buat worksheet part
					WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
					worksheetPart.Worksheet = new Worksheet(new SheetData());

					// Tambahkan sheet ke workbook
					Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
					Sheet sheet = new Sheet()
					{
						Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
						SheetId = 1,
						Name = "Data Nasabah"
					};
					sheets.Append(sheet);

					// Tambahkan data ke sheet
					SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

					// Tambahkan header
					Row headerRow = new Row();
					headerRow.Append(
						new Cell() { CellValue = new CellValue("ID"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("No Rekening"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Nama"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Alamat"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Jenis Kelamin"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Telepon"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Tanggal Bergabung"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Saldo"), DataType = CellValues.String }
					);
					sheetData.AppendChild(headerRow);

					// Tambahkan data nasabah
					foreach (var nasabah in ListNasabah)
					{
						Row dataRow = new Row();
						dataRow.Append(
							new Cell() { CellValue = new CellValue(nasabah.ID.ToString()), DataType = CellValues.Number },
							new Cell() { CellValue = new CellValue(nasabah.NoRekening), DataType = CellValues.String },
							new Cell() { CellValue = new CellValue(nasabah.Nama), DataType = CellValues.String },
							new Cell() { CellValue = new CellValue(nasabah.Alamat), DataType = CellValues.String },
							new Cell() { CellValue = new CellValue(nasabah.JenisKelamin), DataType = CellValues.String },
							new Cell() { CellValue = new CellValue(nasabah.Telepon), DataType = CellValues.String },
							new Cell() { CellValue = new CellValue(nasabah.TanggalBergabung.ToString("dd-MM-yyyy")), DataType = CellValues.String },
							new Cell() { CellValue = new CellValue(nasabah.Saldo.ToString()), DataType = CellValues.Number }
						);
						sheetData.AppendChild(dataRow);
					}

					workbookPart.Workbook.Save();
				}

				// Tampilkan pesan sukses
				MessageBox.Show($"Data nasabah telah diekspor ke file Excel:\n{filePath}", "Ekspor Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

				// Buka file Excel setelah diekspor
				System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
			}
			catch (Exception ex)
			{
				// Tampilkan pesan error jika terjadi kesalahan
				MessageBox.Show($"Terjadi kesalahan saat mengekspor data ke Excel:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

	}
}
