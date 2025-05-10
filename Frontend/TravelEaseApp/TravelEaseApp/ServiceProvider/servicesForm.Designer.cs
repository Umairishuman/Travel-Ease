namespace TravelEaseApp.ServiceProvider
{
    partial class servicesForm
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
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            textBox1 = new TextBox();
            mainDisplayPanel = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.Location = new Point(484, 25);
            label1.Name = "label1";
            label1.Size = new Size(149, 46);
            label1.TabIndex = 1;
            label1.Text = "Services";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(533, 598);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(15, 15);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "<";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(575, 598);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(15, 15);
            linkLabel2.TabIndex = 2;
            linkLabel2.TabStop = true;
            linkLabel2.Text = ">";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(554, 599);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(15, 16);
            textBox1.TabIndex = 3;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.WordWrap = false;
            // 
            // mainDisplayPanel
            // 
            mainDisplayPanel.AutoScroll = true;
            mainDisplayPanel.Location = new Point(12, 91);
            mainDisplayPanel.Name = "mainDisplayPanel";
            mainDisplayPanel.Size = new Size(1094, 480);
            mainDisplayPanel.TabIndex = 4;
            // 
            // servicesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 610);
            Controls.Add(mainDisplayPanel);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "servicesForm";
            Text = "Form1";
            Load += ServicesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private TextBox textBox1;
        private Panel mainDisplayPanel;
    }
}