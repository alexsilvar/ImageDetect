using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDetect
{
    class Strategy
    {
        //Posicao 0 goleiro, 1 zagueiro, 2 atacante
        private Robo[] robot;
        private Point ball;
        private int gameState;
        private Environment env;

        public Robo[] Robot
        {
            get
            {
                return robot;
            }

            set
            {
                robot = value;
            }
        }

        public Strategy(int gameState, Environment envio)
        {
            this.gameState = gameState;
            env = envio;
        }



        public void step()
        {
            atacante();
            zagueiro();
            goleiro();
        }

        private void zagueiro()
        {
            throw new NotImplementedException();
        }

        private void atacante()
        {
            throw new NotImplementedException();
        }

        private void goleiro()
        {
            double velocityLeft = 0, velocityRight = 0;

            double Tx = env.GoalBounds.Right - env.currentBall().X;
            double Ty = env.FieldBounds.Top - env.currentBall().Y;

            double Ax = env.GoalBounds.Right - Robot[0].Position.X;
            double Ay = env.FieldBounds.Top - Robot[0].Position.Y;
        }
    }
}
