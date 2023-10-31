# C# OCR library for reading text from images and PDF

[IronOCR](https://ironsoftware.com/csharp/ocr/) is a powerful C# OCR (Optical Character Recognition) library that allows you to convert scanned documents, scanned images, and different image formats into searchable and editable text. This repository contains an example of an OCR scanner application in C# using the IronOCR .NET Framework Library to convert images to text.

## Building an OCR Scanner Application in C# with IronOCR

### Step 1: Download the Project

Download the IronOCR OCR scanner project to your local disk and open the solution file using Visual Studio. You can also create your own project using a Windows Forms application in Visual Studio.

### Step 2: Rebuild Solution

If you downloaded the project, rebuild the solution to install the required IronOCR NuGet package and OpenCVSharp4 camera accessing package. If you create your own project, then install the IronOCR and OpenCVSharp4 packages using the NuGet package manager or Package Manager Console.

### Step 3: Setting up OCR C# Application Interface

In this application, users can provide images through two methods:

- By opening the camera and capturing images, which can include receipts, notes, documents, photos, and business cards.

- By selecting images from their device's photo gallery.

#### Add CameraForm

Right-click on the project in Solution Explorer and click "Add" to choose Forms and name it "CameraForm."

#### Add Controls to Form1

Add the following controls to Form1, which is the main form:

- **PictureBox:** Name it as `imageBox`. This control will display the selected image.

- **Button:** Name it as `btnSelectImage`. This button will allow the user to select an image for OCR.

- **Button:** Name it as `btnConvertToText`. This button will trigger the OCR process.

- **Button:** Name it as `btnOpenCamera`. This button will allow the user to open the default camera using OpenCVSharp4 library.

- **RichTextBox:** Name it as `outputTextBox`. This RichTextBox will display the recognized text.

The form on execution looks like this:

#### Add Controls to CameraForm

Add the following controls to CameraForm:

- **PictureBox:** Name it as `cameraBox`. This control will display the camera feed captured using OpenCVSharp4.

- **Button:** Name it as `btnConvertToText`. This button will trigger the OCR process.

- **RichTextBox:** Name it as `outputTextBox`. This RichTextBox will display the recognized text.

The form looks like this:

#### Image Files

This application will be able to open multiple image formats (.jpg, .jpeg, .png, .gif, .bmp, .ico). Here is the sample image used:

### Step 4: Add Methods to Select Image File and Open Camera

Click each button as mentioned in the previous step and add the following code respectively:

```java
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
```
This code allows users to select an image, perform OCR using tesseract OCR engine on it, and display the recognized text. It also provides an option to open a camera form for capturing images.

- **Select Image:** When the "Select Image" button (**btnSelectImage**) is clicked, an **OpenFileDialog** is created, allowing the user to choose an image file. The selected image is then loaded and displayed in the **imageBox** PictureBox to extract text from it.

- **Convert to Text:** When the "Convert to Text" button (**btnConvertToText**) is clicked, OCR is performed on the selected image. It uses the [IronTesseract](https://ironsoftware.com/csharp/ocr/tutorials/c-sharp-tesseract-ocr/) method from **Iron OCR** library to recognize text in the image. The recognized text is displayed in the **outputTextBox**. Optional filters like **denoising** and **deskewing** can also be used to correct low quality scans or if image is tilted.

- **Open Camera:** When the "Open Camera" button (**btnOpenCamera**) is clicked, it opens a new form (**CameraForm**) that presumably allows for camera capture. The ShowDialog method is used to show the camera form as a dialog.

### Step 5: Initiate Camera and Capture Frame as Image for OCR

In CameraForm's `Form_Load` method, capture video from a camera, display the video feed, and perform Optical Character Recognition (OCR) on the current captured [image to read text in C# .NET](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/).

```java
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
```
This code helps in real-time camera video capture and OCR text recognition, allowing users to see the recognized text from the camera feed. It uses the **VideoCapture** class for camera access in OpenCVSharp and the **IronTesseract OCR** API for OCR functionality.

- **Initialization:** The code initializes variables for video capture (**videoCapture**), frame storage (**frame**), and image display (**image**). The form is constructed with its components and controls.

- **Camera Loading:** Upon form loading, the code attempts to open the default camera (**ID 0**) using the **VideoCapture** class. If successful, it subscribes to an event handler to continuously process video frames.

- **Frame Processing:** The **ProcessFrame** method is called repeatedly. It captures a frame from the camera, converts it into an **AnyBitmap**, and displays it in a (**cameraBox**) PictureBox.

- **Text Conversion:** When a button (**btnConvertToText**) is clicked, OCR is performed on the displayed image. The **IronTesseract** method of IronOCR .NET library is used to recognize text in the image. The OCR result is displayed in a (**outputTextBox**) RichTextBox.

- **Closing the Application:** When the form is closing, resources are released. The camera capture is released, and the **frame** object is disposed of.

## Conclusion

In this guide, we've explored how to build an OCR scanner application in C# using IronOCR to convert scanned images into searchable and editable PDF documents. By following these steps, you can create a robust OCR application that helps you extract text from images and save them as PDFs. For more information, refer to the complete source code available in the GitHub repository.

For more details about IronOCR and its capabilities, you can visit the [IronOCR website](https://ironsoftware.com/csharp/ocr/).

For code examples and tutorials, you can visit the [documentation page](https://ironsoftware.com/csharp/ocr/docs/).

If you have any questions or need assistance, feel free to reach out to the IronOCR [support team](https://ironsoftware.com/suite/extensions/#helpscout-support).

## Licensing

IronOCR offers both paid licenses for commercial use and free for development purposes. It also provides a [free trial](https://ironsoftware.com/csharp/ocr/licensing/#trial-license) option that grants access to its full features for a limited period. This trial period allows developers to assess IronOCR's suitability for their OCR needs before purchasing a license.

## About IronOCR

IronOCR is a powerful C# OCR library that provides comprehensive OCR capabilities for developers. It enables you to extract text from scanned documents, images, and PDFs, making it a valuable tool for a wide range of applications. IronOCR offers a rich set of features and is designed to be easy to integrate into your C# projects.
