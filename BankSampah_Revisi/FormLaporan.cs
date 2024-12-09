using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using BankSampah_Revisi.Entitas;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace BankSampah_Revisi
{
	public partial class FormLaporan : Form
	{
		private ApplicationDbContext db;

		public FormLaporan()
		{
			InitializeComponent();
			db = new ApplicationDbContext();
			LoadDataTransaksi();
			LoadData();
		}

		private void LoadDataTransaksi()
		{
			var transaksiList = db.TblTransaksi.Include(t => t.Nasabah).Include(t => t.Sampah).ToList();
			var dataSource = transaksiList.Select(t => new
			{
				t.ID,
				NasabahNama = t.Nasabah.Nama,
				SampahJenis = t.Sampah.Jenis,
				t.KategoriSampah,
				t.Berat,
				TanggalTransaksi = t.TanggalTransaksi.ToString("dd-MM-yyyy"),
				t.TotalHarga
			}).ToList();

			dataGridViewTransfer.DataSource = dataSource;
		}

		private void LoadData()
		{
			var penarikanList = db.TblPenarikan.Include(p => p.Nasabah).ToList();
			var dataSource = penarikanList.Select(p => new
			{
				p.ID,
				p.NamaNasabah,
				p.NoRekening,
				p.JumlahPenarikan,
				TanggalPenarikan = p.TanggalPenarikan.ToString("dd-MM-yyyy")
			}).ToList();

			dataGridView1.DataSource = dataSource;
		}

		private void buttonTransfer_Click(object sender, EventArgs e)
		{
			ExportDataGridViewToExcel(dataGridViewTransfer, "Laporan_Transaksi.xlsx");
		}

		private void buttonTarik_Click(object sender, EventArgs e)
		{
			ExportDataGridViewToExcel(dataGridView1, "Laporan_Penarikan.xlsx");
		}

		private void ExportDataGridViewToExcel(DataGridView dataGridView, string fileName)
		{
			// Tentukan path folder di dalam direktori proyek
			string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documents");

			// Periksa apakah folder sudah ada, jika tidak ada, buat folder baru
			if (!System.IO.Directory.Exists(folderPath))
			{
				System.IO.Directory.CreateDirectory(folderPath);
			}

			// Gabungkan nama file dengan path folder
			string filePath = System.IO.Path.Combine(folderPath, fileName);

			using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
			{
				WorkbookPart workbookPart = document.AddWorkbookPart();
				workbookPart.Workbook = new Workbook();

				WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
				worksheetPart.Worksheet = new Worksheet(new SheetData());

				Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());
				Sheet sheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Laporan" };
				sheets.Append(sheet);

				SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

				// Menambahkan Judul
				Row titleRow = new Row();
				Cell titleCell = new Cell
				{
					DataType = CellValues.String,
					CellValue = new CellValue("Laporan Data")
				};
				titleCell.StyleIndex = 1; // Style for title
				titleRow.AppendChild(titleCell);
				sheetData.AppendChild(titleRow);

				// Style untuk title
				var stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
				stylesPart.Stylesheet = new Stylesheet(
					new Fonts(
						new Font(
							new FontSize() { Val = 16 },
							new Bold()
						)
					),
					new Fills(new Fill()), // Default fill
					new Borders(new Border()), // Default border
					new CellFormats(
						new CellFormat() { FontId = 0, FillId = 0, BorderId = 0, ApplyFont = true },
						new CellFormat() { FontId = 1, FillId = 0, BorderId = 0, ApplyFont = true }
					)
				);
				stylesPart.Stylesheet.Save();

				// Menambahkan Header
				Row headerRow = new Row();
				foreach (DataGridViewColumn column in dataGridView.Columns)
				{
					Cell cell = new Cell
					{
						DataType = CellValues.String,
						CellValue = new CellValue(column.HeaderText),
						StyleIndex = 0 // Style for header
					};
					headerRow.AppendChild(cell);
				}
				sheetData.AppendChild(headerRow);

				// Menambahkan Data
				foreach (DataGridViewRow dgvRow in dataGridView.Rows)
				{
					if (!dgvRow.IsNewRow) // Skip the new row placeholder
					{
						Row newRow = new Row();
						foreach (DataGridViewCell dgvCell in dgvRow.Cells)
						{
							Cell cell = new Cell
							{
								DataType = CellValues.String,
								CellValue = new CellValue(dgvCell.Value?.ToString() ?? string.Empty)
							};
							newRow.AppendChild(cell);
						}
						sheetData.AppendChild(newRow);
					}
				}

				workbookPart.Workbook.Save();
			}

			MessageBox.Show($"Laporan berhasil disimpan dengan nama {filePath}", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
