namespace controlPrg.Forms
{
    partial class OCR_Form
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
            this.Load_xml_file_btn = new System.Windows.Forms.Button();
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // Load_xml_file_btn
            // 
            this.Load_xml_file_btn.Location = new System.Drawing.Point(12, 407);
            this.Load_xml_file_btn.Name = "Load_xml_file_btn";
            this.Load_xml_file_btn.Size = new System.Drawing.Size(172, 23);
            this.Load_xml_file_btn.TabIndex = 0;
            this.Load_xml_file_btn.Text = "Загрузить элементы из XML";
            this.Load_xml_file_btn.UseVisualStyleBackColor = true;
            this.Load_xml_file_btn.Click += new System.EventHandler(this.Load_xml_file_btn_Click);
            // 
            // ibOriginal
            // 
            this.ibOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibOriginal.Location = new System.Drawing.Point(12, 12);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(359, 389);
            this.ibOriginal.TabIndex = 3;
            this.ibOriginal.TabStop = false;
            // 
            // OCR_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 572);
            this.Controls.Add(this.ibOriginal);
            this.Controls.Add(this.Load_xml_file_btn);
            this.Name = "OCR_Form";
            this.Text = "OCR_Form";
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Load_xml_file_btn;
        private Emgu.CV.UI.ImageBox ibOriginal;
    }
}