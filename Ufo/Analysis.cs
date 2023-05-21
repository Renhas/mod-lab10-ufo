using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualBasic.Logging;
using ScottPlot;

namespace Ufo
{
    static internal class Analysis
    {
        static readonly double distance = 1e5;
        static public readonly Semaphore semaphore = new Semaphore(0, 1);
        static private int max_acc = 1000;
        static private double step = 1;
        static private int count = 0;
        static public void Analyse()
        { 
            double[] acc = new double[max_acc];
            double[] result = new double[max_acc];
            count = 0;
            for (int i = 0; i < max_acc; i++) 
            {
                acc[i] = i + 1;
                result[i] = AnalyseOne(i + 1);
                count = i + 1;
            }
            
            Draw(acc, result);
            semaphore.Release();
        }

        static private double AnalyseOne(int accuracy) 
        {
            PointD startPoint = new PointD(0, 0);
            PointD endPoint = new PointD(distance / Math.Sqrt(2), distance / Math.Sqrt(2));
            PointD currentPoint = (PointD)startPoint.Clone();

            double x1 = startPoint.X, x2 = endPoint.X;
            double y1 = startPoint.Y, y2 = endPoint.Y;
            double angle = MyMath.Atn(Math.Abs(y2 - y1) / Math.Abs(x2 - x1), accuracy);

            double true_distance = Distance(startPoint, endPoint);
            double current_distance = Distance(startPoint, currentPoint);

            double current_x = currentPoint.X, current_y = currentPoint.Y;
            while (current_distance < true_distance)
            {
                current_x += step * MyMath.Cos(angle, accuracy);
                current_y += step * MyMath.Sin(angle, accuracy);

                currentPoint = new PointD(current_x, current_y);
                current_distance = Distance(startPoint, currentPoint);
            }
            return Distance(currentPoint, endPoint);
        }

        static public double Distance(PointD first, PointD second)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
        }

        static private void Draw(double[] x, double[] y) 
        {
            var plt = new Plot(1920, 1080);
            plt.AddScatter(x, y, markerSize: 0);
            plt.Title("Зависимость отклонения от точности");
            plt.XLabel("Точность");
            plt.YLabel("Отклонение");
            plt.Grid(false);
            plt.SaveFig("dia.png");
        }

        static public float GetProgress() 
        {
            return (float)count / max_acc;
        }
    }
}
