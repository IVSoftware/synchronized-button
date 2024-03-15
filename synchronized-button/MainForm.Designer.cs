namespace synchronized_button
{
    partial class MainForm
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
            buttonSetting = new Button();
            buttonShowForm1 = new Button();
            buttonShowForm2 = new Button();
            SuspendLayout();
            // 
            // buttonSetting
            // 
            buttonSetting.Location = new Point(43, 42);
            buttonSetting.Name = "buttonSetting";
            buttonSetting.Size = new Size(171, 34);
            buttonSetting.TabIndex = 0;
            buttonSetting.Text = "Setting";
            buttonSetting.UseVisualStyleBackColor = true;
            // 
            // buttonShowForm1
            // 
            buttonShowForm1.Location = new Point(43, 82);
            buttonShowForm1.Name = "buttonShowForm1";
            buttonShowForm1.Size = new Size(171, 34);
            buttonShowForm1.TabIndex = 0;
            buttonShowForm1.Text = "Show Form 1";
            buttonShowForm1.UseVisualStyleBackColor = true;
            // 
            // buttonShowForm2
            // 
            buttonShowForm2.Location = new Point(43, 122);
            buttonShowForm2.Name = "buttonShowForm2";
            buttonShowForm2.Size = new Size(171, 34);
            buttonShowForm2.TabIndex = 0;
            buttonShowForm2.Text = "Show Form 2";
            buttonShowForm2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 244);
            Controls.Add(buttonShowForm2);
            Controls.Add(buttonShowForm1);
            Controls.Add(buttonSetting);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Form";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSetting;
        private Button buttonShowForm1;
        private Button buttonShowForm2;
    }
}
