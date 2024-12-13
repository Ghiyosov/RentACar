namespace Domein.Models;

public class Rental
{
    public int RentalId { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalCost { get; set; }
}