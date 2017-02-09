namespace PetsWonderland.Business.Models.Hotels.Contracts
{
    public interface IHotelLocation
    {
        int Id { get; set; }

        string Address { get; set; }

        bool IsDeleted { get; set; }
    }
}