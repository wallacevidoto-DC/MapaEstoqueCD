namespace MapaEstoqueCD.View.Modal
{
    public partial class QrViewer : Form
    {
        public QrViewer(Image pictureBox)
        {
            InitializeComponent();

            pictureBox_qr.Image = pictureBox;
        }
    }
}
