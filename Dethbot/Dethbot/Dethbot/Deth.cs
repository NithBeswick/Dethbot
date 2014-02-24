using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robocode;

namespace DarkCodex
{
    class Deth : Robot
    {
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
            TurnGunLeft(5);
        }

        //When the robot sees another
        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            Fire(1);
        }
    }
}
