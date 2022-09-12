namespace TravelReservation
{
    partial class SeyahatRaporu
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
            this.dataGridViewUlasim = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewKonaklama = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonHtml = new System.Windows.Forms.Button();
            this.panelSeyahatYok = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUlasim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKonaklama)).BeginInit();
            this.panelSeyahatYok.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewUlasim
            // 
            this.dataGridViewUlasim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUlasim.Location = new System.Drawing.Point(12, 68);
            this.dataGridViewUlasim.Name = "dataGridViewUlasim";
            this.dataGridViewUlasim.RowHeadersWidth = 51;
            this.dataGridViewUlasim.RowTemplate.Height = 24;
            this.dataGridViewUlasim.Size = new System.Drawing.Size(785, 107);
            this.dataGridViewUlasim.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(36, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ulaşım bilgileri";
            // 
            // dataGridViewKonaklama
            // 
            this.dataGridViewKonaklama.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKonaklama.Location = new System.Drawing.Point(12, 234);
            this.dataGridViewKonaklama.Name = "dataGridViewKonaklama";
            this.dataGridViewKonaklama.RowHeadersWidth = 51;
            this.dataGridViewKonaklama.RowTemplate.Height = 24;
            this.dataGridViewKonaklama.Size = new System.Drawing.Size(785, 107);
            this.dataGridViewKonaklama.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(36, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Konaklama bilgileri";
            // 
            // buttonHtml
            // 
            this.buttonHtml.BackColor = System.Drawing.Color.DarkCyan;
            this.buttonHtml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHtml.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonHtml.ForeColor = System.Drawing.Color.White;
            this.buttonHtml.Location = new System.Drawing.Point(63, 389);
            this.buttonHtml.Name = "buttonHtml";
            this.buttonHtml.Size = new System.Drawing.Size(164, 55);
            this.buttonHtml.TabIndex = 36;
            this.buttonHtml.Text = "Çıktı al";
            this.buttonHtml.UseVisualStyleBackColor = false;
            this.buttonHtml.Click += new System.EventHandler(this.buttonHtml_Click);
            // 
            // panelSeyahatYok
            // 
            this.panelSeyahatYok.Controls.Add(this.label3);
            this.panelSeyahatYok.Location = new System.Drawing.Point(12, 57);
            this.panelSeyahatYok.Name = "panelSeyahatYok";
            this.panelSeyahatYok.Size = new System.Drawing.Size(795, 306);
            this.panelSeyahatYok.TabIndex = 37;
            this.panelSeyahatYok.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(34, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Seyahatiniz bulunmamaktadır";
            // 
            // SeyahatRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 543);
            this.Controls.Add(this.panelSeyahatYok);
            this.Controls.Add(this.buttonHtml);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewKonaklama);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewUlasim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SeyahatRaporu";
            this.Text = "SeyahatRaporu";
            this.Load += new System.EventHandler(this.SeyahatRaporu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUlasim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKonaklama)).EndInit();
            this.panelSeyahatYok.ResumeLayout(false);
            this.panelSeyahatYok.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUlasim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewKonaklama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonHtml;
        private System.Windows.Forms.Panel panelSeyahatYok;
        private System.Windows.Forms.Label label3;
    }
}