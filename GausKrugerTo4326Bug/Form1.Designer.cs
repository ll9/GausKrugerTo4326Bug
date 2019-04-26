namespace GausKrugerTo4326Bug
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.SourceWktTextBox = new System.Windows.Forms.TextBox();
            this.DestinationWktTextBox = new System.Windows.Forms.TextBox();
            this.ReprojectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SourceWktTextBox
            // 
            this.SourceWktTextBox.Location = new System.Drawing.Point(43, 92);
            this.SourceWktTextBox.Name = "SourceWktTextBox";
            this.SourceWktTextBox.Size = new System.Drawing.Size(211, 20);
            this.SourceWktTextBox.TabIndex = 0;
            // 
            // DestinationWktTextBox
            // 
            this.DestinationWktTextBox.Location = new System.Drawing.Point(381, 92);
            this.DestinationWktTextBox.Name = "DestinationWktTextBox";
            this.DestinationWktTextBox.Size = new System.Drawing.Size(187, 20);
            this.DestinationWktTextBox.TabIndex = 2;
            // 
            // ReprojectButton
            // 
            this.ReprojectButton.Location = new System.Drawing.Point(276, 152);
            this.ReprojectButton.Name = "ReprojectButton";
            this.ReprojectButton.Size = new System.Drawing.Size(75, 23);
            this.ReprojectButton.TabIndex = 1;
            this.ReprojectButton.Text = "Reproject";
            this.ReprojectButton.UseVisualStyleBackColor = true;
            this.ReprojectButton.Click += new System.EventHandler(this.ReprojectButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReprojectButton);
            this.Controls.Add(this.DestinationWktTextBox);
            this.Controls.Add(this.SourceWktTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SourceWktTextBox;
        private System.Windows.Forms.TextBox DestinationWktTextBox;
        private System.Windows.Forms.Button ReprojectButton;
    }
}

