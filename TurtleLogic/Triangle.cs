using System;

namespace TurtleLogic
{
    public class Triangle : IShape
    {
        private double _base;

        public Triangle(double baseLength)
        {
            _base = baseLength;
        }

        public void Draw(ITurtle turtle)
        {
            double height = Math.Cos(Math.PI / 6) * _base;
            double centre = _base * Math.Tan(Math.PI / 6) / 2;

            turtle.Up();
            turtle.Move(0.5 - _base / 2, 0.5 + centre);
            turtle.Down();
            turtle.Move(0.5 + _base / 2, 0.5 + centre);
            turtle.Move(0.5, 0.5 + centre - height);
            turtle.Move(0.5 - _base / 2, 0.5 + centre);
        }
    }
}
