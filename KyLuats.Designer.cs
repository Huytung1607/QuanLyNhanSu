namespace QuanLyNhanSu
{
    partial class KyLuats
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
            this.txt_Lydo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtp_NgayKT = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_MaBoPhan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid_KyLuat = new System.Windows.Forms.DataGridView();
            this.txt_Timkiem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_TenTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MaKL = new System.Windows.Forms.TextBox();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_KyLuat)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Lydo
            // 
            this.txt_Lydo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txt_Lydo.Location = new System.Drawing.Point(574, 99);
            this.txt_Lydo.Name = "txt_Lydo";
            this.txt_Lydo.Size = new System.Drawing.Size(158, 22);
            this.txt_Lydo.TabIndex = 207;
            // 
            // label9
            // 
            this.label9.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(410, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 22);
            this.label9.TabIndex = 205;
            this.label9.Text = "Lý do :";
            // 
            // dtp_NgayKT
            // 
            this.dtp_NgayKT.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dtp_NgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_NgayKT.Location = new System.Drawing.Point(574, 138);
            this.dtp_NgayKT.Name = "dtp_NgayKT";
            this.dtp_NgayKT.Size = new System.Drawing.Size(127, 22);
            this.dtp_NgayKT.TabIndex = 204;
            // 
            // label8
            // 
            this.label8.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(414, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 22);
            this.label8.TabIndex = 203;
            this.label8.Text = "Ngày kỷ luật :";
            // 
            // txt_MaBoPhan
            // 
            this.txt_MaBoPhan.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txt_MaBoPhan.Location = new System.Drawing.Point(228, 176);
            this.txt_MaBoPhan.Name = "txt_MaBoPhan";
            this.txt_MaBoPhan.Size = new System.Drawing.Size(158, 22);
            this.txt_MaBoPhan.TabIndex = 202;
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 22);
            this.label5.TabIndex = 201;
            this.label5.Text = "Mã bộ phận :";
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox1.Controls.Add(this.grid_KyLuat);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 270);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(1056, 330);
            this.groupBox1.TabIndex = 196;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách kỷ luật";
            // 
            // grid_KyLuat
            // 
            this.grid_KyLuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_KyLuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_KyLuat.Location = new System.Drawing.Point(4, 26);
            this.grid_KyLuat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grid_KyLuat.Name = "grid_KyLuat";
            this.grid_KyLuat.RowHeadersWidth = 51;
            this.grid_KyLuat.RowTemplate.Height = 24;
            this.grid_KyLuat.Size = new System.Drawing.Size(1048, 301);
            this.grid_KyLuat.TabIndex = 0;
            this.grid_KyLuat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_KyLuat_CellClick);
            // 
            // txt_Timkiem
            // 
            this.txt_Timkiem.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txt_Timkiem.Location = new System.Drawing.Point(743, 99);
            this.txt_Timkiem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Timkiem.Name = "txt_Timkiem";
            this.txt_Timkiem.Size = new System.Drawing.Size(158, 22);
            this.txt_Timkiem.TabIndex = 195;
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 22);
            this.label4.TabIndex = 198;
            this.label4.Text = "Tên tài khoản :";
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 22);
            this.label3.TabIndex = 197;
            this.label3.Text = "Mã kỷ luật :";
            // 
            // txt_TenTaiKhoan
            // 
            this.txt_TenTaiKhoan.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txt_TenTaiKhoan.Location = new System.Drawing.Point(228, 141);
            this.txt_TenTaiKhoan.Name = "txt_TenTaiKhoan";
            this.txt_TenTaiKhoan.Size = new System.Drawing.Size(158, 22);
            this.txt_TenTaiKhoan.TabIndex = 200;
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(739, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 22);
            this.label2.TabIndex = 194;
            this.label2.Text = "Tìm theo tên tài khoản :";
            // 
            // txt_MaKL
            // 
            this.txt_MaKL.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txt_MaKL.Location = new System.Drawing.Point(228, 99);
            this.txt_MaKL.Name = "txt_MaKL";
            this.txt_MaKL.Size = new System.Drawing.Size(158, 22);
            this.txt_MaKL.TabIndex = 199;
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Back.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.Image = global::QuanLyNhanSu.Properties.Resources.back;
            this.btn_Back.Location = new System.Drawing.Point(0, 0);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(83, 33);
            this.btn_Back.TabIndex = 206;
            this.btn_Back.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnTimkiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiem.Image = global::QuanLyNhanSu.Properties.Resources.search;
            this.btnTimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimkiem.Location = new System.Drawing.Point(927, 90);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(84, 40);
            this.btnTimkiem.TabIndex = 193;
            this.btnTimkiem.Text = "Tìm";
            this.btnTimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimkiem.UseVisualStyleBackColor = false;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::QuanLyNhanSu.Properties.Resources.discipline;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(370, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 79);
            this.label1.TabIndex = 189;
            this.label1.Text = "Kỷ luật";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Xoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Image = global::QuanLyNhanSu.Properties.Resources.delete;
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.Location = new System.Drawing.Point(797, 193);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(89, 50);
            this.btn_Xoa.TabIndex = 192;
            this.btn_Xoa.Text = "Xoá";
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Sua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Image = global::QuanLyNhanSu.Properties.Resources.edit;
            this.btn_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.Location = new System.Drawing.Point(622, 193);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(89, 50);
            this.btn_Sua.TabIndex = 191;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Sua.UseVisualStyleBackColor = false;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Them.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Image = global::QuanLyNhanSu.Properties.Resources.add;
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(440, 193);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(89, 50);
            this.btn_Them.TabIndex = 190;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Them.UseVisualStyleBackColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // KyLuats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1056, 600);
            this.Controls.Add(this.txt_Lydo);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtp_NgayKT);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_MaBoPhan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Timkiem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_TenTaiKhoan);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.txt_MaKL);
            this.Controls.Add(this.btn_Them);
            this.Name = "KyLuats";
            this.Text = "KyLuats";
            this.Load += new System.EventHandler(this.KyLuats_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_KyLuat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Lydo;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp_NgayKT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_MaBoPhan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grid_KyLuat;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Timkiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_TenTaiKhoan;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.TextBox txt_MaKL;
        private System.Windows.Forms.Button btn_Them;
    }
}