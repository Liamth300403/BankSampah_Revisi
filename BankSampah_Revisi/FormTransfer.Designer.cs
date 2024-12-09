namespace BankSampah_Revisi
{
	partial class FormTransfer
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.labelNomerRekening = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxPenarikan = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.labelSaldo = new System.Windows.Forms.Label();
			this.buttonConfirm = new System.Windows.Forms.Button();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(412, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Form Tarik Tunai";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(380, 78);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(213, 28);
			this.comboBox1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(139, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(123, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nama Nasabah:";
			// 
			// labelNomerRekening
			// 
			this.labelNomerRekening.AutoSize = true;
			this.labelNomerRekening.Location = new System.Drawing.Point(376, 130);
			this.labelNomerRekening.Name = "labelNomerRekening";
			this.labelNomerRekening.Size = new System.Drawing.Size(62, 20);
			this.labelNomerRekening.TabIndex = 3;
			this.labelNomerRekening.Text = "NoREK";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(139, 130);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(149, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "Rekening Nasabah:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(139, 253);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(239, 20);
			this.label4.TabIndex = 5;
			this.label4.Text = "Jumlah Saldo Yang ingin DItarik:";
			// 
			// textBoxPenarikan
			// 
			this.textBoxPenarikan.Location = new System.Drawing.Point(380, 247);
			this.textBoxPenarikan.Name = "textBoxPenarikan";
			this.textBoxPenarikan.Size = new System.Drawing.Size(209, 26);
			this.textBoxPenarikan.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(143, 195);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(129, 20);
			this.label5.TabIndex = 7;
			this.label5.Text = "Saldo Yang Ada:";
			// 
			// labelSaldo
			// 
			this.labelSaldo.AutoSize = true;
			this.labelSaldo.Location = new System.Drawing.Point(376, 195);
			this.labelSaldo.Name = "labelSaldo";
			this.labelSaldo.Size = new System.Drawing.Size(129, 20);
			this.labelSaldo.TabIndex = 8;
			this.labelSaldo.Text = "Saldo Yang Ada:";
			// 
			// buttonConfirm
			// 
			this.buttonConfirm.Location = new System.Drawing.Point(517, 342);
			this.buttonConfirm.Name = "buttonConfirm";
			this.buttonConfirm.Size = new System.Drawing.Size(76, 38);
			this.buttonConfirm.TabIndex = 9;
			this.buttonConfirm.Text = "Confirm";
			this.buttonConfirm.UseVisualStyleBackColor = true;
			this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(722, 25);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(324, 26);
			this.dateTimePicker1.TabIndex = 10;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(13, 572);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(87, 50);
			this.button1.TabIndex = 11;
			this.button1.Text = "Back";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormTransfer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1058, 644);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.buttonConfirm);
			this.Controls.Add(this.labelSaldo);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxPenarikan);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.labelNomerRekening);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Name = "FormTransfer";
			this.Text = "FormTransfer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelNomerRekening;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxPenarikan;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelSaldo;
		private System.Windows.Forms.Button buttonConfirm;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button button1;
	}
}