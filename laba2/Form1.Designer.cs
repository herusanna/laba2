namespace laba2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ParallelogramText = new System.Windows.Forms.RichTextBox();
            this.InputM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GenBtn = new System.Windows.Forms.Button();
            this.QuadrangleText = new System.Windows.Forms.RichTextBox();
            this.InputN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.openN = new System.Windows.Forms.Button();
            this.saveN = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // ParallelogramText
            // 
            this.ParallelogramText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ParallelogramText.Location = new System.Drawing.Point(440, 93);
            this.ParallelogramText.Name = "ParallelogramText";
            this.ParallelogramText.Size = new System.Drawing.Size(396, 215);
            this.ParallelogramText.TabIndex = 24;
            this.ParallelogramText.Text = "";
            // 
            // InputM
            // 
            this.InputM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.InputM.Location = new System.Drawing.Point(790, 20);
            this.InputM.Name = "InputM";
            this.InputM.Size = new System.Drawing.Size(46, 29);
            this.InputM.TabIndex = 22;
            this.InputM.TextChanged += new System.EventHandler(this.InputM_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(511, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "Input quantity of parallelograms ";
            // 
            // GenBtn
            // 
            this.GenBtn.Location = new System.Drawing.Point(382, 19);
            this.GenBtn.Name = "GenBtn";
            this.GenBtn.Size = new System.Drawing.Size(93, 33);
            this.GenBtn.TabIndex = 20;
            this.GenBtn.Text = "Generate";
            this.GenBtn.UseVisualStyleBackColor = true;
            this.GenBtn.Click += new System.EventHandler(this.genN_Click);
            // 
            // QuadrangleText
            // 
            this.QuadrangleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.QuadrangleText.Location = new System.Drawing.Point(12, 93);
            this.QuadrangleText.Name = "QuadrangleText";
            this.QuadrangleText.Size = new System.Drawing.Size(396, 215);
            this.QuadrangleText.TabIndex = 19;
            this.QuadrangleText.Text = "";
            // 
            // InputN
            // 
            this.InputN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.InputN.Location = new System.Drawing.Point(282, 20);
            this.InputN.Name = "InputN";
            this.InputN.Size = new System.Drawing.Size(46, 29);
            this.InputN.TabIndex = 18;
            this.InputN.TextChanged += new System.EventHandler(this.InputN_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Input quantity of quadrangles";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(743, 378);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(93, 33);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click_1);
            // 
            // openN
            // 
            this.openN.Location = new System.Drawing.Point(165, 331);
            this.openN.Name = "openN";
            this.openN.Size = new System.Drawing.Size(93, 33);
            this.openN.TabIndex = 25;
            this.openN.Text = "Open";
            this.openN.UseVisualStyleBackColor = true;
            this.openN.Click += new System.EventHandler(this.openN_Click);
            // 
            // saveN
            // 
            this.saveN.Location = new System.Drawing.Point(616, 331);
            this.saveN.Name = "saveN";
            this.saveN.Size = new System.Drawing.Size(93, 33);
            this.saveN.TabIndex = 26;
            this.saveN.Text = "Save";
            this.saveN.UseVisualStyleBackColor = true;
            this.saveN.Click += new System.EventHandler(this.saveN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 423);
            this.Controls.Add(this.saveN);
            this.Controls.Add(this.openN);
            this.Controls.Add(this.ParallelogramText);
            this.Controls.Add(this.InputM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GenBtn);
            this.Controls.Add(this.QuadrangleText);
            this.Controls.Add(this.InputN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ParallelogramText;
        private System.Windows.Forms.TextBox InputM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GenBtn;
        private System.Windows.Forms.RichTextBox QuadrangleText;
        private System.Windows.Forms.TextBox InputN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button openN;
        private System.Windows.Forms.Button saveN;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

