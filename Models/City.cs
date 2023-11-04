using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class City
{
    [Required] public int CityId { get; set; }
    [Required] public int RegionId { get; set; }
    [Required][MaxLength(60)] string CityName { get; set; }
}