using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Sensors
{
    class VirtualDirectionSensor : DirectionSensorInterface
    {
        public void setDirection(string direction)
        { }

        public string getDirection()
        {
            Random random = new Random();
            return new string(random.Next(0, 140));
        }

        public string toJson()
        {
            return "{\"direction\":\"" + getDirection() + "\"}";
        }
    }
}
