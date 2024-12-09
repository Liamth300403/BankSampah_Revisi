namespace BankSampah_Revisi
{
	partial class FormLaporan
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
			this.dataGridViewTransfer = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.buttonTransfer = new System.Windows.Forms.Button();
			this.buttonTarik = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransfer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewTransfer
			// 
			this.dataGridViewTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTransfer.Location = new System.Drawing.Point(49, 65);
			this.dataGridViewTransfer.Name = "dataGridViewTransfer";
			this.dataGridViewTransfer.RowHeadersWidth = 62;
			this.dataGridViewTransfer.RowTemplate.Height = 28;
			this.dataGridViewTransfer.Size = new System.Drawing.Size(939, 312);
			this.dataGridViewTransfer.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(231, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Data Transaksi Masuk Sampah";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(45, 449);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(195, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Data Tarik Saldo Nasabah";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(49, 489);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 62;
			this.dataGridView1.RowTemplate.Height = 28;
			this.dataGridView1.Size = new System.Drawing.Size(939, 312);
			this.dataGridView1.TabIndex = 2;
			// 
			// buttonTransfer
			// 
			this.buttonTransfer.Location = new System.Drawing.Point(853, 383);
			this.buttonTransfer.Name = "buttonTransfer";
			this.buttonTransfer.Size = new System.Drawing.Size(135, 52);
			this.buttonTransfer.TabIndex = 4;
			this.buttonTransfer.Text = "Cetak";
			this.buttonTransfer.UseVisualStyleBackColor = true;
			this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
			// 
			// buttonTarik
			// 
			this.buttonTarik.Location = new System.Drawing.Point(853, 807);
			this.buttonTarik.Name = "buttonTarik";
			this.buttonTarik.Size = new System.Drawing.Size(135, 52);
			this.buttonTarik.TabIndex = 5;
			this.buttonTarik.Text = "Cetak";
			this.buttonTarik.UseVisualStyleBackColor = true;
			this.buttonTarik.Click += new System.EventHandler(this.buttonTarik_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 823);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(135, 52);
			this.button1.TabIndex = 6;
			this.button1.Text = "Back";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormLaporan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1125, 887);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonTarik);
			this.Controls.Add(this.buttonTransfer);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridViewTransfer);
			this.Name = "FormLaporan";
			this.Text = "FormLaporan";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransfer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewTransfer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button buttonTransfer;
		private System.Windows.Forms.Button buttonTarik;
		private System.Windows.Forms.Button button1;
	}
}