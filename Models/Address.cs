using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class Address
{
    [Required] public int AddressId { get; set; }
    [Required] public int CityId { get; set; }
    [Required] public int StreetId { get; set; }
    [Required] public int BuildingNumberId { get; set; }
}