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
            this.SaveImageButton = new System.Windows.Forms.Button();
            this.ToolsPanel = new System.Windows.Forms.Panel();
            this.ReDoButton = new System.Windows.Forms.Button();
            this.UnDoActionButton = new System.Windows.Forms.Button();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.WriteTextButton = new System.Windows.Forms.Button();
            this.CurrentBackgroundColorLabel = new System.Windows.Forms.Label();
            this.CurrentBackgroundColorPanel = new System.Windows.Forms.Panel();
            this.ClearPictureBox = new System.Windows.Forms.Button();
            this.CurrentColorLabel = new System.Windows.Forms.Label();
            this.CurrentColorPanel = new System.Windows.Forms.Panel();
            this.ThicknessLabel = new System.Windows.Forms.Label();
            this.ThicknessTrackBar = new System.Windows.Forms.TrackBar();
            this.EraseButton = new System.Windows.Forms.Button();
            this.DrawFilledEllipseButton = new System.Windows.Forms.Button();
            this.DrawFilledRectangleButton = new System.Windows.Forms.Button();
            this.RedColorButton = new System.Windows.Forms.Button();
            this.BlackColorButton = new System.Windows.Forms.Button();
            this.DrawEllipseButton = new System.Windows.Forms.Button();
            this.DrawRectangleButton = new System.Windows.Forms.Button();
            this.DrawLineButton = new System.Windows.Forms.Button();
            this.DrawPictureBox = new System.Windows.Forms.PictureBox();
            this.DrawByPenButton = new System.Windows.Forms.Button();
            this.ToolsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThicknessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveImageButton
            // 
            this.SaveImageButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveImageButton.Image")));
            this.SaveImageButton.Location = new System.Drawing.Point(64, 19);
            this.SaveImageButton.Name = "SaveImageButton";
            this.SaveImageButton.Size = new System.Drawing.Size(35, 35);
            this.SaveImageButton.TabIndex = 0;
            this.SaveImageButton.UseVisualStyleBackColor = true;
            this.SaveImageButton.Click += new System.EventHandler(this.OnSaveImageButtonClick);
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ToolsPanel.Controls.Add(this.DrawByPenButton);
            this.ToolsPanel.Controls.Add(this.ReDoButton);
            this.ToolsPanel.Controls.Add(this.UnDoActionButton);
            this.ToolsPanel.Controls.Add(this.OpenFileButton);
            this.ToolsPanel.Controls.Add(this.TextBox);
            this.ToolsPanel.Controls.Add(this.SaveImageButton);
            this.ToolsPanel.Controls.Add(this.WriteTextButton);
            this.ToolsPanel.Controls.Add(this.CurrentBackgroundColorLabel);
            this.ToolsPanel.Controls.Add(this.CurrentBackgroundColorPanel);
            this.ToolsPanel.Controls.Add(this.ClearPictureBox);
            this.ToolsPanel.Controls.Add(this.CurrentColorLabel);
            this.ToolsPanel.Controls.Add(this.CurrentColorPanel);
            this.ToolsPanel.Controls.Add(this.ThicknessLabel);
            this.ToolsPanel.Controls.Add(this.ThicknessTrackBar);
            this.ToolsPanel.Controls.Add(this.EraseButton);
            this.ToolsPanel.Controls.Add(this.DrawFilledEllipseButton);
            this.ToolsPanel.Controls.Add(this.DrawFilledRectangleButton);
            this.ToolsPanel.Controls.Add(this.RedColorButton);
            this.ToolsPanel.Controls.Add(this.BlackColorButton);
            this.ToolsPanel.Controls.Add(this.DrawEllipseButton);
            this.ToolsPanel.Controls.Add(this.DrawRectangleButton);
            this.ToolsPanel.Controls.Add(this.DrawLineButton);
            this.ToolsPanel.Location = new System.Drawing.Point(12, 12);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(1547, 75);
            this.ToolsPanel.TabIndex = 2;
            // 
            // ReDoButton
            // 
            this.ReDoButton.Image = ((System.Drawing.Image)(resources.GetObject("ReDoButton.Image")));
            this.ReDoButton.Location = new System.Drawing.Point(150, 19);
            this.ReDoButton.Margin = new System.Windows.Forms.Padding(1);
            this.ReDoButton.Name = "ReDoButton";
            this.ReDoButton.Size = new System.Drawing.Size(35, 35);
            this.ReDoButton.TabIndex = 5;
            this.ReDoButton.UseVisualStyleBackColor = true;
            this.ReDoButton.Click += new System.EventHandler(this.OnReDoButtonClick);
            // 
            // UnDoActionButton
            // 
            this.UnDoActionButton.Image = ((System.Drawing.Image)(resources.GetObject("UnDoActionButton.Image")));
            this.UnDoActionButton.Location = new System.Drawing.Point(111, 19);
            this.UnDoActionButton.Margin = new System.Windows.Forms.Padding(1);
            this.UnDoActionButton.Name = "UnDoActionButton";
            this.UnDoActionButton.Size = new System.Drawing.Size(35, 35);
            this.UnDoActionButton.TabIndex = 5;
            this.UnDoActionButton.UseVisualStyleBackColor = true;
            this.UnDoActionButton.Click += new System.EventHandler(this.OnUnDoActionButtonClick);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileButton.Image")));
            this.OpenFileButton.Location = new System.Drawing.Point(25, 19);
            this.OpenFileButton.Margin = new System.Windows.Forms.Padding(1);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(35, 35);
            this.OpenFileButton.TabIndex = 5;
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OnOpenFileButtonClick);
            // 
            // TextBox
            // 
            this.TextBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextBox.Location = new System.Drawing.Point(706, 32);
            this.TextBox.Margin = new System.Windows.Forms.Padding(1);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(190, 27);
            this.TextBox.TabIndex = 11;
            // 
            // WriteTextButton
            // 
            this.WriteTextButton.Image = ((System.Drawing.Image)(resources.GetObject("WriteTextButton.Image")));
            this.WriteTextButton.Location = new System.Drawing.Point(640, 19);
            this.WriteTextButton.Margin = new System.Windows.Forms.Padding(1);
            this.WriteTextButton.Name = "WriteTextButton";
            this.WriteTextButton.Size = new System.Drawing.Size(35, 35);
            this.WriteTextButton.TabIndex = 5;
            this.WriteTextButton.UseVisualStyleBackColor = true;
            this.WriteTextButton.Click += new System.EventHandler(this.OnWriteTextButtonClick);
            // 
            // CurrentBackgroundColorLabel
            // 
            this.CurrentBackgroundColorLabel.AutoSize = true;
            this.CurrentBackgroundColorLabel.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrentBackgroundColorLabel.Location = new System.Drawing.Point(1237, 49);
            this.CurrentBackgroundColorLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.CurrentBackgroundColorLabel.Name = "CurrentBackgroundColorLabel";
            this.CurrentBackgroundColorLabel.Size = new System.Drawing.Size(76, 19);
            this.CurrentBackgroundColorLabel.TabIndex = 10;
            this.CurrentBackgroundColorLabel.Text = "Цвет фона";
            // 
            // CurrentBackgroundColorPanel
            // 
            this.CurrentBackgroundColorPanel.BackColor = System.Drawing.SystemColors.InfoText;
            this.CurrentBackgroundColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CurrentBackgroundColorPanel.Location = new System.Drawing.Point(1258, 14);
            this.CurrentBackgroundColorPanel.Margin = new System.Windows.Forms.Padding(1);
            this.CurrentBackgroundColorPanel.Name = "CurrentBackgroundColorPanel";
            this.CurrentBackgroundColorPanel.Size = new System.Drawing.Size(33, 30);
            this.CurrentBackgroundColorPanel.TabIndex = 9;
            this.CurrentBackgroundColorPanel.Click += new System.EventHandler(this.OnCurrentBackgroundColorPanelClick);
            // 
            // ClearPictureBox
            // 
            this.ClearPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ClearPictureBox.Image")));
            this.ClearPictureBox.Location = new System.Drawing.Point(600, 19);
            this.ClearPictureBox.Margin = new System.Windows.Forms.Padding(1);
            this.ClearPictureBox.Name = "ClearPictureBox";
            this.ClearPictureBox.Size = new System.Drawing.Size(35, 35);
            this.ClearPictureBox.TabIndex = 5;
            this.ClearPictureBox.UseVisualStyleBackColor = true;
            this.ClearPictureBox.Click += new System.EventHandler(this.OnClearPictureBoxClick);
            // 
            // CurrentColorLabel
            // 
            this.CurrentColorLabel.AutoSize = true;
            this.CurrentColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CurrentColorLabel.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrentColorLabel.Location = new System.Drawing.Point(1171, 49);
            this.CurrentColorLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.CurrentColorLabel.Name = "CurrentColorLabel";
            this.CurrentColorLabel.Size = new System.Drawing.Size(53, 21);
            this.CurrentColorLabel.TabIndex = 8;
            this.CurrentColorLabel.Text = "Цвет 1";
            // 
            // CurrentColorPanel
            // 
            this.CurrentColorPanel.BackColor = System.Drawing.SystemColors.InfoText;
            this.CurrentColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CurrentColorPanel.Location = new System.Drawing.Point(1176, 6);
            this.CurrentColorPanel.Margin = new System.Windows.Forms.Padding(1);
            this.CurrentColorPanel.Name = "CurrentColorPanel";
            this.CurrentColorPanel.Size = new System.Drawing.Size(41, 37);
            this.CurrentColorPanel.TabIndex = 7;
            this.CurrentColorPanel.Click += new System.EventHandler(this.OnCurrentColorPanelClick);
            // 
            // ThicknessLabel
            // 
            this.ThicknessLabel.AutoSize = true;
            this.ThicknessLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ThicknessLabel.Location = new System.Drawing.Point(918, 0);
            this.ThicknessLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ThicknessLabel.Name = "ThicknessLabel";
            this.ThicknessLabel.Size = new System.Drawing.Size(74, 21);
            this.ThicknessLabel.TabIndex = 6;
            this.ThicknessLabel.Text = "Толщина";
            // 
            // ThicknessTrackBar
            // 
            this.ThicknessTrackBar.Location = new System.Drawing.Point(902, 27);
            this.ThicknessTrackBar.Margin = new System.Windows.Forms.Padding(1);
            this.ThicknessTrackBar.Name = "ThicknessTrackBar";
            this.ThicknessTrackBar.Size = new System.Drawing.Size(107, 45);
            this.ThicknessTrackBar.TabIndex = 5;
            this.ThicknessTrackBar.Scroll += new System.EventHandler(this.OnThicknessTrackBarScroll);
            // 
            // EraseButton
            // 
            this.EraseButton.Image = ((System.Drawing.Image)(resources.GetObject("EraseButton.Image")));
            this.EraseButton.Location = new System.Drawing.Point(558, 19);
            this.EraseButton.Margin = new System.Windows.Forms.Padding(1);
            this.EraseButton.Name = "EraseButton";
            this.EraseButton.Size = new System.Drawing.Size(35, 35);
            this.EraseButton.TabIndex = 5;
            this.EraseButton.UseVisualStyleBackColor = true;
            this.EraseButton.Click += new System.EventHandler(this.OnEraseButtonClick);
            // 
            // DrawFilledEllipseButton
            // 
            this.DrawFilledEllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawFilledEllipseButton.Image")));
            this.DrawFilledEllipseButton.Location = new System.Drawing.Point(518, 19);
            this.DrawFilledEllipseButton.Margin = new System.Windows.Forms.Padding(1);
            this.DrawFilledEllipseButton.Name = "DrawFilledEllipseButton";
            this.DrawFilledEllipseButton.Size = new System.Drawing.Size(35, 35);
            this.DrawFilledEllipseButton.TabIndex = 5;
            this.DrawFilledEllipseButton.UseVisualStyleBackColor = true;
            this.DrawFilledEllipseButton.Click += new System.EventHandler(this.OnDrawFilledEllipseButtonClick);
            // 
            // DrawFilledRectangleButton
            // 
            this.DrawFilledRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawFilledRectangleButton.Image")));
            this.DrawFilledRectangleButton.Location = new System.Drawing.Point(476, 19);
            this.DrawFilledRectangleButton.Margin = new System.Windows.Forms.Padding(1);
            this.DrawFilledRectangleButton.Name = "DrawFilledRectangleButton";
            this.DrawFilledRectangleButton.Size = new System.Drawing.Size(35, 35);
            this.DrawFilledRectangleButton.TabIndex = 5;
            this.DrawFilledRectangleButton.UseVisualStyleBackColor = true;
            this.DrawFilledRectangleButton.Click += new System.EventHandler(this.OnDrawFilledRectangleButtonClick);
            // 
            // RedColorButton
            // 
            this.RedColorButton.BackColor = System.Drawing.Color.Red;
            this.RedColorButton.ForeColor = System.Drawing.Color.Black;
            this.RedColorButton.Location = new System.Drawing.Point(1439, 19);
            this.RedColorButton.Margin = new System.Windows.Forms.Padding(1);
            this.RedColorButton.Name = "RedColorButton";
            this.RedColorButton.Size = new System.Drawing.Size(35, 35);
            this.RedColorButton.TabIndex = 5;
            this.RedColorButton.UseVisualStyleBackColor = false;
            this.RedColorButton.Click += new System.EventHandler(this.OnRedColorButtonClick);
            // 
            // BlackColorButton
            // 
            this.BlackColorButton.BackColor = System.Drawing.SystemColors.WindowText;
            this.BlackColorButton.Location = new System.Drawing.Point(1400, 19);
            this.BlackColorButton.Name = "BlackColorButton";
            this.BlackColorButton.Size = new System.Drawing.Size(35, 35);
            this.BlackColorButton.TabIndex = 5;
            this.BlackColorButton.UseVisualStyleBackColor = false;
            this.BlackColorButton.Click += new System.EventHandler(this.OnBlackColorButtonClick);
            // 
            // DrawEllipseButton
            // 
            this.DrawEllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawEllipseButton.Image")));
            this.DrawEllipseButton.Location = new System.Drawing.Point(436, 19);
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
            this.DrawRectangleButton.Location = new System.Drawing.Point(395, 19);
            this.DrawRectangleButton.Name = "DrawRectangleButton";
            this.DrawRectangleButton.Size = new System.Drawing.Size(35, 35);
            this.DrawRectangleButton.TabIndex = 5;
            this.DrawRectangleButton.UseVisualStyleBackColor = true;
            this.DrawRectangleButton.Click += new System.EventHandler(this.OnDrawRectangleButtonClick);
            // 
            // DrawLineButton
            // 
            this.DrawLineButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawLineButton.Image")));
            this.DrawLineButton.Location = new System.Drawing.Point(355, 19);
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
            this.DrawPictureBox.Location = new System.Drawing.Point(12, 93);
            this.DrawPictureBox.Name = "DrawPictureBox";
            this.DrawPictureBox.Size = new System.Drawing.Size(1261, 800);
            this.DrawPictureBox.TabIndex = 4;
            this.DrawPictureBox.TabStop = false;
            this.DrawPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDrawPictureBoxPaint);
            this.DrawPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnDrawPictureBoxMouseDown);
            this.DrawPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDrawPictureBoxMouseMove);
            this.DrawPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnDrawPictureBoxMouseUp);
            // 
            // DrawByPenButton
            // 
            this.DrawByPenButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawByPenButton.Image")));
            this.DrawByPenButton.Location = new System.Drawing.Point(314, 19);
            this.DrawByPenButton.Name = "DrawByPenButton";
            this.DrawByPenButton.Size = new System.Drawing.Size(35, 35);
            this.DrawByPenButton.TabIndex = 5;
            this.DrawByPenButton.UseVisualStyleBackColor = true;
            this.DrawByPenButton.Click += new System.EventHandler(this.OnDrawByPenButtonClick);
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1583, 1061);
            this.Controls.Add(this.DrawPictureBox);
            this.Controls.Add(this.ToolsPanel);
            this.Name = "PaintForm";
            this.Text = "Paint 2.0";
            this.ToolsPanel.ResumeLayout(false);
            this.ToolsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThicknessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button SaveImageButton;
        private Panel ToolsPanel;
        private Button DrawLineButton;
        private PictureBox DrawPictureBox;
        private Button DrawRectangleButton;
        private Button DrawEllipseButton;
        private Button BlackColorButton;
        private Button RedColorButton;
        private Button DrawFilledEllipseButton;
        private Button DrawFilledRectangleButton;
        private Button EraseButton;
        private TrackBar ThicknessTrackBar;
        private Label ThicknessLabel;
        private Panel CurrentColorPanel;
        private Label CurrentColorLabel;
        private Button ClearPictureBox;
        private Label CurrentBackgroundColorLabel;
        private Panel CurrentBackgroundColorPanel;
        private Button WriteTextButton;
        private TextBox TextBox;
        private Button OpenFileButton;
        private Button UnDoActionButton;
        private Button ReDoButton;
        private Button DrawByPenButton;
    }
}