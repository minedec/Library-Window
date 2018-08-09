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
    public partial class record : Form
    {
        string id = null;
        public record()
        {
            InitializeComponent();
        }

        private void record_Load(object sender, EventArgs e)
        {
            InitFinishRecordView();
        }

        public void InitLendRecordView()    
        {
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM lendrecord", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "lendrecord");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "lendrecord";
                dataGridView2.RowHeadersVisible = false;  //隐藏行头
                dataGridView2.Columns[0].HeaderText = "图书编号";
                dataGridView2.Columns[1].HeaderText = "图书名称";
                dataGridView2.Columns[2].HeaderText = "读者编号";  
                dataGridView2.Columns[3].HeaderText = "读者姓名";
                dataGridView2.Columns[4].HeaderText = "借阅日期";
                dataGridView2.Columns[5].HeaderText = "应还日期";

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

        public void InitFinishRecordView()   
        {
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM finishrecord", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "finishrecord");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "finishrecord";
                dataGridView1.RowHeadersVisible = false;  //隐藏行头
                dataGridView1.Columns[0].HeaderText = "图书编号";
                dataGridView1.Columns[1].HeaderText = "图书名称";
                dataGridView1.Columns[2].HeaderText = "读者编号";
                dataGridView1.Columns[3].HeaderText = "读者姓名";
                dataGridView1.Columns[4].HeaderText = "借阅日期";
                dataGridView1.Columns[5].HeaderText = "应还日期";
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

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                InitFinishRecordView();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                InitLendRecordView();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            id = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            //DataTable dt = (DataTable)dataGridView1.DataSource;
            for ( i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if ((string)dataGridView1.Rows[i].Cells["bookid"].Value == id)
                {
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    //return;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            id = textBox2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = 0;
            //DataTable dt = (DataTable)dataGridView1.DataSource;
            for (i = 0; i < this.dataGridView2.Rows.Count; i++)
            {
                if ((string)dataGridView2.Rows[i].Cells["bookid"].Value == id)
                {
                    dataGridView2.Rows[i].Selected = true;
                    dataGridView2.FirstDisplayedScrollingRowIndex = i;
                    //return;
                }
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            for (i = 0; i < this.dataGridView2.Rows.Count; i++)
            {
                if (DateTime.Now > (DateTime)dataGridView2.Rows[i].Cells["returndate"].Value)
                {
                    dataGridView2.Rows[i].Selected = true;
                    dataGridView2.FirstDisplayedScrollingRowIndex = i;
                }
            }
        }
    }
}
