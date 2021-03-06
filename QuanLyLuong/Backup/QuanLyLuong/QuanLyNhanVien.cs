using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyLuong
{
    public partial class QuanLyNhanVien : Form
    {
        private SqlConnection conn;        
        private SqlDataAdapter da;
        private DataSet ds = new DataSet();
        private int GioiTinh;
        private DataTable dt = new DataTable();
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyTienLuongDataSet1.bTroCap' table. You can move, or remove it, as needed.
            this.bTroCapTableAdapter.Fill(this.quanLyTienLuongDataSet1.bTroCap);
            // TODO: This line of code loads data into the 'quanLyTienLuongDataSet.bBacLuong' table. You can move, or remove it, as needed.
            this.bBacLuongTableAdapter.Fill(this.quanLyTienLuongDataSet.bBacLuong);
 
            HienThiDuLieuXemTruoc();

        }
        private void HienThiDuLieuXemTruoc()
        {
            try
            {
                conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                conn.Open();
                SqlCommand commnd;
                commnd = new SqlCommand("select MaNhanVien,HoDem,Ten,NgaySinh,GioiTinh,PhongBan,ChucVu,DiaChi,DienThoai,CMND,EMail,TenBacLuong,TenTroCap from bThongTinNhanVien a left join bBacLuong b ON a.MaBacLuong=b.MaBacLuong left join bTroCap c ON a.MaTroCap=c.MaTroCap", conn);
                da = new SqlDataAdapter(commnd);
                DataSet ds = new DataSet();
                da.Fill(ds, "NhanVien");

                DataGV.DataSource = ds.Tables["NhanVien"].DefaultView;
                conn.Close();

            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                MessageBox.Show(excep.StackTrace);
            }

        }

        private void btnLuuSua_Click(object sender, EventArgs e)
        {
            if (CheckData() == true)
            {
                //Gia Tri Cac O TextBox dc gan cho cac bien trung gian

                string MNV = txtMaNhanVien.Text;
                string HD = txtHoDem.Text;
                string Ten = txtTen.Text;
                string PB = cbPhongBan.Text;
                string CV = txtChucVu.Text;
                string DC = txtDiaChi.Text;
                int SoDT = Convert.ToInt32(txtDienThoai.Text);
                int CMND = Convert.ToInt32(txtCMND.Text);
                string NS = txtNgaySinh.Text;
                string Email = txtEmail.Text;
                string BL = cbBacLuong.Text;
                string TC = cbTroCap.Text;
                if (rdNam.Checked == true)
                {
                    GioiTinh = 1;
                }
                else
                {
                    GioiTinh = 0;
                }

                //Lấy ra mã bậc lương và mã trợ cấp từ tên BLuong và tên TCap

                conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                conn.Open();
                SqlCommand commnd;
                commnd = new SqlCommand("select MaBacLuong,MaTroCap from bBacLuong,bTroCap where TenBacLuong='" + BL + "' and TenTroCap='" + TC + "'", conn);
                da = new SqlDataAdapter(commnd);
                DataSet ds = new DataSet();
                da.Fill(ds, "MaBLvaTC");
                dt = ds.Tables["MaBLvaTC"];
                string MaBL = dt.Rows[0]["MaBacLuong"].ToString();
                string MaTC = dt.Rows[0]["MaTroCap"].ToString();
                //string MaNC = "";  //Ma Ngay Cong tam thoi cho =null
                conn.Close();

                try
                {
                    conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                    conn.Open();
                    SqlCommand commndUpdate;
                    string Sqlcomnd = "Update bThongTinNhanVien Set HoDem='" + HD + "',Ten ='" + Ten + "',NgaySinh='" + NS + "',GioiTinh=" + GioiTinh + ",PhongBan='" + PB + "',ChucVu='" + CV + "',DiaChi='" + DC + "',DienThoai=" + SoDT + ",CMND=" + CMND + ",Email='" + Email + "',MaBacLuong='" + MaBL + "',MaTroCap='" + MaTC + "'where MaNhanVien='" + MNV + "'";
                    commndUpdate = new SqlCommand(Sqlcomnd, conn);
                    commndUpdate.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    MessageBox.Show(excep.StackTrace);
                }


                HienThiDuLieuXemTruoc();
                MessageBox.Show("Đã Cập Nhật Dữ Liệu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
        }

        public void ResetField()
        {
            txtMaNhanVien.Text = "";
            txtHoDem.Text = "";
            txtTen.Text = "";
            cbPhongBan.Text = "";
            txtChucVu.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtCMND.Text = "";
            txtNgaySinh.Text = "";
            txtEmail.Text = "";
            cbBacLuong.Text = "";
            cbTroCap.Text = "";
            rdNam.Checked = true;
            rdNu.Checked = false;

        }

        //Hàm kiểm tra thông tin nhập liệu
        public Boolean CheckData()
        {
            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Mã Nhân Viên Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNhanVien.Focus();
                return false;
            }
            if (txtHoDem.Text == "")
            {
                MessageBox.Show("Họ Đệm Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoDem.Focus();
                return false;
            }
            if (txtTen.Text == "")
            {
                MessageBox.Show("Tên Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return false;
            }
            if (cbPhongBan.Text == "")
            {
                MessageBox.Show("Phòng Ban Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbPhongBan.Focus();
                return false;
            }
            if (txtChucVu.Text == "")
            {
                MessageBox.Show("Chức Vụ Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChucVu.Focus();
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa Chỉ Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return false;
            }
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Điện Thoại Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDienThoai.Focus();
                return false;
            }
            try
            {
                int i = Convert.ToInt32(txtDienThoai.Text);
            }
            catch
            {
                MessageBox.Show("Điện Thoại Ko Phải Là Kiểu Số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDienThoai.Focus();
                return false;
            }
            if (txtCMND.Text == "")
            {
                MessageBox.Show("Số CMND Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCMND.Focus();
                return false;
            }
            try
            {
                int j = Convert.ToInt32(txtCMND.Text);
            }
            catch
            {
                MessageBox.Show("số CMND Ko Phải Là Kiểu Số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCMND.Focus();
                return false;
            }
            if (txtNgaySinh.Text == "")
            {
                MessageBox.Show("Ngày Sinh Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgaySinh.Focus();
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Email Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            if (cbBacLuong.Text == "")
            {
                MessageBox.Show("Bậc Lương Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbBacLuong.Focus();
                return false;
            }
            if (cbTroCap.Text == "")
            {
                MessageBox.Show("Trợ Cấp Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbTroCap.Focus();
                return false;
            }
            if (rdNam.Checked == false && rdNu.Checked == false)
            {
                MessageBox.Show("Chưa Chọn Giới Tính Cho Nhân Viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetField();
            HienThiDuLieuXemTruoc();
        }

        private void rdNam_CheckedChanged(object sender, EventArgs e)
        {
            GioiTinh = 1;
        }

        private void rdNu_CheckedChanged(object sender, EventArgs e)
        {
            GioiTinh = 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (CheckData() == true)
            {
                //Gia Tri Cac O TextBox dc gan cho cac bien trung gian
                //GiaTriTextBox();
                string MNV = txtMaNhanVien.Text;
                string HD = txtHoDem.Text;
                string Ten = txtTen.Text;
                string PB = cbPhongBan.Text;
                string CV = txtChucVu.Text;
                string DC = txtDiaChi.Text;
                int SoDT = Convert.ToInt32(txtDienThoai.Text);
                int CMND = Convert.ToInt32(txtCMND.Text);
                string NS = txtNgaySinh.Text;
                string Email = txtEmail.Text;
                string BL = cbBacLuong.Text;
                string TC = cbTroCap.Text;
                if (rdNam.Checked == true)
                {
                    GioiTinh = 1;
                }
                else
                {
                    GioiTinh = 0;
                }
                //Lấy ra mã bậc lương và mã trợ cấp từ tên BLuong và tên TCap
                //MaBLvaTC();
                //Lấy ra mã bậc lương và mã trợ cấp từ tên BLuong và tên TCap
                conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                conn.Open();
                SqlCommand commnd;
                commnd = new SqlCommand("select MaBacLuong,MaTroCap from bBacLuong,bTroCap where TenBacLuong='" + BL + "' and TenTroCap='" + TC + "'", conn);
                da = new SqlDataAdapter(commnd);
                DataSet ds = new DataSet();
                da.Fill(ds, "MaBLvaTC");
                DataTable dtMaBLvaTc;
                dtMaBLvaTc = ds.Tables["MaBLvaTC"];
                string MaBL = dtMaBLvaTc.Rows[0]["MaBacLuong"].ToString();
                string MaTC = dtMaBLvaTc.Rows[0]["MaTroCap"].ToString();
                //string MaNC = "";  //Ma Ngay Cong tam thoi cho =null
                //string MaThuong = "";
                //string MaKhauTru = "";
                //string MaLuong = "";
                conn.Close();

                //Lưu Lại Dữ Liệu Đã Cập Nhật Cho Chương Trình
                try
                {
                    conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                    conn.Open();
                    //Insert Data vào bThongTinNhanVien
                    SqlCommand commndInsert;
                    string sqlcomnd = "Insert into bThongTinNhanVien(MaNhanVien,HoDem,Ten,Ngaysinh,GioiTinh,PhongBan,ChucVu,DiaChi,DienThoai,CMND,Email,MaBacLuong,MaTroCap) values('" + MNV + "','" + HD + "','" + Ten + "','" + NS + "'," + GioiTinh + ",'" + PB + "','" + CV + "','" + DC + "'," + SoDT + "," + CMND + ",'" + Email + "','" + MaBL + "','" + MaTC + "')";
                    commndInsert = new SqlCommand(sqlcomnd, conn);
                    commndInsert.ExecuteNonQuery();

                    //Khoi Tao 1 Gia Tri Tuong ung voi Ma Nhan Vien do trong bang bLuong
                    SqlCommand commndInsert_bLuong;
                    string sqlcomnd_bLuong = "Insert into bLuong(MaNhanVien) values ('"+MNV+"')";
                    commndInsert_bLuong = new SqlCommand(sqlcomnd_bLuong, conn);
                    commndInsert_bLuong.ExecuteNonQuery();
                    
                    //Thong Bao Da Hoan Thanh
                    MessageBox.Show("Đã Thêm 1 Bản Ghi Vào CSDL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetField();
                    conn.Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    MessageBox.Show(excep.StackTrace);

                }
                HienThiDuLieuXemTruoc();

            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string TKMaNV = txtTimMa.Text;
            string TKTenNV = txtTimTen.Text;
            try
            {
                conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                conn.Open();
                SqlCommand commnd;
                commnd = new SqlCommand("select MaNhanVien,HoDem,Ten,NgaySinh,GioiTinh,PhongBan,ChucVu,DiaChi,DienThoai,CMND,EMail,TenBacLuong,TenTroCap from bThongTinNhanVien a left join bBacLuong b ON a.MaBacLuong=b.MaBacLuong left join bTroCap c ON a.MaTroCap=c.MaTroCap where  MaNhanVien ='" + TKMaNV + "' or Ten like'" + TKTenNV + "'", conn);
                da = new SqlDataAdapter(commnd);
                DataSet ds = new DataSet();
                da.Fill(ds, "TimKiem");
                DataGV.DataSource = ds.Tables["TimKiem"].DefaultView;
                conn.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                MessageBox.Show(excep.StackTrace);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (DataGV.CurrentRow != null)
            {             
                if (MessageBox.Show("Bạn đã chắc chắn sẽ xóa bản ghi này chứ!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string MaNV = DataGV.Rows[DataGV.CurrentRow.Index].Cells[0].Value.ToString();
                    conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                    conn.Open();
                    SqlCommand commnd;
                    SqlCommand commnd1;
                    // Xóa bản ghi trong bảng bLuong trước khi xóa bản ghi trong bản bThongTinNhanVien
                    commnd1 = new SqlCommand("Delete bLuong where MaNhanVien='" + MaNV + "'", conn);
                    commnd = new SqlCommand("Delete bThongTinNhanVien where MaNhanVien='" + MaNV + "'", conn);
                    commnd1.ExecuteNonQuery();
                    commnd.ExecuteNonQuery();
                    conn.Close();
                    HienThiDuLieuXemTruoc();
                }
            } 
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DateTime dt;
            if (DataGV.CurrentRow != null)
            {
                txtMaNhanVien.Text = DataGV.Rows[DataGV.CurrentRow.Index].Cells[0].Value.ToString();
                txtHoDem.Text = DataGV.Rows[DataGV.CurrentRow.Index].Cells[1].Value.ToString();
                txtTen.Text = DataGV.Rows[DataGV.CurrentRow.Index].Cells[2].Value.ToString();
                dt = Convert.ToDateTime(DataGV.Rows[DataGV.CurrentRow.Index].Cells[3].Value.ToString());
                txtNgaySinh.Text = dt.ToShortDateString();
                string check = DataGV.Rows[DataGV.CurrentRow.Index].Cells[4].Value.ToString();
                rdNam.Checked = Convert.ToBoolean(check);
                rdNu.Checked = !Convert.ToBoolean(check);

                cbPhongBan.Text = DataGV.Rows[DataGV.CurrentRow.Index].Cells[5].Value.ToString();
                txtChucVu.Text = DataGV.Rows[DataGV.CurrentRow.Index].Cells[6].Value.ToString();
                txtDiaChi.Text = DataGV.Rows[DataGV.CurrentRow.Index].Cells[7].Value.ToString();
                txtDienThoai.Text = DataGV.Rows[DataGV.CurrentRow.Index].Cells[8].Value.ToString();
                txtCMND.Text = DataGV.Rows[DataGV.CurrentRow.Index].Cells[9].Value.ToString();
                txtEmail.Text = DataGV.Rows[DataGV.CurrentRow.Index].Cells[10].Value.ToString();
                cbBacLuong.Text = DataGV.Rows[DataGV.CurrentRow.Index].Cells[11].Value.ToString();
                cbTroCap.Text = DataGV.Rows[DataGV.CurrentRow.Index].Cells[12].Value.ToString();
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtNgaySinh.Text = dateTimePicker1.Value.ToShortDateString();
        }

    }
}