namespace LibrarySystemApplication
{
    partial class ProfileUI
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Age = new System.Windows.Forms.TextBox();
            this.txt_Address = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibrarySystemApplication.Properties.Resources.icons8_student_male_1001;
            this.pictureBox1.Location = new System.Drawing.Point(12, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 266);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(341, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(341, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(341, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 36);
            this.label3.TabIndex = 3;
            this.label3.Text = "Age";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(341, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 36);
            this.label4.TabIndex = 4;
            this.label4.Text = "Address";
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(471, 75);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(257, 31);
            this.txt_ID.TabIndex = 5;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(471, 161);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Size = new System.Drawing.Size(257, 31);
            this.txt_Name.TabIndex = 6;
            // 
            // txt_Age
            // 
            this.txt_Age.Location = new System.Drawing.Point(471, 233);
            this.txt_Age.Name = "txt_Age";
            this.txt_Age.ReadOnly = true;
            this.txt_Age.Size = new System.Drawing.Size(257, 31);
            this.txt_Age.TabIndex = 7;
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(471, 310);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.ReadOnly = true;
            this.txt_Address.Size = new System.Drawing.Size(257, 31);
            this.txt_Address.TabIndex = 8;
            // 
            // ProfileUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.txt_Age);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ProfileUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProfileUI";
            this.Load += new System.EventHandler(this.ProfileUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Age;
        private System.Windows.Forms.TextBox txt_Address;
    }
}