using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guiApp
{
    public partial class Form1 : Form
    {
        private long points = 0;
        private long autoClickers = 0;
        private bool denyEnter = false;

        private Timer timer1; //for autoclickers

        public Form1()
        {
            InitializeComponent();
            InitTimer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void form1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter);
            if(!denyEnter)
            {
                points += 1;
                refreshGUIPoints();
            }
            denyEnter = false;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //the button for autoclicker upgrades
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult userOption = MessageBox.Show("Buy auot clicker 100 pts???", 
                "Confirm!?!", MessageBoxButtons.YesNo);
            if((userOption == DialogResult.Yes) && (points >= 100))
            {
                points -= 100;
                autoClickers += 1;
                refreshGUIPoints();
            }
            else if((userOption == DialogResult.Yes) && (points < 100))
            {
                MessageBox.Show("big noob! not enough points !!!");
            }
            else
            {
                //do nothing
            }
        }

        //update the point counter on the GUI
        private void refreshGUIPoints()
        {
            label2.Text = "points:\n" + points;
        }

        //points gained through auto clickers
        private void addAutoPoints()
        {
            points += autoClickers * 1;
            refreshGUIPoints();
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            addAutoPoints();
        }

        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                System.Console.WriteLine("enter shall not bazinga");
                denyEnter = true;
            }
        }
    }
}
