using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorGrpc.Shared
{

    public partial class WeatherForecast
    {
        public DateTime Date
        {
            get => DateTimeStamp.ToDateTime();
            set { DateTimeStamp = Timestamp.FromDateTime(value.ToUniversalTime()); }
        }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
