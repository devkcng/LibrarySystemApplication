using System.ComponentModel;

namespace LibrarianUI
{
    partial class frmUpdateBorrower
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
        this.txtName = new System.Windows.Forms.TextBox();
        this.txtAddress = new System.Windows.Forms.TextBox();
        this.btnUpdate = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.txtId = new System.Windows.Forms.TextBox();
        this.txtUsername = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.txtPassword = new System.Windows.Forms.TextBox();
        this.label6 = new System.Windows.Forms.Label();
        this.txtAge = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // txtName
        // 
        this.txtName.Location = new System.Drawing.Point(183, 64);
        this.txtName.Name = "txtName";
        this.txtName.Size = new System.Drawing.Size(305, 22);
        this.txtName.TabIndex = 0;
        // 
        // txtAddress
        // 
        this.txtAddress.Location = new System.Drawing.Point(183, 104);
        this.txtAddress.Name = "txtAddress";
        this.txtAddress.Size = new System.Drawing.Size(305, 22);
        this.txtAddress.TabIndex = 1;
        // 
        // btnUpdate
        // 
        this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnUpdate.Location = new System.Drawing.Point(353, 270);
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
        this.btnCancel.Location = new System.Drawing.Point(525, 270);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(89, 33);
        this.btnCancel.TabIndex = 3;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // txtId
        // 
        this.txtId.Location = new System.Drawing.Point(183, 22);
        this.txtId.Name = "txtId";
        this.txtId.Size = new System.Drawing.Size(305, 22);
        this.txtId.TabIndex = 4;
        // 
        // txtUsername
        // 
        this.txtUsername.Location = new System.Drawing.Point(183, 186);
        this.txtUsername.Name = "txtUsername";
        this.txtUsername.Size = new System.Drawing.Size(306, 22);
        this.txtUsername.TabIndex = 5;
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.Location = new System.Drawing.Point(49, 26);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(77, 18);
        this.label1.TabIndex = 7;
        this.label1.Text = "ID";
        // 
        // label2
        // 
        this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label2.Location = new System.Drawing.Point(49, 68);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(77, 18);
        this.label2.TabIndex = 8;
        this.label2.Text = "Name";
        // 
        // label3
        // 
        this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label3.Location = new System.Drawing.Point(49, 108);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(77, 18);
        this.label3.TabIndex = 9;
        this.label3.Text = "Address";
        // 
        // label4
        // 
        this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label4.Location = new System.Drawing.Point(49, 190);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(115, 30);
        this.label4.TabIndex = 10;
        this.label4.Text = "Username";
        // 
        // label5
        // 
        this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label5.Location = new System.Drawing.Point(49, 233);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(115, 18);
        this.label5.TabIndex = 11;
        this.label5.Text = "Password";
        // 
        // txtPassword
        // 
        this.txtPassword.Location = new System.Drawing.Point(182, 233);
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.Size = new System.Drawing.Size(306, 22);
        this.txtPassword.TabIndex = 12;
        // 
        // label6
        // 
        this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label6.Location = new System.Drawing.Point(48, 150);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(115, 30);
        this.label6.TabIndex = 14;
        this.label6.Text = "Age";
        // 
        // txtAge
        // 
        this.txtAge.Location = new System.Drawing.Point(182, 146);
        this.txtAge.Name = "txtAge";
        this.txtAge.Size = new System.Drawing.Size(306, 22);
        this.txtAge.TabIndex = 13;
        // 
        // frmUpdateBorrower
        // 
        this.ClientSize = new System.Drawing.Size(667, 326);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.txtAge);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.txtId);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnUpdate);
        this.Controls.Add(this.txtAddress);
        this.Controls.Add(this.txtName);
        this.Name = "frmUpdateBorrower";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Update Book";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtAge;

    private System.Windows.Forms.TextBox txtPassword;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.TextBox txtUsername;

    private System.Windows.Forms.TextBox txtId;

    #endregion

    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnCancel;
}

}