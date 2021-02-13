using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace AC_Cheat
{
    public partial class Form1 : Form
    {
        Mem meme = new Mem();
        public static string RifleAmmo = "ac_client.exe + 0x00109B74,150";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int PID = meme.GetProcIdFromName("ac_client");
            if (PID > 0)
            {
                meme.OpenProcess(PID);
                Thread WA = new Thread(WriteAmmo) { IsBackground = true };
                WA.Start();
            }
        }
        private void WriteAmmo()
        {
            while (true)
            {
                if (checkBox1.Checked)
                {
                    meme.WriteMemory(RifleAmmo, "int", "99999");
                    Thread.Sleep(2);
                }
                Thread.Sleep(2);
            }
        }
    }
}
