
namespace Task_02
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
            this.info = new System.Windows.Forms.ListBox();
            this.startButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // info
            // 
            this.info.FormattingEnabled = true;
            this.info.ItemHeight = 15;
            this.info.Location = new System.Drawing.Point(302, 148);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(160, 139);
            this.info.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(260, 92);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(254, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Отобразить изначальный список";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(260, 319);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(254, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить выбранный элемент";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.info);
            this.Name = "Form1";
            this.Text = "ListBox";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox info;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button deleteButton;
    }
}

