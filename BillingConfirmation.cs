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
    public partial class BillingConfirmation : Form
    {
        String sql;
        SQLConnect r = new SQLConnect();
        public BillingConfirmation()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            BookingConfirmation a = new BookingConfirmation(label2.Text);
            a.Show();
            this.Hide();
        }
    }
}
