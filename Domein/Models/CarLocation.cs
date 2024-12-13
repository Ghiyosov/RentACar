namespace Domein.Models;

public class CarLocation
{
    public int CarId { get; set; }
    public Car Car { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
}