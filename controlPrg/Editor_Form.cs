using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace controlPrg
{
    public partial class Editor_Form : Form
    {
        public Editor_Form()
        {
            InitializeComponent();
        }
        Bitmap btm = new Bitmap(320, 320);
        Graphics gr;

        int thickness = 1;
        SolidBrush brush = new SolidBrush(Color.White);


        bool mouse_flag = false;
        private void pb_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_flag = true;
        }
        private void pb_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_flag = false;
        }
        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if ((mouse_flag) && (e.X > 0) && (e.Y > 0) && (e.X < 320) && (e.Y < 320))
            {
                gr.FillRectangle(brush, e.X, e.Y, thickness, thickness);
                pb.Refresh();
            }
        }

        
        public string return_data()
        {
            return path_to_new_file;
        }

        private void Editor_Form_Load(object sender, EventArgs e)
        {
            gr = Graphics.FromImage(btm);
            pb.Image = btm;
            clear();
        }
        
        string save_format = ".jpg";
        int sizeformat_img = 16;

        string path_to_new_file = "";
        private void save_btn_Click(object sender, EventArgs e)
        {
            pb.DrawToBitmap(btm, new Rectangle(0, 0, pb.Width, pb.Height));
            var res = new Bitmap(sizeformat_img, sizeformat_img);
            using (var g = Graphics.FromImage(res))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(btm, new Rectangle(0, 0, sizeformat_img, sizeformat_img), new Rectangle(0, 0, btm.Width, btm.Height), GraphicsUnit.Pixel);
            }
            res = BlachAndWhite(res, 80);
            if (save_format == ".jpg")
                res.Save(nameImg_tb.Text + save_format, ImageFormat.Jpeg);
            else
                res.Save(nameImg_tb.Text + save_format, ImageFormat.Bmp);
            path_to_new_file = nameImg_tb.Text + save_format;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private Bitmap BlachAndWhite(Bitmap bmpImg, int P)
        {
            Bitmap result = new Bitmap(bmpImg.Width, bmpImg.Height);
            Color color = new Color();
            try
            {
                for (int j = 0; j < bmpImg.Height; j++)
                {
                    for (int i = 0; i < bmpImg.Width; i++)
                    {
                        color = bmpImg.GetPixel(i, j);
                        int K = ((color.R + color.G + color.B) / 3);
                        result.SetPixel(i, j, (K <= P ? Color.White : Color.Black));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }


        private void clear_btn_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {
            btm = new Bitmap(320, 320);
            gr.FillRectangle(Brushes.Black, new Rectangle(0, 0, 320, 320));
            pb.Refresh();
        }

        private void brush_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (brush_rb.Checked)
                brush = new SolidBrush(Color.White);
        }

        private void erase_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (erase_rb.Checked)
                brush = new SolidBrush(Color.Black);
        }

        private void thick_num_ValueChanged(object sender, EventArgs e)
        {
            thickness = (int)thick_num.Value;
        }

        private void saveBmpImg_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (saveBmpImg_chb.Checked)
                save_format = ".bmp";
            else
                save_format = ".jpg";
        }

        private void sizeImg_tb_TextChanged(object sender, EventArgs e)
        {
            sizeformat_img = Convert.ToInt32(sizeImg_tb.Text);
        }
    }
}
