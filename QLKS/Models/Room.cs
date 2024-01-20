using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models { 
public class Room : BaseEntity<int> {

    public string RoomName { get; set; }
    public int Floor { get; set; }
    public int RoomTypeId { get; set; }
    public string RoomStatus { get; set; } // Sạch, bẩn, đang dọn, đang kiểm tra
    [ForeignKey(nameof(RoomTypeId))]
    public RoomType RoomType { get; set; }

}
}