﻿namespace laba2
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
            this.genM = new System.Windows.Forms.Button();
            this.NumberM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.genN = new System.Windows.Forms.Button();
            this.QuadrangleText = new System.Windows.Forms.RichTextBox();
            this.NumberN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ParallelogramText
            // 
            this.ParallelogramText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ParallelogramText.Location = new System.Drawing.Point(440, 93);
            this.ParallelogramText.Name = "ParallelogramText";
            this.ParallelogramText.Size = new System.Drawing.Size(396, 269);
            this.ParallelogramText.TabIndex = 24;
            this.ParallelogramText.Text = "";
            // 
            // genM
            // 
            this.genM.Location = new System.Drawing.Point(776, 19);
            this.genM.Name = "genM";
            this.genM.Size = new System.Drawing.Size(93, 33);
            this.genM.TabIndex = 23;
            this.genM.Text = "Generate";
            this.genM.UseVisualStyleBackColor = true;
            this.genM.Click += new System.EventHandler(this.genM_Click);
            // 
            // NumberM
            // 
            this.NumberM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.NumberM.Location = new System.Drawing.Point(715, 21);
            this.NumberM.Name = "NumberM";
            this.NumberM.Size = new System.Drawing.Size(46, 29);
            this.NumberM.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(436, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "Input quantity of parallelograms ";
            // 
            // genN
            // 
            this.genN.Location = new System.Drawing.Point(325, 17);
            this.genN.Name = "genN";
            this.genN.Size = new System.Drawing.Size(93, 33);
            this.genN.TabIndex = 20;
            this.genN.Text = "Generate";
            this.genN.UseVisualStyleBackColor = true;
            this.genN.Click += new System.EventHandler(this.genN_Click);
            // 
            // QuadrangleText
            // 
            this.QuadrangleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.QuadrangleText.Location = new System.Drawing.Point(12, 93);
            this.QuadrangleText.Name = "QuadrangleText";
            this.QuadrangleText.Size = new System.Drawing.Size(396, 269);
            this.QuadrangleText.TabIndex = 19;
            this.QuadrangleText.Text = "";            
            // 
            // NumberN
            // 
            this.NumberN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.NumberN.Location = new System.Drawing.Point(264, 18);
            this.NumberN.Name = "NumberN";
            this.NumberN.Size = new System.Drawing.Size(46, 29);
            this.NumberN.TabIndex = 18;
            //
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Input quantity of quadrangles";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(725, 381);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(93, 33);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 450);
            this.Controls.Add(this.ParallelogramText);
            this.Controls.Add(this.genM);
            this.Controls.Add(this.NumberM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.genN);
            this.Controls.Add(this.QuadrangleText);
            this.Controls.Add(this.NumberN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ParallelogramText;
        private System.Windows.Forms.Button genM;
        private System.Windows.Forms.TextBox NumberM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button genN;
        private System.Windows.Forms.RichTextBox QuadrangleText;
        private System.Windows.Forms.TextBox NumberN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
    }
}
