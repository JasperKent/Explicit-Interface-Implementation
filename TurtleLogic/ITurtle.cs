using System.Threading.Tasks;

namespace TurtleLogic
{
    public interface ITurtle 
    {
        void Up();
        void Down();
        void Move(double x, double y);
    }
}
