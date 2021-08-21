
namespace wndprod02
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lab_WM_MOVE_1 = new System.Windows.Forms.Label();
            this.lab_WM_MOVE_2 = new System.Windows.Forms.Label();
            this.lab_WM_KeyDown = new System.Windows.Forms.Label();
            this.lab_WM_KeyChar = new System.Windows.Forms.Label();
            this.lab_KeyDown = new System.Windows.Forms.Label();
            this.lab_KeyPress = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lab_WM_MOVE_1
            // 
            this.lab_WM_MOVE_1.AutoSize = true;
            this.lab_WM_MOVE_1.Location = new System.Drawing.Point(124, 61);
            this.lab_WM_MOVE_1.Name = "lab_WM_MOVE_1";
            this.lab_WM_MOVE_1.Size = new System.Drawing.Size(159, 23);
            this.lab_WM_MOVE_1.TabIndex = 0;
            this.lab_WM_MOVE_1.Text = "lab_WM_MOVE_1";
            this.lab_WM_MOVE_1.Click += new System.EventHandler(this.lab_WM_MOVE_1_Click);
            // 
            // lab_WM_MOVE_2
            // 
            this.lab_WM_MOVE_2.AutoSize = true;
            this.lab_WM_MOVE_2.Location = new System.Drawing.Point(124, 102);
            this.lab_WM_MOVE_2.Name = "lab_WM_MOVE_2";
            this.lab_WM_MOVE_2.Size = new System.Drawing.Size(159, 23);
            this.lab_WM_MOVE_2.TabIndex = 1;
            this.lab_WM_MOVE_2.Text = "lab_WM_MOVE_2";
            this.lab_WM_MOVE_2.Click += new System.EventHandler(this.lab_WM_MOVE_2_Click);
            // 
            // lab_WM_KeyDown
            // 
            this.lab_WM_KeyDown.AutoSize = true;
            this.lab_WM_KeyDown.Location = new System.Drawing.Point(124, 174);
            this.lab_WM_KeyDown.Name = "lab_WM_KeyDown";
            this.lab_WM_KeyDown.Size = new System.Drawing.Size(167, 23);
            this.lab_WM_KeyDown.TabIndex = 2;
            this.lab_WM_KeyDown.Text = "lab_WM_KeyDown";
            // 
            // lab_WM_KeyChar
            // 
            this.lab_WM_KeyChar.AutoSize = true;
            this.lab_WM_KeyChar.Location = new System.Drawing.Point(126, 230);
            this.lab_WM_KeyChar.Name = "lab_WM_KeyChar";
            this.lab_WM_KeyChar.Size = new System.Drawing.Size(157, 23);
            this.lab_WM_KeyChar.TabIndex = 3;
            this.lab_WM_KeyChar.Text = "lab_WM_KeyChar";
            // 
            // lab_KeyDown
            // 
            this.lab_KeyDown.AutoSize = true;
            this.lab_KeyDown.Location = new System.Drawing.Point(376, 174);
            this.lab_KeyDown.Name = "lab_KeyDown";
            this.lab_KeyDown.Size = new System.Drawing.Size(124, 23);
            this.lab_KeyDown.TabIndex = 4;
            this.lab_KeyDown.Text = "lab_KeyDown";
            // 
            // lab_KeyPress
            // 
            this.lab_KeyPress.AutoSize = true;
            this.lab_KeyPress.Location = new System.Drawing.Point(376, 230);
            this.lab_KeyPress.Name = "lab_KeyPress";
            this.lab_KeyPress.Size = new System.Drawing.Size(118, 23);
            this.lab_KeyPress.TabIndex = 5;
            this.lab_KeyPress.Text = "lab_KeyPress";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(523, 286);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(163, 31);
            this.comboBox1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lab_KeyPress);
            this.Controls.Add(this.lab_KeyDown);
            this.Controls.Add(this.lab_WM_KeyChar);
            this.Controls.Add(this.lab_WM_KeyDown);
            this.Controls.Add(this.lab_WM_MOVE_2);
            this.Controls.Add(this.lab_WM_MOVE_1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_WM_MOVE_1;
        private System.Windows.Forms.Label lab_WM_MOVE_2;
        private System.Windows.Forms.Label lab_WM_KeyDown;
        private System.Windows.Forms.Label lab_WM_KeyChar;
        private System.Windows.Forms.Label lab_KeyDown;
        private System.Windows.Forms.Label lab_KeyPress;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

