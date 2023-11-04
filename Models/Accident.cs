using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class Accident
{
    [Required] public int AccidentId { get; set; }
    [Required][MaxLength(80)] public string Description { get; set; }
    public DateTime DateTimeA { get; set; }
    [Required] public int AddressId { get; set; }
    [Required] public int DriverId { get; set; }
    [Required] public int CarId { get; set; }
}