namespace Restorant
{
    partial class ReportsForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            label7 = new Label();
            dateTimePicker2 = new DateTimePicker();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            label8 = new Label();
            button2 = new Button();
            dataGridView2 = new DataGridView();
            button3 = new Button();
            dataGridView3 = new DataGridView();
            button4 = new Button();
            dataGridView4 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 0;
            label1.Text = "Поръчки по период";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 241);
            label2.Name = "label2";
            label2.Size = new Size(133, 15);
            label2.TabIndex = 1;
            label2.Text = "Поръчки по ресторант";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(485, 32);
            label3.Name = "label3";
            label3.Size = new Size(239, 15);
            label3.TabIndex = 2;
            label3.Text = "Най-нисък и най-висок оборот по години";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(485, 241);
            label4.Name = "label4";
            label4.Size = new Size(256, 15);
            label4.TabIndex = 3;
            label4.Text = "Справка по заведения (брой клиенти и суми)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 404);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 4;
            label5.Text = "Графики";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 52);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 32);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 6;
            label6.Text = "Начална дата";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 93);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 7;
            label7.Text = "Крайна дата";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(13, 111);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(14, 156);
            button1.Name = "button1";
            button1.Size = new Size(199, 23);
            button1.TabIndex = 9;
            button1.Text = "Генерирай";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(253, 52);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(187, 127);
            dataGridView1.TabIndex = 10;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(16, 296);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(197, 23);
            comboBox1.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 278);
            label8.Name = "label8";
            label8.Size = new Size(117, 15);
            label8.TabIndex = 12;
            label8.Text = "Избор на ресторант";
            // 
            // button2
            // 
            button2.Location = new Point(16, 325);
            button2.Name = "button2";
            button2.Size = new Size(199, 23);
            button2.TabIndex = 13;
            button2.Text = "Генерирай";
            button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(253, 241);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(187, 107);
            dataGridView2.TabIndex = 14;
            // 
            // button3
            // 
            button3.Location = new Point(485, 54);
            button3.Name = "button3";
            button3.Size = new Size(199, 23);
            button3.TabIndex = 15;
            button3.Text = "Генерирай";
            button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(485, 85);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(199, 94);
            dataGridView3.TabIndex = 16;
            // 
            // button4
            // 
            button4.Location = new Point(485, 259);
            button4.Name = "button4";
            button4.Size = new Size(199, 23);
            button4.TabIndex = 17;
            button4.Text = "Генерирай";
            button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(485, 288);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.Size = new Size(199, 94);
            dataGridView4.TabIndex = 18;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 547);
            Controls.Add(dataGridView4);
            Controls.Add(button4);
            Controls.Add(dataGridView3);
            Controls.Add(button3);
            Controls.Add(dataGridView2);
            Controls.Add(button2);
            Controls.Add(label8);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(dateTimePicker2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ReportsForm";
            Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private Label label7;
        private DateTimePicker dateTimePicker2;
        private Button button1;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Label label8;
        private Button button2;
        private DataGridView dataGridView2;
        private Button button3;
        private DataGridView dataGridView3;
        private Button button4;
        private DataGridView dataGridView4;
    }
}