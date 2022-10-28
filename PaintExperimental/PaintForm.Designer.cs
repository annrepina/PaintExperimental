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
            this.DrawEllipseButton = new System.Windows.Forms.Button();
            this.DrawRectangleButton = new System.Windows.Forms.Button();
            this.DrawLineButton = new System.Windows.Forms.Button();
            this.DrawPictureBox = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ToolsPanel.SuspendLayout();
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
            this.ToolsPanel.Controls.Add(this.DrawEllipseButton);
            this.ToolsPanel.Controls.Add(this.DrawRectangleButton);
            this.ToolsPanel.Controls.Add(this.DrawLineButton);
            this.ToolsPanel.Location = new System.Drawing.Point(12, 12);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(1225, 57);
            this.ToolsPanel.TabIndex = 2;
            // 
            // DrawEllipseButton
            // 
            this.DrawEllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawEllipseButton.Image")));
            this.DrawEllipseButton.Location = new System.Drawing.Point(198, 19);
            this.DrawEllipseButton.Name = "DrawEllipseButton";
            this.DrawEllipseButton.Size = new System.Drawing.Size(35, 35);
            this.DrawEllipseButton.TabIndex = 5;
            this.DrawEllipseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DrawEllipseButton.UseVisualStyleBackColor = true;
            this.DrawEllipseButton.Click += new System.EventHandler(this.OnDrawEllipseButtonClick);
            // 
            // DrawRectangleButton
            // 
            this.DrawRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawRectangleButton.Image")));
            this.DrawRectangleButton.Location = new System.Drawing.Point(157, 19);
            this.DrawRectangleButton.Name = "DrawRectangleButton";
            this.DrawRectangleButton.Size = new System.Drawing.Size(35, 35);
            this.DrawRectangleButton.TabIndex = 5;
            this.DrawRectangleButton.UseVisualStyleBackColor = true;
            this.DrawRectangleButton.Click += new System.EventHandler(this.OnDrawRectangleButtonClick);
            // 
            // DrawLineButton
            // 
            this.DrawLineButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawLineButton.Image")));
            this.DrawLineButton.Location = new System.Drawing.Point(116, 19);
            this.DrawLineButton.Name = "DrawLineButton";
            this.DrawLineButton.Size = new System.Drawing.Size(35, 35);
            this.DrawLineButton.TabIndex = 3;
            this.DrawLineButton.UseVisualStyleBackColor = true;
            this.DrawLineButton.Click += new System.EventHandler(this.OnDrawLineButtonClick);
            // 
            // DrawPictureBox
            // 
            this.DrawPictureBox.BackColor = System.Drawing.Color.White;
            this.DrawPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawPictureBox.Location = new System.Drawing.Point(12, 91);
            this.DrawPictureBox.Name = "DrawPictureBox";
            this.DrawPictureBox.Size = new System.Drawing.Size(1232, 603);
            this.DrawPictureBox.TabIndex = 4;
            this.DrawPictureBox.TabStop = false;
            this.DrawPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDrawPictureBoxPaint);
            this.DrawPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnDrawPictureBoxMouseDown);
            this.DrawPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDrawPictureBoxMouseMove);
            this.DrawPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnDrawPictureBoxMouseUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1281, 322);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 1061);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DrawPictureBox);
            this.Controls.Add(this.ToolsPanel);
            this.Controls.Add(this.button1);
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
        private Button button2;
    }
}