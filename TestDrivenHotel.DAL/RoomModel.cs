using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenHotel.DAL
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public string? RoomType { get; set; }
        public bool IsAvailable { get; set; }
    }
}
