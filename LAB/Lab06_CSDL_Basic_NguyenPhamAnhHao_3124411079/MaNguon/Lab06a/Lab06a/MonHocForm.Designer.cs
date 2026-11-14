namespace Lab06a
{
    partial class MonHocForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblList;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        // Phần dựng giao diện được tách khỏi các hàm xử lý sự kiện trong .cs.
        private void InitializeComponent()
        {
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMa = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblList = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.Text = "QUẢN LÝ MÔN HỌC";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Size = new System.Drawing.Size(690, 32);
            this.lblMa.Text = "Mã môn học";
            this.lblMa.Location = new System.Drawing.Point(24, 66);
            this.lblMa.Size = new System.Drawing.Size(130, 24);
            this.lblTen.Text = "Tên môn học";
            this.lblTen.Location = new System.Drawing.Point(24, 100);
            this.lblTen.Size = new System.Drawing.Size(130, 24);

            this.txtMa.Name = "txtMa";
            this.txtMa.Location = new System.Drawing.Point(164, 63);
            this.txtMa.Size = new System.Drawing.Size(380, 23);
            this.txtMa.MaxLength = 10;
            this.txtMa.TabIndex = 0;
            this.txtTen.Name = "txtTen";
            this.txtTen.Location = new System.Drawing.Point(164, 97);
            this.txtTen.Size = new System.Drawing.Size(380, 23);
            this.txtTen.MaxLength = 100;
            this.txtTen.TabIndex = 1;

            this.btnThem.Name = "btnThem";
            this.btnThem.Text = "Thêm";
            this.btnThem.Location = new System.Drawing.Point(164, 138);
            this.btnThem.Size = new System.Drawing.Size(90, 32);
            this.btnThem.TabIndex = 2;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(264, 138);
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Name = "btnSua";
            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new System.Drawing.Point(364, 138);
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.TabIndex = 4;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new System.Drawing.Point(464, 138);
            this.btnLamMoi.Size = new System.Drawing.Size(90, 32);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.lblHint.Text = "Xóa: chỉ nhập mã. Thêm/Sửa: nhập đủ mã và tên môn học.";
            this.lblHint.Location = new System.Drawing.Point(24, 185);
            this.lblHint.Size = new System.Drawing.Size(700, 26);
            this.lblList.Text = "Danh sách môn học đang lưu";
            this.lblList.Location = new System.Drawing.Point(24, 218);
            this.lblList.Size = new System.Drawing.Size(680, 24);
            this.grid.Name = "grid";
            this.grid.Location = new System.Drawing.Point(24, 246);
            this.grid.Size = new System.Drawing.Size(712, 252);
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
            this.grid.TabIndex = 6;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ClientSize = new System.Drawing.Size(760, 522);
            this.MinimumSize = new System.Drawing.Size(776, 561);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "MonHocForm";
            this.Text = "Lab06a - Bài 1 - Quản lý môn học";
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblMa, this.lblTen, this.txtMa, this.txtTen,
                this.btnThem, this.btnXoa, this.btnSua, this.btnLamMoi,
                this.lblHint, this.lblList, this.grid });
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
