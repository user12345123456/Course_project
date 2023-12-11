namespace ZakazObedov1.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DeliveryAddress { get; set; }
        public string PhoneNumber { get; set; }
        public List<Order>? Orders { get; set; }
    }
}