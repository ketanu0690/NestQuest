namespace NestQuestBackEnd.Domain.Models.Dtos
{
    public class HouseSearchParameterDto
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinBedrooms { get; set; }
        public int? MinBathrooms { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public bool? PetFriendly { get; set; }
        public bool? Furnished { get; set; }

    }

}
