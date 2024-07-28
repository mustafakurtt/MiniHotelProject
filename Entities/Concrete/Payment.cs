using Core.Entities;
using Entities.Concrete.Enums;

namespace Entities.Concrete;

public class Payment : Entity<Guid>
{
    public Guid ReservationId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public virtual Reservation Reservation { get; set; }
}