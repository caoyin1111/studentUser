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
    public partial class Tianjia : Form
    {
        MySqlLite<StudentUser> userTable = new MySqlLite<StudentUser>();
        StudentUser user = new StudentUser();
        public Tianjia()
        {
            InitializeComponent();
        }

      
        private void Button1_Click(object sender, EventArgs e)
        {
            
            user.Name = textBox1.Text;
            user.Chinese = textBox2.Text;
            user.Math = textBox3.Text;
            user.English = textBox6.Text;
            user.Wuli = textBox4.Text;
            user.Huaxue = textBox5.Text;
            user.Avg = ((Convert.ToDouble(user.Chinese) + Convert.ToDouble(user.Math) + Convert.ToDouble(user.English) + Convert.ToDouble(user.Wuli) + Convert.ToDouble(user.Huaxue) )/ 5.0).ToString();
            textBox7.Text = user.Avg;
            bool iosk = userTable.Add(user);
            MessageBox.Show(iosk.ToString());
            //MessageBox.Show(iosk.ToString());
            //MessageBox.Show("创建!");
        }

        
    }
}
