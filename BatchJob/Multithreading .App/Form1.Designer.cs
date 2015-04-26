namespace Multithreading.App
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
            this.lstNumbers = new System.Windows.Forms.ListBox();
            this.btnTime = new System.Windows.Forms.Button();
            this.btnPrintNumber = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstNumbers
            // 
            this.lstNumbers.FormattingEnabled = true;
            this.lstNumbers.Location = new System.Drawing.Point(60, 99);
            this.lstNumbers.Name = "lstNumbers";
            this.lstNumbers.Size = new System.Drawing.Size(128, 147);
            this.lstNumbers.TabIndex = 0;
            // 
            // btnTime
            // 
            this.btnTime.Location = new System.Drawing.Point(60, 23);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(128, 23);
            this.btnTime.TabIndex = 1;
            this.btnTime.Text = "Time Consuming Work";
            this.btnTime.UseVisualStyleBackColor = true;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // btnPrintNumber
            // 
            this.btnPrintNumber.Location = new System.Drawing.Point(60, 53);
            this.btnPrintNumber.Name = "btnPrintNumber";
            this.btnPrintNumber.Size = new System.Drawing.Size(128, 23);
            this.btnPrintNumber.TabIndex = 2;
            this.btnPrintNumber.Text = "Print Number";
            this.btnPrintNumber.UseVisualStyleBackColor = true;
            this.btnPrintNumber.Click += new System.EventHandler(this.btnPrintNumber_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnPrintNumber);
            this.Controls.Add(this.btnTime);
            this.Controls.Add(this.lstNumbers);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstNumbers;
        private System.Windows.Forms.Button btnTime;
        private System.Windows.Forms.Button btnPrintNumber;
    }
}

