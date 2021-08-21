using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace wndprod02
{
    public partial class Form1 : Form
    {
        private const int WM_ACTIVATEAPP = 0x001C;
        private bool appActive = true;

        const int WM_MOUSEMOVE = 0x0200;//定義ID       
        int WndProcCallTime = 0;

        const int WM_KEYDOWN = 0x0100;
        const int WM_CHAR = 0x0102;
        public Form1()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(300, 300);
            this.Text = "Form1";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Paint a string in different styles depending on whether the
            // application is active.
            if (appActive)
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, 20, 20, 260, 50);
                e.Graphics.DrawString("Application is active", this.Font, SystemBrushes.ActiveCaptionText, 20, 20);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.InactiveCaption, 20, 20, 260, 50);
                e.Graphics.DrawString("Application is Inactive", this.Font, SystemBrushes.ActiveCaptionText, 20, 20);
            }
        }
       
        // WindowProc callback function 就是拿來接收windows message的一個函數
        // 當我們覆寫它的時候 就是自己決定要怎麼處理這個windows message
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            WndProcCallTime++;

            char keys = (char)m.WParam;
            // Listen for operating system messages.
            switch (m.Msg)
            {
                // The WM_ACTIVATEAPP message occurs when the application
                // becomes the active application or becomes inactive.
                case WM_ACTIVATEAPP:

                    // The WParam value identifies what is occurring.
                    appActive = (((int)m.WParam != 0));

                    // Invalidate to get new text painted.
                    this.Invalidate();

                    break;
                case WM_MOUSEMOVE:
                    string binary = System.Convert.ToString(m.LParam.ToInt32(), 2).PadLeft(32, '0');//轉成二進制
                    string lWord = "";
                    string hWord = "";
                    for (int i = 0; i < 16; i++)
                    {
                        hWord += binary[i].ToString();
                    }

                    for (int i = 17; i < 32; i++)
                    {
                        lWord += binary[i].ToString();
                    }
                    int x = Convert.ToInt32(lWord, 2);//二進制轉十進制
                    int y = Convert.ToInt32(hWord, 2);
                    this.lab_WM_MOVE_1.Text = string.Format("使用WM_MOUSEMOVE ,X:{0},Y:{1}", x, y);

                    ushort xpos = (ushort)m.LParam;//表示X座標
                    ushort ypos = (ushort)(m.LParam.ToInt32() >> 16);//表示X座標
                    this.lab_WM_MOVE_2.Text = string.Format("使用WM_MOUSEMOVE ,X:{0},Y:{1}", xpos, ypos);
                    break;
                case WM_KEYDOWN:
                    this.lab_WM_KeyDown.Text = string.Format("使用WM_KEYDOWN ,按下:{0}", keys.ToString());
                    break;
                case WM_CHAR:
                    this.lab_WM_KeyChar.Text = string.Format("使用WM_CHAR ,按下:{0}", keys.ToString());
                    break;
            }
            Console.WriteLine("run is: " + WndProcCallTime);           
            
            //MessageBox.Show("run is: " + WndProcCallTime);
            base.WndProc(ref m);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            this.lab_KeyDown.Text = string.Format("KeyDown 事件 ,按下:{0}", ((char)e.KeyCode).ToString());
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.lab_KeyPress.Text = string.Format("KeyPress事件 ,按下:{0}", e.KeyChar.ToString());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        // show console
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void lab_WM_MOVE_1_Click(object sender, EventArgs e)
        {

        }

        private void lab_WM_MOVE_2_Click(object sender, EventArgs e)
        {

        }
    }
}
