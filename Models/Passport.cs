using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class Passport
{
    [Required] public int PassportId { get; set; }
    [Required][MaxLength(50)] public string FirstName { get; set; }
    [Required][MaxLength(50)] public string MiddleName { get; set; }
    [Required][MaxLength(50)] public string LastName { get; set; }
    [Required][MaxLength(50)] public string Sex { get; set; }
    [Required][MaxLength(50)] public string PassportNumber { get; set; }
    [Required] public int AddressId { get; set; }
    public DateTime BirthDate { get; set; }
}
