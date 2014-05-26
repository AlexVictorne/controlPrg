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
            this.createISN_btn = new System.Windows.Forms.Button();
            this.teachISN_btn = new System.Windows.Forms.Button();
            this.testwith_btn = new System.Windows.Forms.Button();
            this.testwithout_btn = new System.Windows.Forms.Button();
            this.loadImg_btn = new System.Windows.Forms.Button();
            this.recImg_btn = new System.Windows.Forms.Button();
            this.createsample_btn = new System.Windows.Forms.Button();
            this.segm_btn = new System.Windows.Forms.Button();
            this.edit_btn = new System.Windows.Forms.Button();
            this.samp_btn = new System.Windows.Forms.Button();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 216);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 320);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 214);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(484, 22);
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
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(90, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Модель";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Старт";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 187);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Стоп";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // createISN_btn
            // 
            this.createISN_btn.Location = new System.Drawing.Point(260, 12);
            this.createISN_btn.Name = "createISN_btn";
            this.createISN_btn.Size = new System.Drawing.Size(202, 23);
            this.createISN_btn.TabIndex = 9;
            this.createISN_btn.Text = "Создать нейронную сеть";
            this.createISN_btn.UseVisualStyleBackColor = true;
            this.createISN_btn.Click += new System.EventHandler(this.createISN_btn_Click);
            // 
            // teachISN_btn
            // 
            this.teachISN_btn.Enabled = false;
            this.teachISN_btn.Location = new System.Drawing.Point(260, 41);
            this.teachISN_btn.Name = "teachISN_btn";
            this.teachISN_btn.Size = new System.Drawing.Size(202, 23);
            this.teachISN_btn.TabIndex = 10;
            this.teachISN_btn.Text = "Обучить нейронную сеть";
            this.teachISN_btn.UseVisualStyleBackColor = true;
            this.teachISN_btn.Click += new System.EventHandler(this.teachISN_btn_Click);
            // 
            // testwith_btn
            // 
            this.testwith_btn.Enabled = false;
            this.testwith_btn.Location = new System.Drawing.Point(260, 70);
            this.testwith_btn.Name = "testwith_btn";
            this.testwith_btn.Size = new System.Drawing.Size(100, 23);
            this.testwith_btn.TabIndex = 11;
            this.testwith_btn.Text = "Тест с обуч";
            this.testwith_btn.UseVisualStyleBackColor = true;
            this.testwith_btn.Click += new System.EventHandler(this.testwith_btn_Click);
            // 
            // testwithout_btn
            // 
            this.testwithout_btn.Enabled = false;
            this.testwithout_btn.Location = new System.Drawing.Point(362, 70);
            this.testwithout_btn.Name = "testwithout_btn";
            this.testwithout_btn.Size = new System.Drawing.Size(100, 23);
            this.testwithout_btn.TabIndex = 12;
            this.testwithout_btn.Text = "Тест без обуч";
            this.testwithout_btn.UseVisualStyleBackColor = true;
            this.testwithout_btn.Click += new System.EventHandler(this.testwithout_btn_Click);
            // 
            // loadImg_btn
            // 
            this.loadImg_btn.Enabled = false;
            this.loadImg_btn.Location = new System.Drawing.Point(260, 99);
            this.loadImg_btn.Name = "loadImg_btn";
            this.loadImg_btn.Size = new System.Drawing.Size(202, 23);
            this.loadImg_btn.TabIndex = 13;
            this.loadImg_btn.Text = "Загрузить изображение";
            this.loadImg_btn.UseVisualStyleBackColor = true;
            this.loadImg_btn.Click += new System.EventHandler(this.loadImg_btn_Click);
            // 
            // recImg_btn
            // 
            this.recImg_btn.Enabled = false;
            this.recImg_btn.Location = new System.Drawing.Point(260, 128);
            this.recImg_btn.Name = "recImg_btn";
            this.recImg_btn.Size = new System.Drawing.Size(202, 23);
            this.recImg_btn.TabIndex = 14;
            this.recImg_btn.Text = "Распознать изображение";
            this.recImg_btn.UseVisualStyleBackColor = true;
            this.recImg_btn.Click += new System.EventHandler(this.recImg_btn_Click);
            // 
            // createsample_btn
            // 
            this.createsample_btn.Location = new System.Drawing.Point(260, 157);
            this.createsample_btn.Name = "createsample_btn";
            this.createsample_btn.Size = new System.Drawing.Size(202, 23);
            this.createsample_btn.TabIndex = 15;
            this.createsample_btn.Text = "Создать выборку";
            this.createsample_btn.UseVisualStyleBackColor = true;
            this.createsample_btn.Click += new System.EventHandler(this.createsample_btn_Click);
            // 
            // segm_btn
            // 
            this.segm_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.segm_btn.Location = new System.Drawing.Point(127, 41);
            this.segm_btn.Name = "segm_btn";
            this.segm_btn.Size = new System.Drawing.Size(100, 23);
            this.segm_btn.TabIndex = 19;
            this.segm_btn.Text = "Сегментатор";
            this.segm_btn.UseVisualStyleBackColor = true;
            this.segm_btn.Click += new System.EventHandler(this.segm_btn_Click);
            // 
            // edit_btn
            // 
            this.edit_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.edit_btn.Location = new System.Drawing.Point(127, 70);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(100, 23);
            this.edit_btn.TabIndex = 20;
            this.edit_btn.Text = "Редактор";
            this.edit_btn.UseVisualStyleBackColor = true;
            this.edit_btn.Click += new System.EventHandler(this.edit_btn_Click);
            // 
            // samp_btn
            // 
            this.samp_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.samp_btn.Location = new System.Drawing.Point(127, 12);
            this.samp_btn.Name = "samp_btn";
            this.samp_btn.Size = new System.Drawing.Size(100, 23);
            this.samp_btn.TabIndex = 21;
            this.samp_btn.Text = "Выборщик";
            this.samp_btn.UseVisualStyleBackColor = true;
            this.samp_btn.Click += new System.EventHandler(this.samp_btn_Click);
            // 
            // imageBox
            // 
            this.imageBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.imageBox.Location = new System.Drawing.Point(12, 12);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(64, 64);
            this.imageBox.TabIndex = 22;
            this.imageBox.TabStop = false;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 236);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.samp_btn);
            this.Controls.Add(this.edit_btn);
            this.Controls.Add(this.segm_btn);
            this.Controls.Add(this.createsample_btn);
            this.Controls.Add(this.recImg_btn);
            this.Controls.Add(this.loadImg_btn);
            this.Controls.Add(this.testwithout_btn);
            this.Controls.Add(this.testwith_btn);
            this.Controls.Add(this.teachISN_btn);
            this.Controls.Add(this.createISN_btn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
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
        private System.Windows.Forms.Button createISN_btn;
        private System.Windows.Forms.Button teachISN_btn;
        private System.Windows.Forms.Button testwith_btn;
        private System.Windows.Forms.Button testwithout_btn;
        private System.Windows.Forms.Button loadImg_btn;
        private System.Windows.Forms.Button recImg_btn;
        private System.Windows.Forms.Button createsample_btn;
        private System.Windows.Forms.Button segm_btn;
        private System.Windows.Forms.Button edit_btn;
        private System.Windows.Forms.Button samp_btn;
        private Emgu.CV.UI.ImageBox imageBox;
    }
}

