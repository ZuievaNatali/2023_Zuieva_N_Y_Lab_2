using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class Street
{
    [Required] public int StreetId { get; set; }
    [Required][MaxLength(80)] public string StreetName { get; set; }
    [Required] public int CityId { get; set; }
}