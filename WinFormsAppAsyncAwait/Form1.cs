using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppAsyncAwait
{
    //每隔一秒更新一次文本,顯示當前時間的窗體
    public partial class Form1 : Form
    {
        public Label _label1;
        public Form1()
        {
            //訪問只有在同步上下文(介面線程)中才能使用的資源(介面控件)
            _label1 = new Label();
            _label1.Size = new Size(600, 600);
            _label1.Location = new Point(30, 30);
            Controls.Add(_label1);

            //借助 await 執行後台任務, 會在執行到第一個await時立刻返回   
            UpdateLabel();
            //可從執行緒視窗觀察  task.run的thread 會不斷進入背景執行緒  但async await只進去一次


        }

        public async void UpdateLabel()
        {
            bool isDisposed = false;
            while (!isDisposed)
            {
                //休眠1s
                //await 前 會自動記錄當前的同步上下文
                await Task.Delay(1000);

                //await 後會自動使用之前紀錄的同步上下文執行接下來的代碼
                //之前紀錄的同步上下文會在介面線程中 調用接下來的代碼

                //訪問只有在介面線程中才能使用的資源(介面控件)
                isDisposed = _label1.IsDisposed;

                //防止控件銷毀後操作
                if (!isDisposed)
                {
                    _label1.Text = DateTime.Now.ToString();
                }
            }
        }

    }
}
