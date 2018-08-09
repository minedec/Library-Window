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
    public partial class bookmultipleadd : Form
    {
        private static int counter = 0;  //静态变量，用于编号计数
        private String id = null;
        private String name = null;
        private String publish = null;
        private String isbn = null;
        private int state = 0;  //0代表未借出，1代表以借出
        private String opendate;
        private double price = 0;
        private int num = 0;
        public bookmultipleadd()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                num = Convert.ToInt32(textBox1.Text);
                if (num < 0 || num > 100)
                {
                    MessageBox.Show("数量在0~100之间", "提示");
                    textBox1.Clear();
                    return;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("请输入正确格式", "提示");
                textBox1.Clear();
                return;
            }
            
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

        private String SetId()
        /*生成随机数id，格式为年月日小时秒数+ISBN码第二位到第四位+顺序计数2位调用一次counter加一*/
        {
            DateTime dt = DateTime.Now;
            StringBuilder rid = new StringBuilder();
            String pid = null;
            rid.Append(string.Format("{0:yyyyMMddHHss}", dt));
            rid.Append(isbn.Substring(2, 3));
            rid.Append(string.Format("{0:00}", counter++));
            pid = rid.ToString();
            return pid;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(name == null || name =="")
            {
                MessageBox.Show("书名不能为空", "提示");
                return;
            }
            int i = 0;
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
            MySqlConnection conn = new MySqlConnection(connstr);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO book (id, name ,publish, isbn, state, opendate, price) VALUES ");
            while (i < num-1)
            {
                id = SetId(); //生成id
                Console.WriteLine("当前生成编号为：" + id);
                opendate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  //以字符串格式化记录记录开户时间
                sb.Append(" ('" + id + "','" + name + "','" + publish + "','" + isbn + "'," + state + ",'" + opendate + "'," + price + "),");
                //cmd.CommandText = "INSERT INTO book (id, name ,publish, isbn, state, opendate, price) VALUES (@id, @name, @publish, @isbn, @state, @opendate, @price)";
                //cmd.Parameters.AddWithValue("@id", id);
                //cmd.Parameters.AddWithValue("@name", name);
                //cmd.Parameters.AddWithValue("@publish", publish);
                //cmd.Parameters.AddWithValue("@isbn", isbn);
                //cmd.Parameters.AddWithValue("@state", state);
                //cmd.Parameters.AddWithValue("@opendate", opendate);
                //cmd.Parameters.AddWithValue("@price", price);
                //cmd.ExecuteNonQuery();
                i++;
            }
            id = SetId(); //生成id
            Console.WriteLine("当前生成编号为：" + id);
            opendate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  //以字符串格式化记录记录开户时间
            sb.Append(" ('" + id + "','" + name + "','" + publish + "','" + isbn + "'," + state + ",'" + opendate + "'," + price + ");");  //末尾改分号
            string sql = sb.ToString();
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine(sql);
                MessageBox.Show("添加成功", "提示");
                counter = 0;
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
