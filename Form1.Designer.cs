namespace Session3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoneway = new System.Windows.Forms.RadioButton();
            this.edreturn = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.outboundate = new System.Windows.Forms.DateTimePicker();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbfrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgout = new System.Windows.Forms.DataGridView();
            this.dgret = new System.Windows.Forms.DataGridView();
            this.chout = new System.Windows.Forms.CheckBox();
            this.chret = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtpassenger = new System.Windows.Forms.TextBox();
            this.btnBook = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.outfrom = new System.Windows.Forms.Label();
            this.outto = new System.Windows.Forms.Label();
            this.retto = new System.Windows.Forms.Label();
            this.retfrom = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgret)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoneway);
            this.groupBox1.Controls.Add(this.edreturn);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.outboundate);
            this.groupBox1.Controls.Add(this.cmbSort);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbfrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(892, 90);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter by";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rdoneway
            // 
            this.rdoneway.AutoSize = true;
            this.rdoneway.Location = new System.Drawing.Point(101, 59);
            this.rdoneway.Name = "rdoneway";
            this.rdoneway.Size = new System.Drawing.Size(67, 17);
            this.rdoneway.TabIndex = 28;
            this.rdoneway.TabStop = true;
            this.rdoneway.Text = "One way";
            this.rdoneway.UseVisualStyleBackColor = true;
            // 
            // edreturn
            // 
            this.edreturn.AutoSize = true;
            this.edreturn.Location = new System.Drawing.Point(24, 59);
            this.edreturn.Name = "edreturn";
            this.edreturn.Size = new System.Drawing.Size(57, 17);
            this.edreturn.TabIndex = 27;
            this.edreturn.TabStop = true;
            this.edreturn.Text = "Return";
            this.edreturn.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(521, 53);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(441, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Outbound";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(75)))), ((int)(((byte)(102)))));
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(731, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 38);
            this.button1.TabIndex = 24;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // outboundate
            // 
            this.outboundate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.outboundate.Location = new System.Drawing.Point(262, 52);
            this.outboundate.Name = "outboundate";
            this.outboundate.Size = new System.Drawing.Size(121, 20);
            this.outboundate.TabIndex = 16;
            // 
            // cmbSort
            // 
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "Economy",
            "Business",
            "First Class"});
            this.cmbSort.Location = new System.Drawing.Point(718, 19);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(121, 21);
            this.cmbSort.TabIndex = 15;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(638, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Cabin Type";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Items.AddRange(new object[] {
            "AUH",
            "CAI",
            "BAH",
            "ADE",
            "DOH",
            "RUH"});
            this.cmbTo.Location = new System.Drawing.Point(409, 21);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(121, 21);
            this.cmbTo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(334, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "To";
            // 
            // cmbfrom
            // 
            this.cmbfrom.FormattingEnabled = true;
            this.cmbfrom.Items.AddRange(new object[] {
            "AUH",
            "CAI",
            "BAH",
            "ADE",
            "DOH",
            "RUH"});
            this.cmbfrom.Location = new System.Drawing.Point(101, 21);
            this.cmbfrom.Name = "cmbfrom";
            this.cmbfrom.Size = new System.Drawing.Size(121, 21);
            this.cmbfrom.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(182, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Outbound";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "From";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Outbound flight details:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 351);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Return flight details:";
            // 
            // dgout
            // 
            this.dgout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgout.GridColor = System.Drawing.Color.White;
            this.dgout.Location = new System.Drawing.Point(15, 212);
            this.dgout.Name = "dgout";
            this.dgout.Size = new System.Drawing.Size(889, 126);
            this.dgout.TabIndex = 31;
            // 
            // dgret
            // 
            this.dgret.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgret.GridColor = System.Drawing.Color.White;
            this.dgret.Location = new System.Drawing.Point(15, 374);
            this.dgret.Name = "dgret";
            this.dgret.Size = new System.Drawing.Size(889, 116);
            this.dgret.TabIndex = 32;
            // 
            // chout
            // 
            this.chout.AutoSize = true;
            this.chout.Location = new System.Drawing.Point(648, 189);
            this.chout.Name = "chout";
            this.chout.Size = new System.Drawing.Size(190, 17);
            this.chout.TabIndex = 33;
            this.chout.Text = "Display three days before and after";
            this.chout.UseVisualStyleBackColor = true;
            // 
            // chret
            // 
            this.chret.AutoSize = true;
            this.chret.Location = new System.Drawing.Point(648, 351);
            this.chret.Name = "chret";
            this.chret.Size = new System.Drawing.Size(190, 17);
            this.chret.TabIndex = 34;
            this.chret.Text = "Display three days before and after";
            this.chret.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtpassenger);
            this.groupBox2.Controls.Add(this.btnBook);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(141, 496);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(620, 82);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Confirm Booking for";
            // 
            // txtpassenger
            // 
            this.txtpassenger.Location = new System.Drawing.Point(169, 44);
            this.txtpassenger.Name = "txtpassenger";
            this.txtpassenger.Size = new System.Drawing.Size(100, 20);
            this.txtpassenger.TabIndex = 25;
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(75)))), ((int)(((byte)(102)))));
            this.btnBook.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(400, 34);
            this.btnBook.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(91, 38);
            this.btnBook.TabIndex = 24;
            this.btnBook.Text = "Book Flight";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(291, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Passengers";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(781, 522);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 38);
            this.btnExit.TabIndex = 35;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // outfrom
            // 
            this.outfrom.AutoSize = true;
            this.outfrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outfrom.ForeColor = System.Drawing.Color.White;
            this.outfrom.Location = new System.Drawing.Point(290, 238);
            this.outfrom.Name = "outfrom";
            this.outfrom.Size = new System.Drawing.Size(69, 13);
            this.outfrom.TabIndex = 29;
            this.outfrom.Text = "Outbound";
            this.outfrom.Visible = false;
            // 
            // outto
            // 
            this.outto.AutoSize = true;
            this.outto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outto.ForeColor = System.Drawing.Color.White;
            this.outto.Location = new System.Drawing.Point(418, 238);
            this.outto.Name = "outto";
            this.outto.Size = new System.Drawing.Size(69, 13);
            this.outto.TabIndex = 36;
            this.outto.Text = "Outbound";
            this.outto.Visible = false;
            // 
            // retto
            // 
            this.retto.AutoSize = true;
            this.retto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retto.ForeColor = System.Drawing.Color.White;
            this.retto.Location = new System.Drawing.Point(418, 393);
            this.retto.Name = "retto";
            this.retto.Size = new System.Drawing.Size(69, 13);
            this.retto.TabIndex = 38;
            this.retto.Text = "Outbound";
            // 
            // retfrom
            // 
            this.retfrom.AutoSize = true;
            this.retfrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retfrom.ForeColor = System.Drawing.Color.White;
            this.retfrom.Location = new System.Drawing.Point(290, 394);
            this.retfrom.Name = "retfrom";
            this.retfrom.Size = new System.Drawing.Size(69, 13);
            this.retfrom.TabIndex = 37;
            this.retfrom.Text = "Outbound";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Session3.Properties.Resources.white_2x;
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(106)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(916, 607);
            this.Controls.Add(this.dgret);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chret);
            this.Controls.Add(this.chout);
            this.Controls.Add(this.dgout);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.retto);
            this.Controls.Add(this.retfrom);
            this.Controls.Add(this.outto);
            this.Controls.Add(this.outfrom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search for Flights";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgret)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.DateTimePicker outboundate;
        public System.Windows.Forms.ComboBox cmbSort;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmbTo;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbfrom;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.RadioButton rdoneway;
        public System.Windows.Forms.RadioButton edreturn;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.DataGridView dgout;
        public System.Windows.Forms.DataGridView dgret;
        public System.Windows.Forms.CheckBox chout;
        public System.Windows.Forms.CheckBox chret;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txtpassenger;
        public System.Windows.Forms.Button btnBook;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Label outfrom;
        public System.Windows.Forms.Label outto;
        public System.Windows.Forms.Label retto;
        public System.Windows.Forms.Label retfrom;
    }
}

