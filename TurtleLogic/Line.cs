using System.Threading.Tasks;

namespace TurtleLogic
{
    public class Line : IShape
    {
        public void Draw(ITurtle turtle)
        {
            turtle.Up();
            turtle.Move(0.2, 0.5);
            turtle.Down();
            turtle.Move(0.8, 0.5);
        }
    }
}
