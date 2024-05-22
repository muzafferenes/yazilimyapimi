namespace WindowsFormsApp2
{
    partial class Form4
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
            this.klmekle = new System.Windows.Forms.Button();
            this.snvgiris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // klmekle
            // 
            this.klmekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.klmekle.Location = new System.Drawing.Point(276, 135);
            this.klmekle.Name = "klmekle";
            this.klmekle.Size = new System.Drawing.Size(186, 67);
            this.klmekle.TabIndex = 0;
            this.klmekle.Text = "Kelime Ekle";
            this.klmekle.UseVisualStyleBackColor = true;
            this.klmekle.Click += new System.EventHandler(this.klmekle_Click);
            // 
            // snvgiris
            // 
            this.snvgiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.snvgiris.Location = new System.Drawing.Point(276, 242);
            this.snvgiris.Name = "snvgiris";
            this.snvgiris.Size = new System.Drawing.Size(186, 74);
            this.snvgiris.TabIndex = 1;
            this.snvgiris.Text = "Sınava Gir";
            this.snvgiris.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.snvgiris);
            this.Controls.Add(this.klmekle);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button klmekle;
        private System.Windows.Forms.Button snvgiris;
    }
}