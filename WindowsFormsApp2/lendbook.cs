using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class lendbook : Form
    {
        public string readerid = null;
        public string readername = null;
        public string bookid = null;
        public string bookname = null;
        public string lenddate = null;
        public string returndate = null;
        public lendbook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bookid == null || bookid == "")
            {
                MessageBox.Show("图书编号不能为空", "提示");
                return;
            }
            if (bookname == null || bookname == "")
            {
                MessageBox.Show("图书名称不能为空", "提示");
                return;
            }
            if (readername == null || readername == "")
            {
                MessageBox.Show("读者名称不能为空", "提示");
                return;
            }
            if (readerid == null || readerid == "")
            {
                MessageBox.Show("读者编号不能为空", "提示");
                return;
            }
            lenddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  //以字符串格式化记录记录开户时间
            returndate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd HH:mm:ss");  //以字符串格式化记录归还时间,30天
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
            MySqlConnection conn = new MySqlConnection(connstr);
            MySqlCommand cmd = conn.CreateCommand();
            //MySqlConnection conn1 = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                cmd.CommandText = "INSERT INTO lendrecord (bookid, bookname ,readerid, readername, lenddate, returndate) VALUES (@bookid, @bookname, @readerid, @readername, @lenddate, @returndate)";
                cmd.Parameters.AddWithValue("@bookid", bookid);
                cmd.Parameters.AddWithValue("@bookname", bookname);
                cmd.Parameters.AddWithValue("@readerid", readerid);
                cmd.Parameters.AddWithValue("@readername", readername);
                cmd.Parameters.AddWithValue("@lenddate", lenddate);
                cmd.Parameters.AddWithValue("@returndate", returndate);
                cmd.ExecuteNonQuery();  //将记录添加到 lendrecord ，每条记录对应唯一bookid
                //cmd.CommandText = "UPDATE book SET state = @state WHERE id='@id';";
                //cmd.Parameters.AddWithValue("@state", 1);
                //cmd.Parameters.AddWithValue("@id", bookid);
                //cmd.ExecuteNonQuery();  //将图书状态置为 流通
                cmd.CommandText = "UPDATE book SET state = "+1+" WHERE id='"+bookid+"';";
                //cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("借阅成功", "提示");
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //conn1.Close();
                conn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            readerid = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            readername = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            bookid = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            bookname = textBox4.Text;
        }
    }
}
