using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using BankSampah_Revisi.Entitas;

namespace BankSampah_Revisi
{
	public class ApplicationDbContext:DbContext
	{
		public DbSet<Nasabah> TblNasabah { get; set; }
		public DbSet<Sampah> TblSampah { get; set; }
		public DbSet<Transaksi> TblTransaksi { get; set; }
		public DbSet<Penarikan> TblPenarikan {  get; set; }
	}
}
