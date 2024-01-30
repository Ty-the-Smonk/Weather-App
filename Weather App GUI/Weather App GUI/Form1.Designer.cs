namespace Weather_App_GUI
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
            btnGet = new Button();
            lblWeather = new Label();
            SuspendLayout();
            // 
            // btnGet
            // 
            btnGet.Location = new Point(330, 294);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(123, 87);
            btnGet.TabIndex = 0;
            btnGet.Text = "Collect WEATHER";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // lblWeather
            // 
            lblWeather.AutoSize = true;
            lblWeather.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWeather.Location = new Point(362, 104);
            lblWeather.Name = "lblWeather";
            lblWeather.Size = new Size(67, 30);
            lblWeather.TabIndex = 1;
            lblWeather.Text = "______";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblWeather);
            Controls.Add(btnGet);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGet;
        private Label lblWeather;
    }
}
