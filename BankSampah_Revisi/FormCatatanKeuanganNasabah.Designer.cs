namespace BankSampah_Revisi
{
	partial class FormCatatanKeuanganNasabah
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonCetak = new System.Windows.Forms.Button();
			this.labelNomerRekening = new System.Windows.Forms.Label();
			this.comboBoxNasabah = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.labelSaldo = new System.Windows.Forms.Label();
			this.buttonBack = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(377, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(211, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Catatan Keuangan Nasabah";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(279, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nama Nasabah";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(279, 139);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(125, 20);
			this.label4.TabIndex = 4;
			this.label4.Text = "Nomer rekening:";
			// 
			// buttonCetak
			// 
			this.buttonCetak.Location = new System.Drawing.Point(483, 297);
			this.buttonCetak.Name = "buttonCetak";
			this.buttonCetak.Size = new System.Drawing.Size(119, 44);
			this.buttonCetak.TabIndex = 6;
			this.buttonCetak.Text = "Cetak";
			this.buttonCetak.UseVisualStyleBackColor = true;
			this.buttonCetak.Click += new System.EventHandler(this.buttonCetak_Click);
			// 
			// labelNomerRekening
			// 
			this.labelNomerRekening.AutoSize = true;
			this.labelNomerRekening.Location = new System.Drawing.Point(479, 139);
			this.labelNomerRekening.Name = "labelNomerRekening";
			this.labelNomerRekening.Size = new System.Drawing.Size(121, 20);
			this.labelNomerRekening.TabIndex = 5;
			this.labelNomerRekening.Text = "Nomer rekening";
			// 
			// comboBoxNasabah
			// 
			this.comboBoxNasabah.FormattingEnabled = true;
			this.comboBoxNasabah.Location = new System.Drawing.Point(483, 71);
			this.comboBoxNasabah.Name = "comboBoxNasabah";
			this.comboBoxNasabah.Size = new System.Drawing.Size(177, 28);
			this.comboBoxNasabah.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(279, 199);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 20);
			this.label6.TabIndex = 12;
			this.label6.Text = "Total Saldo";
			// 
			// labelSaldo
			// 
			this.labelSaldo.AutoSize = true;
			this.labelSaldo.Location = new System.Drawing.Point(479, 199);
			this.labelSaldo.Name = "labelSaldo";
			this.labelSaldo.Size = new System.Drawing.Size(50, 20);
			this.labelSaldo.TabIndex = 13;
			this.labelSaldo.Text = "Saldo";
			// 
			// buttonBack
			// 
			this.buttonBack.Location = new System.Drawing.Point(12, 488);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.Size = new System.Drawing.Size(119, 44);
			this.buttonBack.TabIndex = 14;
			this.buttonBack.Text = "Back";
			this.buttonBack.UseVisualStyleBackColor = true;
			this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
			// 
			// FormCatatanKeuanganNasabah
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1071, 544);
			this.Controls.Add(this.buttonBack);
			this.Controls.Add(this.labelSaldo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.comboBoxNasabah);
			this.Controls.Add(this.buttonCetak);
			this.Controls.Add(this.labelNomerRekening);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormCatatanKeuanganNasabah";
			this.Text = "FormCatatanKeuanganNasabah";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonCetak;
		private System.Windows.Forms.Label labelNomerRekening;
		private System.Windows.Forms.ComboBox comboBoxNasabah;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label labelSaldo;
		private System.Windows.Forms.Button buttonBack;
	}
}