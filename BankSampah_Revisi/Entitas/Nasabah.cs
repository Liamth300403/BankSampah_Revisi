using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSampah_Revisi.Entitas
{
	public class Nasabah
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string NoRekening { get; set; }
		public string Nama { get; set; }

		public string Alamat { get; set; }
		public string JenisKelamin { get; set; }

		public string Telepon { get; set; }

		public DateTime TanggalBergabung { get; set; }

		[Required]
		public decimal Saldo { get; set; }
	}
}
