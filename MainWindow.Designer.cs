
namespace ImagePaste
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this._uiPictureBox = new System.Windows.Forms.PictureBox();
            this._uiPathTextBox = new System.Windows.Forms.TextBox();
            this._uiMainButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._uiPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _uiPictureBox
            // 
            this._uiPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this._uiPictureBox.Location = new System.Drawing.Point(356, 12);
            this._uiPictureBox.Name = "_uiPictureBox";
            this._uiPictureBox.Size = new System.Drawing.Size(128, 128);
            this._uiPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._uiPictureBox.TabIndex = 0;
            this._uiPictureBox.TabStop = false;
            // 
            // _uiPathTextBox
            // 
            this._uiPathTextBox.Location = new System.Drawing.Point(12, 12);
            this._uiPathTextBox.Name = "_uiPathTextBox";
            this._uiPathTextBox.Size = new System.Drawing.Size(338, 20);
            this._uiPathTextBox.TabIndex = 1;
            // 
            // _uiMainButton
            // 
            this._uiMainButton.Location = new System.Drawing.Point(12, 38);
            this._uiMainButton.Name = "_uiMainButton";
            this._uiMainButton.Size = new System.Drawing.Size(338, 102);
            this._uiMainButton.TabIndex = 2;
            this._uiMainButton.Text = "Save";
            this._uiMainButton.UseVisualStyleBackColor = true;
            this._uiMainButton.Click += new System.EventHandler(this._uiMainButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 151);
            this.Controls.Add(this._uiMainButton);
            this.Controls.Add(this._uiPathTextBox);
            this.Controls.Add(this._uiPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(512, 190);
            this.MinimumSize = new System.Drawing.Size(512, 190);
            this.Name = "MainWindow";
            this.Text = "Image Paste";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this._uiPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _uiPictureBox;
        private System.Windows.Forms.TextBox _uiPathTextBox;
        private System.Windows.Forms.Button _uiMainButton;
    }
}

