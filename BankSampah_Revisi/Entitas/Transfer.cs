using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSampah_Revisi.Entitas
{
	public class Transaksi
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[ForeignKey("Nasabah")]
		public int NasabahID { get; set; }
		public string Nama { get; set; }

		[Required]
		[ForeignKey("Sampah")]
		public int SampahID { get; set; }
		public string KategoriSampah { get; set; }
		[Required]
		public decimal Berat { get; set; }

		[Required]
		public DateTime TanggalTransaksi { get; set; }

		[Required]
		public decimal TotalHarga { get; set; }

		public virtual Nasabah Nasabah { get; set; }
		public virtual Sampah Sampah { get; set; }
	}
}
