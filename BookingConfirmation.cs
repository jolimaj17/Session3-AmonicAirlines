using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session3
{
    public partial class BookingConfirmation : Form
    {
        SQLConnect r = new SQLConnect();
        String sql;
        
        public BookingConfirmation(string pass)
        {
            InitializeComponent();
            passenger.Text = pass.ToString();
        }

        private void BookingConfirmation_Load(object sender, EventArgs e)
        {
            sql = "select Name from Countries";
            t5.DataSource = r.MultipleData(sql).Tables["tbl"];
            t5.DisplayMember = "Name";
            t5.ValueMember = "Name";
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (t1.Text == "" || t2.Text == "" || t4.Text=="" || t5.Text == "" || t6.Text == "")
            {
                MessageBox.Show("Incomplete fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                int n = dgout.Rows.Add();
                dgout.Rows[n].Cells[0].Value = t1.Text;
                dgout.Rows[n].Cells[1].Value = t2.Text;
                dgout.Rows[n].Cells[2].Value = t3.Value.ToString("yyyyMMdd");
                dgout.Rows[n].Cells[3].Value = t4.Text;
                dgout.Rows[n].Cells[4].Value = t5.Text;
                dgout.Rows[n].Cells[5].Value = t6.Text;
                n = n + 1;

                lblcounts.Text = n.ToString();
                if (n == Convert.ToInt16(passenger.Text))
                {
                    button2.Enabled = false;
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total;
            BillingConfirmation a = new BillingConfirmation();
            total = (Convert.ToInt16(lblprice1.Text) + Convert.ToInt16(lblprice3.Text)) * Convert.ToInt16(passenger.Text);
            a.total.Text = total.ToString();

            a.label2.Text = passenger.Text;
            
            a.Show();

            this.Hide();

            
        }
    }
}
