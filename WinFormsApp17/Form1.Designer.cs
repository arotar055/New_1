namespace WinFormsApp17
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();

            // checkBox1
            this.checkBox1.Location = new System.Drawing.Point(30, 20);
            this.checkBox1.Text = "Запустить 1-й поток";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);

            // checkBox2
            this.checkBox2.Location = new System.Drawing.Point(30, 50);
            this.checkBox2.Text = "Приостановить 1-й поток";
            this.checkBox2.Enabled = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);

            // checkBox4
            this.checkBox4.Location = new System.Drawing.Point(30, 90);
            this.checkBox4.Text = "Запустить 2-й поток";
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);

            // checkBox3
            this.checkBox3.Location = new System.Drawing.Point(30, 120);
            this.checkBox3.Text = "Приостановить 2-й поток";
            this.checkBox3.Enabled = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);

            // checkBox6
            this.checkBox6.Location = new System.Drawing.Point(30, 160);
            this.checkBox6.Text = "Запустить 3-й поток";
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);

            // checkBox5
            this.checkBox5.Location = new System.Drawing.Point(30, 190);
            this.checkBox5.Text = "Приостановить 3-й поток";
            this.checkBox5.Enabled = false;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);

            // progressBar1
            this.progressBar1.Location = new System.Drawing.Point(200, 30);
            this.progressBar1.Size = new System.Drawing.Size(200, 20);

            // progressBar2
            this.progressBar2.Location = new System.Drawing.Point(200, 100);
            this.progressBar2.Size = new System.Drawing.Size(200, 20);

            // progressBar3
            this.progressBar3.Location = new System.Drawing.Point(200, 170);
            this.progressBar3.Size = new System.Drawing.Size(200, 20);

            // Form1
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar3);
            this.Text = "Многопоточное приложение";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
    }
}
