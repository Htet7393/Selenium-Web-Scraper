namespace PS7_Web_Scraper
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
            this.display_box = new System.Windows.Forms.RichTextBox();
            this.course_button = new System.Windows.Forms.Button();
            this.semester_select = new System.Windows.Forms.ComboBox();
            this.semester_label = new System.Windows.Forms.Label();
            this.year_box = new System.Windows.Forms.TextBox();
            this.year_label = new System.Windows.Forms.Label();
            this.course_box = new System.Windows.Forms.TextBox();
            this.course_label = new System.Windows.Forms.Label();
            this.single_course_button = new System.Windows.Forms.Button();
            this.dept_box = new System.Windows.Forms.TextBox();
            this.dept_label = new System.Windows.Forms.Label();
            this.enroll_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // display_box
            // 
            this.display_box.Location = new System.Drawing.Point(12, 12);
            this.display_box.Name = "display_box";
            this.display_box.Size = new System.Drawing.Size(1043, 432);
            this.display_box.TabIndex = 1;
            this.display_box.Text = "";
            // 
            // course_button
            // 
            this.course_button.BackColor = System.Drawing.SystemColors.Highlight;
            this.course_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.course_button.Location = new System.Drawing.Point(504, 473);
            this.course_button.Name = "course_button";
            this.course_button.Size = new System.Drawing.Size(191, 40);
            this.course_button.TabIndex = 2;
            this.course_button.Text = "Scrape All Courses";
            this.course_button.UseVisualStyleBackColor = false;
            this.course_button.Click += new System.EventHandler(this.course_button_Click);
            // 
            // semester_select
            // 
            this.semester_select.FormattingEnabled = true;
            this.semester_select.Location = new System.Drawing.Point(200, 490);
            this.semester_select.Name = "semester_select";
            this.semester_select.Size = new System.Drawing.Size(121, 23);
            this.semester_select.TabIndex = 3;
            this.semester_select.SelectedIndexChanged += new System.EventHandler(this.semester_select_SelectedIndexChanged);
            // 
            // semester_label
            // 
            this.semester_label.AutoSize = true;
            this.semester_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.semester_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.semester_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.semester_label.Location = new System.Drawing.Point(200, 470);
            this.semester_label.Name = "semester_label";
            this.semester_label.Size = new System.Drawing.Size(63, 17);
            this.semester_label.TabIndex = 4;
            this.semester_label.Text = "Semester";
            // 
            // year_box
            // 
            this.year_box.Location = new System.Drawing.Point(200, 556);
            this.year_box.Name = "year_box";
            this.year_box.Size = new System.Drawing.Size(121, 23);
            this.year_box.TabIndex = 5;
            this.year_box.TextChanged += new System.EventHandler(this.year_box_TextChanged);
            // 
            // year_label
            // 
            this.year_label.AutoSize = true;
            this.year_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.year_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.year_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.year_label.Location = new System.Drawing.Point(200, 536);
            this.year_label.Name = "year_label";
            this.year_label.Size = new System.Drawing.Size(33, 17);
            this.year_label.TabIndex = 6;
            this.year_label.Text = "Year";
            // 
            // course_box
            // 
            this.course_box.Location = new System.Drawing.Point(344, 556);
            this.course_box.Name = "course_box";
            this.course_box.Size = new System.Drawing.Size(121, 23);
            this.course_box.TabIndex = 9;
            this.course_box.TextChanged += new System.EventHandler(this.course_box_TextChanged);
            // 
            // course_label
            // 
            this.course_label.AutoSize = true;
            this.course_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.course_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.course_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.course_label.Location = new System.Drawing.Point(344, 536);
            this.course_label.Name = "course_label";
            this.course_label.Size = new System.Drawing.Size(96, 17);
            this.course_label.TabIndex = 10;
            this.course_label.Text = "Course Number";
            // 
            // single_course_button
            // 
            this.single_course_button.BackColor = System.Drawing.SystemColors.Highlight;
            this.single_course_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.single_course_button.Location = new System.Drawing.Point(504, 519);
            this.single_course_button.Name = "single_course_button";
            this.single_course_button.Size = new System.Drawing.Size(191, 40);
            this.single_course_button.TabIndex = 11;
            this.single_course_button.Text = "Scrape A Course";
            this.single_course_button.UseVisualStyleBackColor = false;
            this.single_course_button.Click += new System.EventHandler(this.single_course_button_Click);
            // 
            // dept_box
            // 
            this.dept_box.Location = new System.Drawing.Point(344, 490);
            this.dept_box.Name = "dept_box";
            this.dept_box.Size = new System.Drawing.Size(121, 23);
            this.dept_box.TabIndex = 12;
            this.dept_box.TextChanged += new System.EventHandler(this.dept_box_TextChanged);
            // 
            // dept_label
            // 
            this.dept_label.AutoSize = true;
            this.dept_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dept_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dept_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dept_label.Location = new System.Drawing.Point(344, 470);
            this.dept_label.Name = "dept_label";
            this.dept_label.Size = new System.Drawing.Size(78, 17);
            this.dept_label.TabIndex = 13;
            this.dept_label.Text = "Department";
            // 
            // enroll_button
            // 
            this.enroll_button.BackColor = System.Drawing.SystemColors.Highlight;
            this.enroll_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.enroll_button.Location = new System.Drawing.Point(504, 565);
            this.enroll_button.Name = "enroll_button";
            this.enroll_button.Size = new System.Drawing.Size(191, 40);
            this.enroll_button.TabIndex = 14;
            this.enroll_button.Text = "Enrollments";
            this.enroll_button.UseVisualStyleBackColor = false;
            this.enroll_button.Click += new System.EventHandler(this.enroll_button_Click);
            // 
            // save_button
            // 
            this.save_button.BackColor = System.Drawing.SystemColors.Highlight;
            this.save_button.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.save_button.Location = new System.Drawing.Point(701, 473);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(191, 132);
            this.save_button.TabIndex = 15;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = false;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 621);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.enroll_button);
            this.Controls.Add(this.dept_label);
            this.Controls.Add(this.dept_box);
            this.Controls.Add(this.single_course_button);
            this.Controls.Add(this.course_label);
            this.Controls.Add(this.course_box);
            this.Controls.Add(this.year_label);
            this.Controls.Add(this.year_box);
            this.Controls.Add(this.semester_label);
            this.Controls.Add(this.semester_select);
            this.Controls.Add(this.course_button);
            this.Controls.Add(this.display_box);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RichTextBox display_box;
        private Button primary_button;
        private Button course_button;
        private ComboBox semester_select;
        private Label semester_label;
        private TextBox year_box;
        private Label year_label;
        private TextBox course_box;
        private Label course_label;
        private Button single_course_button;
        private TextBox dept_box;
        private Label dept_label;
        private Button enroll_button;
        private Button save_button;
    }
}