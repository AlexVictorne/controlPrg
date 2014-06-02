﻿namespace controlPrg
{
    partial class Vectorizer_Form
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
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ibProcessed = new Emgu.CV.UI.ImageBox();
            this.button3 = new System.Windows.Forms.Button();
            this.thres_label = new System.Windows.Forms.Label();
            this.maxContLen_label = new System.Windows.Forms.Label();
            this.minContLen_label = new System.Windows.Forms.Label();
            this.autocont_chb = new System.Windows.Forms.CheckBox();
            this.nf_chb = new System.Windows.Forms.CheckBox();
            this.blur_chb = new System.Windows.Forms.CheckBox();
            this.minContAr_label = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.minContLen_tb = new System.Windows.Forms.NumericUpDown();
            this.minContAr_tb = new System.Windows.Forms.NumericUpDown();
            this.maxContLen_tb = new System.Windows.Forms.NumericUpDown();
            this.thres_tb = new System.Windows.Forms.NumericUpDown();
            this.nf_tb = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibProcessed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minContLen_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minContAr_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxContLen_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thres_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nf_tb)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ibOriginal
            // 
            this.ibOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibOriginal.Location = new System.Drawing.Point(0, 0);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(338, 390);
            this.ibOriginal.TabIndex = 2;
            this.ibOriginal.TabStop = false;
            this.ibOriginal.Paint += new System.Windows.Forms.PaintEventHandler(this.ibOriginal_Paint);
            this.ibOriginal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ibOriginal_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Загрузить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(109, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "Векторизовать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ibProcessed
            // 
            this.ibProcessed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibProcessed.Location = new System.Drawing.Point(0, 0);
            this.ibProcessed.Name = "ibProcessed";
            this.ibProcessed.Size = new System.Drawing.Size(359, 390);
            this.ibProcessed.TabIndex = 2;
            this.ibProcessed.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 26);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // thres_label
            // 
            this.thres_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thres_label.Location = new System.Drawing.Point(6, 78);
            this.thres_label.Name = "thres_label";
            this.thres_label.Size = new System.Drawing.Size(87, 20);
            this.thres_label.TabIndex = 54;
            this.thres_label.Text = "Порог";
            // 
            // maxContLen_label
            // 
            this.maxContLen_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxContLen_label.Location = new System.Drawing.Point(6, 58);
            this.maxContLen_label.Name = "maxContLen_label";
            this.maxContLen_label.Size = new System.Drawing.Size(117, 20);
            this.maxContLen_label.TabIndex = 49;
            this.maxContLen_label.Text = "МаксВысота";
            // 
            // minContLen_label
            // 
            this.minContLen_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minContLen_label.Location = new System.Drawing.Point(6, 21);
            this.minContLen_label.Name = "minContLen_label";
            this.minContLen_label.Size = new System.Drawing.Size(117, 20);
            this.minContLen_label.TabIndex = 47;
            this.minContLen_label.Text = "МинВысота";
            // 
            // autocont_chb
            // 
            this.autocont_chb.AutoSize = true;
            this.autocont_chb.Location = new System.Drawing.Point(194, 38);
            this.autocont_chb.Name = "autocont_chb";
            this.autocont_chb.Size = new System.Drawing.Size(96, 17);
            this.autocont_chb.TabIndex = 44;
            this.autocont_chb.Text = "Автоконтраст";
            this.autocont_chb.UseVisualStyleBackColor = true;
            this.autocont_chb.CheckedChanged += new System.EventHandler(this.autocont_chb_CheckedChanged);
            // 
            // nf_chb
            // 
            this.nf_chb.AutoSize = true;
            this.nf_chb.Checked = true;
            this.nf_chb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nf_chb.Location = new System.Drawing.Point(9, 99);
            this.nf_chb.Name = "nf_chb";
            this.nf_chb.Size = new System.Drawing.Size(96, 17);
            this.nf_chb.TabIndex = 45;
            this.nf_chb.Text = "Фильтр шума";
            this.nf_chb.UseVisualStyleBackColor = true;
            // 
            // blur_chb
            // 
            this.blur_chb.AutoSize = true;
            this.blur_chb.Location = new System.Drawing.Point(194, 21);
            this.blur_chb.Name = "blur_chb";
            this.blur_chb.Size = new System.Drawing.Size(78, 17);
            this.blur_chb.TabIndex = 46;
            this.blur_chb.Text = "Размытие";
            this.blur_chb.UseVisualStyleBackColor = true;
            this.blur_chb.CheckedChanged += new System.EventHandler(this.blur_chb_CheckedChanged);
            // 
            // minContAr_label
            // 
            this.minContAr_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minContAr_label.Location = new System.Drawing.Point(6, 38);
            this.minContAr_label.Name = "minContAr_label";
            this.minContAr_label.Size = new System.Drawing.Size(117, 20);
            this.minContAr_label.TabIndex = 48;
            this.minContAr_label.Text = "МинПлощадь";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(109, 58);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 26);
            this.button4.TabIndex = 61;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // minContLen_tb
            // 
            this.minContLen_tb.Location = new System.Drawing.Point(129, 21);
            this.minContLen_tb.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minContLen_tb.Name = "minContLen_tb";
            this.minContLen_tb.Size = new System.Drawing.Size(42, 20);
            this.minContLen_tb.TabIndex = 62;
            this.minContLen_tb.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.minContLen_tb.ValueChanged += new System.EventHandler(this.minContLen_tb_Scroll);
            // 
            // minContAr_tb
            // 
            this.minContAr_tb.Location = new System.Drawing.Point(129, 38);
            this.minContAr_tb.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minContAr_tb.Name = "minContAr_tb";
            this.minContAr_tb.Size = new System.Drawing.Size(42, 20);
            this.minContAr_tb.TabIndex = 63;
            this.minContAr_tb.ValueChanged += new System.EventHandler(this.minContAr_tb_Scroll);
            // 
            // maxContLen_tb
            // 
            this.maxContLen_tb.Location = new System.Drawing.Point(129, 58);
            this.maxContLen_tb.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxContLen_tb.Name = "maxContLen_tb";
            this.maxContLen_tb.Size = new System.Drawing.Size(42, 20);
            this.maxContLen_tb.TabIndex = 64;
            this.maxContLen_tb.Value = new decimal(new int[] {
            418,
            0,
            0,
            0});
            this.maxContLen_tb.ValueChanged += new System.EventHandler(this.maxContLen_tb_Scroll);
            // 
            // thres_tb
            // 
            this.thres_tb.Location = new System.Drawing.Point(129, 78);
            this.thres_tb.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.thres_tb.Name = "thres_tb";
            this.thres_tb.Size = new System.Drawing.Size(42, 20);
            this.thres_tb.TabIndex = 65;
            this.thres_tb.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.thres_tb.ValueChanged += new System.EventHandler(this.thres_tb_Scroll);
            // 
            // nf_tb
            // 
            this.nf_tb.Location = new System.Drawing.Point(129, 96);
            this.nf_tb.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nf_tb.Name = "nf_tb";
            this.nf_tb.Size = new System.Drawing.Size(42, 20);
            this.nf_tb.TabIndex = 66;
            this.nf_tb.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nf_tb.ValueChanged += new System.EventHandler(this.nf_tb_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.minContLen_label);
            this.groupBox1.Controls.Add(this.nf_tb);
            this.groupBox1.Controls.Add(this.minContAr_label);
            this.groupBox1.Controls.Add(this.thres_tb);
            this.groupBox1.Controls.Add(this.blur_chb);
            this.groupBox1.Controls.Add(this.maxContLen_tb);
            this.groupBox1.Controls.Add(this.nf_chb);
            this.groupBox1.Controls.Add(this.minContAr_tb);
            this.groupBox1.Controls.Add(this.autocont_chb);
            this.groupBox1.Controls.Add(this.minContLen_tb);
            this.groupBox1.Controls.Add(this.maxContLen_label);
            this.groupBox1.Controls.Add(this.thres_label);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 156);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(701, 550);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.TabIndex = 68;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button3);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.button4);
            this.splitContainer2.Panel1.Controls.Add(this.button2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(701, 156);
            this.splitContainer2.SplitterDistance = 233;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ibOriginal);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.ibProcessed);
            this.splitContainer3.Size = new System.Drawing.Size(701, 390);
            this.splitContainer3.SplitterDistance = 338;
            this.splitContainer3.TabIndex = 0;
            // 
            // Vectorizer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 550);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Vectorizer_Form";
            this.Text = "Векторизатор";
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibProcessed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minContLen_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minContAr_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxContLen_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thres_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nf_tb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibOriginal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Emgu.CV.UI.ImageBox ibProcessed;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label thres_label;
        private System.Windows.Forms.Label maxContLen_label;
        private System.Windows.Forms.Label minContLen_label;
        private System.Windows.Forms.CheckBox autocont_chb;
        private System.Windows.Forms.CheckBox nf_chb;
        private System.Windows.Forms.CheckBox blur_chb;
        private System.Windows.Forms.Label minContAr_label;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown minContLen_tb;
        private System.Windows.Forms.NumericUpDown minContAr_tb;
        private System.Windows.Forms.NumericUpDown maxContLen_tb;
        private System.Windows.Forms.NumericUpDown thres_tb;
        private System.Windows.Forms.NumericUpDown nf_tb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}