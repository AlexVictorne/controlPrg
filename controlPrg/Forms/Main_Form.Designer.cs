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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tick_tack = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pai_btn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.createISN_btn = new System.Windows.Forms.Button();
            this.recImg_btn = new System.Windows.Forms.Button();
            this.teachISN_btn = new System.Windows.Forms.Button();
            this.testwith_btn = new System.Windows.Forms.Button();
            this.createsample_btn = new System.Windows.Forms.Button();
            this.testwithout_btn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImg_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.модулиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.samp_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.segm_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.edit_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.db_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.vectorizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.oCRModulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(366, 294);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = " ";
            // 
            // tick_tack
            // 
            this.tick_tack.Enabled = true;
            this.tick_tack.Interval = 30;
            this.tick_tack.Tick += new System.EventHandler(this.tick_tack_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(89, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Символ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Модель";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(89, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Старт";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(170, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Стоп";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // imageBox
            // 
            this.imageBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.imageBox.Location = new System.Drawing.Point(19, 19);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(64, 64);
            this.imageBox.TabIndex = 22;
            this.imageBox.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button5);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.createISN_btn);
            this.splitContainer1.Panel2.Controls.Add(this.recImg_btn);
            this.splitContainer1.Panel2.Controls.Add(this.teachISN_btn);
            this.splitContainer1.Panel2.Controls.Add(this.testwith_btn);
            this.splitContainer1.Panel2.Controls.Add(this.createsample_btn);
            this.splitContainer1.Panel2.Controls.Add(this.testwithout_btn);
            this.splitContainer1.Size = new System.Drawing.Size(624, 395);
            this.splitContainer1.SplitterDistance = 387;
            this.splitContainer1.TabIndex = 24;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(383, 391);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pai_btn);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(375, 362);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Моделирование ИНС";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pai_btn
            // 
            this.pai_btn.Location = new System.Drawing.Point(251, 19);
            this.pai_btn.Name = "pai_btn";
            this.pai_btn.Size = new System.Drawing.Size(109, 23);
            this.pai_btn.TabIndex = 9;
            this.pai_btn.Text = "Рисовать вручную";
            this.pai_btn.UseVisualStyleBackColor = true;
            this.pai_btn.Click += new System.EventHandler(this.pai_btn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.imageBox);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(375, 362);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Распознавание";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(138, 48);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 23;
            this.button5.Text = "Тест сети";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(53, 50);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 19);
            this.button4.TabIndex = 22;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // createISN_btn
            // 
            this.createISN_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createISN_btn.Location = new System.Drawing.Point(15, 96);
            this.createISN_btn.Name = "createISN_btn";
            this.createISN_btn.Size = new System.Drawing.Size(198, 23);
            this.createISN_btn.TabIndex = 16;
            this.createISN_btn.Text = "Создать нейронную сеть";
            this.createISN_btn.UseVisualStyleBackColor = true;
            // 
            // recImg_btn
            // 
            this.recImg_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recImg_btn.Enabled = false;
            this.recImg_btn.Location = new System.Drawing.Point(15, 239);
            this.recImg_btn.Name = "recImg_btn";
            this.recImg_btn.Size = new System.Drawing.Size(198, 23);
            this.recImg_btn.TabIndex = 20;
            this.recImg_btn.Text = "Распознать изображение";
            this.recImg_btn.UseVisualStyleBackColor = true;
            // 
            // teachISN_btn
            // 
            this.teachISN_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teachISN_btn.Enabled = false;
            this.teachISN_btn.Location = new System.Drawing.Point(15, 125);
            this.teachISN_btn.Name = "teachISN_btn";
            this.teachISN_btn.Size = new System.Drawing.Size(198, 23);
            this.teachISN_btn.TabIndex = 17;
            this.teachISN_btn.Text = "Обучить нейронную сеть";
            this.teachISN_btn.UseVisualStyleBackColor = true;
            // 
            // testwith_btn
            // 
            this.testwith_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testwith_btn.Enabled = false;
            this.testwith_btn.Location = new System.Drawing.Point(15, 154);
            this.testwith_btn.Name = "testwith_btn";
            this.testwith_btn.Size = new System.Drawing.Size(198, 23);
            this.testwith_btn.TabIndex = 18;
            this.testwith_btn.Text = "Тест с обуч";
            this.testwith_btn.UseVisualStyleBackColor = true;
            // 
            // createsample_btn
            // 
            this.createsample_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createsample_btn.Location = new System.Drawing.Point(15, 268);
            this.createsample_btn.Name = "createsample_btn";
            this.createsample_btn.Size = new System.Drawing.Size(198, 23);
            this.createsample_btn.TabIndex = 21;
            this.createsample_btn.Text = "Создать выборку";
            this.createsample_btn.UseVisualStyleBackColor = true;
            // 
            // testwithout_btn
            // 
            this.testwithout_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testwithout_btn.Enabled = false;
            this.testwithout_btn.Location = new System.Drawing.Point(15, 181);
            this.testwithout_btn.Name = "testwithout_btn";
            this.testwithout_btn.Size = new System.Drawing.Size(198, 23);
            this.testwithout_btn.TabIndex = 19;
            this.testwithout_btn.Text = "Тест без обуч";
            this.testwithout_btn.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.модулиToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImg_btn});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(48, 20);
            this.toolStripComboBox1.Text = "Файл";
            // 
            // loadImg_btn
            // 
            this.loadImg_btn.Name = "loadImg_btn";
            this.loadImg_btn.Size = new System.Drawing.Size(205, 22);
            this.loadImg_btn.Text = "Загрузить изображение";
            this.loadImg_btn.Click += new System.EventHandler(this.loadImg_btn_Click);
            // 
            // модулиToolStripMenuItem
            // 
            this.модулиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.samp_btn,
            this.segm_btn,
            this.edit_btn,
            this.db_btn,
            this.vectorizerToolStripMenuItem,
            this.oCRModulToolStripMenuItem});
            this.модулиToolStripMenuItem.Name = "модулиToolStripMenuItem";
            this.модулиToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.модулиToolStripMenuItem.Text = "Модули";
            // 
            // samp_btn
            // 
            this.samp_btn.Name = "samp_btn";
            this.samp_btn.Size = new System.Drawing.Size(152, 22);
            this.samp_btn.Text = "Выборщик";
            this.samp_btn.Click += new System.EventHandler(this.samp_btn_Click);
            // 
            // segm_btn
            // 
            this.segm_btn.Name = "segm_btn";
            this.segm_btn.Size = new System.Drawing.Size(152, 22);
            this.segm_btn.Text = "Сегментатор";
            this.segm_btn.Click += new System.EventHandler(this.segm_btn_Click);
            // 
            // edit_btn
            // 
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(152, 22);
            this.edit_btn.Text = "Редактор";
            this.edit_btn.Click += new System.EventHandler(this.edit_btn_Click);
            // 
            // db_btn
            // 
            this.db_btn.Name = "db_btn";
            this.db_btn.Size = new System.Drawing.Size(152, 22);
            this.db_btn.Text = "Просмотр БД";
            this.db_btn.Click += new System.EventHandler(this.db_btn_Click);
            // 
            // vectorizerToolStripMenuItem
            // 
            this.vectorizerToolStripMenuItem.Name = "vectorizerToolStripMenuItem";
            this.vectorizerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.vectorizerToolStripMenuItem.Text = "Vectorizer";
            this.vectorizerToolStripMenuItem.Click += new System.EventHandler(this.vectorizerToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(240, 22);
            this.toolStripMenuItem1.Text = "Добавить начальный элемент";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(240, 22);
            this.toolStripMenuItem2.Text = "Добавить элемент";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(240, 22);
            this.toolStripMenuItem3.Text = "Сформировать слой";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(240, 22);
            this.toolStripMenuItem4.Text = "Добавить конечный элемент";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // oCRModulToolStripMenuItem
            // 
            this.oCRModulToolStripMenuItem.Name = "oCRModulToolStripMenuItem";
            this.oCRModulToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oCRModulToolStripMenuItem.Text = "OCR Modul";
            this.oCRModulToolStripMenuItem.Click += new System.EventHandler(this.oCRModulToolStripMenuItem_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Main_Form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer tick_tack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem loadImg_btn;
        private System.Windows.Forms.ToolStripMenuItem модулиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem samp_btn;
        private System.Windows.Forms.ToolStripMenuItem segm_btn;
        private System.Windows.Forms.ToolStripMenuItem edit_btn;
        private System.Windows.Forms.ToolStripMenuItem db_btn;
        private System.Windows.Forms.Button createISN_btn;
        private System.Windows.Forms.Button recImg_btn;
        private System.Windows.Forms.Button teachISN_btn;
        private System.Windows.Forms.Button testwith_btn;
        private System.Windows.Forms.Button createsample_btn;
        private System.Windows.Forms.Button testwithout_btn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.Button pai_btn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem vectorizerToolStripMenuItem;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem oCRModulToolStripMenuItem;
    }
}

