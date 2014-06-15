namespace controlPrg
{
    partial class Main_Form
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tick_tack = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openxmlbtnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openfromhddbtnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openfromdbbtnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savexmlbtnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tohddbtnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todbbtnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.модулиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.db_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.vectorizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 733);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1152, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel1.Text = " ";
            // 
            // tick_tack
            // 
            this.tick_tack.Enabled = true;
            this.tick_tack.Interval = 30;
            this.tick_tack.Tick += new System.EventHandler(this.tick_tack_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.модулиToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1152, 28);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openxmlbtnToolStripMenuItem,
            this.savexmlbtnToolStripMenuItem});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(64, 24);
            this.toolStripComboBox1.Text = "Схема";
            // 
            // openxmlbtnToolStripMenuItem
            // 
            this.openxmlbtnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openfromhddbtnToolStripMenuItem,
            this.openfromdbbtnToolStripMenuItem});
            this.openxmlbtnToolStripMenuItem.Name = "openxmlbtnToolStripMenuItem";
            this.openxmlbtnToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.openxmlbtnToolStripMenuItem.Text = "Загрузить";
            // 
            // openfromhddbtnToolStripMenuItem
            // 
            this.openfromhddbtnToolStripMenuItem.Name = "openfromhddbtnToolStripMenuItem";
            this.openfromhddbtnToolStripMenuItem.Size = new System.Drawing.Size(197, 24);
            this.openfromhddbtnToolStripMenuItem.Text = "С жесткого диска";
            this.openfromhddbtnToolStripMenuItem.Click += new System.EventHandler(this.button7_Click);
            // 
            // openfromdbbtnToolStripMenuItem
            // 
            this.openfromdbbtnToolStripMenuItem.Name = "openfromdbbtnToolStripMenuItem";
            this.openfromdbbtnToolStripMenuItem.Size = new System.Drawing.Size(197, 24);
            this.openfromdbbtnToolStripMenuItem.Text = "Из БД";
            // 
            // savexmlbtnToolStripMenuItem
            // 
            this.savexmlbtnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tohddbtnToolStripMenuItem,
            this.todbbtnToolStripMenuItem});
            this.savexmlbtnToolStripMenuItem.Name = "savexmlbtnToolStripMenuItem";
            this.savexmlbtnToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.savexmlbtnToolStripMenuItem.Text = "Сохранить";
            // 
            // tohddbtnToolStripMenuItem
            // 
            this.tohddbtnToolStripMenuItem.Name = "tohddbtnToolStripMenuItem";
            this.tohddbtnToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.tohddbtnToolStripMenuItem.Text = "На жесткий диск";
            this.tohddbtnToolStripMenuItem.Click += new System.EventHandler(this.button4_Click);
            // 
            // todbbtnToolStripMenuItem
            // 
            this.todbbtnToolStripMenuItem.Name = "todbbtnToolStripMenuItem";
            this.todbbtnToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.todbbtnToolStripMenuItem.Text = "В БД";
            // 
            // модулиToolStripMenuItem
            // 
            this.модулиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.db_btn,
            this.vectorizerToolStripMenuItem});
            this.модулиToolStripMenuItem.Name = "модулиToolStripMenuItem";
            this.модулиToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.модулиToolStripMenuItem.Text = "Модули";
            // 
            // db_btn
            // 
            this.db_btn.Name = "db_btn";
            this.db_btn.Size = new System.Drawing.Size(174, 24);
            this.db_btn.Text = "Просмотр БД";
            this.db_btn.Click += new System.EventHandler(this.db_btn_Click);
            // 
            // vectorizerToolStripMenuItem
            // 
            this.vectorizerToolStripMenuItem.Name = "vectorizerToolStripMenuItem";
            this.vectorizerToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.vectorizerToolStripMenuItem.Text = "Векторизатор";
            this.vectorizerToolStripMenuItem.Click += new System.EventHandler(this.vectorizerToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.удалитьToolStripMenuItem,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(229, 100);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(228, 24);
            this.toolStripMenuItem1.Text = "Добавить агента";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(228, 24);
            this.toolStripMenuItem2.Text = "Добавить отношение";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(228, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(228, 24);
            this.toolStripMenuItem3.Text = "Очистить";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 55);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 28);
            this.button1.TabIndex = 29;
            this.button1.Text = "Распознать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(16, 55);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(132, 28);
            this.button5.TabIndex = 27;
            this.button5.Text = "Обучить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(16, 91);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1119, 636);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(308, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(827, 28);
            this.label1.TabIndex = 32;
            this.label1.Text = "Результат:";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 758);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main_Form";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer tick_tack;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem модулиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem db_btn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem vectorizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem openxmlbtnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openfromhddbtnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openfromdbbtnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savexmlbtnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tohddbtnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todbbtnToolStripMenuItem;
    }
}

