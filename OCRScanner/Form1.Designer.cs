namespace OCRScanner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            imageBox = new PictureBox();
            btnSelectImage = new Button();
            btnOpenCamera = new Button();
            btnConvertToText = new Button();
            label1 = new Label();
            label2 = new Label();
            outputTextBox = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)imageBox).BeginInit();
            SuspendLayout();
            // 
            // imageBox
            // 
            imageBox.BorderStyle = BorderStyle.Fixed3D;
            imageBox.Location = new System.Drawing.Point(10, 41);
            imageBox.Margin = new Padding(3, 2, 3, 2);
            imageBox.Name = "imageBox";
            imageBox.Size = new System.Drawing.Size(680, 212);
            imageBox.SizeMode = PictureBoxSizeMode.Zoom;
            imageBox.TabIndex = 0;
            imageBox.TabStop = false;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new System.Drawing.Point(10, 264);
            btnSelectImage.Margin = new Padding(3, 2, 3, 2);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new System.Drawing.Size(330, 38);
            btnSelectImage.TabIndex = 2;
            btnSelectImage.Text = "Select an Image";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // btnOpenCamera
            // 
            btnOpenCamera.Location = new System.Drawing.Point(186, 306);
            btnOpenCamera.Margin = new Padding(3, 2, 3, 2);
            btnOpenCamera.Name = "btnOpenCamera";
            btnOpenCamera.Size = new System.Drawing.Size(330, 38);
            btnOpenCamera.TabIndex = 3;
            btnOpenCamera.Text = "Open Camera";
            btnOpenCamera.UseVisualStyleBackColor = true;
            btnOpenCamera.Click += btnOpenCamera_Click;
            // 
            // btnConvertToText
            // 
            btnConvertToText.Location = new System.Drawing.Point(360, 264);
            btnConvertToText.Margin = new Padding(3, 2, 3, 2);
            btnConvertToText.Name = "btnConvertToText";
            btnConvertToText.Size = new System.Drawing.Size(330, 38);
            btnConvertToText.TabIndex = 4;
            btnConvertToText.Text = "Convert to Text";
            btnConvertToText.UseVisualStyleBackColor = true;
            btnConvertToText.Click += btnConvertToText_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(203, 7);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(271, 30);
            label1.TabIndex = 5;
            label1.Text = "OCR Scanner Application";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(10, 346);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(88, 30);
            label2.TabIndex = 6;
            label2.Text = "Output";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // outputTextBox
            // 
            outputTextBox.BackColor = SystemColors.ScrollBar;
            outputTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            outputTextBox.Location = new System.Drawing.Point(10, 376);
            outputTextBox.Margin = new Padding(3, 2, 3, 2);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new System.Drawing.Size(680, 172);
            outputTextBox.TabIndex = 7;
            outputTextBox.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(700, 559);
            Controls.Add(outputTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnConvertToText);
            Controls.Add(btnOpenCamera);
            Controls.Add(btnSelectImage);
            Controls.Add(imageBox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "OCR Scanner in C#";
            ((System.ComponentModel.ISupportInitialize)imageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox imageBox;
        private Button btnSelectImage;
        private Button btnOpenCamera;
        private Button btnConvertToText;
        private Label label1;
        private Label label2;
        private RichTextBox outputTextBox;
    }
}