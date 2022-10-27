using System.Drawing.Drawing2D;

namespace PaintExperimental
{
    public partial class PaintForm : Form
    {


        private Point? _startPoint = null;

        private readonly Bitmap image;

        public PaintForm()
        {
            InitializeComponent();

            //Show();

            //var graphics = this.CreateGraphics();

            //Pen pen = new Pen(Color.YellowGreen, 20);

            //graphics.DrawRectangle(pen, 50, 50, 200, 100);

            //graphics.Dispose();

            image = new Bitmap(1000, 1000);
        }


        //// ������ ������� ������ ������ � ������� Graphics

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);

        //    var graphics = e.Graphics;
        //}

        private void OnFormPaint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            Pen pen = new Pen(Color.YellowGreen, 10);
            //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;

            SolidBrush brush = new SolidBrush(Color.DarkRed);

            //// �������� ���������� ����� � ������� ��������
            Image image = new Bitmap(@"D:\WinForms\Homeworks\WF HT6\PaintExperimental\c++logo.png");
            //TextureBrush texture = new TextureBrush(image);

            //// ������� �����
            //HatchBrush hatchBrush = new HatchBrush(HatchStyle.ZigZag, Color.Yellow, Color.Black);

            LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(0, 0, 100, 100), Color.Blue, Color.Red, LinearGradientMode.Horizontal);

            Pen pen1 = new Pen(brush, 10);
            //pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            graphics.FillRectangle(brush, 50, 50, 200, 100);
            graphics.DrawRectangle(pen, 50, 50, 200, 100);

            graphics.DrawRectangle(pen, 300, 50, 200, 100);
            //graphics.FillRectangle(brush, 300, 50, 200, 100);
            //graphics.FillRectangle(texture, 300, 50, 200, 100);
            //graphics.FillRectangle(hatchBrush, 300, 50, 200, 100);
            //graphics.FillRectangle(linear, 300, 50, 200, 100);

            graphics.DrawLine(pen1, 50, 200, 200, 200);
            graphics.DrawLine(pen1, 50, 200, 200, 250);

            graphics.DrawLines(pen1, new Point[] { new Point(50, 300), new Point(100, 350), new Point(75, 400) });

            //graphics.FillEllipse(brush, 50, 450, 200, 100);
            //graphics.DrawEllipse(pen, 50, 450, 200, 100);

            graphics.FillPolygon(brush, new Point[] { new Point(50, 300), new Point(100, 350), new Point(75, 400) });
            graphics.DrawPolygon(pen, new Point[] { new Point(50, 300), new Point(100, 350), new Point(75, 400) });

            graphics.DrawImage(image, 200, 350);

            Font font = new Font("Arial", 14);

            graphics.DrawString("Hello World1", font, brush, 450, 450);
            var size = graphics.MeasureString("Hello World1", font);



            graphics.Dispose();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                _startPoint = e.Location;
            }
        }

        //private void OnPaintFormMouseUp(object sender, MouseEventArgs e)
        //{
        //    if(e.Button == MouseButtons.Left && _startPoint.HasValue && _s)
        //    {
        //        //using (var graphics = CreateGraphics())
        //        using (var graphics = Graphics.FromImage(image))
        //        {
        //            Pen pen1 = new Pen(Color.Black, 5);

        //            graphics.DrawLine(pen1, _startPoint.Value, e.Location);
                   
        //            _startPoint = null;
        //        }
        //    }
        //}

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            image.Save("����������.png");
        }

        private void OnDrawLineButtonClick(object sender, EventArgs e)
        {

        }

        private void OnDrawPaneMouseDown(object sender, MouseEventArgs e)
        {
            // ��������� ����� - ������� ����� (����������, ��� ��������� ����)
            _startPoint = e.Location;

            //// ���� ������ ����� ������ ����
            //if (e.Button == MouseButtons.Left)
            //{

            //}    

        }

        private void OnDrawPanelMouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && _startPoint.HasValue)
            //{
            //    //using (var graphics = CreateGraphics())
            //    using (var graphics = Graphics.FromImage(image))
            //    {
            //        Pen pen1 = new Pen(Color.Black, 5);

            //        graphics.DrawLine(pen1, _startPoint.Value, e.Location);

            //        _startPoint = null;
            //    }
            //}
        }

        private void OnPaintFormMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _startPoint.HasValue)
            {
                //using (var graphics = CreateGraphics())
                using (var graphics = Graphics.FromImage(image))
                {
                    Pen pen1 = new Pen(Color.Black, 5);

                    graphics.DrawLine(pen1, _startPoint.Value, e.Location);

                    _startPoint = null;
                }
            }
        }

        /// <summary>
        /// ���� �� ��������� ����� � ������� ������ ��� ���������?
        /// </summary>
        /// <returns></returns>
        private bool WasStartPointInDrawPanel()
        {
            bool res = _startPoint.Value.X > DrawPanel.Location.X && _startPoint.Value.X < (DrawPanel.Location.X + DrawPanel.Width) 
                && _startPoint.Value.Y > DrawPanel.Location.Y && _startPoint.Value.Y < (DrawPanel.Location.Y + DrawPanel.Height);

            return res;
        }   
    }
}