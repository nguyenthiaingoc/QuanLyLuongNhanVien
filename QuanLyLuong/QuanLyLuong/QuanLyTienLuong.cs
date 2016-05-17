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
  public partial class QuanLyTienLuong : Form
  {
    private SqlConnection conn;
    private SqlDataAdapter mDataAdapter;
    private DataSet ds = new DataSet();
    private DataTable dt = new DataTable();
    private string MaNV;

    private const string sqlGrid = @"
          SELECT a.MaNhanVien
          , HoDem
          , Ten
          , PhongBan
          , ChucVu
          , TenBacLuong
          , TenTroCap
          , a.MaNgayCong
          , TenThuong
          , TenKhauTru
          , SoTienLuong
          , ThanhToan
          FROM bThongTinNhanVien a
          LEFT JOIN bBacLuong b ON a.MaBacLuong = b.MaBacLuong
          LEFT JOIN bTroCap c ON a.MaTroCap = c.MaTroCap
          LEFT JOIN bNgayCong d ON a.MaNgayCong = d.MaNgayCong
          LEFT JOIN bThuong e ON a.MaThuong = e.MaThuong
          LEFT JOIN bKhauTru f ON a.MaKhauTru = f.MaKhauTru
          LEFT JOIN bLuong g ON a.MaNhanVien = g.MaNhanVien";

    public QuanLyTienLuong()
    {
      InitializeComponent();
    }

    private void QuanLyTienLuong_Load(object sender, EventArgs e)
    {
      this.quanLyTienLuongDataSet.EnforceConstraints = false;
      bKhauTruTableAdapter.Fill(this.quanLyTienLuongDataSet.bKhauTru);
      bThuongTableAdapter.Fill(this.quanLyTienLuongDataSet.bThuong);
      bNgayCongTableAdapter.Fill(this.quanLyTienLuongDataSet.bNgayCong);
      bTroCapTableAdapter.Fill(this.quanLyTienLuongDataSet.bTroCap);
      bBacLuongTableAdapter.Fill(this.quanLyTienLuongDataSet.bBacLuong);
      HienDataGrid_QLTL();
    }

    private void HienDataGrid_QLTL()
    {
      try
      {
        using (var conn = Helper.getConnection())
        {
          conn.Open();
          mDataAdapter = new SqlDataAdapter(new SqlCommand(sqlGrid, conn));
          DataSet dataSet = new DataSet();
          mDataAdapter.Fill(dataSet, "NhanVien");
          dtGrid_QLTL.DataSource = dataSet.Tables["NhanVien"].DefaultView;
          conn.Close();
        }

      }
      catch (Exception excep)
      {
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
    }

    private void btnQLL_TimKiem_Click(object sender, EventArgs e)
    {
      string TKMaNV = txtTimMa.Text;
      string TKTenNV = txtTimTen.Text;
      try
      {
        var sql = sqlGrid + string.Format(" WHERE a.MaNhanVien = '{0}' OR a.Ten like '%{1}%'", TKMaNV, TKTenNV);
        using (var conn = Helper.getConnection())
        {
          conn.Open();

          mDataAdapter = new SqlDataAdapter(new SqlCommand(sql));
          DataSet ds = new DataSet();
          mDataAdapter.Fill(ds, "TimKiem");
          dtGrid_QLTL.DataSource = ds.Tables["TimKiem"].DefaultView;
          conn.Close();
        }
      }
      catch (Exception excep)
      {
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
    }
    private void btnQLL_Xem_Click(object sender, EventArgs e)
    {
      if (dtGrid_QLTL.CurrentRow != null)
      {
        MaNV = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[0].Value.ToString();
        txtHoDem.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[1].Value.ToString();
        txtTen.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[2].Value.ToString();
        cbPhongBan.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[3].Value.ToString();
        txtChucVu.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[4].Value.ToString();
        cbBacLuong.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[5].Value.ToString();
        cbTroCap.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[6].Value.ToString();
        cbNgayCong.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[7].Value.ToString();
        cbThuong.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[8].Value.ToString();
        cbKhauTru.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[9].Value.ToString();
        txtTongLuong.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[10].Value.ToString();
      }
      HienDataGrid_QLTL();
    }

    private void btnQLL_Tinh_Click(object sender, EventArgs e)
    {
      int BacLuong, TroCap, NgayCong, Thuong, KhauTru, TongLuong;
      BacLuong = Convert.ToInt32(cbBacLuong.SelectedValue.ToString());
      TroCap = Convert.ToInt32(cbTroCap.SelectedValue.ToString());
      NgayCong = Convert.ToInt32(cbNgayCong.SelectedValue.ToString());
      Thuong = Convert.ToInt32(cbThuong.SelectedValue.ToString());
      KhauTru = Convert.ToInt32(cbKhauTru.SelectedValue.ToString());
      TongLuong = ((BacLuong + TroCap) / 23) * NgayCong + Thuong - KhauTru;
      txtTongLuong.Text = TongLuong.ToString();
    }

    private void btnQLL_CapNhat_Click(object sender, EventArgs e)
    {
      if (txtTen.Text != "")
      {
        try
        {
          var sql = string.Format(@"
          SELECT MaBacLuong
          , MaTroCap
          , MaThuong
          , MaKhauTru
          FROM bBacLuong, bTroCap, bThuong, bKhauTru
          WHERE TenBacLuong='{0}' AND TenTroCap='{1}' AND TenThuong='{2}' AND TenKhauTru='{3}'",
            cbBacLuong.Text, cbTroCap.Text, cbThuong.Text, cbKhauTru.Text);

          //Tim MaThuong, MaTroCap, MaNgayCong, MaBacLuong, MaKhauTru cua 1 Nhan Vien
          using (var conn = Helper.getConnection())
          {
            using (var command = new SqlCommand(sql, conn))
            {
              conn.Open();
              using (var reader = command.ExecuteReader())
              {
                reader.Read();
                var MaBL = reader.GetString(reader.GetOrdinal("MaBacLuong"));
                var MaTC = reader.GetString(reader.GetOrdinal("MaTroCap"));
                var MaKT = reader.GetString(reader.GetOrdinal("MaKhauTru"));
                var MaT = reader.GetString(reader.GetOrdinal("MaThuong"));
                var MaNC = cbNgayCong.Text;

                sql = string.Format(@"
                UDPATE bThongTinNhanVien
                SET MaBacLuong='{0}', MaTroCap='{1}', MaNgayCong='{2}', MaThuong='{3}', MaKhauTru='{4}'
                WHERE MaNhanVien='{5}'", MaBL, MaTC, MaNC, MaT, MaKT, MaNV);

                var updateCommand = new SqlCommand(sql, conn);
                updateCommand.ExecuteNonQuery();

                //Kiem tra Nhan Vien ung voi MaNhanVien do da co luong trong bLuong hay chua!
                sql = string.Format(@"
                UDPATE bLuong
                SET SoTienLuong='{0}', ThanhToan = 0
                WHERE MaNhanVien='{1}'", Convert.ToInt32(txtTongLuong.Text), MaNV);

                var selectUpdate_bLuong = new SqlCommand(sql, conn);
                selectUpdate_bLuong.ExecuteNonQuery();
              }
            }
          }

          HienDataGrid_QLTL();

          MessageBox.Show("Đã Cập Nhật Dữ Liệu Thành Công!", "Thông Báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception excep)
        {
          MessageBox.Show(excep.Message);
          MessageBox.Show(excep.StackTrace);
        }
      }
    }
  }
}