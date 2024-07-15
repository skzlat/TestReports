namespace TestReports
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
            this.BTN_Start_Report = new System.Windows.Forms.Button();
            this.label_reports = new System.Windows.Forms.Label();
            this.label_modelobjects = new System.Windows.Forms.Label();
            this.BTN_Start_ModelObjects = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_Start_Report
            // 
            this.BTN_Start_Report.Location = new System.Drawing.Point(29, 32);
            this.BTN_Start_Report.Name = "BTN_Start_Report";
            this.BTN_Start_Report.Size = new System.Drawing.Size(130, 26);
            this.BTN_Start_Report.TabIndex = 0;
            this.BTN_Start_Report.Text = "Start (Report)";
            this.BTN_Start_Report.UseVisualStyleBackColor = true;
            this.BTN_Start_Report.Click += new System.EventHandler(this.BTN_Start_Click);
            // 
            // label_reports
            // 
            this.label_reports.AutoSize = true;
            this.label_reports.Location = new System.Drawing.Point(54, 61);
            this.label_reports.Name = "label_reports";
            this.label_reports.Size = new System.Drawing.Size(0, 13);
            this.label_reports.TabIndex = 1;
            // 
            // label_modelobjects
            // 
            this.label_modelobjects.AutoSize = true;
            this.label_modelobjects.Location = new System.Drawing.Point(213, 61);
            this.label_modelobjects.Name = "label_modelobjects";
            this.label_modelobjects.Size = new System.Drawing.Size(0, 13);
            this.label_modelobjects.TabIndex = 3;
            // 
            // BTN_Start_ModelObjects
            // 
            this.BTN_Start_ModelObjects.Location = new System.Drawing.Point(188, 32);
            this.BTN_Start_ModelObjects.Name = "BTN_Start_ModelObjects";
            this.BTN_Start_ModelObjects.Size = new System.Drawing.Size(130, 26);
            this.BTN_Start_ModelObjects.TabIndex = 2;
            this.BTN_Start_ModelObjects.Text = "Start (ModelObjects)";
            this.BTN_Start_ModelObjects.UseVisualStyleBackColor = true;
            this.BTN_Start_ModelObjects.Click += new System.EventHandler(this.BTN_Start_ModelObjects_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 145);
            this.Controls.Add(this.label_modelobjects);
            this.Controls.Add(this.BTN_Start_ModelObjects);
            this.Controls.Add(this.label_reports);
            this.Controls.Add(this.BTN_Start_Report);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Start_Report;
        private System.Windows.Forms.Label label_reports;
        private System.Windows.Forms.Label label_modelobjects;
        private System.Windows.Forms.Button BTN_Start_ModelObjects;
    }
}

