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
    public partial class Form1 : Form
    {

        SQLConnect r = new SQLConnect();
        String sql;
        int from, to;
      
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.dgout.Columns["From"].Visible = false;
            ////this.dgout.Columns["ID"].Visible = false;
            ////this.dgret.Columns["RouteID"].Visible = false;
            ////this.dgret.Columns["ID"].Visible = false;
            txtpassenger.Enabled = false;
            btnBook.Enabled = false;
            
            dg();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(rdoneway.Checked==false && edreturn.Checked == false)
            {
                MessageBox.Show("Please Choose between Return or One way!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                cabinsort();
                txtpassenger.Enabled = true;
                btnBook.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            BookFlight();
        }

        //dg display
        private void dg()
        {
            sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        Cast(EconomyPrice as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID";
            r.DisplaySingle(sql);
            dgout.DataSource = r.MultipleData(sql).Tables["tbl"];

        }

        //fromto code
        private void FromTo()
        {
            if (cmbfrom.SelectedIndex == 0)
            {
                from = 2;
            }
            else if (cmbfrom.SelectedIndex == 1)
            {
                from = 3;
            }
            else if (cmbfrom.SelectedIndex == 2)
            {
                from = 4;
            }
            else if (cmbfrom.SelectedIndex == 3)
            {
                from = 5;
            }
            else if (cmbfrom.SelectedIndex == 4)
            {
                from = 6;
            }
            else if (cmbfrom.SelectedIndex == 5)
            {
                from = 7;
            }

            if (cmbTo.SelectedIndex == 0)
            {
                to = 2;
            }
            else if (cmbTo.SelectedIndex == 1)
            {
                to = 3;
            }
            else if (cmbTo.SelectedIndex == 2)
            {
                to = 4;
            }
            else if (cmbTo.SelectedIndex == 3)
            {
                to = 5;
            }
            else if (cmbTo.SelectedIndex == 4)
            {
                to = 6;
            }
            else if (cmbTo.SelectedIndex == 5)
            {
                to = 7;
            }
        }
        //indirect flight
        private void indirectEco1()
        {
            if (rdoneway.Checked == true)
            {
                sql = @"Select distinct
	case when RouteID=8 then (Select IATACode from Airports where ID=Routes.DepartureAirportID)
		 else 'AUH' end as [From],
	case when RouteID=10 then (Select IATACode from Airports where ID=Routes.ArrivalAirportID)
		 else 'CAI' end  as [To],
	Date,
	Time,

	case when RouteID=8 then 
		(Select distinct FlightNumber from Schedules where RouteID=8)+'-'+ (Select distinct FlightNumber  from Schedules where RouteID=10)
	else FlightNumber  end as[FlightNumber],
	case when RouteID=8 and Date='2017-10-04' then
		(Select distinct EconomyPrice  from Schedules where RouteID=8 and Date='2017-10-04')+'-'+ (Select distinct  EconomyPrice   from Schedules where RouteID=10 and Date='2017-10-04')
		when RouteID=8 and Date='2017-10-11' then
		(Select distinct EconomyPrice  from Schedules where RouteID=8 and Date='2017-10-11')+'-'+ (Select distinct  EconomyPrice   from Schedules where RouteID=10 and Date='2017-10-11')
		when RouteID=8 and Date='2017-10-18' then
		(Select distinct EconomyPrice  from Schedules where RouteID=8 and Date='2017-10-18')+'-'+ (Select distinct  EconomyPrice   from Schedules where RouteID=10 and Date='2017-10-18')
		when RouteID=8 and Date='2017-10-25' then
		(Select distinct EconomyPrice  from Schedules where RouteID=8 and Date='2017-10-25')+'-'+ (Select distinct  EconomyPrice   from Schedules where RouteID=10 and Date='2017-10-25')
	else cast(EconomyPrice as int) end as [Cabin Price],
	case when RouteID=8 then 1
		when RouteID=10 then 1
	else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	from Schedules
	inner join Routes on Schedules.RouteID=Routes.ID where RouteID=8 or RouteID=14  OR DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'and Date='" + outboundate.Value.ToString("yyyyMMdd") + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
            }
            else if (edreturn.Checked == true)
            {
                sql = @"Select distinct
	case when RouteID=8 then (Select IATACode from Airports where ID=Routes.DepartureAirportID)
		 else 'AUH' end as [From],
	case when RouteID=10 then (Select IATACode from Airports where ID=Routes.ArrivalAirportID)
		 else 'CAI' end  as [To],
	Date,
	Time,

	case when RouteID=8 then 
		(Select distinct FlightNumber from Schedules where RouteID=8)+'-'+ (Select distinct FlightNumber  from Schedules where RouteID=10)
	else FlightNumber  end as[FlightNumber],
	case when RouteID=8 and Date='2017-10-04' then
		(Select distinct EconomyPrice  from Schedules where RouteID=8 and Date='2017-10-04')+'-'+ (Select distinct  EconomyPrice   from Schedules where RouteID=10 and Date='2017-10-04')
		when RouteID=8 and Date='2017-10-11' then
		(Select distinct EconomyPrice  from Schedules where RouteID=8 and Date='2017-10-11')+'-'+ (Select distinct  EconomyPrice   from Schedules where RouteID=10 and Date='2017-10-11')
		when RouteID=8 and Date='2017-10-18' then
		(Select distinct EconomyPrice  from Schedules where RouteID=8 and Date='2017-10-18')+'-'+ (Select distinct  EconomyPrice   from Schedules where RouteID=10 and Date='2017-10-18')
		when RouteID=8 and Date='2017-10-25' then
		(Select distinct EconomyPrice  from Schedules where RouteID=8 and Date='2017-10-25')+'-'+ (Select distinct  EconomyPrice   from Schedules where RouteID=10 and Date='2017-10-25')
	else cast(EconomyPrice as int) end as [Cabin Price],
	case when RouteID=8 then 1
		when RouteID=10 then 1
	else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	from Schedules
	inner join Routes on Schedules.RouteID=Routes.ID where RouteID=8 or RouteID=14  OR DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'and Date='" + outboundate.Value.ToString("yyyyMMdd") + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
                sql = @"Select distinct
	case when RouteID=8 then (Select IATACode from Airports where ID=Routes.DepartureAirportID)
		 else 'CAI' end as [From],
	case when RouteID=10 then (Select IATACode from Airports where ID=Routes.ArrivalAirportID)
		 else 'AUH' end  as [To],
	Date,
	Time,

	case when RouteID=8 then 
		(Select distinct FlightNumber from Schedules where RouteID=8)+'-'+ (Select distinct FlightNumber  from Schedules where RouteID=10)
	else FlightNumber  end as[FlightNumber],
	case when RouteID=8 and Date='2017-10-04' then
		(Select distinct EconomyPrice  from Schedules where RouteID=8 and Date='2017-10-04')+'-'+ (Select distinct  EconomyPrice   from Schedules where RouteID=10 and Date='2017-10-04')
		when RouteID=8 and Date='2017-10-11' then
		(Select distinct EconomyPrice  from Schedules where RouteID=8 and Date='2017-10-11')+'-'+ (Select distinct  EconomyPrice   from Schedules where RouteID=10 and Date='2017-10-11')
		when RouteID=8 and Date='2017-10-18' then
		(Select distinct EconomyPrice  from Schedules where RouteID=8 and Date='2017-10-18')+'-'+ (Select distinct  EconomyPrice   from Schedules where RouteID=10 and Date='2017-10-18')
		when RouteID=8 and Date='2017-10-25' then
		(Select distinct EconomyPrice  from Schedules where RouteID=8 and Date='2017-10-25')+'-'+ (Select distinct  EconomyPrice   from Schedules where RouteID=10 and Date='2017-10-25')
	else cast(EconomyPrice as int) end as [Cabin Price],
	case when RouteID=8 then 1
		when RouteID=10 then 1
	else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	from Schedules
	inner join Routes on Schedules.RouteID=Routes.ID where RouteID=9 or RouteID=15 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' OR DepartureAirportID='" + to + "'and ArrivalAirportID='" + from + "'";
                r.DisplaySingle(sql);
                dgret.DataSource = r.MultipleData(sql).Tables["tbl"];
                retfrom.Text = r.getf1();
                retto.Text = r.getf2();
            }
        }
        private void indirectBusiness1()
        {
            if (rdoneway.Checked == true)
            {
                sql = @"Select distinct
	case when RouteID=8 then (Select IATACode from Airports where ID=Routes.DepartureAirportID)
		 else 'AUH' end as [From],
	case when RouteID=10 then (Select IATACode from Airports where ID=Routes.ArrivalAirportID)
		 else 'CAI' end  as [To],
	Date,
	Time,

	case when RouteID=8 then 
		(Select distinct FlightNumber from Schedules where RouteID=8)+'-'+ (Select distinct FlightNumber  from Schedules where RouteID=10)
	else FlightNumber  end as[FlightNumber],
	case when RouteID=8 and Date='2017-10-04' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-04')+'-'+ (Select distinct   (EconomyPrice*.35+EconomyPrice)   from Schedules where RouteID=10 and Date='2017-10-04')
		when RouteID=8 and Date='2017-10-11' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int) from Schedules where RouteID=8 and Date='2017-10-11')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-11')
		when RouteID=8 and Date='2017-10-18' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)  from Schedules where RouteID=8 and Date='2017-10-18')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-18')
		when RouteID=8 and Date='2017-10-25' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-25')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice)as int   from Schedules where RouteID=10 and Date='2017-10-25')
	else cast(EconomyPrice as int) end as [Cabin Price],
	case when RouteID=8 then 1
		when RouteID=10 then 1
	else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	from Schedules
	inner join Routes on Schedules.RouteID=Routes.ID where RouteID=8 or RouteID=14  OR DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'and Date='" + outboundate.Value.ToString("yyyyMMdd") + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
            }
            else if (edreturn.Checked == true)
            {
                sql = @"Select distinct
	case when RouteID=8 then (Select IATACode from Airports where ID=Routes.DepartureAirportID)
		 else 'AUH' end as [From],
	case when RouteID=10 then (Select IATACode from Airports where ID=Routes.ArrivalAirportID)
		 else 'CAI' end  as [To],
	Date,
	Time,

	case when RouteID=8 then 
		(Select distinct FlightNumber from Schedules where RouteID=8)+'-'+ (Select distinct FlightNumber  from Schedules where RouteID=10)
	else FlightNumber  end as[FlightNumber],
	case when RouteID=8 and Date='2017-10-04' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-04')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-04')
		when RouteID=8 and Date='2017-10-11' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int) from Schedules where RouteID=8 and Date='2017-10-11')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-11')
		when RouteID=8 and Date='2017-10-18' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)  from Schedules where RouteID=8 and Date='2017-10-18')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-18')
		when RouteID=8 and Date='2017-10-25' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-25')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-25')
	else cast(EconomyPrice as int) end as [Cabin Price],
	case when RouteID=8 then 1
		when RouteID=10 then 1
	else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	from Schedules
	inner join Routes on Schedules.RouteID=Routes.ID where RouteID=8 or RouteID=14  OR DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'and Date='" + outboundate.Value.ToString("yyyyMMdd") + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
                sql = @"Select distinct
	case when RouteID=8 then (Select IATACode from Airports where ID=Routes.DepartureAirportID)
		 else 'AUH' end as [From],
	case when RouteID=10 then (Select IATACode from Airports where ID=Routes.ArrivalAirportID)
		 else 'CAI' end  as [To],
	Date,
	Time,

	case when RouteID=8 then 
		(Select distinct FlightNumber from Schedules where RouteID=8)+'-'+ (Select distinct FlightNumber  from Schedules where RouteID=10)
	else FlightNumber  end as[FlightNumber],
	case when RouteID=8 and Date='2017-10-04' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-04')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-04')
		when RouteID=8 and Date='2017-10-11' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int) from Schedules where RouteID=8 and Date='2017-10-11')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-11')
		when RouteID=8 and Date='2017-10-18' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)  from Schedules where RouteID=8 and Date='2017-10-18')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-18')
		when RouteID=8 and Date='2017-10-25' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-25')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-25')
	else cast(EconomyPrice as int) end as [Cabin Price],
	case when RouteID=8 then 1
		when RouteID=10 then 1
	else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	from Schedules
	inner join Routes on Schedules.RouteID=Routes.ID where RouteID=9 or RouteID=15 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' OR DepartureAirportID='" + to + "'and ArrivalAirportID='" + from + "'";
                r.DisplaySingle(sql);
                dgret.DataSource = r.MultipleData(sql).Tables["tbl"];
                retfrom.Text = r.getf1();
                retto.Text = r.getf2();
            }
        }
        private void indirectBusiness2()
        {
            if (rdoneway.Checked == true)
            {
                sql = @"Select distinct
	case when RouteID=8 then (Select IATACode from Airports where ID=Routes.DepartureAirportID)
		 else 'AUH' end as [From],
	case when RouteID=10 then (Select IATACode from Airports where ID=Routes.ArrivalAirportID)
		 else 'CAI' end  as [To],
	Date,
	Time,

	case when RouteID=8 then 
		(Select distinct FlightNumber from Schedules where RouteID=8)+'-'+ (Select distinct FlightNumber  from Schedules where RouteID=10)
	else FlightNumber  end as[FlightNumber],
	case when RouteID=8 and Date='2017-10-04' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-04')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-04')
		when RouteID=8 and Date='2017-10-11' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int) from Schedules where RouteID=8 and Date='2017-10-11')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-11')
		when RouteID=8 and Date='2017-10-18' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)  from Schedules where RouteID=8 and Date='2017-10-18')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-18')
		when RouteID=8 and Date='2017-10-25' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-25')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-25')
	else cast(EconomyPrice as int) end as [Cabin Price],
	case when RouteID=8 then 1
		when RouteID=10 then 1
	else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	from Schedules
	inner join Routes on Schedules.RouteID=Routes.ID where RouteID=9 or RouteID=15  OR DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'and Date='" + outboundate.Value.ToString("yyyyMMdd") + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
            }
            else if (edreturn.Checked == true)
            {
                sql = @"Select distinct
	case when RouteID=8 then (Select IATACode from Airports where ID=Routes.DepartureAirportID)
		 else 'AUH' end as [From],
	case when RouteID=10 then (Select IATACode from Airports where ID=Routes.ArrivalAirportID)
		 else 'CAI' end  as [To],
	Date,
	Time,

	case when RouteID=8 then 
		(Select distinct FlightNumber from Schedules where RouteID=8)+'-'+ (Select distinct FlightNumber  from Schedules where RouteID=10)
	else FlightNumber  end as[FlightNumber],
	case when RouteID=8 and Date='2017-10-04' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-04')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-04')
		when RouteID=8 and Date='2017-10-11' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int) from Schedules where RouteID=8 and Date='2017-10-11')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-11')
		when RouteID=8 and Date='2017-10-18' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)  from Schedules where RouteID=8 and Date='2017-10-18')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-18')
		when RouteID=8 and Date='2017-10-25' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-25')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-25')
	else cast(EconomyPrice as int) end as [Cabin Price],
	case when RouteID=8 then 1
		when RouteID=10 then 1
	else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	from Schedules
	inner join Routes on Schedules.RouteID=Routes.ID where RouteID=9 or RouteID=15  OR DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'and Date='" + outboundate.Value.ToString("yyyyMMdd") + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
                sql = @"Select distinct
	case when RouteID=8 then (Select IATACode from Airports where ID=Routes.DepartureAirportID)
		 else 'AUH' end as [From],
	case when RouteID=10 then (Select IATACode from Airports where ID=Routes.ArrivalAirportID)
		 else 'CAI' end  as [To],
	Date,
	Time,

	case when RouteID=8 then 
		(Select distinct FlightNumber from Schedules where RouteID=8)+'-'+ (Select distinct FlightNumber  from Schedules where RouteID=10)
	else FlightNumber  end as[FlightNumber],
	case when RouteID=8 and Date='2017-10-04' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-04')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-04')
		when RouteID=8 and Date='2017-10-11' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int) from Schedules where RouteID=8 and Date='2017-10-11')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-11')
		when RouteID=8 and Date='2017-10-18' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)  from Schedules where RouteID=8 and Date='2017-10-18')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-18')
		when RouteID=8 and Date='2017-10-25' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-25')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-25')
	else cast(EconomyPrice as int) end as [Cabin Price],
	case when RouteID=8 then 1
		when RouteID=10 then 1
	else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	from Schedules
	inner join Routes on Schedules.RouteID=Routes.ID where RouteID=8 or RouteID=14 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' OR DepartureAirportID='" + to + "'and ArrivalAirportID='" + from + "'";
                r.DisplaySingle(sql);
                dgret.DataSource = r.MultipleData(sql).Tables["tbl"];
                retfrom.Text = r.getf1();
                retto.Text = r.getf2();
            }
        }
        private void indirectEco2()
        {
            if (rdoneway.Checked == true)
            {
                sql = @"Select distinct
	case when RouteID=8 then (Select IATACode from Airports where ID=Routes.DepartureAirportID)
		 else 'AUH' end as [From],
	case when RouteID=10 then (Select IATACode from Airports where ID=Routes.ArrivalAirportID)
		 else 'CAI' end  as [To],
	Date,
	Time,

	case when RouteID=8 then 
		(Select distinct FlightNumber from Schedules where RouteID=8)+'-'+ (Select distinct FlightNumber  from Schedules where RouteID=10)
	else FlightNumber  end as[FlightNumber],
	case when RouteID=8 and Date='2017-10-04' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-04')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-04')
		when RouteID=8 and Date='2017-10-11' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int) from Schedules where RouteID=8 and Date='2017-10-11')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-11')
		when RouteID=8 and Date='2017-10-18' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)  from Schedules where RouteID=8 and Date='2017-10-18')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-18')
		when RouteID=8 and Date='2017-10-25' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-25')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-25')
	else cast(EconomyPrice as int) end as [Cabin Price],
	case when RouteID=8 then 1
		when RouteID=10 then 1
	else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	from Schedules
	inner join Routes on Schedules.RouteID=Routes.ID where RouteID=9 or RouteID=15  OR DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'and Date='" + outboundate.Value.ToString("yyyyMMdd") + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
            }
            else if (edreturn.Checked == true)
            {
                sql = @"Select distinct
	case when RouteID=8 then (Select IATACode from Airports where ID=Routes.DepartureAirportID)
		 else 'AUH' end as [From],
	case when RouteID=10 then (Select IATACode from Airports where ID=Routes.ArrivalAirportID)
		 else 'CAI' end  as [To],
	Date,
	Time,

	case when RouteID=8 then 
		(Select distinct FlightNumber from Schedules where RouteID=8)+'-'+ (Select distinct FlightNumber  from Schedules where RouteID=10)
	else FlightNumber  end as[FlightNumber],
	case when RouteID=8 and Date='2017-10-04' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-04')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-04')
		when RouteID=8 and Date='2017-10-11' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int) from Schedules where RouteID=8 and Date='2017-10-11')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-11')
		when RouteID=8 and Date='2017-10-18' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)  from Schedules where RouteID=8 and Date='2017-10-18')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-18')
		when RouteID=8 and Date='2017-10-25' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-25')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-25')
	else cast(EconomyPrice as int) end as [Cabin Price],
	case when RouteID=8 then 1
		when RouteID=10 then 1
	else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	from Schedules
	inner join Routes on Schedules.RouteID=Routes.ID where RouteID=9 or RouteID=15  OR DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'and Date='" + outboundate.Value.ToString("yyyyMMdd") + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
                sql = @"Select distinct
	case when RouteID=8 then (Select IATACode from Airports where ID=Routes.DepartureAirportID)
		 else 'AUH' end as [From],
	case when RouteID=10 then (Select IATACode from Airports where ID=Routes.ArrivalAirportID)
		 else 'CAI' end  as [To],
	Date,
	Time,

	case when RouteID=8 then 
		(Select distinct FlightNumber from Schedules where RouteID=8)+'-'+ (Select distinct FlightNumber  from Schedules where RouteID=10)
	else FlightNumber  end as[FlightNumber],
	case when RouteID=8 and Date='2017-10-04' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-04')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-04')
		when RouteID=8 and Date='2017-10-11' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int) from Schedules where RouteID=8 and Date='2017-10-11')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-11')
		when RouteID=8 and Date='2017-10-18' then
		(Select distinct cast(EconomyPrice*.35+EconomyPrice as int)  from Schedules where RouteID=8 and Date='2017-10-18')+'-'+ (Select distinct   cast(EconomyPrice*.35+EconomyPrice as int)    from Schedules where RouteID=10 and Date='2017-10-18')
		when RouteID=8 and Date='2017-10-25' then
		(Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=8 and Date='2017-10-25')+'-'+ (Select distinct  cast(EconomyPrice*.35+EconomyPrice as int)   from Schedules where RouteID=10 and Date='2017-10-25')
	else cast(EconomyPrice as int) end as [Cabin Price],
	case when RouteID=8 then 1
		when RouteID=10 then 1
	else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	from Schedules
	inner join Routes on Schedules.RouteID=Routes.ID where RouteID=8 or RouteID=14 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' OR DepartureAirportID='" + to + "'and ArrivalAirportID='" + from + "'";
                r.DisplaySingle(sql);
                dgret.DataSource = r.MultipleData(sql).Tables["tbl"];
                retfrom.Text = r.getf1();
                retto.Text = r.getf2();
            }
        }
        //direct flight code
        private void directeco1()
        {
            FromTo();
            if (rdoneway.Checked == true)
            {
                sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        Cast(EconomyPrice as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>8 and RouteID<>14 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
            }
            else
            {
                sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        Cast(EconomyPrice as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>8 OR RouteID<>14 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' OR  DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
                sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        Cast(EconomyPrice as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>8 and RouteID<>14 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + to + "'and ArrivalAirportID='" + from + "'";
                r.DisplaySingle(sql);
                dgret.DataSource = r.MultipleData(sql).Tables["tbl"];
                retfrom.Text = r.getf1();
                retto.Text = r.getf2();
            }
           
        }

        //direct flight code
        private void directeco2()
        {
            FromTo();
            if (rdoneway.Checked == true)
            {
                sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        Cast(EconomyPrice as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>9 and RouteID<>15 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
            }
            else
            {
                if (outboundate.Value > dateTimePicker1.Value)
                {
                    MessageBox.Show("Invalid return date!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        Cast(EconomyPrice as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>9 and RouteID<>15 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'";
                    r.DisplaySingle(sql);
                    dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                    outfrom.Text = r.getf1();
                    outto.Text = r.getf2();
                    sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        Cast(EconomyPrice as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>9 and RouteID<>15 and Date='" + dateTimePicker1.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + to + "'and ArrivalAirportID='" + from + "'";
                    r.DisplaySingle(sql);
                    dgret.DataSource = r.MultipleData(sql).Tables["tbl"];
                    retfrom.Text = r.getf1();
                    retto.Text = r.getf2();
                }
            }
        }
        //direct flight code
        private void directbusiness1()
        {
            FromTo();
            if (rdoneway.Checked == true)
            {
                sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	       Cast((EconomyPrice*.35+EconomyPrice) as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>8 and RouteID<>14 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
            }
            else
            {
                if (outboundate.Value < dateTimePicker1.Value)
                {
                    MessageBox.Show("Invalid return date!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        Cast((EconomyPrice*.35+EconomyPrice) as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>8 and RouteID<>14 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'";
                    r.DisplaySingle(sql);
                    dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                    outfrom.Text = r.getf1();
                    outto.Text = r.getf2();
                    sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        Cast((EconomyPrice*.35+EconomyPrice) as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>8 and RouteID<>14 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + to + "'and ArrivalAirportID='" + from + "'";
                    r.DisplaySingle(sql);
                    dgret.DataSource = r.MultipleData(sql).Tables["tbl"];
                    retfrom.Text = r.getf1();
                    retto.Text = r.getf2();
                }
            }

        }

        //direct flight code
        private void directbusiness()
        {
            FromTo();
            if (rdoneway.Checked == true)
            {
                sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	         Cast((EconomyPrice*.35+EconomyPrice) as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>9 and RouteID<>15 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
            }
            else
            {
                if (outboundate.Value < dateTimePicker1.Value)
                {
                    MessageBox.Show("Invalid return date!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        Cast((EconomyPrice*.35+EconomyPrice) as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>9 and RouteID<>15 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'";
                    r.DisplaySingle(sql);
                    dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                    outfrom.Text = r.getf1();
                    outto.Text = r.getf2();
                    sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	         Cast((EconomyPrice*.35+EconomyPrice) as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>9 and RouteID<>15 and Date='" + dateTimePicker1.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + to + "'and ArrivalAirportID='" + from + "'";
                    r.DisplaySingle(sql);
                    dgret.DataSource = r.MultipleData(sql).Tables["tbl"];
                    retfrom.Text = r.getf1();
                    retto.Text = r.getf2();
                }
            }
        }

        //direct flight code
        private void directFirst1()
        {
            FromTo();
            if (rdoneway.Checked == true)
            {
                sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	       	Cast((EconomyPrice*.35+EconomyPrice)*.30 +(EconomyPrice*.35+EconomyPrice)as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>8 and RouteID<>14 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
            }
            else
            {
                if (outboundate.Value < dateTimePicker1.Value)
                {
                    MessageBox.Show("Invalid return date!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	       	Cast((EconomyPrice*.35+EconomyPrice)*.30 +(EconomyPrice*.35+EconomyPrice)as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>8 and RouteID<>14 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'";
                    r.DisplaySingle(sql);
                    dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                    outfrom.Text = r.getf1();
                    outto.Text = r.getf2();
                    sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        	Cast((EconomyPrice*.35+EconomyPrice)*.30 +(EconomyPrice*.35+EconomyPrice)as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>8 and RouteID<>14 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + to + "'and ArrivalAirportID='" + from + "'";
                    r.DisplaySingle(sql);
                    dgret.DataSource = r.MultipleData(sql).Tables["tbl"];
                    retfrom.Text = r.getf1();
                    retto.Text = r.getf2();
                }
            }
               

        }

        //direct flight code
        private void directFirst()
        {
            FromTo();
            if (rdoneway.Checked == true)
            {
                sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        	Cast((EconomyPrice*.35+EconomyPrice)*.30 +(EconomyPrice*.35+EconomyPrice)as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>9 and RouteID<>15 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
            }
            else
            {
                sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        	Cast((EconomyPrice*.35+EconomyPrice)*.30 +(EconomyPrice*.35+EconomyPrice)as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>9 and RouteID<>15 and Date='" + outboundate.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + from + "'and ArrivalAirportID='" + to + "'";
                r.DisplaySingle(sql);
                dgout.DataSource = r.MultipleData(sql).Tables["tbl"];
                outfrom.Text = r.getf1();
                outto.Text = r.getf2();
                sql = @"Select 
	        (Select IATACode from Airports where ID=Routes.DepartureAirportID) as [From],
	        (Select IATACode from Airports where ID=Routes.ArrivalAirportID) as [To],
	        Date,
	        Time,
	        FlightNumber,
	        	Cast((EconomyPrice*.35+EconomyPrice)*.30 +(EconomyPrice*.35+EconomyPrice)as float) as [Cabin Price],
	        case when RouteID=8 then 1
		        when RouteID=10 then 1
	        else 0 end as [Number of Stops],RouteID,Schedules.ID,AircraftID
	        from Schedules
	        inner join Routes on Schedules.RouteID=Routes.ID where RouteID<>9 and RouteID<>15 and Date='" + dateTimePicker1.Value.ToString("yyyyMMdd") + "' and DepartureAirportID='" + to + "'and ArrivalAirportID='" + from + "'";
                r.DisplaySingle(sql);
                dgret.DataSource = r.MultipleData(sql).Tables["tbl"];
                retfrom.Text = r.getf1();
                retto.Text = r.getf2();
            }
        }
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            cabinsort();
        }
        //cabin sort code
        private void cabinsort()
        {
            if (rdoneway.Checked == true)
            {
                if (cmbSort.SelectedIndex == 0)
                {
                    if(cmbfrom.Text!="AUH" && cmbTo.Text != "CAI")
                    {
                        directeco1();
                    }
                    else if (cmbfrom.Text != "CAI" && cmbTo.Text != "AUH")
                    {
                        directeco2();
                    }
                    if (cmbfrom.Text == "AUH" && cmbTo.Text == "CAI")
                    {
                        indirectEco1();
                    }
                    else if (cmbfrom.Text == "CAI" && cmbTo.Text == "AUH")
                    {
                        indirectEco2();
                    }

                }
                else if (cmbSort.SelectedIndex == 1)
                {
                    if (cmbfrom.Text != "AUH" && cmbTo.Text != "CAI")
                    {
                        directbusiness1();
                    }
                    else if (cmbfrom.Text != "CAI" && cmbTo.Text != "AUH")
                    {
                        directbusiness();
                    }
                    if (cmbfrom.Text == "AUH" && cmbTo.Text == "CAI")
                    {
                        indirectBusiness1();
                    }
                    else if (cmbfrom.Text == "CAI" && cmbTo.Text == "AUH")
                    {
                        indirectBusiness2();
                    }

                }
                else if (cmbSort.SelectedIndex ==2)
                {
                    if (outfrom.Text != "AUH" && outto.Text != "CAI")
                    {
                        directFirst1();
                    }
                    else if (outfrom.Text != "CAI" && outto.Text != "AUH")
                    {
                        directFirst();
                    }
                    else if (outfrom.Text == "CAI" && outto.Text == "AUH")
                    {
                        directeco2();
                    }
                    else if (outfrom.Text == "AUH" && outto.Text == "CAI")
                    {
                        indirectBusiness1();
                    }

                }
            }
            else if (edreturn.Checked == true)
            {
                if (cmbSort.SelectedIndex == 0)
                {
                    if (cmbfrom.Text != "AUH" && cmbTo.Text != "CAI")
                    {
                        directeco1();
                    }
                    else if (cmbfrom.Text != "CAI" && cmbTo.Text != "AUH")
                    {
                        directeco2();
                    }
                    if (cmbfrom.Text == "AUH" && cmbTo.Text == "CAI")
                    {
                        indirectEco1();
                    }
                    else if (cmbfrom.Text == "CAI" && cmbTo.Text == "AUH")
                    {
                        indirectEco2();
                    }

                }
                else if (cmbSort.SelectedIndex == 1)
                {
                    if (cmbfrom.Text != "AUH" && cmbTo.Text != "CAI")
                    {
                        directbusiness1();
                    }
                    else if (cmbfrom.Text != "CAI" && cmbTo.Text != "AUH")
                    {
                        directbusiness();
                    }
                    if (cmbfrom.Text == "AUH" && cmbTo.Text == "CAI")
                    {
                        indirectBusiness1();
                    }
                    else if (cmbfrom.Text != "CAI" && cmbTo.Text != "AUH")
                    {
                        indirectBusiness2();
                    }

                }
                else if (cmbSort.SelectedIndex == 2)
                {
                    if (outfrom.Text != "AUH" && outto.Text != "CAI")
                    {
                        directFirst1();
                    }
                    else if (outfrom.Text != "CAI" && outto.Text != "AUH")
                    {
                        directFirst();
                    }
                    else if (outfrom.Text == "CAI" && outto.Text == "AUH")
                    {
                        directeco2();
                    }
                    else if (outfrom.Text == "AUH" && outto.Text == "CAI")
                    {
                        indirectBusiness1();
                    }

                }
            }
        }
        int eco1, eco2, busi1, busi2, fc1, fc2;
        //code bookflight
        private void air1()
        {
            sql = "  Select EconomySeats,BusinessSeats,Totalseats-(EconomySeats+BusinessSeats) from Aircrafts where ID=1";
            r.DisplaySingle(sql);
            eco1 = Convert.ToInt16(r.getf1());
            busi1 = Convert.ToInt16(r.getf2());
            fc1= Convert.ToInt16(r.getf3());
        }
        private void air2()
        {
            sql = "  Select EconomySeats,BusinessSeats,Totalseats-(EconomySeats+BusinessSeats) from Aircrafts where ID=2";
            r.DisplaySingle(sql);
            eco2 = Convert.ToInt16(r.getf1());
            busi2 = Convert.ToInt16(r.getf2());
            fc2 = Convert.ToInt16(r.getf3());
        }

        private void BookFlight()
        {
            if (rdoneway.Checked == true)
            {
                if (dgout.Rows[dgout.CurrentRow.Index].Cells["AircraftID"].Value.ToString() == "1")
                {
                    air1();
                    if (eco1 < Convert.ToInt16(txtpassenger.Text))
                    {
                        MessageBox.Show("There is only" + " " + eco1.ToString() + " " + "seat available","Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (busi1 < Convert.ToInt16(txtpassenger.Text))
                    {
                        MessageBox.Show("There is only" + " " + busi1.ToString() + " " + "seat available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (fc1 < Convert.ToInt16(txtpassenger.Text))
                    {
                        MessageBox.Show("There is only" + " " + fc1.ToString() + " " + "seat available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        BookingConfirmation a = new BookingConfirmation(txtpassenger.Text);
                        a.lblfrom.Text=dgout.Rows[dgout.CurrentRow.Index].Cells["From"].Value.ToString();
                        a.lblto.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["To"].Value.ToString();
                        a.lbldate.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["Date"].Value.ToString();
                        a.lblflightnum.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["FlightNumber"].Value.ToString();
                        a.lblcabinret.Text = cmbSort.Text;
                        a.lblprice1.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["Cabin Price"].Value.ToString();
                        a.Show();
                        this.Hide();
                    }
                }
                else if (dgout.Rows[dgout.CurrentRow.Index].Cells["AircraftID"].Value.ToString() == "2")
                {
                    air2();
                    if (eco2< Convert.ToInt16(txtpassenger.Text))
                    {
                        MessageBox.Show("There is only" + " " + eco2.ToString() + " " + "seat available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (busi2< Convert.ToInt16(txtpassenger.Text))
                    {
                        MessageBox.Show("There is only" + " " + busi2.ToString() + " " + "seat available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (fc2< Convert.ToInt16(txtpassenger.Text))
                    {
                        MessageBox.Show("There is only" + " " + fc2.ToString() + " " + "seat available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        BookingConfirmation a = new BookingConfirmation(txtpassenger.Text);
                        a.lblfrom.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["From"].Value.ToString();
                        a.lblto.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["To"].Value.ToString();
                        a.lbldate.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["Date"].Value.ToString();
                        a.lblflightnum.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["FlightNumber"].Value.ToString();
                        a.lblcabinret.Text = cmbSort.Text;
                        a.lblprice1.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["Cabin Price"].Value.ToString();
                        a.Show();
                        this.Hide();
                    }
                }
            }
            else if (edreturn.Checked == true)
            {
                if (dgout.Rows[dgout.CurrentRow.Index].Cells["AircraftID"].Value.ToString() == "1" && dgret.Rows[dgret.CurrentRow.Index].Cells["AircraftID"].Value.ToString() == "1")
                {
                    air1();
                    if (eco1 < Convert.ToInt16(txtpassenger.Text))
                    {
                        MessageBox.Show("There is only" + " " + eco1.ToString() + " " + "seat available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (busi1 < Convert.ToInt16(txtpassenger.Text))
                    {
                        MessageBox.Show("There is only" + " " + busi1.ToString() + " " + "seat available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (fc1 < Convert.ToInt16(txtpassenger.Text))
                    {
                        MessageBox.Show("There is only" + " " + fc1.ToString() + " " + "seat available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        BookingConfirmation a = new BookingConfirmation(txtpassenger.Text);
                        a.lblfrom.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["From"].Value.ToString();
                        a.lblto.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["To"].Value.ToString();
                        a.lbldate.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["Date"].Value.ToString();
                        a.lblflightnum.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["FlightNumber"].Value.ToString();
                        a.lblcabinret.Text = cmbSort.Text;
                        a.lblprice1.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["Cabin Price"].Value.ToString();
                        a.lblrefrom.Text = dgret.Rows[dgret.CurrentRow.Index].Cells["From"].Value.ToString();
                        a.lblretto.Text = dgret.Rows[dgret.CurrentRow.Index].Cells["To"].Value.ToString();
                        a.lbldate1.Text = dgret.Rows[dgret.CurrentRow.Index].Cells["Date"].Value.ToString();
                        a.lblflighn.Text = dgret.Rows[dgret.CurrentRow.Index].Cells["FlightNumber"].Value.ToString();
                        a.lblcabin.Text = cmbSort.Text;
                        a.lblprice3.Text = dgret.Rows[dgret.CurrentRow.Index].Cells["Cabin Price"].Value.ToString();
                        a.Show();
                        this.Hide();
                    }
                }
                else if (dgout.Rows[dgout.CurrentRow.Index].Cells["AircraftID"].Value.ToString() == "1" && dgret.Rows[dgret.CurrentRow.Index].Cells["AircraftID"].Value.ToString() == "2")
                {
                    air2();
                    if (eco2 < Convert.ToInt16(txtpassenger.Text))
                    {
                        MessageBox.Show("There is only" + " " + eco2.ToString() + " " + "seat available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (busi2 < Convert.ToInt16(txtpassenger.Text))
                    {
                        MessageBox.Show("There is only" + " " + busi2.ToString() + " " + "seat available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (fc2 < Convert.ToInt16(txtpassenger.Text))
                    {
                        MessageBox.Show("There is only" + " " + fc2.ToString() + " " + "seat available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        BookingConfirmation a = new BookingConfirmation(txtpassenger.Text);
                        a.lblfrom.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["From"].Value.ToString();
                        a.lblto.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["To"].Value.ToString();
                        a.lbldate.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["Date"].Value.ToString();
                        a.lblflightnum.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["FlightNumber"].Value.ToString();
                        a.lblcabinret.Text = cmbSort.Text;
                        a.lblprice1.Text = dgout.Rows[dgout.CurrentRow.Index].Cells["Cabin Price"].Value.ToString();
                        a.lblrefrom.Text = dgret.Rows[dgret.CurrentRow.Index].Cells["From"].Value.ToString();
                        a.lblretto.Text = dgret.Rows[dgret.CurrentRow.Index].Cells["To"].Value.ToString();
                        a.lbldate1.Text = dgret.Rows[dgret.CurrentRow.Index].Cells["Date"].Value.ToString();
                        a.lblflighn.Text = dgret.Rows[dgret.CurrentRow.Index].Cells["FlightNumber"].Value.ToString();
                        a.lblcabin.Text = cmbSort.Text;
                        a.lblprice3.Text = dgret.Rows[dgret.CurrentRow.Index].Cells["Cabin Price"].Value.ToString();
                        a.Show();
                        this.Hide();
                    }
                }
            }
        }
    }
}
