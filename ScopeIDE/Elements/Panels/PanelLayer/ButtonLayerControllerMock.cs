using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ScopeIDE.Elements.Panels.PanelLayer {
    public class ButtonLayerControllerMock : IButtonLayerController {
        private Bitmap _bitmap;

        public ButtonLayerControllerMock() {
            var genBitmapRandom = GenBitmapRandom();
            var randLetter = DrawRandLetter(genBitmapRandom);
            var compressBitmap = CompressBitmap(randLetter);
            _bitmap = compressBitmap;
        }

        public Bitmap GetLayerScreen() {
            return _bitmap;
        }

        public void SetName(string nameBoxText) {
            // Pam pam, new name has set
        }

        public void SetVisible(bool layerVisibleStatus) {
            //Tum tum, new visible status has set
        }

        private Bitmap GenBitmapRandom() {
            var rnd = new Random();
            
            var width = rnd.Next(720, 4000);
            var height = rnd.Next(720, 4000);

            var bitmap = new Bitmap(width, height);
            using var gfx = Graphics.FromImage(bitmap);
            using var brush = new SolidBrush(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            gfx.FillRectangle(brush, 0, 0, width, height);

            return bitmap;
        }

        private Bitmap CompressBitmap(Bitmap bitmap) {
            var newWidth = 40;
            var newHeight = 40;
            var compressed = new Bitmap(newWidth, newHeight);

            var coofWidth = bitmap.Width / newWidth;
            var coofHeight = bitmap.Height / newHeight;
            for (var y = 0; y < newHeight; y++) {
                for (var x = 0; x < newWidth; x++) {
                    var scopeX = x * coofWidth;
                    var scopeY = y * coofHeight;
                    if (scopeX <= bitmap.Width && scopeY <= bitmap.Height)
                        compressed.SetPixel(x, y, bitmap.GetPixel(scopeX, scopeY));
                }
            }

            return compressed;
        }

        private Bitmap DrawRandLetter(Bitmap bitmap) {
            RectangleF rectf = new RectangleF(bitmap.Width / 10, bitmap.Height / 10, bitmap.Width, bitmap.Height);

            Graphics g = Graphics.FromImage(bitmap);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(GetRandomCharacter(), new Font("Tahoma",(Convert.ToInt32(Math.Min(bitmap.Width, bitmap.Width) / 2))), Brushes.Black, rectf);

            g.Flush();

            bitmap.Save(@"F:\test\" + bitmap.Width + "X" + bitmap.Height + ".jpg");
            return bitmap;
        }
        
        public string GetRandomCharacter() {
            string text = "йцукенгшщзхїфівапролджєячсмитьбю";
            int index = new Random().Next(text.Length);
            return text[index].ToString();
        }
    }
}