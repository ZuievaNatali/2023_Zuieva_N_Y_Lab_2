using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class CarByDriver
{
    [Required] public int CarByDriverId { get; set; }
    [Required] public int DriverId { get; set; }
    [Required] public int CarId { get; set; }
}