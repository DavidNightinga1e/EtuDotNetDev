namespace Client.DTO.Read
{
    public class CarDTO
    {
        public ulong CarId { get; set; }
        public OwnerDTO Owner { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Mileage { get; set; }
    }
}