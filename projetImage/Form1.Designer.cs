namespace projetImage
{
    partial class Form1
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
            this.button_loadPicture = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.button_saveInDb = new System.Windows.Forms.Button();
            this.button_loadFromDB = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_saveSketch = new System.Windows.Forms.Button();
            this.textBox_db = new System.Windows.Forms.TextBox();
            this.button_loadSketch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonLineColor = new System.Windows.Forms.Button();
            this.buttonSizeLine = new System.Windows.Forms.Button();
            this.buttonDrawLine = new System.Windows.Forms.Button();
            this.button_createSketch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_loadPicture
            // 
            this.button_loadPicture.Location = new System.Drawing.Point(6, 19);
            this.button_loadPicture.Name = "button_loadPicture";
            this.button_loadPicture.Size = new System.Drawing.Size(75, 23);
            this.button_loadPicture.TabIndex = 0;
            this.button_loadPicture.Text = "Load picture";
            this.button_loadPicture.UseVisualStyleBackColor = true;
            this.button_loadPicture.Click += new System.EventHandler(this.button_loadPicture_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(44, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(518, 446);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(721, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(133, 19);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(94, 23);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_saveInDb
            // 
            this.button_saveInDb.Location = new System.Drawing.Point(6, 48);
            this.button_saveInDb.Name = "button_saveInDb";
            this.button_saveInDb.Size = new System.Drawing.Size(81, 23);
            this.button_saveInDb.TabIndex = 4;
            this.button_saveInDb.Text = "save picture";
            this.button_saveInDb.UseVisualStyleBackColor = true;
            this.button_saveInDb.Click += new System.EventHandler(this.button_saveInDb_Click);
            // 
            // button_loadFromDB
            // 
            this.button_loadFromDB.Location = new System.Drawing.Point(6, 19);
            this.button_loadFromDB.Name = "button_loadFromDB";
            this.button_loadFromDB.Size = new System.Drawing.Size(75, 23);
            this.button_loadFromDB.TabIndex = 5;
            this.button_loadFromDB.Text = "Load picture";
            this.button_loadFromDB.UseVisualStyleBackColor = true;
            this.button_loadFromDB.Click += new System.EventHandler(this.button_loadFromDB_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_loadPicture);
            this.groupBox1.Controls.Add(this.button_save);
            this.groupBox1.Location = new System.Drawing.Point(633, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 58);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folder access";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(646, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button_saveSketch);
            this.groupBox2.Controls.Add(this.textBox_db);
            this.groupBox2.Controls.Add(this.button_loadSketch);
            this.groupBox2.Controls.Add(this.button_saveInDb);
            this.groupBox2.Controls.Add(this.button_loadFromDB);
            this.groupBox2.Location = new System.Drawing.Point(615, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 123);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DB access";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name : ";
            // 
            // button_saveSketch
            // 
            this.button_saveSketch.Location = new System.Drawing.Point(117, 48);
            this.button_saveSketch.Name = "button_saveSketch";
            this.button_saveSketch.Size = new System.Drawing.Size(75, 23);
            this.button_saveSketch.TabIndex = 7;
            this.button_saveSketch.Text = "Save sketch";
            this.button_saveSketch.UseVisualStyleBackColor = true;
            // 
            // textBox_db
            // 
            this.textBox_db.Location = new System.Drawing.Point(106, 87);
            this.textBox_db.Name = "textBox_db";
            this.textBox_db.Size = new System.Drawing.Size(187, 20);
            this.textBox_db.TabIndex = 6;
            // 
            // button_loadSketch
            // 
            this.button_loadSketch.Location = new System.Drawing.Point(106, 19);
            this.button_loadSketch.Name = "button_loadSketch";
            this.button_loadSketch.Size = new System.Drawing.Size(86, 23);
            this.button_loadSketch.TabIndex = 1;
            this.button_loadSketch.Text = "Load  sketch";
            this.button_loadSketch.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonLineColor);
            this.groupBox3.Controls.Add(this.buttonSizeLine);
            this.groupBox3.Controls.Add(this.buttonDrawLine);
            this.groupBox3.Controls.Add(this.button_createSketch);
            this.groupBox3.Location = new System.Drawing.Point(621, 361);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 97);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sketch";
            // 
            // buttonLineColor
            // 
            this.buttonLineColor.Location = new System.Drawing.Point(12, 68);
            this.buttonLineColor.Name = "buttonLineColor";
            this.buttonLineColor.Size = new System.Drawing.Size(75, 23);
            this.buttonLineColor.TabIndex = 3;
            this.buttonLineColor.Text = "Color";
            this.buttonLineColor.UseVisualStyleBackColor = true;
            // 
            // buttonSizeLine
            // 
            this.buttonSizeLine.Location = new System.Drawing.Point(240, 31);
            this.buttonSizeLine.Name = "buttonSizeLine";
            this.buttonSizeLine.Size = new System.Drawing.Size(75, 23);
            this.buttonSizeLine.TabIndex = 2;
            this.buttonSizeLine.Text = "Size";
            this.buttonSizeLine.UseVisualStyleBackColor = true;
            this.buttonSizeLine.Click += new System.EventHandler(this.buttonSizeLine_Click);
            // 
            // buttonDrawLine
            // 
            this.buttonDrawLine.Location = new System.Drawing.Point(136, 31);
            this.buttonDrawLine.Name = "buttonDrawLine";
            this.buttonDrawLine.Size = new System.Drawing.Size(75, 23);
            this.buttonDrawLine.TabIndex = 1;
            this.buttonDrawLine.Text = "drawLine";
            this.buttonDrawLine.UseVisualStyleBackColor = true;
            this.buttonDrawLine.Click += new System.EventHandler(this.buttonDrawLine_Click);
            // 
            // button_createSketch
            // 
            this.button_createSketch.Location = new System.Drawing.Point(12, 31);
            this.button_createSketch.Name = "button_createSketch";
            this.button_createSketch.Size = new System.Drawing.Size(98, 23);
            this.button_createSketch.TabIndex = 0;
            this.button_createSketch.Text = "Create a sketch";
            this.button_createSketch.UseVisualStyleBackColor = true;
            this.button_createSketch.Click += new System.EventHandler(this.button_createSketch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(761, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 504);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_loadPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_saveInDb;
        private System.Windows.Forms.Button button_loadFromDB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_loadSketch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_createSketch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_saveSketch;
        private System.Windows.Forms.TextBox textBox_db;
        private System.Windows.Forms.Button buttonLineColor;
        private System.Windows.Forms.Button buttonSizeLine;
        private System.Windows.Forms.Button buttonDrawLine;
        private System.Windows.Forms.Button button1;
    }
}

