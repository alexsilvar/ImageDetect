using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDetect
{
    class Environment
    {
        private Point _currentBall, _lastBall, _predictBall;//Bolas e predicts
        private Rectangle _fieldBounds;
        private Rectangle _goalBounds;
        private Rectangle _opponetGoalBounds;//Areas onde os robôs devem ficar e fazer gol


        public Environment(Rectangle field, Rectangle goal, Rectangle opponentGoal)
        {
            FieldBounds = field;
            GoalBounds = goal;
            OpponetGoalBounds = opponentGoal;

            _currentBall = Point.Empty;
            _lastBall = Point.Empty;
        }

        public Rectangle FieldBounds
        {
            get
            {
                return _fieldBounds;
            }

            set
            {
                _fieldBounds = value;
            }
        }

        public Rectangle GoalBounds
        {
            get
            {
                return _goalBounds;
            }

            set
            {
                _goalBounds = value;
            }
        }

        public Rectangle OpponetGoalBounds
        {
            get
            {
                return _opponetGoalBounds;
            }

            set
            {
                _opponetGoalBounds = value;
            }
        }

        public Point predictBall()
        {
            //Predict simples, pega a ultima posição e testa a variação em X e Y, para imaginar o próximo estado
            int dx = _currentBall.X - _lastBall.X;
            int dy = _currentBall.Y - _lastBall.Y;
            _predictBall = new Point(_currentBall.X + dx, _currentBall.Y + dy);
            return _predictBall;
        }
        public Point currentBall()
        {
            return _currentBall;
        }
        public void newBall(Point ball)
        {
            _lastBall = _currentBall;
            _currentBall = ball;
        }
    }
}
