using Core.Entities;

namespace Entities.Concrete;

public class ReservationGuest : Entity<Guid>
{
    public Guid ReservationId { get; set; }
    public Guid GuestId { get; set; }
    public virtual Reservation Reservation { get; set; }
    public virtual Guest Guest { get; set; }
}