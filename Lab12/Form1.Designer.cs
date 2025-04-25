namespace AlarmClockApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTimeInput;
        private System.Windows.Forms.Button btnStart;

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
            this.txtTimeInput = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTimeInput
            // 
            this.txtTimeInput.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimeInput.Location = new System.Drawing.Point(30, 30);
            this.txtTimeInput.Name = "txtTimeInput";
            this.txtTimeInput.Text = "HH:MM:SS";
            this.txtTimeInput.ForeColor = System.Drawing.Color.Gray;
            this.txtTimeInput.GotFocus += (s, e) => {
                if (txtTimeInput.Text == "HH:MM:SS")
                {
                    txtTimeInput.Text = "";
                    txtTimeInput.ForeColor = System.Drawing.Color.Black;
                }
            };
            this.txtTimeInput.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtTimeInput.Text))
                {
                    txtTimeInput.Text = "HH:MM:SS";
                    txtTimeInput.ForeColor = System.Drawing.Color.Gray;
                }
            };
            this.txtTimeInput.Size = new System.Drawing.Size(200, 29);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnStart.Location = new System.Drawing.Point(250, 30);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.Text = "Start Alarm";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(400, 100);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtTimeInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Alarm Clock";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}