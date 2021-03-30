using System;
using System.Drawing;

namespace ScopeIDE.Elements.Panels.PanelLayer {
    public class ButtonLayerControllerMock : IButtonLayerController {
        private Bitmap _bitmap;
        public ButtonLayerControllerMock() {
            _bitmap = CompressBitmap(GenBitmapRandom());
        }

        public Bitmap GetLayerScreen() {
            // Bitmap compressBitmap = CompressBitmap(_bitmap);
            return _bitmap;
        }

        private Bitmap GenBitmapRandom() {
            var width = new Random().Next(720, 4000);
            var height = new Random().Next(720, 4000);

            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(bitmap))
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(
                new Random().Next(60, 255),
                new Random().Next(60, 255),
                new Random().Next(60, 255)
            ))) {
                gfx.FillRectangle(brush, 0, 0, width, height);
            }

            return bitmap;
        }

        private Bitmap CompressBitmap(Bitmap bitmap) {
            var newWidth = 50;
            var newHeight = 50;
            var compressed = new Bitmap(newWidth, newHeight);

            var coofWidth = bitmap.Width / newWidth;
            for (var y = 0; y < newHeight; y++) {
                for (var x = 0; x < newWidth; x++) {
                    if (x > bitmap.Width || y > bitmap.Height) continue;
                    var pixel = bitmap.GetPixel(x, y);
                    compressed.SetPixel(x, y, pixel);
                }
            }

            return compressed;
        }
    }
}