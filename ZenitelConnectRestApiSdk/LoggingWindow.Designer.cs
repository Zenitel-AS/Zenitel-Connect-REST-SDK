
namespace Zenitel.Connect.RestApi.Sdk
{
    partial class LoggingWindow
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
            this.lbx_Logger = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbx_Logger
            // 
            this.lbx_Logger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_Logger.FormattingEnabled = true;
            this.lbx_Logger.HorizontalScrollbar = true;
            this.lbx_Logger.ItemHeight = 20;
            this.lbx_Logger.Location = new System.Drawing.Point(15, 13);
            this.lbx_Logger.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbx_Logger.Name = "lbx_Logger";
            this.lbx_Logger.Size = new System.Drawing.Size(1504, 524);
            this.lbx_Logger.TabIndex = 18;
            // 
            // LoggingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 554);
            this.Controls.Add(this.lbx_Logger);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoggingWindow";
            this.Text = "LoggingWindow";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lbx_Logger;
    }
}