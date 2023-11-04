using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class DriverLicense
{
    [Required] public int DriverLicenseId { get; set; }
    [Required][MaxLength(80)] public string LicenseNumber { get; set; }
    [Required][MaxLength(80)] public string DepartmentName { get; set; }
    public DateTime DateOfReceiving { get; set; }
    [Required] public int CategoriesId { get; set; }
}