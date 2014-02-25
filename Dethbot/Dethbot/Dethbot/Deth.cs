using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robocode;
using System.Drawing;

namespace DarkCodex
{
    class Deth : Robot
    {
        public enum myState { Start, FollowinWall, Panic }
        public myState state = myState.Start;
        private int wantedX = 0;
        private int wantedY = 0;
        private bool invertDir = false;

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

            SetColors(Color.Black, Color.Black, Color.White, Color.Red, Color.Black);

            wantedX = (int)(this.X > (BattleFieldWidth*0.5) ? BattleFieldWidth : 0);
            wantedY = (int)(this.Y > (BattleFieldHeight*0.5) ? BattleFieldHeight : 0);
        }

        // Perform robot logic here calling robot commands etc.
        private void Update()
        {
            if (state == myState.Start)
            {
                if (wantedX == 0)
                {
                    if (this.Heading > 90 && this.Heading <= 270)
                    {
                        TurnRight(270 - this.Heading);
                    }
                    else
                    {
                        TurnLeft(270 - this.Heading);
                    }
                    Ahead(this.X);
                }
                else
                {
                    if (this.Heading >= 90 && this.Heading < 270)
                    {
                        TurnRight(90 - this.Heading);
                    }
                    else
                    {
                        TurnRight(90 - this.Heading);
                    }
                    Ahead(BattleFieldWidth - this.X);
                }                
            } 
            else if (state == myState.FollowinWall)
            {
                TurnRadarRight((Math.Sin(this.Time * 0.1) + 1) * 180);
                //TurnRadarRight(double.PositiveInfinity);
                //TurnGunRight(double.PositiveInfinity);
                Ahead(invertDir?-5000:5000);
            }
            else if (state == myState.Panic)
            {
                state = myState.FollowinWall;
            }
        }

        public override void OnHitWall(HitWallEvent evnt)
        {
            if (state == myState.Start)
            {
                if ((this.Y > BattleFieldHeight * 0.5 && this.X > BattleFieldWidth * 0.5) || (this.Y < BattleFieldHeight * 0.5 && this.X < BattleFieldWidth * 0.5))
                {
                    TurnLeft(90);
                    TurnGunLeft(90);
                }
                else
                {
                    TurnRight(90);
                    TurnGunRight(90);
                }
                

                state = myState.FollowinWall;
            }
            else
            {
                invertDir = !invertDir;
                /*
                if ((this.Y > BattleFieldHeight * 0.5 && this.X > BattleFieldWidth * 0.5) || (this.Y < BattleFieldHeight * 0.5 && this.X < BattleFieldWidth * 0.5))
                    TurnLeft(180);
                else
                    TurnRight(180);
                */
            }
        }

        //When the robot sees another
        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {     
            /*
            double angleToEnemy = Robocode.Util.Utils.ToRadians(GunHeading) + evnt.BearingRadians;
            double radarTurn = Robocode.Util.Utils.NormalRelativeAngle(angleToEnemy - Robocode.Util.Utils.ToRadians(RadarHeading));
            double extraTurn = Math.Min(Math.Atan(36.0 / evnt.Distance), Rules.RADAR_TURN_RATE_RADIANS);

            radarTurn += (radarTurn < 0 ? -extraTurn : extraTurn);
            TurnRadarRight(Robocode.Util.Utils.ToRadians(radarTurn));
            */

            /*
            if (GunHeading < RadarHeading)
            {
                double diff = RadarHeading - GunHeading;
                TurnGunRight(diff);
                TurnRadarLeft(diff);
            }
            else
            {
                double diff = GunHeading - RadarHeading;
                TurnGunLeft(diff);
                TurnRadarRight(diff);
            }
            */
            System.Pr
            Fire(0.1);                         
        }

        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            state = myState.Panic;
        }

    }
}
