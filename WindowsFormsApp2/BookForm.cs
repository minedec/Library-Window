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
    public partial class BookForm : Form
    {
        public String id = null;
        public String name = null;
        public String publish = null;
        public String isbn = null;
        public int state = 0;  //0代表未借出，1代表以借出
        public String opendate;
        public double price = 0;
        private int total = 0;
        private int rest = 0;
        public BookForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            if (Login.authority == 0)
            {
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = publish;
            textBox4.Text = isbn;
            textBox5.Text = price.ToString();
            textBox6.Text = opendate;
            if(state == 0)
            {
                button1.Visible = false;
                textBox7.Text = "入库";
            }
            else
            {
                button1.Visible = true;
                textBox7.Text = "流通";
            }
            textBox8.Text = CheckTotalBook().ToString();  //显示总数
            total = CheckTotalBook();
            textBox9.Text = CheckLendBook().ToString();  //显示流通数
            rest = CheckLendBook();
            textBox10.Text = (total - rest).ToString();  //显示入库数
            InitRecord(id);
            if (name == null)  //信息检查
            {
                MessageBox.Show("信息不存在", "提示");
                return;
            }
        }

        public void InitRecord(string id)  //grid view初始化流通记录
        {
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM finishrecord WHERE bookid = '{id}';";
                //cmd.Parameters.AddWithValue("@id", id);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "finishrecord");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "finishrecord";
                dataGridView1.RowHeadersVisible = false;  //隐藏行头
                dataGridView1.Columns[0].Visible = false;  //隐藏列
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "读者编号";  //修改列标题
                dataGridView1.Columns[3].HeaderText = "姓名";
                dataGridView1.Columns[4].HeaderText = "借出日期";
                dataGridView1.Columns[5].HeaderText = "归还日期";
                dataGridView1.Columns[6].HeaderText = "订单编号";
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(name == null || name == "")
            {
                MessageBox.Show("书名不能为空", "提示");
                return;
            }
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
            MySqlConnection conn = new MySqlConnection(connstr);
            MySqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                cmd.CommandText = "UPDATE book SET name = '@name' , publish='@publish',isbn='@isbn',price='@price' WHERE id='@id';";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@publish", publish);
                cmd.Parameters.AddWithValue("@isbn", isbn);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("修改成功", "提示");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private int CheckTotalBook()  //查询所有该名称书籍数量
        {
            int num = 0;
            string connstr = "sslmode = none;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                //MySqlCommand cmd = conn.CreateCommand();
                //cmd.CommandText = "SELECT COUNT(*) FROM book WHERE name = '@name';";
                //cmd.Parameters.AddWithValue("@name", name);
                string sql = "SELECT COUNT(*) FROM book WHERE name = '"+name+"';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                num = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return num;
        }

        private int CheckLendBook()  //查询所有该名称书籍流通数量
        {
            int num = 0;
            string connstr = "sslmode = none;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                //MySqlCommand cmd = conn.CreateCommand();
                //cmd.CommandText = "SELECT COUNT(*) FROM book WHERE bookname = '@name';";
                //cmd.Parameters.AddWithValue("@name", name);
                string sql = "SELECT COUNT(*) FROM lendrecord WHERE bookname = '" + name + "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                num = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return num;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            name = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            publish = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            isbn = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                price = Convert.ToDouble(textBox5.Text);
                if (price < 0)
                {
                    MessageBox.Show("价格不能为负", "提示");
                    textBox5.Clear();
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("价格格式不正确，请重新输入", "提示");
                textBox5.Clear();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)  //确认选项
            {
                String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
                MySqlConnection conn = new MySqlConnection(connstr);
                string sql = "DELETE FROM book WHERE id = '" + id + "' ;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    Console.WriteLine("数据库连接成功...");
                    Console.WriteLine(id);
                    int i;
                    i = cmd.ExecuteNonQuery();
                    Console.WriteLine(i);
                    MessageBox.Show("删除成功", "提示");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = "sslmode = none;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";
            MySqlConnection conn = new MySqlConnection(connstr);
            DateTime lenddate = new DateTime();
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                //MySqlCommand cmd = conn.CreateCommand();
                //cmd.CommandText = "SELECT COUNT(*) FROM book WHERE bookname = '@name';";
                //cmd.Parameters.AddWithValue("@name", name);
                string sql = $"SELECT returndate FROM lendrecord WHERE bookid ='{id}';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                DateTime returndate = new DateTime();
                while(reader.Read())
                {
                    lenddate = Convert.ToDateTime(reader.GetString("lenddate"));
                    returndate = Convert.ToDateTime(reader.GetString("returndate"));
                }
                conn.Close();  //连接使用完断开，重新连接，否则cmd执行报错
                if((returndate - lenddate).Days == 60)  //判断是否已经续借过一次
                {
                    MessageBox.Show("最多可以续借一次！", "提示");
                    return;
                }
                conn.Open();
                returndate = returndate.AddDays(30);
                sql = $"UPDATE lendrecord SET returndate = '{returndate}' WHERE bookid = '{id}';"; 
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("续借成功", "提示");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
