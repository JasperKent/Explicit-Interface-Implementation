using System;

namespace TurtleLogic
{
    public class Circle : IShape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }
        public void Draw(ITurtle turtle)
        {
            turtle.Up();
            turtle.Move(0.5, 0.5 + _radius);
            turtle.Down();

            for (double theta = 0.0; theta <= 2 * Math.PI; theta += Math.PI / 20)
                turtle.Move(0.5 + _radius * Math.Sin(theta), 0.5 + _radius * Math.Cos(theta));
        }
    }
}
