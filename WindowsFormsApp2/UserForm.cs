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
    public partial class UserForm : Form
    {
        public String id = null;
        public String name = null;
        public String sex = null;
        public DateTime birth;
        public String birthtime = null;
        public int age = 0;
        public String opendate;
        public UserForm()
        {
            InitializeComponent();
        }
   
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sex = man.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sex = woman.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (name == null || name == "")
            {
                MessageBox.Show("读者名称不能为空", "提示");
                return;
            }
            age = DateTime.Now.Year - birth.Year;  //计算年龄
            birthtime = birth.ToString("yyyy-MM-dd");  //同上
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
            MySqlConnection conn = new MySqlConnection(connstr);
            //MySqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                //cmd.CommandText = "UPDATE reader SET name = '@name', sex = '@sex', birthdate='@birthdate',age='@age' WHERE id='@id';";
                //cmd.Parameters.AddWithValue("@name", name);
                //cmd.Parameters.AddWithValue("@sex", sex);
                //cmd.Parameters.AddWithValue("@birthdate", birthtime);
                //cmd.Parameters.AddWithValue("@age", age);
                //cmd.Parameters.AddWithValue("@id", id);
                //cmd.ExecuteNonQuery();
                string sql = "UPDATE reader SET name = '"+name+"', sex = '"+sex+"', birthdate='"+birthtime+"',age="+age+" WHERE id='"+id+"';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
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

        private void readername_TextChanged(object sender, EventArgs e)
        {
            name = readername.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            birth = dateTimePicker1.Value;
        }
  

        private void readerid_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void UserForm_Load_1(object sender, EventArgs e)  //载入函数
        {
            if (Login.authority == 0)
            {
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
            readerid.Text = id;
            readername.Text = name;
            if(sex == "男")
            {
                man.Checked = true;
            }
            else if(sex == "女")
            {
                woman.Checked = true;
            }
            dateTimePicker1.Value = Convert.ToDateTime(birthtime);
            textBox1.Text = opendate;
            textBox2.Text = Convert.ToString(age);
            InitRecord(id);
            if (name == null)  //信息检查
            {
                MessageBox.Show("信息不存在", "提示");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)  //删除读者信息
        {
            DialogResult dr = MessageBox.Show("确定删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)  //确认选项
            {
                String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
                MySqlConnection conn = new MySqlConnection(connstr);
                string sql = "DELETE FROM reader WHERE id = '" + id + "' ;";
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

        private void button3_Click(object sender, EventArgs e)  //点选取消按钮，清空选项
        {
            readerid.Clear();
            readername.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                cmd.CommandText = $"SELECT * FROM finishrecord WHERE readerid = '{id}';";
                //cmd.Parameters.AddWithValue("@id", id);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "finishrecord");
                this.dataGridView1.DataSource = ds;
                this.dataGridView1.DataMember = "finishrecord";
                this.dataGridView1.RowHeadersVisible = false;  //隐藏行头
                this.dataGridView1.Columns[0].HeaderText = "图书编号";
                this.dataGridView1.Columns[1].HeaderText = "图书名称";
                this.dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[3].Visible = false;
                this.dataGridView1.Columns[4].HeaderText = "借出日期";
                this.dataGridView1.Columns[5].HeaderText = "归还日期";
                this.dataGridView1.Columns[6].HeaderText = "订单编号";
           
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
}
