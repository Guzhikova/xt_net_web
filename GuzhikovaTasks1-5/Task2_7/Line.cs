using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
    class Line : Geometry
    {

        public Line(Point point1, Point point2)
        {
            _point1 = point1;
            _point2 = point2;

            if (_point1 == _point2)
                throw new ArgumentException("ERROR! Point1 and Point2 mustn't be same");



        }

        private Point _point1, _point2;

        public Point Point1
        {
            get => _point1;
            set
            {
                if (value == Point2)
                    throw new ArgumentException("ERROR! Point1 and Point2 mustn't be same", "Point1");
                _point1 = value;
            }
        }


        public Point Point2 {
            get => _point2;
            set
            {
                if (value == Point1)
                    throw new ArgumentException("ERROR! Point1 and Point2 mustn't be same", "Point2");
                _point2 = value;
            }
        }        
       
        public double Length { get => Math.Sqrt(Math.Pow(Point2.Y - Point1.Y, 2) + Math.Pow(Point2.X - Point1.X, 2)); }

        public override string ToString()
        {
            return String.Format($"ОТРЕЗОК с координатами А ({Point1.X}, {Point1.Y}) и B ({Point2.X}, {Point2.Y})" +
                                $"{Environment.NewLine}Длина отрезка L = {Length.ToString("0.0")}. ");
        }
    }
}
