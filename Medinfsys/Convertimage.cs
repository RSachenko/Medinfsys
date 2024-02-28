using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Medinfsys
{
    public static class ConvertImage
    {
        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                var BitmapImage = new BitmapImage();
                BitmapImage.BeginInit();
                BitmapImage.StreamSource = memory;
                BitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                BitmapImage.EndInit();
                BitmapImage.Freeze();
                return BitmapImage;
            }
        }
    }
}
