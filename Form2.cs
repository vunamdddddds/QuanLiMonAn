using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyMonAn
{
    public partial class Form2 : Form
    {

        SqlCommand cmd;
        string connectionString = @"Data Source=DESKTOP-MI1NE8C\SQLEXPRESS;Initial Catalog=quanlimonan;Integrated Security=True;TrustServerCertificate=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlConnection conn;
        DataTable dt = new DataTable();

        public Form2()
        {
            InitializeComponent();
        }
        private void loaddata()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM monan";
            adapter.SelectCommand = cmd;
            dt.Clear();

            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);

            try
            {
                // Mở kết nối
                conn.Open();
                // Tải dữ liệu
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Đảm bảo rằng kết nối được đóng khi không sử dụng
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {conn=new SqlConnection(connectionString);
            try { 
            conn.Open();
                cmd=conn.CreateCommand();
                cmd.CommandText = "insert into monan(id,tenmonan,mota,giaban,donvitinh)values (@id,@name,@mota,@giaban,@donvitinh)";
                cmd.Parameters.AddWithValue("@id",id.Text);
                cmd.Parameters.AddWithValue("@name",name.Text);
                cmd.Parameters.AddWithValue("@mota",mota.Text);
                cmd.Parameters.AddWithValue("@giaban",giaban.Text);
                cmd.Parameters.AddWithValue("@donvitinh",donvitinh.Text);
                cmd.ExecuteNonQuery();
                loaddata();


            
            } catch(Exception ex) { MessageBox.Show("error:"+ex); } finally {

                if (conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is not on a header row
            if (e.RowIndex >= 0)
            {
                // Safely retrieve the current row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Safely assign values to text fields
                id.Text = selectedRow.Cells[0].Value?.ToString() ?? string.Empty;
                name.Text = selectedRow.Cells[1].Value?.ToString() ?? string.Empty;
                mota.Text = selectedRow.Cells[2].Value?.ToString() ?? string.Empty;
                giaban.Text = selectedRow.Cells[3].Value?.ToString() ?? string.Empty;
                donvitinh.Text = selectedRow.Cells[4].Value?.ToString() ?? string.Empty;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();

                cmd = conn.CreateCommand();
                cmd.CommandText = "delete from monan where id=@id";

                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.ExecuteNonQuery();
                loaddata();
            }
            catch (Exception ex) { MessageBox.Show("error: " + ex); }
            finally {
                if (conn.State==ConnectionState.Open) { conn.Close(); }
            
            
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn=new SqlConnection(connectionString);



            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandText = "update  monan set tenmonan=@ten,mota=@mota,giaban=@giaban,donvitinh=@dvt where id=@id";
                cmd.Parameters.AddWithValue("@id",id.Text);
                cmd.Parameters.AddWithValue("@ten", name.Text);
                cmd.Parameters.AddWithValue("@mota", mota.Text);
                cmd.Parameters.AddWithValue("@giaban", giaban.Text);
                cmd.Parameters.AddWithValue("@dvt", donvitinh.Text);
                cmd.ExecuteNonQuery();
                loaddata();



            }
            catch (Exception ex) { MessageBox.Show("error:" + ex); }
            finally { if (conn.State == ConnectionState.Open) {                 
               conn.Close();


} }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();

                // Khởi tạo câu lệnh SQL với điều kiện tìm kiếm
                string query = "SELECT * FROM monan WHERE 1=1";

                if (!string.IsNullOrEmpty(id.Text))
                {
                    query += " AND id LIKE @id";
                    cmd.Parameters.AddWithValue("@id", id.Text );
                }

                if (!string.IsNullOrEmpty(name.Text))
                {
                    query += " AND tenmonan LIKE @name";
                    cmd.Parameters.AddWithValue("@name",  name.Text );
                }

                if (!string.IsNullOrEmpty(mota.Text))
                {
                    query += " AND mota LIKE @mota";
                    cmd.Parameters.AddWithValue("@mota",  mota.Text );
                }

                if (!string.IsNullOrEmpty(giaban.Text))
                {
                    query += " AND giaban LIKE @giaban";
                    cmd.Parameters.AddWithValue("@giaban",  giaban.Text );
                }

                if (!string.IsNullOrEmpty(donvitinh.Text))
                {
                    query += " AND donvitinh LIKE @donvitinh";
                    cmd.Parameters.AddWithValue("@donvitinh",  donvitinh.Text );
                }

                cmd.CommandText = query;

                dt.Clear();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            id.Text = "";
            mota.Text = "";
            name.Text = "";
            giaban.Text = "";
            donvitinh.Text = "";
            loaddata();
        }
    }
}
