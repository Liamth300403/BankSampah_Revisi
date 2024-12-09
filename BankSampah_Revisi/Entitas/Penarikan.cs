using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSampah_Revisi.Entitas
{
	public class Penarikan
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[ForeignKey("Nasabah")]
		public int NasabahID { get; set; }

		public string NamaNasabah { get; set; }
		public string NoRekening { get; set; }

		[Required]
		public decimal JumlahPenarikan { get; set; }

		[Required]
		public DateTime TanggalPenarikan { get; set; }

		public virtual Nasabah Nasabah { get; set; }
	}
}
