namespace controlPrg
{
    partial class Editor_Form
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sizeImg_tb = new System.Windows.Forms.TextBox();
            this.saveBmpImg_chb = new System.Windows.Forms.CheckBox();
            this.nameImg_tb = new System.Windows.Forms.TextBox();
            this.thick_lb = new System.Windows.Forms.Label();
            this.thick_num = new System.Windows.Forms.NumericUpDown();
            this.erase_rb = new System.Windows.Forms.RadioButton();
            this.brush_rb = new System.Windows.Forms.RadioButton();
            this.clear_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thick_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sizeImg_tb);
            this.groupBox1.Controls.Add(this.saveBmpImg_chb);
            this.groupBox1.Controls.Add(this.nameImg_tb);
            this.groupBox1.Controls.Add(this.thick_lb);
            this.groupBox1.Controls.Add(this.thick_num);
            this.groupBox1.Controls.Add(this.erase_rb);
            this.groupBox1.Controls.Add(this.brush_rb);
            this.groupBox1.Controls.Add(this.clear_btn);
            this.groupBox1.Controls.Add(this.save_btn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 83);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление";
            // 
            // sizeImg_tb
            // 
            this.sizeImg_tb.Location = new System.Drawing.Point(130, 19);
            this.sizeImg_tb.Name = "sizeImg_tb";
            this.sizeImg_tb.Size = new System.Drawing.Size(32, 20);
            this.sizeImg_tb.TabIndex = 22;
            this.sizeImg_tb.Text = "16";
            this.sizeImg_tb.TextChanged += new System.EventHandler(this.sizeImg_tb_TextChanged);
            // 
            // saveBmpImg_chb
            // 
            this.saveBmpImg_chb.AutoSize = true;
            this.saveBmpImg_chb.Location = new System.Drawing.Point(87, 21);
            this.saveBmpImg_chb.Name = "saveBmpImg_chb";
            this.saveBmpImg_chb.Size = new System.Drawing.Size(49, 17);
            this.saveBmpImg_chb.TabIndex = 21;
            this.saveBmpImg_chb.Text = ".bmp";
            this.saveBmpImg_chb.UseVisualStyleBackColor = true;
            this.saveBmpImg_chb.CheckedChanged += new System.EventHandler(this.saveBmpImg_chb_CheckedChanged);
            // 
            // nameImg_tb
            // 
            this.nameImg_tb.Location = new System.Drawing.Point(6, 19);
            this.nameImg_tb.Name = "nameImg_tb";
            this.nameImg_tb.Size = new System.Drawing.Size(75, 20);
            this.nameImg_tb.TabIndex = 20;
            // 
            // thick_lb
            // 
            this.thick_lb.AutoSize = true;
            this.thick_lb.Location = new System.Drawing.Point(245, 41);
            this.thick_lb.Name = "thick_lb";
            this.thick_lb.Size = new System.Drawing.Size(53, 13);
            this.thick_lb.TabIndex = 19;
            this.thick_lb.Text = "Толщина";
            // 
            // thick_num
            // 
            this.thick_num.Location = new System.Drawing.Point(252, 57);
            this.thick_num.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.thick_num.Name = "thick_num";
            this.thick_num.Size = new System.Drawing.Size(42, 20);
            this.thick_num.TabIndex = 18;
            this.thick_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thick_num.ValueChanged += new System.EventHandler(this.thick_num_ValueChanged);
            // 
            // erase_rb
            // 
            this.erase_rb.AutoSize = true;
            this.erase_rb.Location = new System.Drawing.Point(184, 62);
            this.erase_rb.Name = "erase_rb";
            this.erase_rb.Size = new System.Drawing.Size(62, 17);
            this.erase_rb.TabIndex = 4;
            this.erase_rb.TabStop = true;
            this.erase_rb.Text = "Ластик";
            this.erase_rb.UseVisualStyleBackColor = true;
            this.erase_rb.CheckedChanged += new System.EventHandler(this.erase_rb_CheckedChanged);
            // 
            // brush_rb
            // 
            this.brush_rb.AutoSize = true;
            this.brush_rb.Checked = true;
            this.brush_rb.Location = new System.Drawing.Point(184, 39);
            this.brush_rb.Name = "brush_rb";
            this.brush_rb.Size = new System.Drawing.Size(55, 17);
            this.brush_rb.TabIndex = 3;
            this.brush_rb.TabStop = true;
            this.brush_rb.Text = "Кисть";
            this.brush_rb.UseVisualStyleBackColor = true;
            this.brush_rb.CheckedChanged += new System.EventHandler(this.brush_rb_CheckedChanged);
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(87, 48);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(75, 23);
            this.clear_btn.TabIndex = 2;
            this.clear_btn.Text = "Очистить";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.save_btn.Location = new System.Drawing.Point(6, 48);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 1;
            this.save_btn.Text = "Сохранить";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(304, 320);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb.TabIndex = 4;
            this.pb.TabStop = false;
            this.pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_MouseDown);
            this.pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_MouseMove);
            this.pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_MouseUp);
            // 
            // Editor_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 411);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Editor_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор";
            this.Load += new System.EventHandler(this.Editor_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thick_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label thick_lb;
        private System.Windows.Forms.NumericUpDown thick_num;
        private System.Windows.Forms.RadioButton erase_rb;
        private System.Windows.Forms.RadioButton brush_rb;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.CheckBox saveBmpImg_chb;
        private System.Windows.Forms.TextBox nameImg_tb;
        private System.Windows.Forms.TextBox sizeImg_tb;
    }
}