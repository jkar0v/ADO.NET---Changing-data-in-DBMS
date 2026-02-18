using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string author = textBox2.Text;
            decimal price = Convert.ToDecimal(textBox3.Text);

            dbHelper.InsertBook(title, author, price);

            dataGridView1.DataSource = dbHelper.GetBooks();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbHelper.GetBooks();
        }
    }
}
