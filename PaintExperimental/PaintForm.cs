using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static PaintExperimental.PaintForm;
using static System.Net.Mime.MediaTypeNames;

namespace PaintExperimental
{
    /// <summary>
    /// ������� �����
    /// </summary>
    public partial class PaintForm : Form
    {
        #region �������� � �������

        /// <summary>
        /// ��� �������� PaintAction, ������� ����� ������������ ������� �����������
        /// </summary>
        /// <param name="graphics">�������� � ���� GDI+ ������������</param>
        public delegate void PaintAction(Graphics graphics);

        /// <summary>
        /// �������, ������� ����� ������� ������ �� ���������� ������ ���������
        /// </summary>
        private PaintAction _allActions;

        /// <summary>
        /// ��������� �������� ���������
        /// </summary>
        private PaintAction _lastAction;

        /// <summary>
        /// ��� �������� CurrentPaintAction, ������� ����� ������� ������� �����, ������� ����� ���������� ��� ���������
        /// </summary>
        public delegate void CurrentPaintAction();

        /// <summary>
        /// ������� ��������, ������� ����� �����������
        /// </summary>
        private CurrentPaintAction _currentPaintAction;

        #endregion �������� � �������


        #region ��������� � readonly ����

        /// <summary>
        /// ����������� ��� �������� ��� ����������
        /// </summary>
        private readonly Bitmap _image;

        /// <summary>
        /// ��� ������� ��������
        /// </summary>
        private Stack<PaintAction> _stackOfAllActions;

        /// <summary>
        /// ���������� ��������
        /// </summary>
        private Stack<PaintAction> _canceledActions;

        /// <summary>
        /// ������ ����� ������� �����
        /// </summary>
        private List<Point> _pointsOfBrokenLine;
           
        /// <summary>
        /// ������ ���-�� ��������?
        /// </summary>
        private bool _isDrawing;

        /// <summary>
        /// ������ �������� � ������� ���������? (������� �����)
        /// </summary>
        private bool _isDrawingByPen;

        /// <summary>
        /// ������ ������� �����?
        /// </summary>
        private bool _isTypingText;

        /// <summary>
        /// �������� ��������� ���������
        /// </summary>
        private bool _isActionCompleted;

        /// <summary>
        /// ������� ���� - ���� ���������?
        /// </summary>
        private bool _isColorOfPainting;

        /// <summary>
        /// GDI+ ������������
        /// </summary>
        private Graphics _graphics;

        /// <summary>
        /// ������� ��������
        /// </summary>
        private Pen _pen;

        /// <summary>
        /// ������� ���� ������
        /// </summary>
        private Color _currentColor;

        /// <summary>
        /// ������� ���� ������� �����
        /// </summary>
        private Color _backgroundColor;

        /// <summary>
        /// ������ �����
        /// </summary>
        private float _lineWidth;

        /// <summary>
        /// ��������� ����� - ������� ����
        /// </summary>
        private Point? _startMousePosition;

        /// <summary>
        /// �������� ����� - ������� ����
        /// </summary>
        private Point? _endMousePosition;

        #endregion ��������� � readonly ����


        /// <summary>
        /// ����������� �� ���������
        /// </summary>
        public PaintForm()
        {
            InitializeComponent();

            _graphics = DrawPictureBox.CreateGraphics();

            _currentPaintAction = DrawLines;

            _image = new Bitmap(1000, 1000);

            _currentColor = Color.Black;
            _backgroundColor = Color.White;

            _lineWidth = 1;
            _pen = new Pen(_currentColor, _lineWidth);

            _isDrawing = false;
            _isDrawingByPen = true;
            _isTypingText = false;
            _isColorOfPainting = true;
            _isActionCompleted = false;

            _stackOfAllActions = new Stack<PaintAction>();
            _canceledActions = new Stack<PaintAction>();
            _pointsOfBrokenLine = new List<Point>();

            _startMousePosition = new Point();
            _endMousePosition = new Point();
        }

        #region ����������� ������� �� ������

        /// <summary>
        /// ���������� ������� �� ������ ��������� ������ �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnDrawLineButtonClick(object sender, EventArgs e)
        {
            _currentPaintAction = DrawLine;
            _isDrawingByPen = false;
            _isTypingText = false;
        }

        /// <summary>
        /// ���������� ������� �� ������ ��������� ��������������
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnDrawRectangleButtonClick(object sender, EventArgs e)
        {
            _currentPaintAction = DrawRectangle;
            _isDrawingByPen = false;
            _isTypingText = false;
        }

        /// <summary>
        /// ���������� ������� �� ������ ��������� ������
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnDrawEllipseButtonClick(object sender, EventArgs e)
        {
            _currentPaintAction = DrawEllipse;
            _isDrawingByPen = false;
            _isTypingText = false;
        }

        /// <summary>
        /// ���������� ������� �� ������ ��������� ������ � ��������
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnDrawFilledEllipseButtonClick(object sender, EventArgs e)
        {
            _currentPaintAction = DrawFilledEllipse;
            _isDrawingByPen = false;
            _isTypingText = false;
        }

        /// <summary>
        /// ���������� ������� �� ������ ��������� �������������� � ��������
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnDrawFilledRectangleButtonClick(object sender, EventArgs e)
        {
            _currentPaintAction = DrawFilledRectangle;
            _isDrawingByPen = false;
            _isTypingText = false;
        }

        /// <summary>
        /// ���������� ������� �� ������ ��������� ���������� (������� �����)
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnDrawByPenButtonClick(object sender, EventArgs e)
        {
            _isDrawingByPen = true;
            _isTypingText = false;
            _currentPaintAction = DrawLines;
        }

        /// <summary>
        /// ���������� ������� �� ������ �������
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnEraseButtonClick(object sender, EventArgs e)
        {
            _isDrawingByPen = true;
            _isTypingText = false;
            _currentPaintAction = Erase;
        }

        /// <summary>
        /// ���������� ������� �� ������ �������� ����� �������
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnClearPictureBoxClick(object sender, EventArgs e)
        {
            _allActions = null;
            _lastAction = null;
            _currentPaintAction = null;
            _stackOfAllActions.Clear();
            _canceledActions.Clear();
            
            DrawPictureBox.Image = null;

            _graphics.Clear(Color.White);
        }

        /// <summary>
        /// ���������� ������� �� ������ ��������� ������ �� �������
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnWriteTextButtonClick(object sender, EventArgs e)
        {
            _currentPaintAction = DrawString;
            _isDrawingByPen = false;
            _isTypingText = true;
        }

        /// <summary>
        /// ���������� ������� �� ������ �������� �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnOpenFileButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // ������ ��� �������� ������ ������ ������
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Image image = new Bitmap($@"{openFileDialog.FileName}");

                DrawPictureBox.Image = image;
                DrawPictureBox.Invalidate();
            }
        }

        /// <summary>
        /// ��������� ������� ������ "���������"
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnSaveImageButtonClick(object sender, EventArgs e)
        {
            Rectangle rec = new Rectangle(DrawPictureBox.Location, DrawPictureBox.Size);
            DrawPictureBox.DrawToBitmap(_image, rec);

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // ������ ��� ���������� ������ ������ ������
            saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _image.Save($"{saveFileDialog.FileName}");
            }
        }

        /// <summary>
        /// ���������� ������� �� ������ ������ ���������� ��������
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnUnDoActionButtonClick(object sender, EventArgs e)
        {
            if (_stackOfAllActions.Count > 0)
            {
                var action = _stackOfAllActions.Pop();

                _canceledActions.Push(action);

                _allActions -= action;

                _lastAction -= action;

                DrawPictureBox.Invalidate();
            }
        }

        /// <summary>
        /// ���������� ������� �� ������ ����������� ���������� ��������
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnReDoButtonClick(object sender, EventArgs e)
        {
            if (_canceledActions.Count > 0)
            {
                var action = _canceledActions.Pop();

                AddPaintAction(action);
            }
        }

        /// <summary>
        /// ������� �������������� ����� (����������)
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnChooseOtherColorButtonClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SetColors(colorDialog.Color);
            }
        }

        #endregion ����������� ������� �� ������


        #region ����������� ������ ����� � ������� ������������� � ������

        /// <summary>
        /// ���������� ������� �� ������ � ������� ������
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnCurrentColorPanelClick(object sender, EventArgs e)
        {
            _isColorOfPainting = true;
            CurrentColorLabel.BorderStyle = BorderStyle.Fixed3D;
            CurrentBackgroundColorLabel.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// ���������� ������� �� ������ � ������ ������� ���� �������
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnCurrentBackgroundColorPanelClick(object sender, EventArgs e)
        {
            _isColorOfPainting = false;
            CurrentBackgroundColorLabel.BorderStyle = BorderStyle.Fixed3D;
            CurrentColorLabel.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// ���������� ������� �� ������ ������ ������� �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnBlackColorButtonClick(object sender, EventArgs e)
        {
            SetColors(Color.Black);
        }

        /// <summary>
        /// ���������� ������� �� ������ ������ �������� �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnRedColorButtonClick(object sender, EventArgs e)
        {
            SetColors(Color.Red);
        }

        /// <summary>
        /// ���������� ������� �� ������ ������ ������ �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnGrayColorButtonClick(object sender, EventArgs e)
        {
            SetColors(Color.Gray);
        }

        /// <summary>
        /// ���������� ������� �� ������ ������ ������ �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnWhiteColorButtonClick(object sender, EventArgs e)
        {
            SetColors(Color.White);
        }

        /// <summary>
        /// ���������� ������� �� ������ ������ ���������� �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnOrangeColorButtonClick(object sender, EventArgs e)
        {
            SetColors(Color.Orange);
        }

        /// <summary>
        /// ���������� ������� �� ������ ������ ������� �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnYellowColorButtonClick(object sender, EventArgs e)
        {
            SetColors(Color.Yellow);
        }

        /// <summary>
        /// ���������� ������� �� ������ ������ �������� �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnGreenColorButtonClick(object sender, EventArgs e)
        {
            SetColors(Color.Green);
        }

        /// <summary>
        /// ���������� ������� �� ������ ������ �������� �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void DeepSkyBlueColorButtonClick(object sender, EventArgs e)
        {
            SetColors(Color.DeepSkyBlue);
        }

        /// <summary>
        /// ���������� ������� �� ������ ������ ������ �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnBlueColorButtonClick(object sender, EventArgs e)
        {
            SetColors(Color.Blue);
        }

        /// <summary>
        /// ���������� ������� �� ������ ������ ����������� �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnPurpleColorButtonClick(object sender, EventArgs e)
        {
            SetColors(Color.Purple);
        }

        #endregion ����������� ������ ����� � ������������� � ������


        #region ������, ������� ���������� ��� ���������

        /// <summary>
        /// ���������� ������ � �������
        /// </summary>
        private void DrawString()
        {       
            if(!string.IsNullOrEmpty(TextBox.Text))
            {
                Font font = new Font("Segoe UI", 11);
                Color color = _currentColor;
                Brush brush = new SolidBrush(color);
                PointF startPoint = new Point(_startMousePosition.Value.X, _startMousePosition.Value.Y);

                PaintAction action = (graphics) => { graphics.DrawString(TextBox.Text, font, brush, startPoint); };

                AddPaintAction(action);
            }
        }

        /// <summary>
        /// ���������� ������ �����
        /// </summary>
        private void DrawLine()
        {
            Pen pen = (Pen)_pen.Clone();

            Point? startPoint = new Point(_startMousePosition.Value.X, _startMousePosition.Value.Y);
            Point? endPoint = new Point(_endMousePosition.Value.X, _endMousePosition.Value.Y);

            PaintAction action = (graphics) => { graphics.DrawLine(pen, startPoint.Value, endPoint.Value); };

            AddPaintAction(action);
        }

        /// <summary>
        /// ���������� ��������� ���������� ����� (������)
        /// </summary>
        private void DrawLines()
        {
            Pen pen = _pen.Clone() as Pen;

            Array points = _pointsOfBrokenLine.ToArray();

            PaintAction action = (graphics) => { graphics.DrawLines(pen, points as Point[]); };

            AddPaintAction(action);
        }

        /// <summary>
        /// ������� ��������
        /// </summary>
        private void Erase()
        {
            float width = _lineWidth;

            Pen pen = new Pen(Color.White, width);

            Array points = _pointsOfBrokenLine.ToArray();

            PaintAction action = (graphics) => { graphics.DrawLines(pen, points as Point[]); };

            AddPaintAction(action);
        }

        /// <summary>
        /// ���������� �������������
        /// </summary>
        private void DrawRectangle()
        {
            Pen pen = (Pen)_pen.Clone();

            Rectangle rec = GetRectangle();

            PaintAction action = (graphics) => { graphics.DrawRectangle(pen, rec); };

            AddPaintAction(action);
        }

        /// <summary>
        /// ���������� ������������� � ��������
        /// </summary>
        private void DrawFilledRectangle()
        {
            Brush brush = new SolidBrush(_currentColor);

            Rectangle rec = GetRectangle();

            PaintAction action = (graphics) => { graphics.FillRectangle(brush, rec); };

            AddPaintAction(action);
        }

        /// <summary>
        /// ���������� �����
        /// </summary>
        private void DrawEllipse()
        {
            Pen pen = (Pen)_pen.Clone();

            Rectangle rec = GetRectangle();

            PaintAction action = (graphics) => { graphics.DrawEllipse(pen, rec); };

            AddPaintAction(action);
        }

        /// <summary>
        /// ���������� ����� � ��������
        /// </summary>
        private void DrawFilledEllipse()
        {
            Brush brush = new SolidBrush(_currentColor);

            Rectangle rec = GetRectangle();

            PaintAction action = (graphics) => { graphics.FillEllipse(brush, rec); };

            AddPaintAction(action);
        }

        #endregion ������, ������� ���������� ��� ���������


        #region ����������� �������� ����

        /// <summary>
        /// ���������� ������� ������� ������� ����� �� PictureBox
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnDrawPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _startMousePosition = e.Location;

                if (_isDrawingByPen)
                    _pointsOfBrokenLine.Add(e.Location);

                if (_isTypingText)
                    ClearCancelledActionsStackAndInvokeNewAction();

                _isDrawing = true;
            }
        }

        /// <summary>
        /// ���������� ������� ���������� ������� ����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnDrawPictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _startMousePosition.HasValue)
            {
                _endMousePosition = e.Location;

                _isDrawing = false;

                if (_isDrawingByPen)
                    _pointsOfBrokenLine.Clear();

                DrawPictureBox.Invalidate();

                _isActionCompleted = true;
            }
        }

        /// <summary>
        /// ���������� ������� �������� �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnDrawPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _startMousePosition.HasValue && _isDrawing && !_isTypingText)
            {
                _endMousePosition = e.Location;

                if(_isDrawingByPen)
                {
                    _pointsOfBrokenLine.Add(e.Location);
                }

                if (!_isActionCompleted)
                {
                    _allActions -= _lastAction;

                    if (_stackOfAllActions.Count > 0)
                    {
                        var plug = _stackOfAllActions.Pop();
                    }
                }
                else
                    _isActionCompleted = false;

                ClearCancelledActionsStackAndInvokeNewAction();
            }
        }


        #endregion ����������� �������� ����


        #region ��������������� ������

        /// <summary>
        /// �������� ������������� ������ �� ��������� �����
        /// </summary>
        /// <returns></returns>
        private Rectangle GetRectangle()
        {
            Point? startPoint = new Point(_startMousePosition.Value.X, _startMousePosition.Value.Y);
            Point? endPoint = new Point(_endMousePosition.Value.X, _endMousePosition.Value.Y);

            int left = endPoint.Value.X;
            int right = startPoint.Value.X;
            int top = endPoint.Value.Y;
            int bottom = bottom = startPoint.Value.Y;

            if (endPoint.Value.X > startPoint.Value.X)
            {
                left = startPoint.Value.X;
                right = endPoint.Value.X;
            }

            if (endPoint.Value.Y > startPoint.Value.Y)
            {
                top = startPoint.Value.Y;
                bottom = endPoint.Value.Y;
            }

            Rectangle rec = Rectangle.FromLTRB(left, top, right, bottom);

            return rec;
        }

        /// <summary>
        /// �������� ������ �� ������ � ����������� ��������
        /// </summary>
        /// <param name="paintAction"></param>
        private void AddPaintAction(PaintAction paintAction)
        {
            _allActions += paintAction;
            _lastAction = paintAction;

            _stackOfAllActions.Push(paintAction);

            DrawPictureBox.Invalidate();
        }

        /// <summary>
        /// �������� ���� � ����������� ���������� � ������� ����� ��������
        /// </summary>
        private void ClearCancelledActionsStackAndInvokeNewAction()
        {
            _canceledActions.Clear();

            _currentPaintAction.Invoke();
        }

        /// <summary>
        /// ������ �����
        /// </summary>
        /// <param name="color"></param>
        private void SetColors(Color color)
        {
            if (_isColorOfPainting)
            {
                _currentColor = color;
                _pen.Color = _currentColor;
                CurrentColorPanel.BackColor = _currentColor;
            }

            else
            {
                CurrentBackgroundColorPanel.BackColor = color;
                DrawPictureBox.BackColor = color;
            }
        }

        #endregion ��������������� ������


        #region ������ ����������� 

        /// <summary>
        /// ���������� ������� ������� �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnThicknessTrackBarScroll(object sender, EventArgs e)
        {
            _lineWidth = ThicknessTrackBar.Value;
            _pen.Width = _lineWidth;
        }

        /// <summary>
        /// ���������� ������� ����������� �������� PictureBox
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnDrawPictureBoxPaint(object sender, PaintEventArgs e)
        {
            _allActions?.Invoke(e.Graphics);
        }

        /// <summary>
        /// ���������� ������� �������� �����
        /// </summary>
        /// <param name="sender">������, ��������� �������</param>
        /// <param name="e">�������� ���������� � �������</param>
        private void OnPaintFormClosing(object sender, FormClosingEventArgs e)
        {
            this._graphics.Dispose();
            this._image.Dispose();
        }

        #endregion ������ ����������� 
    }
}