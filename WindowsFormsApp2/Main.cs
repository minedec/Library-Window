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
    public partial class Main : Form
    {
        public  String id = null;
        public  String searchid = null;
        public static String name = null;
        public static String sex = null;
        public static DateTime birth;
        public static String birthtime = null;
        public static int age = 0;
        public static String opendate;
        public static String publish = null;
        public static String isbn = null;
        public static int state = 0;  //0代表未借出，1代表以借出
        public static double price = 0;
        public static int number = 0;
        public static int lend = 0;
        public static int rest = 0;
        public UserForm UserForm;
        public BookForm BookForm;
        public Main()
        {
            InitializeComponent();
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void 切换账户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitReaderView();
            if(Login.authority == 0)
            {
                图书管理ToolStripMenuItem.Visible = false;
                读者管理ToolStripMenuItem.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (searchid == null || searchid == "")
            {
                MessageBox.Show("编号不能为空", "提示");
                return;

            }
            int i = 0;
            for (i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if ((string)dataGridView1.Rows[i].Cells["id"].Value == searchid)
                {
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
            try
            {
                    id = dataGridView1.Rows[i].Cells[0].Value.ToString(); //获得当前行的第0列的值  
                    name = dataGridView1.Rows[i].Cells[1].Value.ToString();     //获得当前行的第1列的值                            
                    sex = dataGridView1.Rows[i].Cells[2].Value.ToString();     //获得当前行的第2列的值                            
                    birthtime = dataGridView1.Rows[i].Cells[3].Value.ToString();     //获得当前行的第3列的值                            
                    age = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value.ToString());     //获得当前行的第4列的值                            
                    opendate = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    UserForm uf = new UserForm();
                    Console.WriteLine("读者搜索...");
                    uf.id = searchid;
                    uf.name = name;
                    uf.sex = sex;
                    uf.birthtime = birthtime;
                    uf.age = age;
                    uf.opendate = opendate;
                    uf.InitRecord(searchid);
                    ShowUserForm(uf);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        public void InitReaderView()   //读者grid view初始化   
        {
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM reader", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "reader");
                dataGridView1.DataSource = ds;
                dataGridView1.RowHeadersVisible = false;  //隐藏行头
                dataGridView1.DataMember = "reader";
                dataGridView1.Columns[0].HeaderText = "编号";
                dataGridView1.Columns[1].HeaderText = "姓名";
                dataGridView1.Columns[2].Visible = false;  //隐藏指定列
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;

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

        public void InitBookView()   //图书grid view初始化   
        {
            String connstr = "SslMode=None;datasource=127.0.0.1;port=3306;userid=root;password=123456;pooling=false; database=library;";  //添加 sslmode=none 取消ssl连接
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                Console.WriteLine("数据库连接成功...");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM book", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "book");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "book";
                dataGridView2.RowHeadersVisible = false;  //隐藏行头
                dataGridView2.Columns[0].HeaderText = "编号";
                dataGridView2.Columns[1].HeaderText = "名称";
                dataGridView2.Columns[2].Visible = false;  //隐藏指定列
                dataGridView2.Columns[3].Visible = false;
                dataGridView2.Columns[4].HeaderText = "状态";
                dataGridView2.Columns[5].Visible = false;
                dataGridView2.Columns[6].Visible = false;

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  //双击grid view事件
        {
           
                int rowindex = e.RowIndex;
                Console.WriteLine("切换到读者...");
                try
                {
                    id = dataGridView1.Rows[rowindex].Cells[0].Value.ToString(); //获得当前行的第0列的值  
                    name = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();     //获得当前行的第1列的值                            
                    sex = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();     //获得当前行的第2列的值                            
                    birthtime = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();     //获得当前行的第3列的值                            
                    age = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[4].Value.ToString());     //获得当前行的第4列的值                            
                    opendate = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();     //获得当前行的第5列的值  
                    UserForm uf = new UserForm();  //新建user form实例变量
                    Console.WriteLine("新建userform窗体...");
                    Console.WriteLine(id);  //debugging...
                    Console.WriteLine(name);
                    Console.WriteLine(sex);
                    Console.WriteLine(birthtime);
                    Console.WriteLine(age);
                    Console.WriteLine(opendate);
                    uf.id = id;
                    uf.name = name;
                    uf.sex = sex;
                    uf.birthtime = birthtime;
                    uf.opendate = opendate;
                    uf.age = age;
                    //uf.InitRecord(id);
                    ShowUserForm(uf);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            

        }

        private void ShowUserForm(UserForm UserForm)
        {
            UserForm.TopLevel = false;      //取消顶层
            UserForm.FormBorderStyle = FormBorderStyle.None;        //取消标题栏
            this.panel1.Controls.Clear();  //清除之前的控制
            UserForm.Dock = System.Windows.Forms.DockStyle.Fill;   //填充panel
            this.panel1.Controls.Add(UserForm);
            UserForm.Show();
        }

        public void ShowBookForm(BookForm BookForm)
        {
            BookForm.TopLevel = false;      //取消顶层
            BookForm.FormBorderStyle = FormBorderStyle.None;        //取消标题栏
            this.panel1.Controls.Clear();  //清除之前的控制
            BookForm.Dock = System.Windows.Forms.DockStyle.Fill;   //填充panel
            this.panel1.Controls.Add(BookForm);
            BookForm.Show();
        }

        public void ShowRecord(record record)
        {
            record.TopLevel = false;      //取消顶层
            record.FormBorderStyle = FormBorderStyle.None;        //取消标题栏
            this.panel1.Controls.Clear();  //清除之前的控制
            record.Dock = System.Windows.Forms.DockStyle.Fill;   //填充panel
            this.panel1.Controls.Add(record);
            record.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellDoubleClick(sender, e);
        }

        private void 批量修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new bookmultiplemodify().Show();
        }

        private void 添加单本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new bookadd().Show();
        }

        private void 添加读者信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new useradd().Show();
        }

        private void 图书借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new lendbook().Show();
        }

        private void 图书归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new returnbook().Show();
        }

        private void 黑名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("开发中", "提示");
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                InitReaderView();  //读者grid view初始化

            }
            else if(tabControl1.SelectedIndex == 1)
            {
                InitBookView();

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            Console.WriteLine("切换到图书...");
            try
            {
                id = dataGridView2.Rows[rowindex].Cells[0].Value.ToString(); //获得当前行的第0列的值  
                name = dataGridView2.Rows[rowindex].Cells[1].Value.ToString();     //获得当前行的第1列的值                            
                publish = dataGridView2.Rows[rowindex].Cells[2].Value.ToString();     //获得当前行的第2列的值                            
                isbn = dataGridView2.Rows[rowindex].Cells[3].Value.ToString();     //获得当前行的第3列的值                            
                state = Convert.ToInt32(dataGridView2.Rows[rowindex].Cells[4].Value.ToString());     //获得当前行的第4列的值                            
                opendate = dataGridView2.Rows[rowindex].Cells[5].Value.ToString();     //获得当前行的第5列的值                            
                price = Convert.ToDouble(dataGridView2.Rows[rowindex].Cells[6].Value.ToString());     //获得当前行的第6列的值 
                Console.WriteLine(id);  //debugging...
                Console.WriteLine(name);
                Console.WriteLine(publish);
                Console.WriteLine(isbn);
                Console.WriteLine(state);
                Console.WriteLine(opendate);
                Console.WriteLine(price);
                BookForm bf = new BookForm();
                Console.WriteLine("新建bookform窗体...");
                bf.id = id;
                bf.name = name;
                bf.publish = publish;
                bf.isbn = isbn;
                bf.state = state;
                bf.opendate = opendate;
                bf.price = Convert.ToDouble(price);
                ShowBookForm(bf);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("项目名称：图书管理系统\n" +
                           "制作方：计算机学院jjd\n" +
                           "联系方式：1820985520@qq.com\n" +
                           "如有不足，欢迎指正","关于");
        }

        private void 记录管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRecord(new record());
        }

        private void 修改单本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new bookmodify().Show();
        }

        private void 删除单本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new bookdelete().Show();
        }

        private void 批量添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new bookmultipleadd().Show();
        }

        private void 批量删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new bookmultipledelete().Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchid = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            searchid = textBox2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (searchid == null || searchid == "")
            {
                MessageBox.Show("编号不能为空", "提示");
                return;

            }
            int i = 0;
            //DataTable dt = (DataTable)dataGridView1.DataSource;
            for (i = 0; i < this.dataGridView2.Rows.Count; i++)
            {
                if ((string)dataGridView2.Rows[i].Cells["id"].Value == searchid)
                {
                    dataGridView2.Rows[i].Selected = true;
                    dataGridView2.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
            try
            {
                    id = dataGridView2.Rows[i].Cells[0].Value.ToString(); //获得当前行的第0列的值  
                    name = dataGridView2.Rows[i].Cells[1].Value.ToString();     //获得当前行的第1列的值                            
                    publish = dataGridView2.Rows[i].Cells[2].Value.ToString();     //获得当前行的第2列的值                            
                    isbn = dataGridView2.Rows[i].Cells[3].Value.ToString();     //获得当前行的第3列的值                            
                    state = Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value.ToString());     //获得当前行的第4列的值                            
                    opendate = dataGridView2.Rows[i].Cells[5].Value.ToString();     //获得当前行的第5列的值                            
                    price = Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value.ToString());     //获得当前行的第6列的值 
                    BookForm bf = new BookForm();
                    Console.WriteLine("新建bookform窗体...");
                    bf.id = searchid;
                    bf.name = name;
                    bf.publish = publish;
                    bf.isbn = isbn;
                    bf.state = state;
                    bf.opendate = opendate;
                    bf.price = Convert.ToDouble(price);
                    bf.InitRecord(searchid);
                    ShowBookForm(bf);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
        }

        private void 使用手册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("右边显示图书读者列表，支持编号搜索\n" +
                "左边显示详细信息，可进行修改删除\n" +
                "上方菜单功能支持图书批量操作，查阅流通记录等", "使用");
        }

        private void 图书管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 读者管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
