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
  public partial class QuanTri : Form
  {
    private SqlDataAdapter da;
    private string mPhanQuyen;
    public QuanTri()
    {
      InitializeComponent();
    }

    private void btnQLNV_Click(object sender, EventArgs e)
    {
      QuanLyNhanVien frmQLNV = new QuanLyNhanVien();
      frmQLNV.Show();
    }

    private void btnQLL_Click(object sender, EventArgs e)
    {
      QuanLyTienLuong frmQLTL = new QuanLyTienLuong();
      frmQLTL.Show();
    }

    private void btnThanhToan_Click(object sender, EventArgs e)
    {
      ThanhToan frmTT = new ThanhToan();
      frmTT.Show();
    }

    private void btnBaoMatPQ_Click(object sender, EventArgs e)
    {
      BaoMatPhanQuyen frmBMPQ = new BaoMatPhanQuyen();
      frmBMPQ.Show();
    }

    private void QuanTri_Load(object sender, EventArgs e)
    {
      btnQLNV.Enabled = btnQLL.Enabled = btnTT.Enabled = btnBMPQ.Enabled = false;

      // Tu TenPhanQuyen Lay ra Ten Phan Quyen
      try
      {
        using (var conn = Helper.getConnection())
        {
          var sql = string.Format("Select TenPQ from bPhanQuyen where MaPQ='{0}'", BienTC.MaPhanQuyen.ToString());
          conn.Open();
          
          da = new SqlDataAdapter(new SqlCommand(sql, conn));
          DataSet ds = new DataSet();
          da.Fill(ds, "TenPQ");

          mPhanQuyen = ds.Tables["TenPQ"].Rows[0]["TenPQ"].ToString();

          conn.Close();
        }

        if (mPhanQuyen == "AD")
        {
          btnQLNV.Enabled = true;
          btnQLL.Enabled = true;
          btnTT.Enabled = true;
          btnBMPQ.Enabled = true;
        }
        else if (mPhanQuyen == "QLNV")
        {
          btnQLNV.Enabled = true;
          btnQLL.Enabled = false;
          btnTT.Enabled = false;
          btnBMPQ.Enabled = false;
        }
        else if (mPhanQuyen == "TTL")
        {
          btnQLNV.Enabled = false;
          btnQLL.Enabled = true;
          btnTT.Enabled = false;
          btnBMPQ.Enabled = false;
        }
        else if (mPhanQuyen == "TT")
        {
          btnQLNV.Enabled = false;
          btnQLL.Enabled = false;
          btnTT.Enabled = true;
          btnBMPQ.Enabled = false;
        }
      }
      catch (Exception excep)
      {
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }

    }

    private void btnTroGiup_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Phần mềm được xây dựng bởi Nguyễn Thị Ái Ngọc, Trần Minh Giàu. Mọi thắc mắc liên hệ mail Giautm@gmail.com và NguyenThiAiNgoc@viendong.edu.vn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


    private void QuanTri_FormClosed(object sender, FormClosedEventArgs e)
    {
      Application.Exit();
    }

  }
}