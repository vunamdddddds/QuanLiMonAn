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
    public partial class Form3 : Form
    {
        string cntion = "Data Source=DESKTOP-MI1NE8C\\SQLEXPRESS;Initial Catalog=quanlimonan;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();


        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(cntion);
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandText = "insert into taikhoan values(@username,@pass)";
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                int password;
                if (textBox1.Text!="" && textBox2.Text!="")
                {
                    if (Int32.TryParse(textBox2.Text, out password))
                    {
                        cmd.Parameters.AddWithValue("@pass", password);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đăng kí thành công");
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu phải là số nguyên. Vui lòng nhập lại.");
                    }
                }
                else { MessageBox.Show("không bỏ trống dòng nào"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("tên tài khoản đã được đăng kí " );
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string query = "SELECT COUNT(*) FROM taikhoan WHERE username = @id AND pass = @pass";   
            using (SqlConnection connection = new SqlConnection(cntion))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    command.Parameters.AddWithValue("@id", textBox1.Text); 
                    command.Parameters.AddWithValue("@pass", textBox2.Text);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();  
                    if (count > 0 && textBox1.Text != "" && textBox2.Text != "")
                    {
                        this.Hide();
                        Form2 form1 = new Form2();
                        form1.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("ID hoặc mật khẩu không đúng, vui lòng thử lại.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Focus();
                    }
                }
                catch (Exception ex) { MessageBox.Show("mật khẩu dạng số nguyên");
                    textBox2.Focus();   
               }





            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
