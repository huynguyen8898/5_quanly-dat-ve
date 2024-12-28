using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;


namespace _5_quanly_dat_ve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string dulieu = @"Data Source=LAPTOP-QJB0H525;Initial Catalog=baitaplon;Integrated Security=True;Encrypt=False";
        SqlConnection ketnoi;
        SqlDataAdapter da;
        SqlCommand th;
        DataTable dt;
        string sql;


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(dulieu);
            hienthi();
            
        }
        public void hienthi()
        {
            SqlConnection ketnoi = new SqlConnection(dulieu);
       
            sql = @"select *from quaanlydatve";
            SqlCommand th = new SqlCommand(sql, ketnoi);
            SqlDataAdapter da = new SqlDataAdapter(th);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
         
        }
        private void them_Click(object sender, EventArgs e)
        {

            
            SqlConnection ketnoi = new SqlConnection(dulieu);
            ketnoi.Open(); string sql = @"INSERT INTO quaanlydatve VALUES (@idmadatve, @idmakhachhang, @idmave, @ngaydat, @soluong)"; 
            using (SqlCommand th = new SqlCommand(sql, ketnoi)) 
            { th.Parameters.AddWithValue("@idmadatve", txtmadatve.Text); 
                th.Parameters.AddWithValue("@idmakhachhang", txtmakhachhang.Text);
                th.Parameters.AddWithValue("@idmave", txtmave.Text);
                th.Parameters.AddWithValue("@ngaydat", DateTime.Parse(txtngaydat.Text)); 
                th.Parameters.AddWithValue("@soluong", int.Parse(txtsoluong.Text));
                th.ExecuteNonQuery(); }
            MessageBox.Show("Thêm thành công");
            hienthi();
            ketnoi.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            int sodong = -1;
            sodong = dataGridView1.CurrentCell.RowIndex;
            if (sodong >= 0)
            {
                txtmadatve.Text = dataGridView1[0,sodong].Value.ToString();
               txtmakhachhang.Text = dataGridView1[1,sodong].Value.ToString();
                txtmave.Text = dataGridView1[2, sodong].Value.ToString();
                txtngaydat.Text = dataGridView1[3, sodong].Value.ToString();
                txtsoluong.Text = dataGridView1[4, sodong].Value.ToString();



            }
            
       }

        private void capnhat_Click(object sender, EventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(dulieu);
            ketnoi.Open();
            sql = @"update quaanlydatve set iddatve=@iddatve,idkhachhang=@idkhachhang,idve=@idve,ngaydat=@ngaydat,soluongve=@soluongve where iddatve=@iddatve";
            SqlCommand th= new SqlCommand(sql,ketnoi);
            th.Parameters.AddWithValue("@iddatve", txtmadatve.Text);
            th.Parameters.AddWithValue("@idkhachhang", txtmakhachhang.Text);
            th.Parameters.AddWithValue("@idve", txtmave.Text);
            th.Parameters.AddWithValue("@ngaydat", DateTime.Parse(txtngaydat.Text));
            th.Parameters.AddWithValue("@soluongve",int.Parse( txtsoluong.Text));
            th.ExecuteNonQuery();
            MessageBox.Show("Cập nhật thành công");
            hienthi();
            ketnoi.Close();
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            SqlConnection ketnoi=new SqlConnection(dulieu);
            ketnoi.Open();
            sql = @"delete from quaanlydatve where iddatve='"+txtmadatve.Text+"'";
            SqlCommand th=new SqlCommand(sql,ketnoi);
            if (MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                th.ExecuteNonQuery();
            }
            ketnoi.Close();
            hienthi();
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            SqlConnection ketnoi=new SqlConnection(dulieu);
            ketnoi.Open();
            sql= @"select* from quaanlydatve where (iddatve like'%" + txttimkiem.Text +"%')";
            th=new SqlCommand(sql,ketnoi);
            SqlDataAdapter da=new SqlDataAdapter(th);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
          
            
            ketnoi.Close();
         
        }

        private void txtmakhachhang_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmave_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
