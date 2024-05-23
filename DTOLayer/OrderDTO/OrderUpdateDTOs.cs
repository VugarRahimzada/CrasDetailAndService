namespace DTOLayer.OrderDTO
{
    public class OrderUpdateDTOs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string LicensePlate { get; set; }
        public DateTime Deadline { get; set; } = DateTime.Now.AddMonths(6);
        public int PricingId { get; set; }
    }
}
