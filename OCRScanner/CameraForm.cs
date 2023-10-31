using OpenCvSharp;
using IronSoftware.Drawing;
using IronOcr;

namespace OCRScanner
{
    public partial class CameraForm : Form
    {

        private VideoCapture videoCapture;
        private Mat frame;
        private AnyBitmap image;

        public CameraForm()
        {
            InitializeComponent();
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
            videoCapture = new VideoCapture(0);

            if (!videoCapture.IsOpened())
            {
                MessageBox.Show("Camera not found. Make sure the camera is connected.", "Camera Error");
                Close();
            }

            Application.Idle += new EventHandler(ProcessFrame);
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            // Capture a frame from the camera.
            frame = new Mat();
            videoCapture.Read(frame);

            if (frame.Empty())
                return;

            // Display the frame in the PictureBox.
            image = new AnyBitmap(frame.ToBytes());
            cameraBox.Image = image;
        }

        private void btnConvertToText_Click(object sender, EventArgs e)
        {
            var ocr = new IronTesseract();

            // Hundreds of languages available
            ocr.Language = OcrLanguage.English;

            using (var input = new OcrInput())
            {
                input.AddImage(image);
                // Input.DeNoise();  optional filter
                // Input.Deskew();   optional filter

                OcrResult result = ocr.Read(input);

                if (result != null)
                {
                    if (result.Text == "")
                    {
                        outputTextBox.Text = "No Text Detected!";
                    }
                    else
                    {
                        outputTextBox.Text = result.Text;
                    }
                }
                else
                {

                }
                // Explore the OcrResult using IntelliSense
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCapture != null)
                videoCapture.Release();
            if (frame != null)
                frame.Dispose();
        }
    }
}
