namespace Lab06a
{
    partial class LopForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.TextBox txtMaKhoa;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblList;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        // Các ô nhập giới hạn độ dài trùng cấu trúc cột trong SQL Server.
        private void InitializeComponent()
        {
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.txtMaKhoa = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.lblMaKhoa = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblList = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.Text = "QUẢN LÝ LỚP";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Size = new System.Drawing.Size(690, 32);
            this.lblMaLop.Text = "Mã lớp";
            this.lblMaLop.Location = new System.Drawing.Point(24, 66);
            this.lblMaLop.Size = new System.Drawing.Size(130, 24);
            this.lblTenLop.Text = "Tên lớp";
            this.lblTenLop.Location = new System.Drawing.Point(24, 100);
            this.lblTenLop.Size = new System.Drawing.Size(130, 24);
            this.lblMaKhoa.Text = "Mã khoa";
            this.lblMaKhoa.Location = new System.Drawing.Point(24, 134);
            this.lblMaKhoa.Size = new System.Drawing.Size(130, 24);

            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Location = new System.Drawing.Point(164, 63);
            this.txtMaLop.Size = new System.Drawing.Size(380, 23);
            this.txtMaLop.MaxLength = 10;
            this.txtMaLop.TabIndex = 0;
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Location = new System.Drawing.Point(164, 97);
            this.txtTenLop.Size = new System.Drawing.Size(380, 23);
            this.txtTenLop.MaxLength = 100;
            this.txtTenLop.TabIndex = 1;
            this.txtMaKhoa.Name = "txtMaKhoa";
            this.txtMaKhoa.Location = new System.Drawing.Point(164, 131);
            this.txtMaKhoa.Size = new System.Drawing.Size(380, 23);
            this.txtMaKhoa.MaxLength = 10;
            this.txtMaKhoa.TabIndex = 2;

            this.btnThem.Name = "btnThem";
            this.btnThem.Text = "Thêm";
            this.btnThem.Location = new System.Drawing.Point(164, 172);
            this.btnThem.Size = new System.Drawing.Size(90, 32);
            this.btnThem.TabIndex = 3;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(264, 172);
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Name = "btnSua";
            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new System.Drawing.Point(364, 172);
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.TabIndex = 5;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new System.Drawing.Point(464, 172);
            this.btnLamMoi.Size = new System.Drawing.Size(90, 32);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.lblHint.Text = "Xóa: chỉ nhập mã lớp. Sửa: nhập mã lớp và ít nhất tên lớp hoặc mã khoa.";
            this.lblHint.Location = new System.Drawing.Point(24, 219);
            this.lblHint.Size = new System.Drawing.Size(710, 26);
            this.lblList.Text = "Danh sách lớp đang lưu";
            this.lblList.Location = new System.Drawing.Point(24, 252);
            this.lblList.Size = new System.Drawing.Size(680, 24);
            this.grid.Name = "grid";
            this.grid.Location = new System.Drawing.Point(24, 280);
            this.grid.Size = new System.Drawing.Size(712, 250);
            this.grid.Anchor = System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.grid.ReadOnly = true;
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.MultiSelect = false;
            this.grid.RowHeadersVisible = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grid.TabIndex = 7;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ClientSize = new System.Drawing.Size(760, 554);
            this.MinimumSize = new System.Drawing.Size(776, 593);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "LopForm";
            this.Text = "Lab06a - Bài 2 - Quản lý lớp";
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblMaLop, this.lblTenLop, this.lblMaKhoa,
                this.txtMaLop, this.txtTenLop, this.txtMaKhoa, this.btnThem,
                this.btnXoa, this.btnSua, this.btnLamMoi, this.lblHint, this.lblList, this.grid });
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
