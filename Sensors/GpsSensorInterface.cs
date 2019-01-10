using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Sensors
{
    interface GpsSensorInterface
    {
        void setPosition(int position);
        int getPosition();
        string toJson();
    }
}
