namespace Task_Management_System
{
    partial class MainPage
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
            this.dataTasksView = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Add = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.taskBox = new System.Windows.Forms.TextBox();
            this.AddTask = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.taskNameBoxUpdate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EditButtonData = new System.Windows.Forms.Button();
            this.dateTimePickerUpdate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.idUpdateBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataTasksView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Add.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTasksView
            // 
            this.dataTasksView.AllowUserToAddRows = false;
            this.dataTasksView.AllowUserToDeleteRows = false;
            this.dataTasksView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTasksView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTasksView.Location = new System.Drawing.Point(12, 216);
            this.dataTasksView.Name = "dataTasksView";
            this.dataTasksView.Size = new System.Drawing.Size(776, 222);
            this.dataTasksView.TabIndex = 0;
            this.dataTasksView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTasksView_CellValueChanged);
            this.dataTasksView.SelectionChanged += new System.EventHandler(this.dataTasksView_SelectionChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Add);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 162);
            this.tabControl1.TabIndex = 1;
            // 
            // Add
            // 
            this.Add.Controls.Add(this.label7);
            this.Add.Controls.Add(this.DeleteBtn);
            this.Add.Controls.Add(this.dateTimePicker);
            this.Add.Controls.Add(this.taskBox);
            this.Add.Controls.Add(this.AddTask);
            this.Add.Controls.Add(this.label2);
            this.Add.Controls.Add(this.label1);
            this.Add.Location = new System.Drawing.Point(4, 22);
            this.Add.Name = "Add";
            this.Add.Padding = new System.Windows.Forms.Padding(3);
            this.Add.Size = new System.Drawing.Size(768, 136);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add Task";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(393, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(352, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "Select the Task that needs to be Deleted!";
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(467, 93);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(200, 37);
            this.DeleteBtn.TabIndex = 6;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(96, 46);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 5;
            // 
            // taskBox
            // 
            this.taskBox.Location = new System.Drawing.Point(96, 15);
            this.taskBox.Name = "taskBox";
            this.taskBox.Size = new System.Drawing.Size(200, 20);
            this.taskBox.TabIndex = 3;
            // 
            // AddTask
            // 
            this.AddTask.Location = new System.Drawing.Point(96, 93);
            this.AddTask.Name = "AddTask";
            this.AddTask.Size = new System.Drawing.Size(200, 37);
            this.AddTask.TabIndex = 2;
            this.AddTask.Text = "Add Task";
            this.AddTask.UseVisualStyleBackColor = true;
            this.AddTask.Click += new System.EventHandler(this.AddTask_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Due Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task Name";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.taskNameBoxUpdate);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.EditButtonData);
            this.tabPage2.Controls.Add(this.dateTimePickerUpdate);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.idUpdateBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 136);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Update Task";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // taskNameBoxUpdate
            // 
            this.taskNameBoxUpdate.Location = new System.Drawing.Point(86, 54);
            this.taskNameBoxUpdate.Name = "taskNameBoxUpdate";
            this.taskNameBoxUpdate.Size = new System.Drawing.Size(200, 20);
            this.taskNameBoxUpdate.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Task Name";
            // 
            // EditButtonData
            // 
            this.EditButtonData.Location = new System.Drawing.Point(274, 94);
            this.EditButtonData.Name = "EditButtonData";
            this.EditButtonData.Size = new System.Drawing.Size(200, 36);
            this.EditButtonData.TabIndex = 4;
            this.EditButtonData.Text = "Edit";
            this.EditButtonData.UseVisualStyleBackColor = true;
            this.EditButtonData.Click += new System.EventHandler(this.EditButtonData_Click);
            // 
            // dateTimePickerUpdate
            // 
            this.dateTimePickerUpdate.Location = new System.Drawing.Point(543, 14);
            this.dateTimePickerUpdate.Name = "dateTimePickerUpdate";
            this.dateTimePickerUpdate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerUpdate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Due Date";
            // 
            // idUpdateBox
            // 
            this.idUpdateBox.Location = new System.Drawing.Point(86, 14);
            this.idUpdateBox.Name = "idUpdateBox";
            this.idUpdateBox.ReadOnly = true;
            this.idUpdateBox.Size = new System.Drawing.Size(200, 20);
            this.idUpdateBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Filter Tasks";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(102, 188);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(200, 20);
            this.SearchTextBox.TabIndex = 8;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataTasksView);
            this.Name = "MainPage";
            this.Text = "Task Management System";
            ((System.ComponentModel.ISupportInitialize)(this.dataTasksView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Add.ResumeLayout(false);
            this.Add.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataTasksView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Add;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddTask;
        private System.Windows.Forms.TextBox taskBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox idUpdateBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button EditButtonData;
        private System.Windows.Forms.DateTimePicker dateTimePickerUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox taskNameBoxUpdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Label label7;
    }
}

