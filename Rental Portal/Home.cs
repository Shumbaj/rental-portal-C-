using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Portal
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form tenant = new Tenants();
            tenant.Show();
            this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form payments = new Payments();
            payments.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form room = new Rooms();
            room.Show();
            this.Hide();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form exp = new Expense();
            exp.Show();
            this.Hide();
        }
    }
}
