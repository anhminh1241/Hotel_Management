using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    [Table("Booking")]
    public class Booking : BaseEntity<int>
    {   
        public string RoomTypeId { get; set; }
        public string RoomId { get; set; }
        public decimal BookingPrice { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; }
        public string CustomerIdCard { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]   
        public User Customer { get; set; }
        public DateTime BookingTime { get; set; }
        public string Status { get; set; } // Chờ xác nhận, đã xác nhận, đã checkin, đã checkout
    }
}
