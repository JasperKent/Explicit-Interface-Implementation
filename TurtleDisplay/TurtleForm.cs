using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TurtleLogic;

namespace TurtleDisplay
{
    public partial class TurtleForm : Form , ITurtle
    {
        public TurtleForm()
        {
            InitializeComponent();
        }

        private void StaggeredDraw(double x, double y)
        {
            double width = x - _lastPoint.x;
            double height = y - _lastPoint.y;

            const int stepRatio = 30;
            const int stepDelay = 30;

            int steps = (int)(Math.Sqrt(width * width + height * height) * stepRatio);

            if (steps > 0)
            {
                double dx = width / steps;
                double dy = height / steps;

                for (int i = 1; i < steps; ++i)
                {
                    DrawSegment(_lastPoint.x + (i - 1) * dx, _lastPoint.y + (i - 1) * dy, _lastPoint.x + i * dx, _lastPoint.y + i * dy);
                    Thread.Sleep(stepDelay);
                }

                DrawSegment(_lastPoint.x + (steps - 1) * dx, _lastPoint.y + (steps - 1) * dy, x, y);
                Thread.Sleep(stepDelay);
            }
            else
            {
                DrawSegment(_lastPoint.x, _lastPoint.y, x, y);
                Thread.Sleep(stepDelay);
            }
        }

        private void DrawSegment(double x0, double y0, double x1, double y1)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate () { DrawSegment(x0, y0, x1, y1); });
            else
                using (var g = pnlMain.CreateGraphics())
                {
                    g.DrawLine(new Pen(Color.DarkBlue, 2), ToLocal(x0, y0), ToLocal(x1, y1));
                }

            Point ToLocal(double x, double y)
            {
                int dimension = Math.Min(pnlMain.Width, pnlMain.Height);

                return new Point((int)(dimension * x) + (pnlMain.Width - dimension) / 2, (int)(dimension * y) + (pnlMain.Height - dimension) / 2);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var g = pnlMain.CreateGraphics())
            {
                g.Clear(pnlMain.BackColor);
            }
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Line().Draw(this);
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Square(0.3).Draw(this);
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           new Circle(0.3).Draw(this);
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Triangle(0.3).Draw(this);
        }

        public void Up()
        {
            _penDown = false;
        }

        public void Down()
        {
            _penDown = true;
        }

        void ITurtle.Move(double x, double y)
        {
            if (_penDown)
                StaggeredDraw(x, y);

            _lastPoint = (x, y);
        }

        private bool _penDown;
        private (double x, double y) _lastPoint;
    }
}
