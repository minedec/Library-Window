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
    public partial class bookmodify : Form
    {
        public string id = null;
        public String name = null;
        public String publish = null;
        public String isbn = null;
        public int state = 0;  //0代表未借出，1代表以借出
        public String opendate;
        public double price = 0;
        public bookmodify()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id == null || id == "")
            {
                MessageBox.Show("编号不能为空", "提示");
                return;

            }
            id = textBox1.Text;
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";
            MySqlConnection conn = new MySqlConnection(connstr);
            string sql = "SELECT * FROM book WHERE id='" + id + "';";
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    name = reader.GetString("name");
                    publish = reader.GetString("publish");
                    isbn = reader.GetString("isbn");
                    state = Convert.ToInt32(reader.GetString("state"));
                    opendate = reader.GetString("opendate");
                    price = Convert.ToDouble(reader.GetString("price"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            BookForm bf = new BookForm();
            bf.id = id;
            bf.name = name;
            bf.publish = publish;
            bf.isbn = isbn;
            bf.state = state;
            bf.opendate = opendate;
            bf.price = price;
            Login.main.ShowBookForm(bf);  //调用login类中静态全局变量main，保证调用对象相同
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
