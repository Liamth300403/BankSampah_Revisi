using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSampah_Revisi.Entitas
{
	public class Sampah
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Jenis { get; set; }
		public string KategoriSampah { get; set; }
		public string Keterangan { get; set; }

		[Required]
		public decimal HargaPerKg { get; set; }
	}
}
