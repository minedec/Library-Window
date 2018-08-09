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
    public partial class bookmultipledelete : Form
    {
        private string[] arr_str = null;
        public bookmultipledelete()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arr_str = textBox1.Text.Split('\n');  //以换行符分割记录字符串
                foreach (string i in arr_str)
                {
                    Console.WriteLine(i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)  //确认选项
            {
                if (arr_str == null || arr_str[0] == "")
                {
                    MessageBox.Show("编号不能为空", "提示");
                    return;

                }
                /*构造批量删除sql语句，在执行*/
                String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";
                MySqlConnection conn = new MySqlConnection(connstr);
                StringBuilder sb = new StringBuilder();
                sb.Append("DELETE FROM book WHERE id IN ( ");
                int i = 0;
                for (; i < arr_str.Length - 2; i++)
                {
                    sb.Append("" + arr_str[i] + ",");
                }
                if(arr_str[arr_str.Length-1] == "\n")  //如果最后跟了一个换行符
                {
                    sb.Append(arr_str[arr_str.Length - 2] + ");");

                }
                else
                {
                    sb.Append(arr_str[arr_str.Length - 1] + ");");

                }
                string sql = sb.ToString();
                Console.WriteLine(sql);
                try
                {
                    conn.Open();
                    Console.WriteLine("数据库连接成功...");
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("删除完成", "提示");
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
    }
}
