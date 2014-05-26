namespace controlPrg
{
    partial class Segment_Form
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadImage_btn = new System.Windows.Forms.Button();
            this.bmp_chb = new System.Windows.Forms.CheckBox();
            this.bitmapformat_tb = new System.Windows.Forms.TextBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.nfVal_label = new System.Windows.Forms.Label();
            this.nf_tb = new System.Windows.Forms.TrackBar();
            this.thresVal_label = new System.Windows.Forms.Label();
            this.maxContLenVal_label = new System.Windows.Forms.Label();
            this.minContArVal_label = new System.Windows.Forms.Label();
            this.minContLenVal_label = new System.Windows.Forms.Label();
            this.thres_label = new System.Windows.Forms.Label();
            this.thres_tb = new System.Windows.Forms.TrackBar();
            this.maxContLen_tb = new System.Windows.Forms.TrackBar();
            this.minContAr_tb = new System.Windows.Forms.TrackBar();
            this.minContLen_tb = new System.Windows.Forms.TrackBar();
            this.maxContLen_label = new System.Windows.Forms.Label();
            this.minContLen_label = new System.Windows.Forms.Label();
            this.autocont_chb = new System.Windows.Forms.CheckBox();
            this.nf_chb = new System.Windows.Forms.CheckBox();
            this.blur_chb = new System.Windows.Forms.CheckBox();
            this.minContAr_label = new System.Windows.Forms.Label();
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nf_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thres_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxContLen_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minContAr_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minContLen_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loadImage_btn);
            this.groupBox1.Controls.Add(this.bmp_chb);
            this.groupBox1.Controls.Add(this.bitmapformat_tb);
            this.groupBox1.Controls.Add(this.save_btn);
            this.groupBox1.Controls.Add(this.nfVal_label);
            this.groupBox1.Controls.Add(this.nf_tb);
            this.groupBox1.Controls.Add(this.thresVal_label);
            this.groupBox1.Controls.Add(this.maxContLenVal_label);
            this.groupBox1.Controls.Add(this.minContArVal_label);
            this.groupBox1.Controls.Add(this.minContLenVal_label);
            this.groupBox1.Controls.Add(this.thres_label);
            this.groupBox1.Controls.Add(this.thres_tb);
            this.groupBox1.Controls.Add(this.maxContLen_tb);
            this.groupBox1.Controls.Add(this.minContAr_tb);
            this.groupBox1.Controls.Add(this.minContLen_tb);
            this.groupBox1.Controls.Add(this.maxContLen_label);
            this.groupBox1.Controls.Add(this.minContLen_label);
            this.groupBox1.Controls.Add(this.autocont_chb);
            this.groupBox1.Controls.Add(this.nf_chb);
            this.groupBox1.Controls.Add(this.blur_chb);
            this.groupBox1.Controls.Add(this.minContAr_label);
            this.groupBox1.Location = new System.Drawing.Point(6, 362);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 200);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление текущим изображением";
            // 
            // loadImage_btn
            // 
            this.loadImage_btn.Location = new System.Drawing.Point(412, 140);
            this.loadImage_btn.Name = "loadImage_btn";
            this.loadImage_btn.Size = new System.Drawing.Size(75, 23);
            this.loadImage_btn.TabIndex = 49;
            this.loadImage_btn.Text = "Загрузить";
            this.loadImage_btn.UseVisualStyleBackColor = true;
            this.loadImage_btn.Click += new System.EventHandler(this.loadImage_btn_Click);
            // 
            // bmp_chb
            // 
            this.bmp_chb.AutoSize = true;
            this.bmp_chb.Location = new System.Drawing.Point(409, 39);
            this.bmp_chb.Name = "bmp_chb";
            this.bmp_chb.Size = new System.Drawing.Size(46, 17);
            this.bmp_chb.TabIndex = 48;
            this.bmp_chb.Text = "bmp";
            this.bmp_chb.UseVisualStyleBackColor = true;
            this.bmp_chb.CheckedChanged += new System.EventHandler(this.bmp_chb_CheckedChanged);
            // 
            // bitmapformat_tb
            // 
            this.bitmapformat_tb.Location = new System.Drawing.Point(409, 85);
            this.bitmapformat_tb.Name = "bitmapformat_tb";
            this.bitmapformat_tb.Size = new System.Drawing.Size(40, 20);
            this.bitmapformat_tb.TabIndex = 46;
            this.bitmapformat_tb.Text = "64";
            this.bitmapformat_tb.TextChanged += new System.EventHandler(this.bitmapformat_tb_TextChanged);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(412, 169);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 3;
            this.save_btn.Text = "Сохранить";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.saveToFolder_btn_Click);
            // 
            // nfVal_label
            // 
            this.nfVal_label.BackColor = System.Drawing.Color.Transparent;
            this.nfVal_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nfVal_label.Location = new System.Drawing.Point(368, 175);
            this.nfVal_label.Name = "nfVal_label";
            this.nfVal_label.Size = new System.Drawing.Size(38, 20);
            this.nfVal_label.TabIndex = 45;
            this.nfVal_label.Text = "100";
            // 
            // nf_tb
            // 
            this.nf_tb.Location = new System.Drawing.Point(118, 175);
            this.nf_tb.Maximum = 100;
            this.nf_tb.Name = "nf_tb";
            this.nf_tb.Size = new System.Drawing.Size(259, 45);
            this.nf_tb.TabIndex = 43;
            this.nf_tb.TickStyle = System.Windows.Forms.TickStyle.None;
            this.nf_tb.Value = 100;
            this.nf_tb.Scroll += new System.EventHandler(this.nf_tb_Scroll);
            // 
            // thresVal_label
            // 
            this.thresVal_label.BackColor = System.Drawing.Color.Transparent;
            this.thresVal_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thresVal_label.Location = new System.Drawing.Point(368, 133);
            this.thresVal_label.Name = "thresVal_label";
            this.thresVal_label.Size = new System.Drawing.Size(38, 20);
            this.thresVal_label.TabIndex = 42;
            this.thresVal_label.Text = "20";
            // 
            // maxContLenVal_label
            // 
            this.maxContLenVal_label.BackColor = System.Drawing.Color.Transparent;
            this.maxContLenVal_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxContLenVal_label.Location = new System.Drawing.Point(368, 93);
            this.maxContLenVal_label.Name = "maxContLenVal_label";
            this.maxContLenVal_label.Size = new System.Drawing.Size(30, 20);
            this.maxContLenVal_label.TabIndex = 41;
            this.maxContLenVal_label.Text = "418";
            // 
            // minContArVal_label
            // 
            this.minContArVal_label.BackColor = System.Drawing.Color.Transparent;
            this.minContArVal_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minContArVal_label.Location = new System.Drawing.Point(368, 55);
            this.minContArVal_label.Name = "minContArVal_label";
            this.minContArVal_label.Size = new System.Drawing.Size(35, 20);
            this.minContArVal_label.TabIndex = 40;
            this.minContArVal_label.Text = "0";
            // 
            // minContLenVal_label
            // 
            this.minContLenVal_label.BackColor = System.Drawing.Color.Transparent;
            this.minContLenVal_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minContLenVal_label.Location = new System.Drawing.Point(368, 18);
            this.minContLenVal_label.Name = "minContLenVal_label";
            this.minContLenVal_label.Size = new System.Drawing.Size(38, 20);
            this.minContLenVal_label.TabIndex = 39;
            this.minContLenVal_label.Text = "50";
            // 
            // thres_label
            // 
            this.thres_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thres_label.Location = new System.Drawing.Point(6, 133);
            this.thres_label.Name = "thres_label";
            this.thres_label.Size = new System.Drawing.Size(87, 20);
            this.thres_label.TabIndex = 38;
            this.thres_label.Text = "Порог";
            // 
            // thres_tb
            // 
            this.thres_tb.Location = new System.Drawing.Point(118, 133);
            this.thres_tb.Maximum = 2000;
            this.thres_tb.Name = "thres_tb";
            this.thres_tb.Size = new System.Drawing.Size(259, 45);
            this.thres_tb.TabIndex = 37;
            this.thres_tb.TickStyle = System.Windows.Forms.TickStyle.None;
            this.thres_tb.Value = 2000;
            this.thres_tb.Scroll += new System.EventHandler(this.thres_tb_Scroll);
            // 
            // maxContLen_tb
            // 
            this.maxContLen_tb.Location = new System.Drawing.Point(118, 93);
            this.maxContLen_tb.Maximum = 1000;
            this.maxContLen_tb.Name = "maxContLen_tb";
            this.maxContLen_tb.Size = new System.Drawing.Size(259, 45);
            this.maxContLen_tb.TabIndex = 36;
            this.maxContLen_tb.TickStyle = System.Windows.Forms.TickStyle.None;
            this.maxContLen_tb.Value = 418;
            this.maxContLen_tb.Scroll += new System.EventHandler(this.maxContLen_tb_Scroll);
            // 
            // minContAr_tb
            // 
            this.minContAr_tb.Location = new System.Drawing.Point(118, 55);
            this.minContAr_tb.Maximum = 1000;
            this.minContAr_tb.Name = "minContAr_tb";
            this.minContAr_tb.Size = new System.Drawing.Size(259, 45);
            this.minContAr_tb.TabIndex = 35;
            this.minContAr_tb.TickStyle = System.Windows.Forms.TickStyle.None;
            this.minContAr_tb.Scroll += new System.EventHandler(this.minContAr_tb_Scroll);
            // 
            // minContLen_tb
            // 
            this.minContLen_tb.Location = new System.Drawing.Point(118, 16);
            this.minContLen_tb.Maximum = 1000;
            this.minContLen_tb.Name = "minContLen_tb";
            this.minContLen_tb.Size = new System.Drawing.Size(259, 45);
            this.minContLen_tb.TabIndex = 34;
            this.minContLen_tb.TickStyle = System.Windows.Forms.TickStyle.None;
            this.minContLen_tb.Value = 50;
            this.minContLen_tb.Scroll += new System.EventHandler(this.minContLen_tb_Scroll);
            // 
            // maxContLen_label
            // 
            this.maxContLen_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxContLen_label.Location = new System.Drawing.Point(6, 96);
            this.maxContLen_label.Name = "maxContLen_label";
            this.maxContLen_label.Size = new System.Drawing.Size(117, 20);
            this.maxContLen_label.TabIndex = 32;
            this.maxContLen_label.Text = "МаксВысота";
            // 
            // minContLen_label
            // 
            this.minContLen_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minContLen_label.Location = new System.Drawing.Point(6, 16);
            this.minContLen_label.Name = "minContLen_label";
            this.minContLen_label.Size = new System.Drawing.Size(117, 20);
            this.minContLen_label.TabIndex = 28;
            this.minContLen_label.Text = "МинВысота";
            // 
            // autocont_chb
            // 
            this.autocont_chb.AutoSize = true;
            this.autocont_chb.Location = new System.Drawing.Point(409, 62);
            this.autocont_chb.Name = "autocont_chb";
            this.autocont_chb.Size = new System.Drawing.Size(96, 17);
            this.autocont_chb.TabIndex = 23;
            this.autocont_chb.Text = "Автоконтраст";
            this.autocont_chb.UseVisualStyleBackColor = true;
            this.autocont_chb.CheckedChanged += new System.EventHandler(this.autocont_chb_CheckedChanged);
            // 
            // nf_chb
            // 
            this.nf_chb.AutoSize = true;
            this.nf_chb.Checked = true;
            this.nf_chb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nf_chb.Location = new System.Drawing.Point(6, 175);
            this.nf_chb.Name = "nf_chb";
            this.nf_chb.Size = new System.Drawing.Size(96, 17);
            this.nf_chb.TabIndex = 24;
            this.nf_chb.Text = "Фильтр шума";
            this.nf_chb.UseVisualStyleBackColor = true;
            this.nf_chb.CheckedChanged += new System.EventHandler(this.nf_chb_CheckedChanged);
            // 
            // blur_chb
            // 
            this.blur_chb.AutoSize = true;
            this.blur_chb.Location = new System.Drawing.Point(409, 16);
            this.blur_chb.Name = "blur_chb";
            this.blur_chb.Size = new System.Drawing.Size(78, 17);
            this.blur_chb.TabIndex = 25;
            this.blur_chb.Text = "Размытие";
            this.blur_chb.UseVisualStyleBackColor = true;
            this.blur_chb.CheckedChanged += new System.EventHandler(this.blur_chb_CheckedChanged);
            // 
            // minContAr_label
            // 
            this.minContAr_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minContAr_label.Location = new System.Drawing.Point(6, 53);
            this.minContAr_label.Name = "minContAr_label";
            this.minContAr_label.Size = new System.Drawing.Size(117, 20);
            this.minContAr_label.TabIndex = 29;
            this.minContAr_label.Text = "МинПлощадь";
            // 
            // ibOriginal
            // 
            this.ibOriginal.Location = new System.Drawing.Point(6, 6);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(500, 350);
            this.ibOriginal.TabIndex = 41;
            this.ibOriginal.TabStop = false;
            this.ibOriginal.Paint += new System.Windows.Forms.PaintEventHandler(this.ibOriginal_Paint);
            // 
            // Segment_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 579);
            this.Controls.Add(this.ibOriginal);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Segment_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сегментатор";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nf_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thres_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxContLen_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minContAr_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minContLen_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox bmp_chb;
        private System.Windows.Forms.TextBox bitmapformat_tb;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Label nfVal_label;
        private System.Windows.Forms.TrackBar nf_tb;
        private System.Windows.Forms.Label thresVal_label;
        private System.Windows.Forms.Label maxContLenVal_label;
        private System.Windows.Forms.Label minContArVal_label;
        private System.Windows.Forms.Label minContLenVal_label;
        private System.Windows.Forms.Label thres_label;
        private System.Windows.Forms.TrackBar thres_tb;
        private System.Windows.Forms.TrackBar maxContLen_tb;
        private System.Windows.Forms.TrackBar minContAr_tb;
        private System.Windows.Forms.TrackBar minContLen_tb;
        private System.Windows.Forms.Label maxContLen_label;
        private System.Windows.Forms.Label minContLen_label;
        private System.Windows.Forms.CheckBox autocont_chb;
        private System.Windows.Forms.CheckBox nf_chb;
        private System.Windows.Forms.CheckBox blur_chb;
        private System.Windows.Forms.Label minContAr_label;
        private Emgu.CV.UI.ImageBox ibOriginal;
        private System.Windows.Forms.Button loadImage_btn;
    }
}