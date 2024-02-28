using MessagingToolkit.QRCode.Codec;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;

namespace Medinfsys
{
    /// <summary>
    /// Логика взаимодействия для QRCode.xaml
    /// </summary>
    public partial class QRCode : Window
    {
        QRCodeEncoder encoder = new QRCodeEncoder();
        Bitmap bitmap;
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public QRCode()
        {
            InitializeComponent();
        }

        private void Gen_Click(object sender, RoutedEventArgs e)
        {
            encoder.QRCodeScale = 8;
            bitmap = encoder.Encode(EnterCode.Text);
            ImgQR.Source = ConvertImage.ToBitmapImage(bitmap);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            saveFileDialog.Filter = "PNG|.png";
            saveFileDialog.FileName = EnterCode.Text;
            if (saveFileDialog.ShowDialog() == true)
            {
                if (bitmap != null)
                {
                    bitmap.Save(string.Concat(saveFileDialog.FileName, ".png"), ImageFormat.Png);
                }
            }
        }

        private void ScanQR_Click(object sender, RoutedEventArgs e)
        {
            ScanQrCode scanQrCode = new ScanQrCode();
            scanQrCode.Show();
            Close();
        }
    }
}
