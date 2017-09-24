

using System.Drawing;
using Emgu.CV.Structure;
namespace ImageDetect
{
    public class Robo
    {
        //private Point position;
        private LineSegment2D orientation;
        private string name;

        public Point Position
        {
            get
            {
                return new Point((orientation.P1.X + orientation.P2.X) / 2, (orientation.P1.Y + orientation.P2.Y) / 2);
            }

        }

        public LineSegment2D Orientation
        {
            get
            {
                return orientation;
            }

            set
            {
                orientation = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Robo(LineSegment2D orientation, string name)
        {
            this.orientation = orientation;
            this.name = name;
        }
    }
}
