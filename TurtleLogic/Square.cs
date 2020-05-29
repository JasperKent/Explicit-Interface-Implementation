namespace TurtleLogic
{
    public class Square : IShape
    {
        private double _side;

        public Square(double side)
        {
            _side = side;
        }

        public void Draw(ITurtle turtle)
        {
            turtle.Up();
            turtle.Move(0.5 - _side / 2, 0.5 - _side / 2);
            turtle.Down();
            turtle.Move(0.5 - _side / 2, 0.5 + _side / 2);
            turtle.Move(0.5 + _side / 2, 0.5 + _side / 2);
            turtle.Move(0.5 + _side / 2, 0.5 - _side / 2);
            turtle.Move(0.5 - _side / 2, 0.5 - _side / 2);
        }
    }
}
