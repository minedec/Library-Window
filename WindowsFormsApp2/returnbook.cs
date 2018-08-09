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
    public partial class returnbook : Form
    {
        public string readerid = null;
        public string readername = null;
        public string bookid = null;
        public string bookname = null;
        public string lenddate = null;
        public string returndate = null;
        public string id = null;
        public returnbook()
        {
            InitializeComponent();
        }

        private String SetId()
        {
            DateTime dt = DateTime.Now;
            StringBuilder rid = new StringBuilder();
            String pid = null;
            rid.Append(string.Format("{0:yyyyMMddHHmmss}", dt));  //记录时间
            rid.Append(bookid + readerid);  //记录书号，读者号
            pid = rid.ToString();
            return pid;
        }

        private void button2_Click(object sender, EventArgs e)  //添加归还记录
        {
            if(bookid == null || bookid == "")
            {
                MessageBox.Show("图书编号不能为空", "提示");
                return;
            }
            if(readerid == null || readerid == "")
            {
                MessageBox.Show("读者编号不能为空", "提示");
                return;
            }
            if(lenddate == null || returndate == null)
            {
                MessageBox.Show("请先进行查询！", "提示");
                return;
            }
            returndate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  //以字符串格式化记录归还时间
            id = SetId();  //生成流水单号
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
            MySqlConnection conn = new MySqlConnection(connstr);
            MySqlCommand cmd = conn.CreateCommand();
            MySqlConnection conn1 = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                cmd.CommandText = "INSERT INTO finishrecord (bookid, bookname ,readerid, readername, lenddate, returndate, id) VALUES (@bookid, @bookname, @readerid, @readername, @lenddate,@returndate,@id)";
                cmd.Parameters.AddWithValue("@bookid", bookid);
                cmd.Parameters.AddWithValue("@bookname", bookname);
                cmd.Parameters.AddWithValue("@readerid", readerid);
                cmd.Parameters.AddWithValue("@readername", readername);
                cmd.Parameters.AddWithValue("@lenddate", lenddate);
                cmd.Parameters.AddWithValue("@returndate", returndate);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();  //在finishrecord中添加记录
                conn1.Open();
                string sql = "DELETE FROM lendrecord WHERE bookid = '" + bookid + "' ;";
                cmd = new MySqlCommand(sql, conn1);
                Console.WriteLine(id);
                int i;
                i = cmd.ExecuteNonQuery();  //删除lendrecord中该书借出记录
                Console.WriteLine(i);
                //cmd.CommandText = "UPDATE book SET state = @state WHERE id='@id';";
                //cmd.Parameters.AddWithValue("@state", 0);
                //cmd.Parameters.AddWithValue("@id", bookid);  //将图书状态置为 入库
                sql = "UPDATE book SET state = " + 0 + " WHERE id='" + bookid + "';";
                cmd = new MySqlCommand(sql, conn1);
                cmd.ExecuteNonQuery();
                MessageBox.Show("已归还", "提示");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn1.Clone();
                conn.Close();
            }
        }

        private void returnbook_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)  //查询记录
        {
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";
            MySqlConnection conn = new MySqlConnection(connstr);  //添加 sslmode=none 取消ssl连接
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                String sql = "SELECT * FROM lendrecord WHERE bookid='"+bookid+"' AND readerid = '"+readerid+"';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    readername = reader.GetString("readername");
                    bookname = reader.GetString("bookname");
                    lenddate = reader.GetString("lenddate");
                    returndate = reader.GetString("returndate");
                }
                if (lenddate != null)
                {
                    textBox5.Text = lenddate;
                    textBox6.Text = returndate;
                    textBox2.Text = readername;
                    textBox4.Text = bookname;
                }
                else
                {
                    MessageBox.Show("记录不存在", "提示");

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
