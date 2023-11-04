using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class CarNumber
{
    [Required] public int CarNumberId { get; set; }
    [Required][MaxLength(80)] public string CarNum { get; set; }
}