namespace P_MouseEvent
{
    partial class Frm_Test
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
            this.lblBtn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBtn
            // 
            this.lblBtn.AutoSize = true;
            this.lblBtn.Location = new System.Drawing.Point(0, 5);
            this.lblBtn.MaximumSize = new System.Drawing.Size(120, 13);
            this.lblBtn.MinimumSize = new System.Drawing.Size(120, 13);
            this.lblBtn.Name = "lblBtn";
            this.lblBtn.Size = new System.Drawing.Size(120, 13);
            this.lblBtn.TabIndex = 0;
            this.lblBtn.Text = "Click ?";
            this.lblBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 27);
            this.Controls.Add(this.lblBtn);
            this.Name = "Frm_Test";
            this.Text = "Frm_Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBtn;
    }
}