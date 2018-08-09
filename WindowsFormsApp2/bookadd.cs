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
    public partial class bookadd : Form
    {
        private String id = null;
        private String name = null;
        private String publish = null;
        private String isbn = null;
        private int state = 0;  //0代表未借出，1代表以借出
        private String opendate;
        private double price = 0;
        public bookadd()
        {
            InitializeComponent();
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
                if(price < 0)
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
        /*生成随机数id，格式为年月日小时秒数+ISBN码第二位到第四位+随机数2位*/
        {
            DateTime dt = DateTime.Now;
            StringBuilder rid = new StringBuilder();
            String pid = null;
            rid.Append(string.Format("{0:yyyyMMddHHss}", dt));
            rid.Append(isbn.Substring(2, 3));
            Random random = new Random();
            int randomnum = random.Next(0, 100);
            rid.Append(Convert.ToString(randomnum));
            pid = rid.ToString();
            return pid;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (name == "" || name == null)
            {
                MessageBox.Show("书名不能为空", "提示");
                return;
            }
            else if (name != "")
            {
                id = SetId(); //生成id
                Console.WriteLine("当前生成编号为：" + id);
                opendate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  //以字符串格式化记录记录开户时间
                String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
                MySqlConnection conn = new MySqlConnection(connstr);
                MySqlCommand cmd = conn.CreateCommand();
                try
                {
                    conn.Open();
                    Console.WriteLine("数据库连接成功...");
                    cmd.CommandText = "INSERT INTO book (id, name ,publish, isbn, state, opendate, price) VALUES (@id, @name, @publish, @isbn, @state, @opendate, @price)";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@publish", publish);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@opendate", opendate);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功", "提示");
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
            
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
