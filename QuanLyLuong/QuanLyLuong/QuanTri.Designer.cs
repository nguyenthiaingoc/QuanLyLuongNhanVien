namespace QuanLyLuong
{
    partial class QuanTri
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanTri));
      this.btnQLNV = new System.Windows.Forms.Button();
      this.btnQLL = new System.Windows.Forms.Button();
      this.btnTT = new System.Windows.Forms.Button();
      this.btnTG = new System.Windows.Forms.Button();
      this.btnBMPQ = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // btnQLNV
      // 
      this.btnQLNV.BackColor = System.Drawing.Color.LightBlue;
      this.btnQLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnQLNV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.btnQLNV.Location = new System.Drawing.Point(1, -1);
      this.btnQLNV.Name = "btnQLNV";
      this.btnQLNV.Size = new System.Drawing.Size(134, 105);
      this.btnQLNV.TabIndex = 1;
      this.btnQLNV.Text = "Quản Lý Nhân Viên";
      this.btnQLNV.UseVisualStyleBackColor = false;
      this.btnQLNV.Click += new System.EventHandler(this.btnQLNV_Click);
      // 
      // btnQLL
      // 
      this.btnQLL.BackColor = System.Drawing.Color.LightBlue;
      this.btnQLL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnQLL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.btnQLL.Location = new System.Drawing.Point(134, -1);
      this.btnQLL.Name = "btnQLL";
      this.btnQLL.Size = new System.Drawing.Size(134, 105);
      this.btnQLL.TabIndex = 2;
      this.btnQLL.Text = "Quản Lý Lương";
      this.btnQLL.UseVisualStyleBackColor = false;
      this.btnQLL.Click += new System.EventHandler(this.btnQLL_Click);
      // 
      // btnTT
      // 
      this.btnTT.BackColor = System.Drawing.Color.LightBlue;
      this.btnTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnTT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.btnTT.Location = new System.Drawing.Point(267, -1);
      this.btnTT.Name = "btnTT";
      this.btnTT.Size = new System.Drawing.Size(134, 105);
      this.btnTT.TabIndex = 3;
      this.btnTT.Text = "Thanh Toán";
      this.btnTT.UseVisualStyleBackColor = false;
      this.btnTT.Click += new System.EventHandler(this.btnThanhToan_Click);
      // 
      // btnTG
      // 
      this.btnTG.BackColor = System.Drawing.Color.LightBlue;
      this.btnTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnTG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.btnTG.Location = new System.Drawing.Point(535, -1);
      this.btnTG.Name = "btnTG";
      this.btnTG.Size = new System.Drawing.Size(126, 105);
      this.btnTG.TabIndex = 4;
      this.btnTG.Text = "Trợ Giúp";
      this.btnTG.UseVisualStyleBackColor = false;
      this.btnTG.Click += new System.EventHandler(this.btnTroGiup_Click);
      // 
      // btnBMPQ
      // 
      this.btnBMPQ.BackColor = System.Drawing.Color.LightBlue;
      this.btnBMPQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnBMPQ.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.btnBMPQ.Location = new System.Drawing.Point(401, -1);
      this.btnBMPQ.Name = "btnBMPQ";
      this.btnBMPQ.Size = new System.Drawing.Size(134, 105);
      this.btnBMPQ.TabIndex = 5;
      this.btnBMPQ.Text = "Bảo Mật Phân Quyền";
      this.btnBMPQ.UseVisualStyleBackColor = false;
      this.btnBMPQ.Click += new System.EventHandler(this.btnBaoMatPQ_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.LightGreen;
      this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
      this.pictureBox1.Location = new System.Drawing.Point(1, 98);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(660, 256);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.UseWaitCursor = true;
      // 
      // QuanTri
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(661, 366);
      this.Controls.Add(this.btnBMPQ);
      this.Controls.Add(this.btnTG);
      this.Controls.Add(this.btnTT);
      this.Controls.Add(this.btnQLL);
      this.Controls.Add(this.btnQLNV);
      this.Controls.Add(this.pictureBox1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Name = "QuanTri";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Hệ Thống Quản Lý Lương Nhân viên";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuanTri_FormClosed);
      this.Load += new System.EventHandler(this.QuanTri_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnQLNV;
        private System.Windows.Forms.Button btnQLL;
        private System.Windows.Forms.Button btnTT;
        private System.Windows.Forms.Button btnTG;
        private System.Windows.Forms.Button btnBMPQ;



    }
}