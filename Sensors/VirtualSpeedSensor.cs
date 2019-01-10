using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Sensors
{
    class VirtualSpeedSensor : SpeedSensorInterface
    {
        public void setSpeed(int speed)
        { }

        public int getSpeed()
        {
            Random random = new Random();
            return new int(random.Next(0, 140));
        }

        public string toJson()
        {
            return "{\"speed\":\"" + getSpeed() + "\"}";
        }
    }
}
