using System.Windows.Forms;

namespace controlPrg
{
    public partial class Entry_Form : Form
    {
        public Entry_Form(string info_text)
        {
            InitializeComponent();
            this.Text = info_text;
        }
    }
}
