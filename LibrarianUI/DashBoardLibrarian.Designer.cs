namespace LibrarianUI
{
    partial class DashBoardLibrarian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoardLibrarian));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ts_books = new System.Windows.Forms.ToolStripDropDownButton();
            this.addBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_borrower = new System.Windows.Forms.ToolStripDropDownButton();
            this.addBorrowerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBorrowerInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_transaction = new System.Windows.Forms.ToolStripDropDownButton();
            this.ts_BorrowItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_returnItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_overdueItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_searchBook = new System.Windows.Forms.ToolStripButton();
            this.ts_returnBook = new System.Windows.Forms.ToolStripButton();
            this.ts_exit = new System.Windows.Forms.ToolStripButton();
            this.ts_login = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ts_books, this.ts_borrower, this.ts_transaction, this.ts_searchBook, this.ts_returnBook, this.ts_exit, this.ts_login });
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1219, 77);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ts_books
            // 
            this.ts_books.AutoSize = false;
            this.ts_books.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addBookToolStripMenuItem, this.viewBookToolStripMenuItem });
            this.ts_books.Image = global::LibrarianUI.Properties.Resources.icons8_books_50;
            this.ts_books.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts_books.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_books.Name = "ts_books";
            this.ts_books.Size = new System.Drawing.Size(69, 69);
            this.ts_books.Text = "Books";
            this.ts_books.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // addBookToolStripMenuItem
            // 
            this.addBookToolStripMenuItem.Image = global::LibrarianUI.Properties.Resources.icons8_add_book_48;
            this.addBookToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addBookToolStripMenuItem.Name = "addBookToolStripMenuItem";
            this.addBookToolStripMenuItem.Size = new System.Drawing.Size(182, 56);
            this.addBookToolStripMenuItem.Text = "Add Book";
            this.addBookToolStripMenuItem.Click += new System.EventHandler(this.addBookToolStripMenuItem_Click);
            // 
            // viewBookToolStripMenuItem
            // 
            this.viewBookToolStripMenuItem.Image = global::LibrarianUI.Properties.Resources.icons8_view_50;
            this.viewBookToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewBookToolStripMenuItem.Name = "viewBookToolStripMenuItem";
            this.viewBookToolStripMenuItem.Size = new System.Drawing.Size(182, 56);
            this.viewBookToolStripMenuItem.Text = "View Book";
            this.viewBookToolStripMenuItem.Click += new System.EventHandler(this.viewBookToolStripMenuItem_Click);
            // 
            // ts_borrower
            // 
            this.ts_borrower.AutoSize = false;
            this.ts_borrower.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addBorrowerToolStripMenuItem, this.viewBorrowerInfoToolStripMenuItem });
            this.ts_borrower.Image = global::LibrarianUI.Properties.Resources.icons8_student_male_100;
            this.ts_borrower.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_borrower.Name = "ts_borrower";
            this.ts_borrower.Size = new System.Drawing.Size(69, 69);
            this.ts_borrower.Text = "Borrower";
            this.ts_borrower.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // addBorrowerToolStripMenuItem
            // 
            this.addBorrowerToolStripMenuItem.Image = global::LibrarianUI.Properties.Resources.icons8_add_user_male_50;
            this.addBorrowerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addBorrowerToolStripMenuItem.Name = "addBorrowerToolStripMenuItem";
            this.addBorrowerToolStripMenuItem.Size = new System.Drawing.Size(239, 56);
            this.addBorrowerToolStripMenuItem.Text = "Add Borrower";
            this.addBorrowerToolStripMenuItem.Click += new System.EventHandler(this.addBorrowerToolStripMenuItem_Click);
            // 
            // viewBorrowerInfoToolStripMenuItem
            // 
            this.viewBorrowerInfoToolStripMenuItem.Image = global::LibrarianUI.Properties.Resources.icons8_view_501;
            this.viewBorrowerInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewBorrowerInfoToolStripMenuItem.Name = "viewBorrowerInfoToolStripMenuItem";
            this.viewBorrowerInfoToolStripMenuItem.Size = new System.Drawing.Size(239, 56);
            this.viewBorrowerInfoToolStripMenuItem.Text = "View Borrower Info";
            // 
            // ts_transaction
            // 
            this.ts_transaction.AutoSize = false;
            this.ts_transaction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ts_BorrowItem, this.ts_returnItem, this.ts_overdueItem });
            this.ts_transaction.Image = ((System.Drawing.Image)(resources.GetObject("ts_transaction.Image")));
            this.ts_transaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_transaction.Name = "ts_transaction";
            this.ts_transaction.Size = new System.Drawing.Size(80, 69);
            this.ts_transaction.Text = "Transaction";
            this.ts_transaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ts_BorrowItem
            // 
            this.ts_BorrowItem.Name = "ts_BorrowItem";
            this.ts_BorrowItem.Size = new System.Drawing.Size(134, 24);
            this.ts_BorrowItem.Text = "Borrow";
            // 
            // ts_returnItem
            // 
            this.ts_returnItem.Name = "ts_returnItem";
            this.ts_returnItem.Size = new System.Drawing.Size(134, 24);
            this.ts_returnItem.Text = "Return";
            // 
            // ts_overdueItem
            // 
            this.ts_overdueItem.Name = "ts_overdueItem";
            this.ts_overdueItem.Size = new System.Drawing.Size(134, 24);
            this.ts_overdueItem.Text = "Overdue";
            // 
            // ts_searchBook
            // 
            this.ts_searchBook.AutoSize = false;
            this.ts_searchBook.Image = ((System.Drawing.Image)(resources.GetObject("ts_searchBook.Image")));
            this.ts_searchBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_searchBook.Name = "ts_searchBook";
            this.ts_searchBook.Size = new System.Drawing.Size(69, 69);
            this.ts_searchBook.Text = "Search Book";
            this.ts_searchBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ts_returnBook
            // 
            this.ts_returnBook.Image = global::LibrarianUI.Properties.Resources.icons8_return_book_50;
            this.ts_returnBook.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts_returnBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_returnBook.Name = "ts_returnBook";
            this.ts_returnBook.Size = new System.Drawing.Size(94, 74);
            this.ts_returnBook.Text = "Return Book";
            this.ts_returnBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ts_exit
            // 
            this.ts_exit.AutoSize = false;
            this.ts_exit.Image = global::LibrarianUI.Properties.Resources.icons8_exit_sign_50;
            this.ts_exit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_exit.Name = "ts_exit";
            this.ts_exit.Size = new System.Drawing.Size(69, 69);
            this.ts_exit.Text = "Exit";
            this.ts_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ts_exit.Click += new System.EventHandler(this.ts_exit_Click);
            // 
            // ts_login
            // 
            this.ts_login.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ts_login.AutoSize = false;
            this.ts_login.Image = global::LibrarianUI.Properties.Resources.log_open;
            this.ts_login.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_login.Name = "ts_login";
            this.ts_login.Size = new System.Drawing.Size(70, 69);
            this.ts_login.Text = "Login";
            this.ts_login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ts_login.Click += new System.EventHandler(this.ts_login_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::LibrarianUI.Properties.Resources.LibraryWallpaper;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1219, 730);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // DashBoardLibrarian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 730);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DashBoardLibrarian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem addBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBorrowerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBorrowerInfoToolStripMenuItem;

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton ts_books;
        private System.Windows.Forms.ToolStripDropDownButton ts_transaction;
        private System.Windows.Forms.ToolStripMenuItem ts_BorrowItem;
        private System.Windows.Forms.ToolStripMenuItem ts_returnItem;
        private System.Windows.Forms.ToolStripMenuItem ts_overdueItem;
        private System.Windows.Forms.ToolStripDropDownButton ts_borrower;
        private System.Windows.Forms.ToolStripButton ts_searchBook;
        private System.Windows.Forms.ToolStripButton ts_returnBook;
        private System.Windows.Forms.ToolStripButton ts_exit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton ts_login;
    }
}

