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
    public partial class bookmultiplemodify : Form
    {
        private String id = null;
        private String name = null;
        private String publish = null;
        private String isbn = null;
        private double price = 0;
        private string[] arr_str = null;
        public bookmultiplemodify()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arr_str = textBox1.Text.Split('\n');  //以换行符分割记录字符串
                foreach(string i in arr_str)
                {
                    Console.WriteLine(i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (arr_str == null || arr_str[0] == "")
            {
                MessageBox.Show("编号不能为空", "提示");
                return;

            }
            if (name == "" || name == null)
            {
                MessageBox.Show("名称不能为空", "提示");
                return;
            }
            /*构造批量修改sql语句，在执行*/
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";
            MySqlConnection conn = new MySqlConnection(connstr);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE book SET name = CASE id ");
            foreach (string i in arr_str)
            {
                sb.Append(" WHEN " + i + " THEN '" + name+"'");
            }
            sb.Append(" END, publish=CASE id ");
            foreach (string i in arr_str)
            {
                sb.Append(" WHEN " + i + " THEN '" + publish + "'");
            }
            sb.Append(" END, isbn=CASE id ");
            foreach (string i in arr_str)
            {
                sb.Append(" WHEN " + i + " THEN '" + isbn + "'");
            }
            sb.Append(" END, price=CASE id ");
            foreach (string i in arr_str)
            {
                sb.Append(" WHEN " + i + " THEN " + price);
            }
            sb.Append(" END");
            string sql = sb.ToString();
            Console.WriteLine(sql);
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("修改完成", "提示");
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

        private void bookmultiplemodify_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
