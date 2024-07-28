using Core.Entities;

namespace Entities.Concrete;

public class Guest : Entity<Guid>
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NationalityId { get; set; }
    public string? CountryCode { get; set; }
    public string? PassportNumber { get; set; }
    public virtual ICollection<ReservationGuest> ReservationGuests { get; set; }

    public Guest()
    {
        ReservationGuests = new HashSet<ReservationGuest>();
    }
}