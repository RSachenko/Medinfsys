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


namespace Medinfsys
{
    /// <summary>
    /// Логика взаимодействия для ScanQrCode.xaml
    /// </summary>
    public partial class ScanQrCode : Window
    {
        OpenFileDialog OpenFileDialog = new OpenFileDialog();
        public ScanQrCode()
        {
            InitializeComponent();
        }

        private void Scan_Click(object sender, RoutedEventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == true)
            {
                ImgQR.Source = new BitmapImage(new Uri(OpenFileDialog.FileName));
            }
        }
    }
}
