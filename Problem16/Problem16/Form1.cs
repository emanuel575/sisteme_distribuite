using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Problem16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Threading.Timer myTimer = new System.Threading.Timer(new TimerCallback(showTime), null, 1000, 1000);

        }

        [StructLayout(LayoutKind.Sequential)]
        public class SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        [DllImport("kernel32.dll")]
        public static extern void GetSystemTime(SYSTEMTIME time);

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public void showTime(object state)
        {
            var myTime = new SYSTEMTIME();
            GetSystemTime(myTime);
            DateTime dt = new DateTime(myTime.wYear, myTime.wMonth, myTime.wDay, myTime.wHour, myTime.wMinute, myTime.wSecond, myTime.wMilliseconds);
            DateTime newDT = dt.ToLocalTime();
            string currentTime = newDT.Hour.ToString() + " : " + newDT.Minute.ToString() + " : " + newDT.Second.ToString();
            textBox1.Text = currentTime;
        }
    }
}
