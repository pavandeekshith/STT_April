using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlarmClockApp
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private DateTime targetTime;
        private bool isAlarmSet = false;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;

            btnStart.Click += BtnStart_Click;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtTimeInput.Text, out targetTime))
            {
                isAlarmSet = true;
                MessageBox.Show($"Alarm set for {targetTime.ToLongTimeString()}");
                timer.Start();
            }
            else
            {
                MessageBox.Show("Invalid time format. Please enter time in HH:MM:SS.");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!isAlarmSet)
                return;

            this.BackColor = GetRandomColor();

            DateTime now = DateTime.Now;
            if (now.Hour == targetTime.Hour &&
                now.Minute == targetTime.Minute &&
                now.Second == targetTime.Second)
            {
                timer.Stop();
                isAlarmSet = false;
                MessageBox.Show("⏰ Alarm! Time's up!", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(255,
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256));
        }
    }
}