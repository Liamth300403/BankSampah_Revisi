using System;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using BankSampah_Revisi.Entitas;
using DocumentFormat.OpenXml;

namespace BankSampah_Revisi
{
	public partial class FormCatatanKeuanganNasabah : Form
	{
		private ApplicationDbContext dbContext;

		public FormCatatanKeuanganNasabah()
		{
			dbContext = new ApplicationDbContext();
			InitializeComponent();
			LoadNasabahNames();
			comboBoxNasabah.SelectedIndexChanged += comboBoxNasabah_SelectedIndexChanged;
		}

		private void LoadNasabahNames()
		{
			using (var db = new ApplicationDbContext())
			{
				var nasabahList = db.TblNasabah
					.Select(n => new { n.ID, n.Nama })
					.ToList();

				comboBoxNasabah.DataSource = nasabahList;
				comboBoxNasabah.DisplayMember = "Nama";
				comboBoxNasabah.ValueMember = "ID";

				// Set up ComboBox for auto-complete
				comboBoxNasabah.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				comboBoxNasabah.AutoCompleteSource = AutoCompleteSource.ListItems;
				comboBoxNasabah.DropDownStyle = ComboBoxStyle.DropDown;
			}
		}

		private void comboBoxNasabah_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxNasabah.SelectedValue != null)
			{
				int selectedNasabahId = (int)comboBoxNasabah.SelectedValue;
				using (var db = new ApplicationDbContext())
				{
					var nasabah = db.TblNasabah.FirstOrDefault(n => n.ID == selectedNasabahId);
					if (nasabah != null)
					{
						labelNomerRekening.Text = nasabah.NoRekening;
						labelSaldo.Text = nasabah.Saldo.ToString("C");
					}
					else
					{
						MessageBox.Show($"Nasabah dengan ID {selectedNasabahId} tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
		}

		private void LoadData(int nasabahId)
		{
			var transaksiMasuk = dbContext.TblTransaksi
				.Where(t => t.NasabahID == nasabahId)
				.ToList();

			var penarikanSaldo = dbContext.TblPenarikan
				.Where(p => p.NasabahID == nasabahId)
				.ToList();

			var nasabah = dbContext.TblNasabah.Find(nasabahId);
			if (nasabah != null)
			{
				labelSaldo.Text = nasabah.Saldo.ToString("C");
				labelNomerRekening.Text = nasabah.NoRekening;
			}
			else
			{
				MessageBox.Show("Nasabah not found.");
			}
		}

		private void buttonCetak_Click(object sender, EventArgs e)
		{
			if (comboBoxNasabah.SelectedValue != null)
			{
				int nasabahId = (int)comboBoxNasabah.SelectedValue;
				string nasabahName = comboBoxNasabah.Text;

				// Tentukan path untuk folder Documents dan subfolder Buku Nasabah
				string documentsFolderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Buku Nasabah");

				// Periksa apakah folder Buku Nasabah sudah ada, jika tidak ada, buat folder baru
				if (!System.IO.Directory.Exists(documentsFolderPath))
				{
					System.IO.Directory.CreateDirectory(documentsFolderPath);
				}

				// Tentukan path file untuk menyimpan file Word
				string fileName = $"LaporanNasabah_{nasabahName}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.docx";
				string filePath = System.IO.Path.Combine(documentsFolderPath, fileName);

				// Buat dokumen Word baru
				using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
				{
					MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
					mainPart.Document = new Document();
					Body body = mainPart.Document.AppendChild(new Body());

					// Tambahkan judul
					Paragraph para = body.AppendChild(new Paragraph());
					Run run = para.AppendChild(new Run());
					run.AppendChild(new Text("Laporan Keuangan Nasabah"));
					para.AppendChild(new Run(new Break()));
					para.AppendChild(new Run(new Break()));

					run = para.AppendChild(new Run());
					run.AppendChild(new Text($"Nama Nasabah: {nasabahName}"));
					para.AppendChild(new Run(new Break()));
					run = para.AppendChild(new Run());
					run.AppendChild(new Text($"Nomer Rekening: {labelNomerRekening.Text}"));
					para.AppendChild(new Run(new Break()));
					run = para.AppendChild(new Run());
					run.AppendChild(new Text($"Total Saldo: {labelSaldo.Text}"));
					para.AppendChild(new Run(new Break()));
					para.AppendChild(new Run(new Break()));

					// Tambahkan tabel transaksi masuk
					para = body.AppendChild(new Paragraph());
					run = para.AppendChild(new Run());
					run.AppendChild(new Text("Transaksi Masuk"));
					para.AppendChild(new Run(new Break()));

					Table table = new Table();
					TableProperties props = new TableProperties(
						new TableBorders(
							new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
							new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
							new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
							new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
							new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
							new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 }
						)
					);
					table.AppendChild(props);

					// Tambahkan header tabel
					TableRow tr = new TableRow();
					TableCell tc = new TableCell(new Paragraph(new Run(new Text("Tanggal"))));
					tr.Append(tc);
					tc = new TableCell(new Paragraph(new Run(new Text("Jenis Sampah"))));
					tr.Append(tc);
					tc = new TableCell(new Paragraph(new Run(new Text("Berat (kg)"))));
					tr.Append(tc);
					tc = new TableCell(new Paragraph(new Run(new Text("Total Harga"))));
					tr.Append(tc);
					table.Append(tr);

					// Tambahkan data transaksi masuk
					var transaksiMasuk = dbContext.TblTransaksi
						.Where(t => t.NasabahID == nasabahId)
						.ToList();

					foreach (var transaksi in transaksiMasuk)
					{
						tr = new TableRow();
						tc = new TableCell(new Paragraph(new Run(new Text(transaksi.TanggalTransaksi.ToString("dd/MM/yyyy")))));
						tr.Append(tc);
						tc = new TableCell(new Paragraph(new Run(new Text(transaksi.KategoriSampah))));
						tr.Append(tc);
						tc = new TableCell(new Paragraph(new Run(new Text(transaksi.Berat.ToString("F2")))));
						tr.Append(tc);
						tc = new TableCell(new Paragraph(new Run(new Text(transaksi.TotalHarga.ToString("C")))));
						tr.Append(tc);
						table.Append(tr);
					}

					body.Append(table);

					// Tambahkan tabel penarikan saldo
					para = body.AppendChild(new Paragraph());
					run = para.AppendChild(new Run());
					run.AppendChild(new Text("Penarikan Saldo"));
					para.AppendChild(new Run(new Break()));

					table = new Table();
					props = new TableProperties(
						new TableBorders(
							new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
							new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
							new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
							new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
							new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
							new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 }
						)
					);
					table.AppendChild(props);

					// Tambahkan header tabel
					tr = new TableRow();
					tc = new TableCell(new Paragraph(new Run(new Text("Tanggal"))));
					tr.Append(tc);
					tc = new TableCell(new Paragraph(new Run(new Text("Jumlah Penarikan"))));
					tr.Append(tc);
					table.Append(tr);

					// Tambahkan data penarikan saldo
					var penarikanSaldo = dbContext.TblPenarikan
						.Where(p => p.NasabahID == nasabahId)
						.ToList();

					foreach (var penarikan in penarikanSaldo)
					{
						tr = new TableRow();
						tc = new TableCell(new Paragraph(new Run(new Text(penarikan.TanggalPenarikan.ToString("dd/MM/yyyy")))));
						tr.Append(tc);
						tc = new TableCell(new Paragraph(new Run(new Text(penarikan.JumlahPenarikan.ToString("C")))));
						tr.Append(tc);
						table.Append(tr);
					}

					body.Append(table);
				}

				// Tampilkan dokumen secara langsung
				System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
				MessageBox.Show("Laporan telah berhasil dibuat dan ditampilkan.");
			}
			else
			{
				MessageBox.Show("Pilih Nasabah terlebih dahulu.");
			}
		}





	

		private void buttonBack_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
