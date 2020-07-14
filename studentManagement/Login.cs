using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqliteTest;
using SqlLite.DLL;

namespace studentManagement
{
  
    public partial class Login : Form
    {
        private MySqlLite<AdminUser> userTable = new MySqlLite<AdminUser>();
        AdminUser user1 = new AdminUser();

        private List<AdminUser> users1 = null;
        public Login()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    

        private void Button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("登录成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //以下开始显示主窗体 并关闭登录窗体
            //if (textBox1.Text.Equals("曹寅") && textBox2.Text.Equals("23456"))
            //{
            //    //Main main = new Main();
            //    //main.Show();
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
            int i;
            string username = textBox1.Text;
            string password = textBox2.Text;
            users1 = userTable.GetListData().ToList();
            for (i=0;i<users1.Count;i++)
            {
                if (users1[i].UserName.Equals(username) && users1[i].Password.Equals(password))
                {
                    //Main main = new Main();
                    //main.Show();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                }
               
               
             
                    
                
            }
            if(i>=users1.Count)
            {
                MessageBox.Show("登录失败");
            }
         
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            user1.UserName = textBox1.Text;
            user1.Password = textBox2.Text;
            userTable.Add(user1);
            MessageBox.Show("注册成功");
            users1 = userTable.GetListData().ToList();
        }
    }
    }

