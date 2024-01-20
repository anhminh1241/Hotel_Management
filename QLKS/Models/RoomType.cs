namespace HotelManagement.Models
{
    public class RoomType : BaseEntity<int>
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public string RoomTypeName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Area { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
