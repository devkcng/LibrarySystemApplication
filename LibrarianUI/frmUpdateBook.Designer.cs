using System.ComponentModel;

namespace LibrarianUI
{
    partial class frmUpdateBook
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
        this.txtTitle = new System.Windows.Forms.TextBox();
        this.txtAuthor = new System.Windows.Forms.TextBox();
        this.btnUpdate = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.txtISBN = new System.Windows.Forms.TextBox();
        this.txtCategory = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.cboStatus = new System.Windows.Forms.ComboBox();
        this.SuspendLayout();
        // 
        // txtTitle
        // 
        this.txtTitle.Location = new System.Drawing.Point(183, 64);
        this.txtTitle.Name = "txtTitle";
        this.txtTitle.Size = new System.Drawing.Size(305, 22);
        this.txtTitle.TabIndex = 0;
        // 
        // txtAuthor
        // 
        this.txtAuthor.Location = new System.Drawing.Point(183, 104);
        this.txtAuthor.Name = "txtAuthor";
        this.txtAuthor.Size = new System.Drawing.Size(305, 22);
        this.txtAuthor.TabIndex = 1;
        // 
        // btnUpdate
        // 
        this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnUpdate.Location = new System.Drawing.Point(353, 250);
        this.btnUpdate.Name = "btnUpdate";
        this.btnUpdate.Size = new System.Drawing.Size(94, 33);
        this.btnUpdate.TabIndex = 2;
        this.btnUpdate.Text = "Update";
        this.btnUpdate.UseVisualStyleBackColor = true;
        this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnCancel.Location = new System.Drawing.Point(525, 250);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(89, 33);
        this.btnCancel.TabIndex = 3;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // txtISBN
        // 
        this.txtISBN.Location = new System.Drawing.Point(183, 22);
        this.txtISBN.Name = "txtISBN";
        this.txtISBN.Size = new System.Drawing.Size(305, 22);
        this.txtISBN.TabIndex = 4;
        // 
        // txtCategory
        // 
        this.txtCategory.Location = new System.Drawing.Point(183, 150);
        this.txtCategory.Name = "txtCategory";
        this.txtCategory.Size = new System.Drawing.Size(306, 22);
        this.txtCategory.TabIndex = 5;
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.Location = new System.Drawing.Point(49, 26);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(77, 18);
        this.label1.TabIndex = 7;
        this.label1.Text = "ISBN";
        // 
        // label2
        // 
        this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label2.Location = new System.Drawing.Point(49, 68);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(77, 18);
        this.label2.TabIndex = 8;
        this.label2.Text = "Title";
        // 
        // label3
        // 
        this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label3.Location = new System.Drawing.Point(49, 108);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(77, 18);
        this.label3.TabIndex = 9;
        this.label3.Text = "Author";
        // 
        // label4
        // 
        this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label4.Location = new System.Drawing.Point(49, 154);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(77, 18);
        this.label4.TabIndex = 10;
        this.label4.Text = "Category";
        // 
        // label5
        // 
        this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label5.Location = new System.Drawing.Point(49, 197);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(115, 18);
        this.label5.TabIndex = 11;
        this.label5.Text = "Status";
        // 
        // cboStatus
        // 
        this.cboStatus.FormattingEnabled = true;
        this.cboStatus.Items.AddRange(new object[] { "Available", "Borrowed" });
        this.cboStatus.Location = new System.Drawing.Point(183, 197);
        this.cboStatus.Name = "cboStatus";
        this.cboStatus.Size = new System.Drawing.Size(305, 24);
        this.cboStatus.TabIndex = 12;
        // 
        // frmUpdateBook
        // 
        this.ClientSize = new System.Drawing.Size(667, 326);
        this.Controls.Add(this.cboStatus);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.txtCategory);
        this.Controls.Add(this.txtISBN);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnUpdate);
        this.Controls.Add(this.txtAuthor);
        this.Controls.Add(this.txtTitle);
        this.Name = "frmUpdateBook";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Update Book";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.ComboBox cboStatus;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.TextBox txtCategory;

    private System.Windows.Forms.TextBox txtISBN;

    #endregion

    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.TextBox txtAuthor;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnCancel;
}

}