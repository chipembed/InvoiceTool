using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using ZXing;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (PdfDocument document = PdfDocument.Open("C:\\Applications\\Fapiao.pdf"))
            {
                Page firstPage = document.GetPages().FirstOrDefault();
                // 处理二维码
                var images = firstPage.GetImages();
                var firstImage = images.FirstOrDefault();
                if (firstImage != null)
                {
                    var bitmap = ConvertPdfImageToBitmap(firstImage);
                    var qcinfo = bitmap is null ? null : new BarcodeReader().Decode(bitmap);
                    var result = qcinfo is null ? "0,99,?,?,?,?,?" : qcinfo.Text;
                    textBox1.Text = result;
                }
            }
        }

        private Bitmap ConvertPdfImageToBitmap(IPdfImage pdfImage)
        {
            pdfImage.TryGetPng(out byte[] pngBytes);
            if (pngBytes == null)
            {
                return null;
            }
            using (MemoryStream ms = new MemoryStream(pngBytes))
            {
                return new Bitmap(ms);
            }
        }
    }
}
