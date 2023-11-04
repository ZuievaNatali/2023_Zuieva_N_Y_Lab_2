using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class Driver
{
    [Required] public int DriverId { get; set; }
    [Required] public int PassportId { get; set; }
    [Required] public int DriverLicenseId { get; set; }
    [Required] public int CarId { get; set; }

}