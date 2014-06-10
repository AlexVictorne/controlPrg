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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.minContLen_label = new System.Windows.Forms.Label();
            this.nf_tb = new System.Windows.Forms.NumericUpDown();
            this.minContAr_label = new System.Windows.Forms.Label();
            this.thres_tb = new System.Windows.Forms.NumericUpDown();
            this.blur_chb = new System.Windows.Forms.CheckBox();
            this.maxContLen_tb = new System.Windows.Forms.NumericUpDown();
            this.nf_chb = new System.Windows.Forms.CheckBox();
            this.minContAr_tb = new System.Windows.Forms.NumericUpDown();
            this.autocont_chb = new System.Windows.Forms.CheckBox();
            this.minContLen_tb = new System.Windows.Forms.NumericUpDown();
            this.maxContLen_label = new System.Windows.Forms.Label();
            this.thres_label = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            this.ibProcessed = new Emgu.CV.UI.ImageBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.ibReader = new Emgu.CV.UI.ImageBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nf_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thres_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxContLen_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minContAr_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minContLen_tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibProcessed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibReader)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button6);
            this.splitContainer2.Panel1.Controls.Add(this.button5);
            this.splitContainer2.Panel1.Controls.Add(this.button3);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.button4);
            this.splitContainer2.Panel1.Controls.Add(this.button2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(687, 144);
            this.splitContainer2.SplitterDistance = 413;
            this.splitContainer2.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(10, 91);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(240, 19);
            this.button6.TabIndex = 67;
            this.button6.Text = "Сохранить в XML файл";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(213, 41);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 19);
            this.button5.TabIndex = 62;
            this.button5.Text = "Очистить буфер заливки";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(150, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(188, 19);
            this.button3.TabIndex = 5;
            this.button3.Text = "Сохранить изображения контуров";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 19);
            this.button1.TabIndex = 3;
            this.button1.Text = "Загрузить изображение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(10, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(240, 19);
            this.button4.TabIndex = 61;
            this.button4.Text = "Обрезать изображение по залитому контуру";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 19);
            this.button2.TabIndex = 4;
            this.button2.Text = "Скелетонизация залитых контуров";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.groupBox1.Size = new System.Drawing.Size(270, 144);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
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
            this.nf_tb.ValueChanged += new System.EventHandler(this.change);
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
            this.thres_tb.ValueChanged += new System.EventHandler(this.change);
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
            this.blur_chb.CheckedChanged += new System.EventHandler(this.change);
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
            this.maxContLen_tb.ValueChanged += new System.EventHandler(this.change);
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
            this.nf_chb.CheckedChanged += new System.EventHandler(this.change);
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
            this.minContAr_tb.ValueChanged += new System.EventHandler(this.change);
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
            this.autocont_chb.CheckedChanged += new System.EventHandler(this.change);
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
            this.minContLen_tb.ValueChanged += new System.EventHandler(this.change);
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
            // thres_label
            // 
            this.thres_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thres_label.Location = new System.Drawing.Point(6, 78);
            this.thres_label.Name = "thres_label";
            this.thres_label.Size = new System.Drawing.Size(87, 20);
            this.thres_label.TabIndex = 54;
            this.thres_label.Text = "Порог";
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
            this.splitContainer3.Size = new System.Drawing.Size(687, 348);
            this.splitContainer3.SplitterDistance = 325;
            this.splitContainer3.TabIndex = 0;
            // 
            // ibOriginal
            // 
            this.ibOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibOriginal.Location = new System.Drawing.Point(0, 0);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(325, 348);
            this.ibOriginal.TabIndex = 2;
            this.ibOriginal.TabStop = false;
            this.ibOriginal.Paint += new System.Windows.Forms.PaintEventHandler(this.ibOriginal_Paint);
            this.ibOriginal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ibOriginal_MouseClick);
            // 
            // ibProcessed
            // 
            this.ibProcessed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibProcessed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibProcessed.Location = new System.Drawing.Point(0, 0);
            this.ibProcessed.Name = "ibProcessed";
            this.ibProcessed.Size = new System.Drawing.Size(358, 348);
            this.ibProcessed.TabIndex = 2;
            this.ibProcessed.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
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
            this.splitContainer1.Size = new System.Drawing.Size(687, 496);
            this.splitContainer1.SplitterDistance = 348;
            this.splitContainer1.TabIndex = 68;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(701, 22);
            this.statusStrip1.TabIndex = 69;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(701, 528);
            this.tabControl1.TabIndex = 70;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(693, 502);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Редактор";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(693, 502);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Просмотр";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.listBox1);
            this.splitContainer4.Size = new System.Drawing.Size(687, 496);
            this.splitContainer4.SplitterDistance = 491;
            this.splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.ibReader);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.button10);
            this.splitContainer5.Panel2.Controls.Add(this.button8);
            this.splitContainer5.Panel2.Controls.Add(this.button7);
            this.splitContainer5.Panel2.Controls.Add(this.button9);
            this.splitContainer5.Size = new System.Drawing.Size(491, 496);
            this.splitContainer5.SplitterDistance = 234;
            this.splitContainer5.TabIndex = 0;
            // 
            // ibReader
            // 
            this.ibReader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibReader.Location = new System.Drawing.Point(0, 0);
            this.ibReader.Name = "ibReader";
            this.ibReader.Size = new System.Drawing.Size(491, 234);
            this.ibReader.TabIndex = 2;
            this.ibReader.TabStop = false;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(191, 61);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 70;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(191, 32);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 69;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(5, 8);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(180, 19);
            this.button7.TabIndex = 68;
            this.button7.Text = "Прочитать XML файл";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(5, 32);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(180, 23);
            this.button9.TabIndex = 1;
            this.button9.Text = "Сохранить элементы в папку";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(192, 496);
            this.listBox1.TabIndex = 0;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_Click);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // Vectorizer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 550);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Vectorizer_Form";
            this.Text = "Векторизатор";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nf_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thres_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxContLen_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minContAr_tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minContLen_tb)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibProcessed)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ibReader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label minContLen_label;
        private System.Windows.Forms.NumericUpDown nf_tb;
        private System.Windows.Forms.Label minContAr_label;
        private System.Windows.Forms.NumericUpDown thres_tb;
        private System.Windows.Forms.CheckBox blur_chb;
        private System.Windows.Forms.NumericUpDown maxContLen_tb;
        private System.Windows.Forms.CheckBox nf_chb;
        private System.Windows.Forms.NumericUpDown minContAr_tb;
        private System.Windows.Forms.CheckBox autocont_chb;
        private System.Windows.Forms.NumericUpDown minContLen_tb;
        private System.Windows.Forms.Label maxContLen_label;
        private System.Windows.Forms.Label thres_label;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Emgu.CV.UI.ImageBox ibOriginal;
        private Emgu.CV.UI.ImageBox ibProcessed;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private Emgu.CV.UI.ImageBox ibReader;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;


    }
}