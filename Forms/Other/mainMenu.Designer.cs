namespace Kursovaya
{
    partial class mainMenu
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.journalComputers = new System.Windows.Forms.Button();
            this.journalReplace = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.room = new System.Windows.Forms.Button();
            this.position = new System.Windows.Forms.Button();
            this.deportment = new System.Windows.Forms.Button();
            this.Employee = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.status = new System.Windows.Forms.Button();
            this.models = new System.Windows.Forms.Button();
            this.computers = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.journalComputers);
            this.groupBox2.Controls.Add(this.journalReplace);
            this.groupBox2.Location = new System.Drawing.Point(486, 39);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(216, 106);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Журналы";
            // 
            // journalComputers
            // 
            this.journalComputers.Location = new System.Drawing.Point(4, 65);
            this.journalComputers.Margin = new System.Windows.Forms.Padding(2);
            this.journalComputers.Name = "journalComputers";
            this.journalComputers.Size = new System.Drawing.Size(198, 32);
            this.journalComputers.TabIndex = 2;
            this.journalComputers.Text = "Журнал состояний АРМ";
            this.journalComputers.UseVisualStyleBackColor = true;
            this.journalComputers.Click += new System.EventHandler(this.journalComputers_Click);
            // 
            // journalReplace
            // 
            this.journalReplace.Location = new System.Drawing.Point(4, 28);
            this.journalReplace.Margin = new System.Windows.Forms.Padding(2);
            this.journalReplace.Name = "journalReplace";
            this.journalReplace.Size = new System.Drawing.Size(198, 32);
            this.journalReplace.TabIndex = 1;
            this.journalReplace.Text = "Журнал перемещений";
            this.journalReplace.UseVisualStyleBackColor = true;
            this.journalReplace.Click += new System.EventHandler(this.journalReplace_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.room);
            this.groupBox3.Controls.Add(this.position);
            this.groupBox3.Controls.Add(this.deportment);
            this.groupBox3.Controls.Add(this.Employee);
            this.groupBox3.Location = new System.Drawing.Point(11, 39);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(216, 182);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Кадры";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // room
            // 
            this.room.Location = new System.Drawing.Point(5, 137);
            this.room.Margin = new System.Windows.Forms.Padding(2);
            this.room.Name = "room";
            this.room.Size = new System.Drawing.Size(198, 32);
            this.room.TabIndex = 4;
            this.room.Text = "Комнаты";
            this.room.UseVisualStyleBackColor = true;
            this.room.Click += new System.EventHandler(this.room_Click);
            // 
            // position
            // 
            this.position.Location = new System.Drawing.Point(5, 101);
            this.position.Margin = new System.Windows.Forms.Padding(2);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(198, 32);
            this.position.TabIndex = 2;
            this.position.Text = "Должности";
            this.position.UseVisualStyleBackColor = true;
            this.position.Click += new System.EventHandler(this.position_Click);
            // 
            // deportment
            // 
            this.deportment.Location = new System.Drawing.Point(5, 65);
            this.deportment.Margin = new System.Windows.Forms.Padding(2);
            this.deportment.Name = "deportment";
            this.deportment.Size = new System.Drawing.Size(198, 32);
            this.deportment.TabIndex = 1;
            this.deportment.Text = "Отделы";
            this.deportment.UseVisualStyleBackColor = true;
            this.deportment.Click += new System.EventHandler(this.button8_Click);
            // 
            // Employee
            // 
            this.Employee.Location = new System.Drawing.Point(5, 28);
            this.Employee.Margin = new System.Windows.Forms.Padding(2);
            this.Employee.Name = "Employee";
            this.Employee.Size = new System.Drawing.Size(198, 32);
            this.Employee.TabIndex = 0;
            this.Employee.Text = "Сотрудники";
            this.Employee.UseVisualStyleBackColor = true;
            this.Employee.Click += new System.EventHandler(this.Employee_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.status);
            this.groupBox4.Controls.Add(this.models);
            this.groupBox4.Controls.Add(this.computers);
            this.groupBox4.Location = new System.Drawing.Point(249, 39);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(216, 144);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Техника";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(4, 101);
            this.status.Margin = new System.Windows.Forms.Padding(2);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(198, 32);
            this.status.TabIndex = 2;
            this.status.Text = "Статусы компьютеров";
            this.status.UseVisualStyleBackColor = true;
            this.status.Click += new System.EventHandler(this.status_Click);
            // 
            // models
            // 
            this.models.Location = new System.Drawing.Point(4, 64);
            this.models.Margin = new System.Windows.Forms.Padding(2);
            this.models.Name = "models";
            this.models.Size = new System.Drawing.Size(198, 32);
            this.models.TabIndex = 1;
            this.models.Text = "Модели компьютеров";
            this.models.UseVisualStyleBackColor = true;
            this.models.Click += new System.EventHandler(this.button11_Click);
            // 
            // computers
            // 
            this.computers.Location = new System.Drawing.Point(4, 28);
            this.computers.Margin = new System.Windows.Forms.Padding(2);
            this.computers.Name = "computers";
            this.computers.Size = new System.Drawing.Size(198, 32);
            this.computers.TabIndex = 0;
            this.computers.Text = "Компьютеры";
            this.computers.UseVisualStyleBackColor = true;
            this.computers.Click += new System.EventHandler(this.computers_Click);
            // 
            // mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 230);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainMenu";
            this.Text = "InventoryContol";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button journalComputers;
        private System.Windows.Forms.Button journalReplace;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button position;
        private System.Windows.Forms.Button deportment;
        private System.Windows.Forms.Button Employee;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button status;
        private System.Windows.Forms.Button models;
        private System.Windows.Forms.Button computers;
        private System.Windows.Forms.Button room;
    }
}

