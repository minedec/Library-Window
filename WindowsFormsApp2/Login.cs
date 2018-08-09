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
    public partial class Login : Form
    {
        public static int authority = 0;  //定义静态变量 权限
        public static Main main;
        private int i = 0;

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user = textBox1.Text;
            String pwd = textBox2.Text;
            if(user == "")
            {
                MessageBox.Show("用户名不能为空", "登录提示");
                return;
            }
            if(pwd == "")
            {
                MessageBox.Show("密码不能为空", "登录提示");
                return;
            }
            if(user != "" && pwd != "")
            {
                String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";
                MySqlConnection conn = new MySqlConnection(connstr);  //添加 sslmode=none 取消ssl连接
                int flag = 0;
                try
                {
                    conn.Open();
                    Console.WriteLine("数据库连接成功...");
                    String sql = "SELECT * FROM admin;";
                    String name = null;  //declare admin name
                    String pass = null;  //declare password
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        name = reader.GetString("name");
                        pass = reader.GetString("pwd");
                        if (user == name && pwd == pass)
                        {
                            authority = Convert.ToInt32(reader.GetString("authority"));
                            main = new Main();
                            flag = 1;
                            this.Hide();
                            main.Show();
                        }
                    }
                    Console.WriteLine(name);
                    Console.WriteLine(pass);
                    if(flag == 0)
                    {
                        MessageBox.Show("用户名或密码错误，请重新输入", "登录提示");
                        textBox2.Clear();

                    }
                }
                catch(MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    
                    conn.Close();
                }
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(i == 0)
            {
                textBox2.PasswordChar = '\0';
                i = 1;
            }
            else if (i==1)
            {
                textBox2.PasswordChar = '*';
                i = 0;
            }

        }
    }
}
