namespace HotelManagement.Models
{
    public class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
