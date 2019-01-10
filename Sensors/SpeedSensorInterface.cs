using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Sensors
{
    interface SpeedSensorInterface
    {
        void setSpeed(int speed);
        int getSpeed();
        string toJson();
    }
}
