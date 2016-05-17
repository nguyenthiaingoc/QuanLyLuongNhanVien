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
  public partial class ThanhToan : Form
  {
    private SqlDataAdapter mDataAdapter;
    private DataSet ds = new DataSet();
    private DataTable dt = new DataTable();
    private string mMaNV;

    public ThanhToan()
    {
      InitializeComponent();
    }

    private void HienThiDataGrid()
    {
      try
      {
        var sql = @"
        SELECT a.MaNhanVien
        , HoDem
        , Ten
        , PhongBan
        , ChucVu
        , SoTienLuong
        ,ThanhToan
        FROM bLuong a
        LEFT JOIN bThongTinNhanVien b
        ON a.MaNhanVien = b.MaNhanVien";

        using (var conn = Helper.getConnection())
        {
          conn.Open();
          mDataAdapter = new SqlDataAdapter(new SqlCommand(sql, conn));

          DataSet ds = new DataSet();
          mDataAdapter.Fill(ds, "Luong");
          dtGrid_TTL.DataSource = ds.Tables["Luong"].DefaultView;
          conn.Close();
        }


      }
      catch (Exception excep)
      {
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
    }

    private void ThanhToan_Load(object sender, EventArgs e)
    {
      HienThiDataGrid();
    }

    private void btnTim_Click(object sender, EventArgs e)
    {
      string TKMaNV = txtTimMa.Text;
      string TKTenNV = txtTimTen.Text;
      try
      {
        using (var conn = Helper.getConnection())
        {
          var sql = string.Format(@"
            SELECT
              a.MaNhanVien
            , HoDem
            , Ten
            , PhongBan
            , ChucVu
            , SoTienLuong
            , ThanhToan
            FROM bLuong a
            LEFT JOIN bThongTinNhanVien b
            ON a.MaNhanVien = b.MaNhanVien
            WHERE b.MaNhanVien ='{0}' OR b.Ten like '%{1}%'", TKMaNV, TKTenNV);
          conn.Open();
          mDataAdapter = new SqlDataAdapter(new SqlCommand(sql, conn));

          DataSet ds = new DataSet();
          mDataAdapter.Fill(ds, "TimLuong");
          dtGrid_TTL.DataSource = ds.Tables["TimLuong"].DefaultView;
          conn.Close();
        }
      }
      catch (Exception excep)
      {
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
    }

    private void btnLuu_Click(object sender, EventArgs e)
    {
      try
      {
        var sql = string.Format("Update bLuong set ThanhToan={0} where MaNhanVien='{1}'",
          chbThanhToan.Checked == true ? 1 : 0, mMaNV);
        using (var conn = Helper.getConnection())
        {
          conn.Open();
          var commnd = new SqlCommand(sql, conn);
          commnd.ExecuteNonQuery();
          conn.Close();
        }
        HienThiDataGrid();
        MessageBox.Show("Đã Cập Nhật Cơ Sở Dữ Liệu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception excep)
      {
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
    }

    private void btnXem_Click(object sender, EventArgs e)
    {
      if (dtGrid_TTL.CurrentRow != null)
      {
        string check = dtGrid_TTL.Rows[dtGrid_TTL.CurrentRow.Index].Cells[6].Value.ToString();
        chbThanhToan.Checked = Convert.ToBoolean(check);

        mMaNV = dtGrid_TTL.Rows[dtGrid_TTL.CurrentRow.Index].Cells[0].Value.ToString();
      }
    }
  }
}