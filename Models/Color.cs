using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class Color
{
    [Required] public int ColorId { get; set; }
    [Required][MaxLength(80)] public string ColorType { get; set; }
}