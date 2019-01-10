using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Sensors
{
    interface DirectionSensorInterface
    {
        void setDirection(string direction);
        string getDirection();
        string toJson();
    }
}
