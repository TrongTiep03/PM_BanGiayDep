namespace PhanMemQuanLyBanGiayDep.Views
{
    partial class frmNhapKho
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
            this.dtNgayHD1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtNgayHD2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtGVChiTietNhapKho = new System.Windows.Forms.DataGridView();
            this.dtGVNhapKho = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVChiTietNhapKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVNhapKho)).BeginInit();
            this.SuspendLayout();
            // 
            // dtNgayHD1
            // 
            this.dtNgayHD1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayHD1.Location = new System.Drawing.Point(588, 11);
            this.dtNgayHD1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtNgayHD1.Name = "dtNgayHD1";
            this.dtNgayHD1.Size = new System.Drawing.Size(157, 22);
            this.dtNgayHD1.TabIndex = 289;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(755, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 288;
            this.label2.Text = "Đến ngày";
            // 
            // dtNgayHD2
            // 
            this.dtNgayHD2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayHD2.Location = new System.Drawing.Point(831, 11);
            this.dtNgayHD2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtNgayHD2.Name = "dtNgayHD2";
            this.dtNgayHD2.Size = new System.Drawing.Size(157, 22);
            this.dtNgayHD2.TabIndex = 287;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 286;
            this.label1.Text = "Từ ngày";
            // 
            // dtGVChiTietNhapKho
            // 
            this.dtGVChiTietNhapKho.AllowUserToAddRows = false;
            this.dtGVChiTietNhapKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGVChiTietNhapKho.BackgroundColor = System.Drawing.Color.White;
            this.dtGVChiTietNhapKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVChiTietNhapKho.Location = new System.Drawing.Point(3, 411);
            this.dtGVChiTietNhapKho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtGVChiTietNhapKho.Name = "dtGVChiTietNhapKho";
            this.dtGVChiTietNhapKho.ReadOnly = true;
            this.dtGVChiTietNhapKho.RowHeadersWidth = 51;
            this.dtGVChiTietNhapKho.Size = new System.Drawing.Size(1115, 231);
            this.dtGVChiTietNhapKho.TabIndex = 281;
            // 
            // dtGVNhapKho
            // 
            this.dtGVNhapKho.AllowUserToAddRows = false;
            this.dtGVNhapKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGVNhapKho.BackgroundColor = System.Drawing.Color.White;
            this.dtGVNhapKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVNhapKho.Location = new System.Drawing.Point(3, 50);
            this.dtGVNhapKho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtGVNhapKho.Name = "dtGVNhapKho";
            this.dtGVNhapKho.ReadOnly = true;
            this.dtGVNhapKho.RowHeadersWidth = 51;
            this.dtGVNhapKho.Size = new System.Drawing.Size(1115, 353);
            this.dtGVNhapKho.TabIndex = 280;
            this.dtGVNhapKho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVNhapKho_CellClick);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(271, 7);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 37);
            this.btnXoa.TabIndex = 373;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(141, 7);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(121, 37);
            this.btnSua.TabIndex = 372;
            this.btnSua.TabStop = false;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(16, 7);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 37);
            this.btnThem.TabIndex = 371;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.SystemColors.Control;
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(993, 5);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(121, 37);
            this.btnTim.TabIndex = 376;
            this.btnTim.TabStop = false;
            this.btnTim.Text = "Tìm";
            this.btnTim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // frmNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1120, 649);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dtNgayHD1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtNgayHD2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtGVChiTietNhapKho);
            this.Controls.Add(this.dtGVNhapKho);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmNhapKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu nhập kho";
            this.Load += new System.EventHandler(this.frmNhapKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVChiTietNhapKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVNhapKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtNgayHD1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtNgayHD2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGVChiTietNhapKho;
        private System.Windows.Forms.DataGridView dtGVNhapKho;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTim;
    }
}