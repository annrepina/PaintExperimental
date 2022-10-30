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
            this.RedColorButton = new System.Windows.Forms.Button();
            this.BlackColorButton = new System.Windows.Forms.Button();
            this.DrawEllipseButton = new System.Windows.Forms.Button();
            this.DrawRectangleButton = new System.Windows.Forms.Button();
            this.DrawLineButton = new System.Windows.Forms.Button();
            this.DrawPictureBox = new System.Windows.Forms.PictureBox();
            this.ToolsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3111, 656);
            this.button1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сохранитьъ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.Controls.Add(this.RedColorButton);
            this.ToolsPanel.Controls.Add(this.BlackColorButton);
            this.ToolsPanel.Controls.Add(this.DrawEllipseButton);
            this.ToolsPanel.Controls.Add(this.DrawRectangleButton);
            this.ToolsPanel.Controls.Add(this.DrawLineButton);
            this.ToolsPanel.Location = new System.Drawing.Point(29, 33);
            this.ToolsPanel.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(2975, 156);
            this.ToolsPanel.TabIndex = 2;
            // 
            // RedColorButton
            // 
            this.RedColorButton.BackColor = System.Drawing.Color.Red;
            this.RedColorButton.ForeColor = System.Drawing.Color.Black;
            this.RedColorButton.Location = new System.Drawing.Point(735, 52);
            this.RedColorButton.Name = "RedColorButton";
            this.RedColorButton.Size = new System.Drawing.Size(85, 96);
            this.RedColorButton.TabIndex = 5;
            this.RedColorButton.UseVisualStyleBackColor = false;
            this.RedColorButton.Click += new System.EventHandler(this.OnRedColorButtonClick);
            // 
            // BlackColorButton
            // 
            this.BlackColorButton.BackColor = System.Drawing.SystemColors.WindowText;
            this.BlackColorButton.Location = new System.Drawing.Point(640, 52);
            this.BlackColorButton.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.BlackColorButton.Name = "BlackColorButton";
            this.BlackColorButton.Size = new System.Drawing.Size(85, 96);
            this.BlackColorButton.TabIndex = 5;
            this.BlackColorButton.UseVisualStyleBackColor = false;
            this.BlackColorButton.Click += new System.EventHandler(this.OnBlackColorButtonClick);
            // 
            // DrawEllipseButton
            // 
            this.DrawEllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawEllipseButton.Image")));
            this.DrawEllipseButton.Location = new System.Drawing.Point(481, 52);
            this.DrawEllipseButton.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.DrawEllipseButton.Name = "DrawEllipseButton";
            this.DrawEllipseButton.Size = new System.Drawing.Size(85, 96);
            this.DrawEllipseButton.TabIndex = 5;
            this.DrawEllipseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DrawEllipseButton.UseVisualStyleBackColor = true;
            this.DrawEllipseButton.Click += new System.EventHandler(this.OnDrawEllipseButtonClick);
            // 
            // DrawRectangleButton
            // 
            this.DrawRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawRectangleButton.Image")));
            this.DrawRectangleButton.Location = new System.Drawing.Point(381, 52);
            this.DrawRectangleButton.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.DrawRectangleButton.Name = "DrawRectangleButton";
            this.DrawRectangleButton.Size = new System.Drawing.Size(85, 96);
            this.DrawRectangleButton.TabIndex = 5;
            this.DrawRectangleButton.UseVisualStyleBackColor = true;
            this.DrawRectangleButton.Click += new System.EventHandler(this.OnDrawRectangleButtonClick);
            // 
            // DrawLineButton
            // 
            this.DrawLineButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawLineButton.Image")));
            this.DrawLineButton.Location = new System.Drawing.Point(282, 52);
            this.DrawLineButton.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.DrawLineButton.Name = "DrawLineButton";
            this.DrawLineButton.Size = new System.Drawing.Size(85, 96);
            this.DrawLineButton.TabIndex = 3;
            this.DrawLineButton.UseVisualStyleBackColor = true;
            this.DrawLineButton.Click += new System.EventHandler(this.OnDrawLineButtonClick);
            // 
            // DrawPictureBox
            // 
            this.DrawPictureBox.BackColor = System.Drawing.Color.White;
            this.DrawPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawPictureBox.Location = new System.Drawing.Point(29, 249);
            this.DrawPictureBox.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.DrawPictureBox.Name = "DrawPictureBox";
            this.DrawPictureBox.Size = new System.Drawing.Size(2989, 1645);
            this.DrawPictureBox.TabIndex = 4;
            this.DrawPictureBox.TabStop = false;
            this.DrawPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDrawPictureBoxPaint);
            this.DrawPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnDrawPictureBoxMouseDown);
            this.DrawPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDrawPictureBoxMouseMove);
            this.DrawPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnDrawPictureBoxMouseUp);
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3361, 2108);
            this.Controls.Add(this.DrawPictureBox);
            this.Controls.Add(this.ToolsPanel);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "PaintForm";
            this.Text = "Paint 2.0";
            this.ToolsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DrawPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Panel ToolsPanel;
        private Button DrawLineButton;
        private PictureBox DrawPictureBox;
        private Button DrawRectangleButton;
        private Button DrawEllipseButton;
        private Button BlackColorButton;
        private Button RedColorButton;
    }
}