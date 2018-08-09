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
    public partial class bookdelete : Form
    {
        public string id = null;
        public bookdelete()
        {
            InitializeComponent();
        }

        private void bookdelete_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(id == null || id == "")
            {
                MessageBox.Show("编号不能为空", "提示");
                return;

            }
            DialogResult dr = MessageBox.Show("确定删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)  //确认选项
            {
                id = textBox1.Text;
                String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";
                MySqlConnection conn = new MySqlConnection(connstr);
                string sql = "DELETE FROM book WHERE id='" + id + "';";
                try
                {
                    conn.Open();
                    Console.WriteLine("数据库连接成功...");
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            id = textBox1.Text;
        }
    }
}
