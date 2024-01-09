namespace WindowsFormsApp2
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
            this.Name_form = new System.Windows.Forms.Label();
            this.Add_new_student = new System.Windows.Forms.Button();
            this.Delete_chose_student = new System.Windows.Forms.Button();
            this.View_gistogramm = new System.Windows.Forms.Button();
            this.Students1_box = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Name_form
            // 
            this.Name_form.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name_form.Location = new System.Drawing.Point(37, 40);
            this.Name_form.Name = "Name_form";
            this.Name_form.Size = new System.Drawing.Size(335, 45);
            this.Name_form.TabIndex = 1;
            this.Name_form.Text = "Decanat PRO Max 2023 ultra";
            this.Name_form.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Add_new_student
            // 
            this.Add_new_student.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Add_new_student.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add_new_student.Location = new System.Drawing.Point(37, 370);
            this.Add_new_student.Name = "Add_new_student";
            this.Add_new_student.Size = new System.Drawing.Size(192, 30);
            this.Add_new_student.TabIndex = 2;
            this.Add_new_student.Text = "Добавить нового студента";
            this.Add_new_student.UseVisualStyleBackColor = false;
            this.Add_new_student.Click += new System.EventHandler(this.Add_new_student_Click);
            // 
            // Delete_chose_student
            // 
            this.Delete_chose_student.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Delete_chose_student.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete_chose_student.Location = new System.Drawing.Point(235, 370);
            this.Delete_chose_student.Name = "Delete_chose_student";
            this.Delete_chose_student.Size = new System.Drawing.Size(137, 30);
            this.Delete_chose_student.TabIndex = 3;
            this.Delete_chose_student.Text = "Удалить студента";
            this.Delete_chose_student.UseVisualStyleBackColor = false;
            this.Delete_chose_student.Click += new System.EventHandler(this.Delete_chose_student_Click);
            // 
            // View_gistogramm
            // 
            this.View_gistogramm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.View_gistogramm.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.View_gistogramm.Location = new System.Drawing.Point(37, 406);
            this.View_gistogramm.Name = "View_gistogramm";
            this.View_gistogramm.Size = new System.Drawing.Size(334, 42);
            this.View_gistogramm.TabIndex = 4;
            this.View_gistogramm.Text = "Вывести гистограмму";
            this.View_gistogramm.UseVisualStyleBackColor = false;
            this.View_gistogramm.Click += new System.EventHandler(this.View_gistogramm_Click);
            // 
            // Students1_box
            // 
            this.Students1_box.FormattingEnabled = true;
            this.Students1_box.ItemHeight = 16;
            this.Students1_box.Location = new System.Drawing.Point(37, 104);
            this.Students1_box.Name = "Students1_box";
            this.Students1_box.Size = new System.Drawing.Size(333, 260);
            this.Students1_box.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(404, 481);
            this.Controls.Add(this.Students1_box);
            this.Controls.Add(this.View_gistogramm);
            this.Controls.Add(this.Delete_chose_student);
            this.Controls.Add(this.Add_new_student);
            this.Controls.Add(this.Name_form);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox Students1_box;

        private System.Windows.Forms.Button View_gistogramm;

        private System.Windows.Forms.Label Name_form;
        private System.Windows.Forms.Button Add_new_student;
        private System.Windows.Forms.Button Delete_chose_student;

        #endregion
    }
}