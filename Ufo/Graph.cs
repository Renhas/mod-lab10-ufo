using System.Windows.Forms;
using System;
using System.Drawing;
using System.Data;
using System.Reflection.Metadata;
using System.Threading;
using System.Drawing.Design;

namespace Ufo
{
    public partial class Graph : Form
    {
        PointF startPoint = new PointF(float.NegativeInfinity, float.NegativeInfinity);
        PointF endPoint = new PointF(float.NegativeInfinity, float.NegativeInfinity);
        PointF currentPoint = new PointF(float.NegativeInfinity, float.NegativeInfinity);
        bool isTimerAlive = false;
        float scale = 0.5f;
        double angle = double.NegativeInfinity;

        public Graph()
        {
            InitializeComponent();
            EnableElements(true);
            timerDraw.Interval = (int)Math.Ceiling(10 * scale);
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            if (startPoint.X == float.NegativeInfinity) return;

            var g = e.Graphics;
            g.ScaleTransform(scale, scale);

            float point_size = 1/scale * 5;
            float x1 = startPoint.X, x2 = endPoint.X;
            float y1 = startPoint.Y, y2 = endPoint.Y;
            float step = (float)numericStep.Value;
            int accuracy = (int)numericAcc.Value;
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x1 - point_size, y1 - point_size, point_size, point_size);
            if (x2 == float.NegativeInfinity) return;
            g.FillEllipse(brush, x2 - point_size, y2 - point_size, point_size, point_size);
            if (angle == double.NegativeInfinity) 
            {
                angle = MyMath.Atn(Math.Abs(y2 - y1) / Math.Abs(x2 - x1), accuracy);
            }
            double true_distance = Distance(startPoint, endPoint);
            double current_distance = Distance(startPoint, currentPoint);

            float current_x = currentPoint.X, current_y = currentPoint.Y;
            if (current_distance < true_distance) 
            {
                current_x += step * (float)MyMath.Cos(angle, accuracy);
                current_y -= step * (float)MyMath.Sin(angle, accuracy);

                currentPoint = new PointF(current_x, current_y);
            }
            g.FillEllipse(brush, current_x - point_size, current_y - point_size, point_size, point_size);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (isTimerAlive) return;
            startPoint = new PointF(1 / scale * 10, mainPanel.Height * 1/scale - 1/scale * 10);
            currentPoint = startPoint;
            endPoint = new PointF(mainPanel.Width * 1/scale - 1/scale * 10, 1/scale * 10);

            isTimerAlive = true;
            timerDraw.Start();
            EnableElements(false);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (isTimerAlive) timerDraw.Stop();
            else timerDraw.Start();
            isTimerAlive = !isTimerAlive;

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            timerDraw.Stop();
            isTimerAlive = false;
            startPoint = new PointF(float.NegativeInfinity, float.NegativeInfinity);
            endPoint = new PointF(float.NegativeInfinity, float.NegativeInfinity);
            angle = double.NegativeInfinity;
            Clear();
            
            EnableElements(true);
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            mainPanel.Invalidate();
        }

        private void Clear() 
        {
            mainPanel.CreateGraphics().Clear(mainPanel.BackColor);
        }

        private void EnableElements(bool value)
        {
            pauseButton.Enabled = !value;
            numericAcc.Enabled = value;
            numericStep.Enabled = value;
        }

        public double Distance(PointF first, PointF second)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
        }

        private void researchButton_Click(object sender, EventArgs e)
        {
            var thrd = new Thread(Research);
            thrd.Name = "Research";
            thrd.Start();
        }

        private void Research() 
        {
            researchButton.BeginInvoke(() => researchButton.Enabled = false);
            progressBar.BeginInvoke(() => progressBar.Visible = true);
            var thrd = new Thread(Analysis.Analyse);
            thrd.Name = "Analysis";
            thrd.Start();
            Thread.Sleep(1000);
            while (Analysis.GetProgress() < 1)
            {
                progressBar.BeginInvoke(() => progressBar.Value = (int)(Analysis.GetProgress() * 100));
                Thread.Sleep(100);

            }
            Analysis.semaphore.WaitOne();
            researchButton.BeginInvoke(() => researchButton.Enabled = true);
            progressBar.BeginInvoke(() => progressBar.Visible = false);
        }
    }
}