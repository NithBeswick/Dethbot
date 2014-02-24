using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robocode;

namespace DarkCodex
{
    class Deth : Robot
    {
        private int panic = 0;

        public override void Run()
        {
            Start();

            while (true)
            {
                Update();
            }
        }

        // Perform your initialization for your robot here
        private void Start() {

        }

        // Perform robot logic here calling robot commands etc.
        private void Update()
        {
            if (panic == 0)
            {
                TurnGunLeft(5);
            }
            else
            {
                TurnGunLeft(20);
                panic--;
            }
        }

        //When the robot sees another
        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            Fire(1);
            Fire(1);
            Fire(1);
            Fire(10);
        }

        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            panic = 20;
        }
    }
}
