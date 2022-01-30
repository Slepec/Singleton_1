using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Singleton_26_06_2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        Users u = Users.getInstance();
        User currentUser=null;
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentUser = u.getAccountByName(textBox5.Text);
            if (currentUser != null)
            {
                panel1.Visible = true;
                textBox4.Text = currentUser.Name;
                textBox3.Text = currentUser.Description;
            }
            else MessageBox.Show("Неправильне ім'я");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                if (textBox1.Text.Length > 2 && textBox2.Text.Length > 0 && u.addAccount(new User(textBox1.Text, textBox2.Text)))
                {
                    MessageBox.Show("Створений новий акаунт");
                    
                    u.printAccounts();
                }
                else MessageBox.Show("Заповніть поля. Ім'я має бути довшим за 2 символи та бути унікальним. Максимум 5 акаунтів");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            u.printAccounts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(u.leave(currentUser))
            {
                panel1.Visible = false;
            }
            else
            {
                MessageBox.Show("Не можу вийти");
            }
            
        }
    }
}
