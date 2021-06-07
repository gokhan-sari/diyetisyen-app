
namespace diyetisyen_uygulamasi
{
    partial class login
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
            this.giris_butonu = new System.Windows.Forms.Button();
            this.sifre = new System.Windows.Forms.TextBox();
            this.kullanici_adi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // giris_butonu
            // 
            this.giris_butonu.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.giris_butonu.Location = new System.Drawing.Point(566, 345);
            this.giris_butonu.Name = "giris_butonu";
            this.giris_butonu.Size = new System.Drawing.Size(250, 50);
            this.giris_butonu.TabIndex = 26;
            this.giris_butonu.Text = "Giriş";
            this.giris_butonu.UseVisualStyleBackColor = true;
            this.giris_butonu.Click += new System.EventHandler(this.giris_butonu_Click);
            // 
            // sifre
            // 
            this.sifre.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifre.Location = new System.Drawing.Point(566, 251);
            this.sifre.Name = "sifre";
            this.sifre.Size = new System.Drawing.Size(250, 40);
            this.sifre.TabIndex = 24;
            this.sifre.Text = "1234";
            this.sifre.UseSystemPasswordChar = true;
            // 
            // kullanici_adi
            // 
            this.kullanici_adi.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullanici_adi.Location = new System.Drawing.Point(566, 157);
            this.kullanici_adi.Name = "kullanici_adi";
            this.kullanici_adi.Size = new System.Drawing.Size(250, 40);
            this.kullanici_adi.TabIndex = 23;
            this.kullanici_adi.Text = "ali";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(266, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 34);
            this.label3.TabIndex = 22;
            this.label3.Text = "Şifre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(266, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 34);
            this.label2.TabIndex = 21;
            this.label2.Text = "Kulanıcı Adı";
            // 
            // login
            // 
            this.AcceptButton = this.giris_butonu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.giris_butonu);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.kullanici_adi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Yap";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.login_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button giris_butonu;
        public System.Windows.Forms.TextBox sifre;
        public System.Windows.Forms.TextBox kullanici_adi;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
    }
}