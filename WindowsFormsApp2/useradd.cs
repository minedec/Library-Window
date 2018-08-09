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
    public partial class useradd : Form
    {
        private String id = null;
        private String name = null;
        private String sex = null;
        private DateTime birth;
        private String birthtime = null;
        private int age = 0;
        private String opendate;
        public useradd()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void readername_TextChanged(object sender, EventArgs e)
        {
            name = readername.Text;
        }

        private void man_CheckedChanged(object sender, EventArgs e)
        {
            sex = man.Text;
        }

        private void woman_CheckedChanged(object sender, EventArgs e)
        {
            sex = woman.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            birth = dateTimePicker1.Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (name == null || name == "")
            {
                MessageBox.Show("读者名称不能为空", "提示");
                return;
            }
            id = SetId(); //生成id
            Console.WriteLine("当前生成编号为：" + id);
            age = DateTime.Now.Year - birth.Year;  //计算年龄
            opendate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  //以字符串格式化记录记录开户时间
            birthtime = birth.ToString("yyyy-MM-dd HH:mm:ss");  //同上
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
            MySqlConnection conn = new MySqlConnection(connstr);
            MySqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                cmd.CommandText = "INSERT INTO reader (id, name ,sex, birthdate, age, opendate) VALUES (@id, @name, @sex, @birthdate, @age, @opendate)";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@sex", sex);
                cmd.Parameters.AddWithValue("@birthdate", birthtime);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@opendate", opendate);
                cmd.ExecuteNonQuery();
                MessageBox.Show("添加成功", "提示");
                readername.Clear();
                
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

        private String SetId()
        /*生成随机数id，格式为年月日+生日月份日期+随机数1位*/
        {
            DateTime dt = DateTime.Now;
            StringBuilder rid = new StringBuilder();
            String pid = null;
            rid.Append(string.Format("{0:yyyyMMdd}", dt));
            rid.Append(string.Format("{0:yyyyMMdd}", birth));
            Random random = new Random();
            int randomnum = random.Next(0, 10);
            rid.Append(Convert.ToString(randomnum));
            pid = rid.ToString();
            return pid;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
