using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Sensors
{
    class VirtualGpsSensor : GpsSensorInterface
    {
        public void setPosition(int position)
        { }

        public string getPosition()
        {
            Random lastLat = new Random();
            Random lastLon = new Random();

            for (int i = 0; i < 50; i++)
            {
                int lat = lastLat.Next(516400146, 630304598);

                int lon = lastLon.Next(224464416, 341194152);

                SamplePostData d0 = new SamplePostData();
                d0.Location = new Location(Convert.ToDouble("18." + lat), Convert.ToDouble("-72." + lon));
                AddPushpin(d0);

            }
        }

        public string toJson()
        {
            return "{\"position\":\"" + getPosition() + "\"}";
        }
    }
}
