namespace AutoQuiz
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
            提交答案 = new Button();
            SuspendLayout();
            // 
            // 提交答案
            // 
            提交答案.Location = new Point(456, 436);
            提交答案.Name = "提交答案";
            提交答案.Size = new Size(112, 34);
            提交答案.TabIndex = 0;
            提交答案.Text = "button1";
            提交答案.UseVisualStyleBackColor = true;
            提交答案.Click += 提交答案_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 686);
            Controls.Add(提交答案);
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button 提交答案;
    }
}