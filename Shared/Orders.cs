using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorGRPC.Shared
{
    public partial class Orders
    {
        public DateTime OrderDate
        {
            get => DateTimeStamp.ToDateTime();
            set { DateTimeStamp=Timestamp.FromDateTime(value.ToUniversalTime()); }
        }
    }
}
