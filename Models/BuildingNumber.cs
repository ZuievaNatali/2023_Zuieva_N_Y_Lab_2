using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class BuildingNumber
{
    [Required] public int BuildingNumberId { get; set; }
	[Required] public int FlatNumber { get; set; }
	[Required] public int StreetId { get; set; }
}