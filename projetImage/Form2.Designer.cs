namespace projetImage
{
    partial class Form2
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
            this.comboBox_name = new System.Windows.Forms.ComboBox();
            this.button_loadImage = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_name
            // 
            this.comboBox_name.FormattingEnabled = true;
            this.comboBox_name.Location = new System.Drawing.Point(142, 64);
            this.comboBox_name.Name = "comboBox_name";
            this.comboBox_name.Size = new System.Drawing.Size(121, 21);
            this.comboBox_name.TabIndex = 0;
            this.comboBox_name.SelectedIndexChanged += new System.EventHandler(this.comboBox_name_SelectedIndexChanged);
            // 
            // button_loadImage
            // 
            this.button_loadImage.Location = new System.Drawing.Point(40, 189);
            this.button_loadImage.Name = "button_loadImage";
            this.button_loadImage.Size = new System.Drawing.Size(75, 23);
            this.button_loadImage.TabIndex = 1;
            this.button_loadImage.Text = "Load image";
            this.button_loadImage.UseVisualStyleBackColor = true;
            this.button_loadImage.Click += new System.EventHandler(this.button_loadImage_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(167, 189);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_loadImage);
            this.Controls.Add(this.comboBox_name);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_name;
        private System.Windows.Forms.Button button_loadImage;
        private System.Windows.Forms.Button button_cancel;
    }
}