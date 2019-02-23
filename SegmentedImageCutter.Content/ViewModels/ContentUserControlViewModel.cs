using Microsoft.Win32;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RiceCakeSoftware.SegmentedImageCutter.Content.ViewModels
{
    public class ContentUserControlViewModel : BindableBase
    {
        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { SetProperty(ref _filePath, value); }
        }

        private ImageSource _originalImage;
        public ImageSource OriginalImage
        {
            get { return _originalImage; }
            set { SetProperty(ref _originalImage, value); }
        }

        private ImageSource _segmentedImage;
        public ImageSource SegmentedImage
        {
            get { return _segmentedImage; }
            set { SetProperty(ref _segmentedImage, value); }
        }

        public DelegateCommand BrowseCommand { get; }
        public InteractionRequest<Notification> NotificationRequest { get; }

        public ContentUserControlViewModel()
        {
            FilePath = string.Empty;
            BrowseCommand = new DelegateCommand(() =>
            {
                OpenFileDialog dialog = new OpenFileDialog()
                {
                    Multiselect = false,
                    CheckPathExists = true,
                    CheckFileExists = true,
                    Filter = "画像ファイル|*.bmp;*.jpg;*.png",
                };
                bool? ret = dialog.ShowDialog();
                if (ret.HasValue && ret.Value)
                {
                    FilePath = dialog.FileName;
                    Mat original = Cv2.ImRead(dialog.FileName);
                    OriginalImage = ToBitmapSource(BitmapConverter.ToBitmap(original));

                    Mat grayscale = new Mat();
                    Cv2.CvtColor(original, grayscale, ColorConversionCodes.BGR2GRAY);
                    Mat binary = new Mat();
                    Cv2.Threshold(grayscale, binary, 0.0, 255.0, ThresholdTypes.Binary | ThresholdTypes.Otsu);
                    Mat labels = new Mat();
                    ConnectedComponents components = Cv2.ConnectedComponentsEx(binary);
                    Mat segmented = new Mat();
                    components.RenderBlobs(segmented);
                    SegmentedImage = ToBitmapSource(BitmapConverter.ToBitmap(segmented));
                }
            });
            System.Diagnostics.Debug.Print(Cv2.GetVersionString());
        }

        private BitmapSource ToBitmapSource(Bitmap bitmap)
        {
            var hBitmap = bitmap.GetHbitmap();
            // HBitmapからBitmapSourceを作成
            try
            {
                var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                );
                return bitmapSource;
            }
            finally
            {
                DeleteObject(hBitmap);
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);
    }
}
