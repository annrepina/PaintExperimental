namespace PaintExperimental
{
    partial class PaintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaintForm));
            this.button1 = new System.Windows.Forms.Button();
            this.ToolsPanel = new System.Windows.Forms.Panel();
            this.DrawLineButton = new System.Windows.Forms.Button();
            this.DrawPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1281, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сохранитьъ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.Location = new System.Drawing.Point(12, 12);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(1225, 57);
            this.ToolsPanel.TabIndex = 2;
            // 
            // DrawLineButton
            // 
            this.DrawLineButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawLineButton.Image")));
            this.DrawLineButton.Location = new System.Drawing.Point(1290, 153);
            this.DrawLineButton.Name = "DrawLineButton";
            this.DrawLineButton.Size = new System.Drawing.Size(24, 23);
            this.DrawLineButton.TabIndex = 3;
            this.DrawLineButton.UseVisualStyleBackColor = true;
            this.DrawLineButton.Click += new System.EventHandler(this.OnDrawLineButtonClick);
            // 
            // DrawPictureBox
            // 
            this.DrawPictureBox.Location = new System.Drawing.Point(12, 91);
            this.DrawPictureBox.Name = "DrawPictureBox";
            this.DrawPictureBox.Size = new System.Drawing.Size(1232, 603);
            this.DrawPictureBox.TabIndex = 4;
            this.DrawPictureBox.TabStop = false;
            this.DrawPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnDrawPictureBoxMouseDown);
            this.DrawPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnDrawPictureBoMouseUp);
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 1061);
            this.Controls.Add(this.DrawPictureBox);
            this.Controls.Add(this.DrawLineButton);
            this.Controls.Add(this.ToolsPanel);
            this.Controls.Add(this.button1);
            this.Name = "PaintForm";
            this.Text = "Paint 2.0";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPaintFormMouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.DrawPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Panel ToolsPanel;
        private Button DrawLineButton;
        private PictureBox DrawPictureBox;
    }
}