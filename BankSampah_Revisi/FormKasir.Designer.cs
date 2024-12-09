namespace BankSampah_Revisi
{
	partial class FormKasir
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
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxSampah = new System.Windows.Forms.ComboBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.buttonTambahKeDataGrid = new System.Windows.Forms.Button();
			this.buttonSimpanKeDatabase = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.labelHarga = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBoxNasabah = new System.Windows.Forms.ComboBox();
			this.labelTotal = new System.Windows.Forms.Label();
			this.textBoxTotal = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(651, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(331, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Input Sampah Nasabah";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(23, 105);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(123, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Nama Nasabah:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 284);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 20);
			this.label3.TabIndex = 3;
			this.label3.Text = "Nama Sampah:";
			// 
			// comboBoxSampah
			// 
			this.comboBoxSampah.FormattingEnabled = true;
			this.comboBoxSampah.Location = new System.Drawing.Point(179, 281);
			this.comboBoxSampah.Name = "comboBoxSampah";
			this.comboBoxSampah.Size = new System.Drawing.Size(215, 28);
			this.comboBoxSampah.TabIndex = 4;
			this.comboBoxSampah.SelectedIndexChanged += new System.EventHandler(this.comboBoxSampah_SelectedIndexChanged);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(1379, 467);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(289, 26);
			this.dateTimePicker1.TabIndex = 5;
			// 
			// buttonTambahKeDataGrid
			// 
			this.buttonTambahKeDataGrid.Location = new System.Drawing.Point(723, 79);
			this.buttonTambahKeDataGrid.Name = "buttonTambahKeDataGrid";
			this.buttonTambahKeDataGrid.Size = new System.Drawing.Size(115, 51);
			this.buttonTambahKeDataGrid.TabIndex = 6;
			this.buttonTambahKeDataGrid.Text = "Tambah";
			this.buttonTambahKeDataGrid.UseVisualStyleBackColor = true;
			this.buttonTambahKeDataGrid.Click += new System.EventHandler(this.buttonTambahKeDataGrid_Click);
			// 
			// buttonSimpanKeDatabase
			// 
			this.buttonSimpanKeDatabase.Location = new System.Drawing.Point(1536, 518);
			this.buttonSimpanKeDatabase.Name = "buttonSimpanKeDatabase";
			this.buttonSimpanKeDatabase.Size = new System.Drawing.Size(132, 53);
			this.buttonSimpanKeDatabase.TabIndex = 7;
			this.buttonSimpanKeDatabase.Text = "Simpan Ke Database";
			this.buttonSimpanKeDatabase.UseVisualStyleBackColor = true;
			this.buttonSimpanKeDatabase.Click += new System.EventHandler(this.buttonSimpanKeDatabase_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(723, 148);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 62;
			this.dataGridView1.RowTemplate.Height = 28;
			this.dataGridView1.Size = new System.Drawing.Size(945, 301);
			this.dataGridView1.TabIndex = 8;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(522, 358);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(153, 26);
			this.numericUpDown1.TabIndex = 9;
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(398, 364);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 20);
			this.label4.TabIndex = 10;
			this.label4.Text = "Jumlah:";
			// 
			// labelHarga
			// 
			this.labelHarga.AutoSize = true;
			this.labelHarga.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHarga.Location = new System.Drawing.Point(516, 298);
			this.labelHarga.Name = "labelHarga";
			this.labelHarga.Size = new System.Drawing.Size(86, 32);
			this.labelHarga.TabIndex = 11;
			this.labelHarga.Text = "label5";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(398, 310);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 20);
			this.label6.TabIndex = 12;
			this.label6.Text = "Harga Dasar:";
			// 
			// comboBoxNasabah
			// 
			this.comboBoxNasabah.FormattingEnabled = true;
			this.comboBoxNasabah.Location = new System.Drawing.Point(179, 102);
			this.comboBoxNasabah.Name = "comboBoxNasabah";
			this.comboBoxNasabah.Size = new System.Drawing.Size(215, 28);
			this.comboBoxNasabah.TabIndex = 13;
			this.comboBoxNasabah.SelectedIndexChanged += new System.EventHandler(this.comboBoxNasabah_SelectedIndexChanged);
			// 
			// labelTotal
			// 
			this.labelTotal.AutoSize = true;
			this.labelTotal.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTotal.Location = new System.Drawing.Point(396, 417);
			this.labelTotal.Name = "labelTotal";
			this.labelTotal.Size = new System.Drawing.Size(86, 32);
			this.labelTotal.TabIndex = 15;
			this.labelTotal.Text = "label5";
			// 
			// textBoxTotal
			// 
			this.textBoxTotal.Location = new System.Drawing.Point(522, 422);
			this.textBoxTotal.Name = "textBoxTotal";
			this.textBoxTotal.Size = new System.Drawing.Size(153, 26);
			this.textBoxTotal.TabIndex = 16;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 656);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(113, 58);
			this.button1.TabIndex = 17;
			this.button1.Text = "Back";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormKasir
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1708, 726);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBoxTotal);
			this.Controls.Add(this.labelTotal);
			this.Controls.Add(this.comboBoxNasabah);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.labelHarga);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.buttonSimpanKeDatabase);
			this.Controls.Add(this.buttonTambahKeDataGrid);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.comboBoxSampah);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormKasir";
			this.Text = "FormKasir";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxSampah;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button buttonTambahKeDataGrid;
		private System.Windows.Forms.Button buttonSimpanKeDatabase;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label labelHarga;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBoxNasabah;
		private System.Windows.Forms.Label labelTotal;
		private System.Windows.Forms.TextBox textBoxTotal;
		private System.Windows.Forms.Button button1;
	}
}