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

namespace WinFormsApp1
{
    //每隔一秒更新一次文本,顯示當前時間的窗體
    public partial class Form1 : Form
    {
        private Label _label1;
        public Form1()
        {
            //訪問只有在同步上下文(介面線程)中才能使用的資源(介面控件)
            _label1 = new Label();
            _label1.Size = new Size(600, 600);
            _label1.Location = new Point(30, 30);
            Controls.Add(_label1);

            //捕捉當前同步上下文
            var context = SynchronizationContext.Current;

            //使用.NET運行時管理的線程池 運行某些後台操作
            Task.Run(() =>
            {
                bool isDisposed = false;
                while (!isDisposed)
                {
                    //休眠1s
                    Thread.Sleep(3000);  //這裡的Thread 是背景執行的Thread

                    //發送委託到同步上下文,委託會在介面線程執行    //可以觀察執行緒視窗  把工作丟回主thread
                    context.Send(state =>
                    {
                        //訪問只有在同步上下文(介面線程)中
                        //才能使用的資源
                        isDisposed = _label1.IsDisposed;

                        //防止控件銷毀後操作
                        if (!isDisposed)
                        {

                            _label1.Text = DateTime.Now.ToString();
                        }
                    }, null);
                }
            });
            //InitializeComponent();
        }

    }
}
