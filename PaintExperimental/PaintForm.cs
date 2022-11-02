using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static PaintExperimental.PaintForm;
using static System.Net.Mime.MediaTypeNames;

namespace PaintExperimental
{
    public partial class PaintForm : Form
    {
        /// <summary>
        /// Тип делегата PaintAction, который будет обрабатывать события перерисовки
        /// </summary>
        /// <param name="graphics">Включает в себя GDI+ пространство</param>
        public delegate void PaintAction(Graphics graphics);

        /// <summary>
        /// Делегат, который будет хранить ссылки на совокупные методы рисования
        /// </summary>
        private PaintAction _allActions;

        /// <summary>
        /// Последнее действие
        /// </summary>
        private PaintAction _lastAction;

        /// <summary>
        /// Все текущие действия
        /// </summary>
        private Stack<PaintAction> _stackOfAllActions;

        /// <summary>
        /// Отмененные действия
        /// </summary>
        private Stack<PaintAction> _canceledActions;

        ///// <summary>
        ///// Все действия, которые происходили во время одного стирания, то есть все совокупные ссылки на DrawLine
        ///// </summary>
        //private Stack<PaintAction> _oneErasingActions;

        /// <summary>
        /// Список точек ломаной линии
        /// </summary>
        private List<Point> _pointsOfBrokenLine;

        /// <summary>
        /// Тип делегата CurrentPaintAction, который будет хранить текущий метод, который нужно произвести при рисовании
        /// </summary>
        public delegate void CurrentPaintAction();

        /// <summary>
        /// Текущее действие, которое будет произведено
        /// </summary>
        private CurrentPaintAction _currentPaintAction;

        private bool _isDrawing;

        private bool _isDrawingByPen;

        private bool _isTypingText;

        private bool _isActionCompleted;

        /// <summary>
        /// Текущий цвет - цвет рисования?
        /// </summary>
        private bool _isColorOfPainting;

        /// <summary>
        /// GDI+ пространство
        /// </summary>
        public Graphics _graphics;

        /// <summary>
        /// Текущий карандаш
        /// </summary>
        public Pen _pen;

        ///// <summary>
        ///// Кисть для заливки внутри фигур
        ///// </summary>
        //public Brush _brush;

        /// <summary>
        /// Текущий цвет кистей
        /// </summary>
        private Color _currentColor;

        /// <summary>
        /// Текущий цвет заднего плана
        /// </summary>
        private Color _backgroundColor;

        public float _lineWidth;

        /// <summary>
        /// Начальная точка - позиция мыши
        /// </summary>
        private Point? _startMousePosition;

        /// <summary>
        /// Конечная точка - позиция мыши
        /// </summary>
        private Point? _endMousePosition;

        private readonly Bitmap _image;

        private Font fnt = new Font("Arial", 10);

        public PaintForm()
        {
            InitializeComponent();

            //Show();

            _graphics = DrawPictureBox.CreateGraphics();

            _image = new Bitmap(1000, 1000);

            _currentColor = Color.Black;
            _backgroundColor = Color.White;
            _lineWidth = 1;
            _pen = new Pen(_currentColor, _lineWidth);

            _isDrawing = false;
            _isDrawingByPen = false;
            _isTypingText = false;
            _isColorOfPainting = true;
            _isActionCompleted = false;

            _stackOfAllActions = new Stack<PaintAction>();
            _canceledActions = new Stack<PaintAction>();
            //_oneErasingActions = new Stack<PaintAction>();
            _pointsOfBrokenLine = new List<Point>();

            //graphics.Dispose();
        }


        //// Разные способы начала работы с классом Graphics

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);

        //    var graphics = e.Graphics;
        //}

        //private void OnFormPaint(object sender, PaintEventArgs e)
        //{
        //    var graphics = e.Graphics;

        //    Pen pen = new Pen(Color.YellowGreen, 10);
        //    //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        //    //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        //    //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
        //    //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;

        //    SolidBrush brush = new SolidBrush(Color.DarkRed);

        //    //// Создание текстурной кисти с помощью картинки
        //    Image image = new Bitmap(@"D:\WinForms\Homeworks\WF HT6\PaintExperimental\c++logo.png");
        //    //TextureBrush texture = new TextureBrush(image);

        //    //// Узорная кисть
        //    //HatchBrush hatchBrush = new HatchBrush(HatchStyle.ZigZag, Color.Yellow, Color.Black);

        //    LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(0, 0, 100, 100), Color.Blue, Color.Red, LinearGradientMode.Horizontal);

        //    Pen pen1 = new Pen(brush, 10);
        //    //pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

        //    graphics.FillRectangle(brush, 50, 50, 200, 100);
        //    graphics.DrawRectangle(pen, 50, 50, 200, 100);

        //    graphics.DrawRectangle(pen, 300, 50, 200, 100);
        //    //graphics.FillRectangle(brush, 300, 50, 200, 100);
        //    //graphics.FillRectangle(texture, 300, 50, 200, 100);
        //    //graphics.FillRectangle(hatchBrush, 300, 50, 200, 100);
        //    //graphics.FillRectangle(linear, 300, 50, 200, 100);

        //    graphics.DrawLine(pen1, 50, 200, 200, 200);
        //    graphics.DrawLine(pen1, 50, 200, 200, 250);

        //    graphics.DrawLines(pen1, new Point[] { new Point(50, 300), new Point(100, 350), new Point(75, 400) });

        //    //graphics.FillEllipse(brush, 50, 450, 200, 100);
        //    //graphics.DrawEllipse(pen, 50, 450, 200, 100);

        //    graphics.FillPolygon(brush, new Point[] { new Point(50, 300), new Point(100, 350), new Point(75, 400) });
        //    graphics.DrawPolygon(pen, new Point[] { new Point(50, 300), new Point(100, 350), new Point(75, 400) });

        //    graphics.DrawImage(image, 200, 350);

        //    Font font = new Font("Arial", 14);

        //    graphics.DrawString("Hello World1", font, brush, 450, 450);
        //    var size = graphics.MeasureString("Hello World1", font);



        //    graphics.Dispose();
        //}

        private void OnDrawLineButtonClick(object sender, EventArgs e)
        {
            _currentPaintAction = DrawLine;
            _isDrawingByPen = false;
            _isTypingText = false;
        }

        private void OnDrawRectangleButtonClick(object sender, EventArgs e)
        {
            _currentPaintAction = DrawRectangle;
            _isDrawingByPen = false;
            _isTypingText = false;
        }

        private void OnDrawEllipseButtonClick(object sender, EventArgs e)
        {
            _currentPaintAction = DrawEllipse;
            _isDrawingByPen = false;
            _isTypingText = false;
        }

        private void OnDrawFilledEllipseButtonClick(object sender, EventArgs e)
        {
            _currentPaintAction = DrawFilledEllipse;
            _isDrawingByPen = false;
            _isTypingText = false;
        }

        private void OnDrawFilledRectangleButtonClick(object sender, EventArgs e)
        {
            _currentPaintAction = DrawFilledRectangle;
            _isDrawingByPen = false;
            _isTypingText = false;
        }

        private void OnDrawByPenButtonClick(object sender, EventArgs e)
        {
            _isDrawingByPen = true;
            _isTypingText = false;
            _currentPaintAction = DrawLines;
        }

        private void OnEraseButtonClick(object sender, EventArgs e)
        {
            _isDrawingByPen = true;
            _isTypingText = false;
            //_currentPaintAction = DrawLine;
            _currentPaintAction = Erase;
        }

        private void OnClearPictureBoxClick(object sender, EventArgs e)
        {
            _allActions = null;
            _lastAction = null;
            _currentPaintAction = null;
            DrawPictureBox.Image = null;


            _graphics.Clear(Color.White);
        }

        private void OnBlackColorButtonClick(object sender, EventArgs e)
        {
            if (_isColorOfPainting)
            {
                _currentColor = Color.Black;
                _pen.Color = _currentColor;
                CurrentColorPanel.BackColor = _currentColor;
            }

            else
            {
                CurrentBackgroundColorPanel.BackColor = Color.Black;
                DrawPictureBox.BackColor = Color.Black;
            }
        }

        private void OnRedColorButtonClick(object sender, EventArgs e)
        {
            if (_isColorOfPainting)
            {
                _currentColor = Color.Red;
                _pen.Color = _currentColor;
                CurrentColorPanel.BackColor = _currentColor;
            }

            else
            {
                CurrentBackgroundColorPanel.BackColor = Color.Red;
                DrawPictureBox.BackColor = Color.Red;
            }
        }

        private void OnThicknessTrackBarScroll(object sender, EventArgs e)
        {
            _lineWidth = ThicknessTrackBar.Value;
            _pen.Width = _lineWidth;
        }

        private void OnCurrentColorPanelClick(object sender, EventArgs e)
        {
            _isColorOfPainting = true;
            CurrentColorLabel.BorderStyle = BorderStyle.Fixed3D;
            CurrentBackgroundColorLabel.BorderStyle = BorderStyle.None;
        }

        private void OnCurrentBackgroundColorPanelClick(object sender, EventArgs e)
        {
            _isColorOfPainting = false;
            CurrentBackgroundColorLabel.BorderStyle = BorderStyle.Fixed3D;
            CurrentColorLabel.BorderStyle = BorderStyle.None;
        }

        private void OnWriteTextButtonClick(object sender, EventArgs e)
        {
            _currentPaintAction = DrawString;
            _isDrawingByPen = false;
            _isTypingText = true;
        }

        private void OnOpenFileButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // фильтр для открытия только нужных файлов
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Image image = new Bitmap($@"{openFileDialog.FileName}");

                DrawPictureBox.Image = image;
                DrawPictureBox.Invalidate();
            }
        }

        private void OnUnDoActionButtonClick(object sender, EventArgs e)
        {
            if(_stackOfAllActions.Count > 0)
            {
                //var extraAction = _stackOfAllActions.Pop();

                var action = _stackOfAllActions.Pop();

                _canceledActions.Push(action);

                _allActions -= action;

                _lastAction -= action;

                DrawPictureBox.Invalidate();
            }
        }

        private void OnReDoButtonClick(object sender, EventArgs e)
        {
            if(_canceledActions.Count > 0)
            {
                var action = _canceledActions.Pop();

                AddPaintAction(action);
            }
        }

        private void DrawString()
        {       
            if(!string.IsNullOrEmpty(TextBox.Text))
            {
                Font font = new Font("Segoe UI", 11);

                Color color = _currentColor;

                Brush brush = new SolidBrush(color);

                PointF startPoint = new Point(_startMousePosition.Value.X, _startMousePosition.Value.Y);

                PaintAction action = (graphics) => { graphics.DrawString(TextBox.Text, font, brush, startPoint); };

                _stackOfAllActions.Push(action);

                _allActions += action;

                DrawPictureBox.Invalidate();

                //AddPaintAction(action);
            }

            //_graphics.DrawString()

            //    graphics.DrawString("Hello World1", font, brush, 450, 450);
            //    var size = graphics.MeasureString("Hello World1", font);
        }

        private void DrawLine()
        {
            Pen pen = (Pen)_pen.Clone();

            Point? startPoint = new Point(_startMousePosition.Value.X, _startMousePosition.Value.Y);
            Point? endPoint = new Point(_endMousePosition.Value.X, _endMousePosition.Value.Y);

            PaintAction action = (graphics) => { graphics.DrawLine(pen, startPoint.Value, endPoint.Value); };

            AddPaintAction(action);

            //_allActions += action;
            //_lastAction = action;

            //DrawPictureBox.Invalidate();
        }

        private void DrawLines()
        {
            Pen pen = (Pen)_pen.Clone();

            Array points = _pointsOfBrokenLine.ToArray();

            //Point? startPoint = new Point(_startMousePosition.Value.X, _startMousePosition.Value.Y);
            //Point? endPoint = new Point(_endMousePosition.Value.X, _endMousePosition.Value.Y);

            //PaintAction action = (graphics) => { graphics.DrawLine(pen, startPoint.Value, endPoint.Value); };

            PaintAction action = (graphics) => { graphics.DrawLines(pen, points as Point[]); };

            //_graphics.DrawLines()

            AddPaintAction(action);

            //_allActions += action;
            //_lastAction = action;

            //DrawPictureBox.Invalidate();
        }

        private void Erase()
        {
            float width = _lineWidth;

            Pen pen = new Pen(Color.White, width);

            Array points = _pointsOfBrokenLine.ToArray();

            //Point? startPoint = new Point(_startMousePosition.Value.X, _startMousePosition.Value.Y);
            //Point? endPoint = new Point(_endMousePosition.Value.X, _endMousePosition.Value.Y);

            //PaintAction action = (graphics) => { graphics.DrawLine(pen, startPoint.Value, endPoint.Value); };

            PaintAction action = (graphics) => { graphics.DrawLines(pen, points as Point[]); };

            //_graphics.DrawLines()

            AddPaintAction(action);

            //_allActions += action;
            //_lastAction = action;

            //DrawPictureBox.Invalidate();
        }

        private void DrawRectangle()
        {
            Pen pen = (Pen)_pen.Clone();

            Rectangle rec = GetRectangle();

            PaintAction action = (graphics) => { graphics.DrawRectangle(pen, rec); };

            AddPaintAction(action);
        }

        //private void DrawRectangle(PaintAction action)
        //{
        //    Pen pen = (Pen)_pen.Clone();

        //    Rectangle rec = GetRectangle();

        //    //PaintAction action = (graphics) => { graphics.DrawRectangle(pen, rec); };

        //    AddPaintAction(action);
        //}

        private void DrawFilledRectangle()
        {
            Brush brush = new SolidBrush(_currentColor);

            Rectangle rec = GetRectangle();

            PaintAction action = (graphics) => { graphics.FillRectangle(brush, rec); };

            AddPaintAction(action);
        }

        private void DrawEllipse()
        {
            Pen pen = (Pen)_pen.Clone();

            Rectangle rec = GetRectangle();

            PaintAction action = (graphics) => { graphics.DrawEllipse(pen, rec); };

            AddPaintAction(action);
        }

        private void DrawFilledEllipse()
        {
            Brush brush = new SolidBrush(_currentColor);

            Rectangle rec = GetRectangle();

            PaintAction action = (graphics) => { graphics.FillEllipse(brush, rec); };

            AddPaintAction(action);
        }

        /// <summary>
        /// Обработчик события нажатия клавиши мышки на PictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDrawPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_startMousePosition == null)
                    _startMousePosition = new Point();

                _startMousePosition = e.Location;

                if (_isDrawingByPen)
                    _pointsOfBrokenLine.Add(e.Location);

                if (_isTypingText)
                    ClearCancelledActionsStackAndInvokeNewAction();
                    //_currentPaintAction.Invoke();

                _isDrawing = true;
            }
        }

        private void OnDrawPictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _startMousePosition.HasValue)
            {
                if (_endMousePosition == null)
                    _endMousePosition = new Point();

                _endMousePosition = e.Location;

                _isDrawing = false;

                //_currentPaintAction?.Invoke();

                if (_isDrawingByPen)
                    _pointsOfBrokenLine.Clear();

                //_allActions -= _lastAction;

                //if (_stackOfAllActions.Count > 0)
                //{
                //    var plug = _stackOfAllActions.Pop();
                //}

                DrawPictureBox.Invalidate();

                var _all = _stackOfAllActions;

                var cancel = _canceledActions;

                _isActionCompleted = true;




                //if (_endMousePosition == null)
                //    _endMousePosition = new Point();

                //_endMousePosition = e.Location;

                //_isDrawing = false;

                //_currentPaintAction?.Invoke();

                //if (_isErasing)
                //    _pointsOfBrokenLine.Clear();

                //_allActions -= _lastAction;

                //if (_stackOfAllActions.Count > 0)
                //{
                //    var plug = _stackOfAllActions.Pop();
                //}

                //var _all = _stackOfAllActions;

                //var cancel = _canceledActions;
            }
        }

        private void OnDrawPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _startMousePosition.HasValue && _isDrawing && !_isTypingText)
            {
                if (_endMousePosition == null)
                    _endMousePosition = new Point();

                _endMousePosition = e.Location;


                //_currentPaintAction?.Invoke();


                //if (_isErasing == false)
                //{
                //    _allActions -= _lastAction;
                //}
                //else
                //{
                //    _pointsOfBrokenLine.Add(e.Location);
                //}

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
                //_currentPaintAction?.Invoke();
            }
        }

        private void OnDrawPictureBoxPaint(object sender, PaintEventArgs e)
        {
            _allActions?.Invoke(e.Graphics);
        }

        private Rectangle GetRectangle()
        {
            Point? startPoint = new Point(_startMousePosition.Value.X, _startMousePosition.Value.Y);
            Point? endPoint = new Point(_endMousePosition.Value.X, _endMousePosition.Value.Y);

            int left;
            int right;
            int top;
            int bottom;

            if (endPoint.Value.X > startPoint.Value.X)
            {
                left = startPoint.Value.X;
                right = endPoint.Value.X;
            }
            else
            {
                left = endPoint.Value.X;
                right = startPoint.Value.X;
            }

            if (endPoint.Value.Y > startPoint.Value.Y)
            {
                top = startPoint.Value.Y;
                bottom = endPoint.Value.Y;
            }
            else
            {
                top = endPoint.Value.Y;
                bottom = startPoint.Value.Y;
            }

            Rectangle rec = Rectangle.FromLTRB(left, top, right, bottom);

            return rec;
        }

        private void AddPaintAction(PaintAction paintAction)
        {
            _allActions += paintAction;
            _lastAction = paintAction;

            _stackOfAllActions.Push(paintAction);

            DrawPictureBox.Invalidate();
        }

        private void OnSaveImageButtonClick(object sender, EventArgs e)
        {
            Rectangle rec = new Rectangle(DrawPictureBox.Location, DrawPictureBox.Size);
            DrawPictureBox.DrawToBitmap(_image, rec);

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // фильтр для сохранения только нужных файлов
            saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _image.Save($"{saveFileDialog.FileName}");
            }
        }

        private void ClearCancelledActionsStackAndInvokeNewAction()
        {
            _canceledActions.Clear();

            _currentPaintAction.Invoke();
        }
    }
}