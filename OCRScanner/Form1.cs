using IronOcr;
using IronSoftware.Drawing;
using OpenCvSharp;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OCRScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.ico|All Files|*.*",
                Title = "Select an Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image and display it in the PictureBox
                    imageBox.Image = new AnyBitmap(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConvertToText_Click(object sender, EventArgs e)
        {
            var ocr = new IronTesseract();

            // Hundreds of languages available
            ocr.Language = OcrLanguage.English;

            using (var input = new OcrInput())
            {
                input.AddImage(imageBox.Image);
                // Input.DeNoise();  optional filter
                // Input.Deskew();   optional filter

                OcrResult result = ocr.Read(input);

                if (result != null)
                {
                    if (result.Text != "")
                    {
                        outputTextBox.Text = result.Text;
                    }
                    else
                    {
                        outputTextBox.Text = "No Text Detected!";
                    }
                }

                // Explore the OcrResult using IntelliSense
            }
        }

        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            CameraForm cameraForm = new CameraForm();
            cameraForm.ShowDialog();

        }
    }
}