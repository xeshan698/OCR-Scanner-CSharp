namespace OCRScanner
{
    partial class CameraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cameraBox = new PictureBox();
            btnConvertToText = new Button();
            outputTextBox = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)cameraBox).BeginInit();
            SuspendLayout();
            // 
            // cameraBox
            // 
            cameraBox.BorderStyle = BorderStyle.FixedSingle;
            cameraBox.Location = new System.Drawing.Point(46, 25);
            cameraBox.Margin = new Padding(3, 2, 3, 2);
            cameraBox.Name = "cameraBox";
            cameraBox.Size = new System.Drawing.Size(560, 365);
            cameraBox.TabIndex = 2;
            cameraBox.TabStop = false;
            // 
            // btnConvertToText
            // 
            btnConvertToText.Location = new System.Drawing.Point(152, 410);
            btnConvertToText.Margin = new Padding(3, 2, 3, 2);
            btnConvertToText.Name = "btnConvertToText";
            btnConvertToText.Size = new System.Drawing.Size(330, 38);
            btnConvertToText.TabIndex = 5;
            btnConvertToText.Text = "Convert to Text";
            btnConvertToText.UseVisualStyleBackColor = true;
            btnConvertToText.Click += btnConvertToText_Click;
            // 
            // outputTextBox
            // 
            outputTextBox.BackColor = SystemColors.ScrollBar;
            outputTextBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            outputTextBox.Location = new System.Drawing.Point(625, 25);
            outputTextBox.Margin = new Padding(3, 2, 3, 2);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new System.Drawing.Size(308, 423);
            outputTextBox.TabIndex = 8;
            outputTextBox.Text = "";
            // 
            // CameraForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(946, 468);
            Controls.Add(outputTextBox);
            Controls.Add(btnConvertToText);
            Controls.Add(cameraBox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CameraForm";
            Text = "CameraForm";
            Load += CameraForm_Load;
            ((System.ComponentModel.ISupportInitialize)cameraBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox cameraBox;
        private Button btnConvertToText;
        private RichTextBox outputTextBox;
    }
}