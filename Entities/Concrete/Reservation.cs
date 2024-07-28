using Core.Entities;

namespace Entities.Concrete;

public class Reservation : Entity<Guid>
{
    public Guid? RoomId { get; set; }
    public Guid? PaymentId { get; set; }
    public DateTime CheckIDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public bool? IsSavedToKBS { get; set; }
    public bool? CheckedIn { get; set; }
    public bool? CheckedOut { get; set; }
    public virtual Payment? Payment { get; set; }
    public virtual Room Room { get; set; }
    public virtual ICollection<ReservationGuest> ReservationGuests { get; set; }

    public Reservation()
    {
        ReservationGuests = new HashSet<ReservationGuest>();
    }
}