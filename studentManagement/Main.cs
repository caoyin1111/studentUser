using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqliteTest;
using SqlLite.DLL;

namespace studentManagement
{

    public partial class Main : Form
    {
        private MySqlLite<StudentUser> userTable = new MySqlLite<StudentUser>();
        //private MySqlLite<AdminUser> user1Table = new MySqlLite<AdminUser>();
        private List<StudentUser> users = null;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string msg = "";
            if (File.Exists(@"\DataBase\Task1.db") == false)
            {
                MySqlLite<StudentUser>.CreateSQLiteDatabase(AppDomain.CurrentDomain.BaseDirectory + @"\DataBase\Task1.db");
                if (MySqlLite<StudentUser>.CreateTable(out msg) == false)
                {
                    MessageBox.Show("创建失败!" + msg);
                }
                if (MySqlLite<AdminUser>.CreateTable(out msg) == false)
                {
                    MessageBox.Show("创建失败!" + msg);
                }
            }

            Login Login = new Login();
            if (Login.ShowDialog() != DialogResult.OK)
            {

                this.Close();
                return;
            }


            users = userTable.GetListData().ToList();
            dataGridView1.DataSource = users;
            //AdminUser user1 = new AdminUser();
            //user1.UserName = "王大刚";
            //user1.Password = "wang123";
            //user1Table.Add(user1);



        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Tianjia add = new Tianjia();
            add.ShowDialog();
            users = userTable.GetListData().ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = users;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                if (userTable.Del(users[idx], "Name", users[idx].Name) == false)
                {
                    MessageBox.Show("失败!");
                    return;
                }
                users.RemoveAt(idx);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = users;
            }
        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                MessageBox.Show("你选择了 ： " + dataGridView1.SelectedRows[0].Index.ToString() + "行");

                int idx = dataGridView1.SelectedRows[0].Index;
                textBox1.Text = users[idx].Name;
                textBox2.Text = users[idx].Chinese;
                textBox3.Text = users[idx].Math;
                textBox6.Text = users[idx].English;
                textBox4.Text = users[idx].Wuli;
                textBox5.Text = users[idx].Huaxue;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                //users[idx].Name = textBox1.Text;
                users[idx].Chinese = textBox2.Text;
                users[idx].Math = textBox3.Text;
                users[idx].English = textBox4.Text;
                users[idx].Wuli = textBox4.Text;
                users[idx].Huaxue = textBox5.Text;
                users[idx].Avg = ((Convert.ToDouble(users[idx].Chinese) + Convert.ToDouble(users[idx].Math) + Convert.ToDouble(users[idx].English) + Convert.ToDouble(users[idx].Wuli) + Convert.ToDouble(users[idx].Huaxue)) / 5.0).ToString();
                textBox8.Text = users[idx].Avg;

                userTable.Modify(users[idx], "Name");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = users;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < users.Count; i++)
            {
                if (users[i].Name.Equals(textBox7.Text))
                {
                    //user = users[i];
                    MessageBox.Show("查询成功");
                    dataGridView1.Rows[i].Selected = true;
                    //userTable.GetListData(user.Name).ToList();
                    break;
                }

            }
            if (i >= users.Count)
                MessageBox.Show("查询失败");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                users[idx].Name = textBox1.Text;
                users[idx].Chinese = textBox2.Text;
                users[idx].Math = textBox3.Text;
                users[idx].English = textBox4.Text;
                users[idx].Wuli = textBox4.Text;
                users[idx].Huaxue = textBox5.Text;

                users[idx].Avg = (Convert.ToDouble(users[idx].Chinese + users[idx].Math + users[idx].English + users[idx].Wuli + users[idx].Huaxue) / 5.0).ToString();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = users;
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            int i, j;
            StudentUser t = null;

            for (i = 0; i < users.Count - 1; i++)
            {
                for (j = 0; j < users.Count - 1 - i; j++)
                {
                    if (Convert.ToDouble(users[j].Avg) > Convert.ToDouble(users[j + 1].Avg))
                    {
                        t = users[j];
                        users[j] = users[j + 1];
                        users[j + 1] = t;

                    }
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = users;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar<48||(int)e.KeyChar>57)&&(int)e.KeyChar!=8 && (int)e.KeyChar!=45 && (int)e.KeyChar!=46)//判断是否为数字
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;//取消显示该字符

            }
        }

        //private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsDigit(e.KeyChar))//判断是否为数字
        //    {
        //        MessageBox.Show("请输入数字！");
        //        e.Handled = true;//取消显示该字符

        //    }
        //}
    }
}

//private MySqlLite<User> userTable = new MySqlLite<User>();
////  private MySqlLite<User> userTable = new MySqlLite<User>();

//private List<User> users = null;
////  private List<User> users = null;
//public Form1()
//{
//    InitializeComponent();
//}
//private void Form1_Load(object sender, EventArgs e)
//{
//    string msg = "";
//    if (File.Exists(@"\DataBase\Task.db") == false)
//    {
//        MySqlLite<User>.CreateSQLiteDatabase(AppDomain.CurrentDomain.BaseDirectory + @"\DataBase\Task.db");
//        if (MySqlLite<User>.CreateTable(out msg) == false)
//        {
//            MessageBox.Show("创建失败!" + msg);
//        }
//    }



//    //User user = new User();
//    //user.Name = "小红";
//    //user.Password = "hong1997";
//    //user.NickName = "hong";
//    //user.CreateTime = "2014.9.5";


//    //bool iosk = userTable.Add(user);
//    //MessageBox.Show(iosk.ToString());
//    users = userTable.GetListData().ToList();
//    dataGridView1.DataSource = users;
//    // userTable.Modify(user,)
//}

//private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
//{

//}

//private void Button1_Click(object sender, EventArgs e)
//{
//    Tianjia add = new Tianjia();
//    add.ShowDialog();
//    users = userTable.GetListData().ToList();
//    dataGridView1.DataSource = null;
//    dataGridView1.DataSource = users;
//}

//private void Button2_Click(object sender, EventArgs e)
//{
//    if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
//    {
//        int idx = dataGridView1.SelectedRows[0].Index;
//        if (userTable.Del(users[idx], "Name", users[idx].Name) == false)
//        {
//            MessageBox.Show("失败!");
//            return;
//        }
//        users.RemoveAt(idx);
//        dataGridView1.DataSource = null;
//        dataGridView1.DataSource = users;
//    }
//}

//private void Button3_Click(object sender, EventArgs e)
//{


//}


///// <summary>
///// 选项改变事件
///// </summary>
///// <param name="sender"></param>
///// <param name="e"></param>
//private void DataGridView1_SelectionChanged(object sender, EventArgs e)
//{
//    if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
//    {
//        MessageBox.Show("你选择了 ： " + dataGridView1.SelectedRows[0].Index.ToString() + "行");

//        int idx = dataGridView1.SelectedRows[0].Index;
//        textBox5.Text = users[idx].Name;
//        textBox6.Text = users[idx].Password;
//        textBox7.Text = users[idx].NickName;
//        textBox8.Text = users[idx].CreateTime;


//    }

//}

//private void Button5_Click(object ender, EventArgs e)
//{

//    if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
//    {
//        int idx = dataGridView1.SelectedRows[0].Index;
//        users[idx].Name = textBox5.Text;
//        users[idx].Password = textBox6.Text;
//        users[idx].NickName = textBox7.Text;
//        users[idx].CreateTime = textBox8.Text;

//        userTable.Modify(users[idx], "NickName");
//        dataGridView1.DataSource = null;
//        dataGridView1.DataSource = users;
//    }
//}


//private void Button4_Click(object sender, EventArgs e)
//{
//    //User user = null;
//    int i;
//    for (i = 0; i < users.Count; i++)
//    {
//        if (users[i].Name.Equals(textBox9.Text))
//        {
//            //user = users[i];
//            MessageBox.Show("查询成功");
//            dataGridView1.Rows[i].Selected = true;
//            //userTable.GetListData(user.Name).ToList();
//            break;
//        }

//    }
//    if (i >= users.Count)
//        MessageBox.Show("查询失败");
//}