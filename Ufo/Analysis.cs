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
        static public readonly Semaphore semaphore = new Semaphore(0, 1);
        static readonly double distance = 1e5;
        //static readonly double min_distance = 1e-3;
        //static readonly double max_distance = 1;
        static readonly int max_acc = (int)5e2;
        //static readonly int count_of_points = (int)1e2;
        static readonly double step = 1;
        
        static private int count = 0;
        static public void Analyse()
        {
            double[] acc = new double[max_acc];
            double[] result = new double[max_acc];
            double[] x = Linspace(1, 50, 50);
            double[] arctg = new double[50];
            for (int i = 0; i < 50; i++) 
            {
                arctg[i] = MyMath.Atn(Math.Sqrt(3), (int)x[i]);
            }
            Draw(x, arctg);
            return;

            //double[] acc = new double[count_of_points];
            //double[] distances = Linspace(min_distance, max_distance, count_of_points);
            count = 0;
            /*
            foreach (var dist in distances) 
            {
                
                int good_acc = 0;
                int start = 1;
                int end = max_acc;
                int current_acc = (start + end) / 2;
                for (int i = 0; i < Math.Ceiling(Math.Log2(max_acc + 1)); i++)
                {
                    if (IsEnter(current_acc, dist))
                    {
                        good_acc = current_acc;
                        end = current_acc - 1;
                    }
                    else 
                    {
                        start = current_acc + 1;
                    }
                    current_acc = (start + end) / 2;
                }
                acc[count] = good_acc;
                count++;
            }
            Draw(distances, acc);
            */
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
            double distance_to_end = Distance(currentPoint, endPoint);

            double current_x = currentPoint.X, current_y = currentPoint.Y;
            double current_distance = distance_to_end + 1;
            while (current_distance > distance_to_end)
            {
                current_distance = distance_to_end;
                current_x += step * MyMath.Cos(angle, accuracy);
                current_y += step * MyMath.Sin(angle, accuracy);

                currentPoint = new PointD(current_x, current_y);
                distance_to_end = Distance(currentPoint, endPoint);
            }
            return Math.Min(distance_to_end, current_distance);
        }

        static private bool IsEnter(int accuracy, double value) 
        {
            PointD startPoint = new PointD(0, 0);
            PointD endPoint = new PointD(distance / Math.Sqrt(2), distance / Math.Sqrt(2));
            PointD currentPoint = (PointD)startPoint.Clone();

            double x1 = startPoint.X, x2 = endPoint.X;
            double y1 = startPoint.Y, y2 = endPoint.Y;
            double angle = MyMath.Atn(Math.Abs(y2 - y1) / Math.Abs(x2 - x1), accuracy);
            
            double distance_to_end = Distance(currentPoint, endPoint);

            double current_x = currentPoint.X, current_y = currentPoint.Y;
            double current_distance = distance_to_end;
            while (distance_to_end > value)
            {
                current_x += step * MyMath.Cos(angle, accuracy);
                current_y += step * MyMath.Sin(angle, accuracy);

                currentPoint = new PointD(current_x, current_y);
                distance_to_end = Distance(currentPoint, endPoint);

                if (current_distance < distance_to_end) 
                {
                    return false;
                }
                current_distance = distance_to_end;
                
            }
            return true;
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
            //return (float)count / count_of_points;
            return (float)count / max_acc;
        }

        public static double[] Linspace(double start_val, double end_val, int steps)
        {
            double interval = (end_val / Math.Abs(end_val)) * Math.Abs(end_val - start_val) / (steps - 1);
            return (from val in Enumerable.Range(0, steps)
                    select start_val + (val * interval)).ToArray();
        }
    }
}
