using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class EmployerPosition
{
    [Required] public int EmployerPositionId { get; set; }
    [Required][MaxLength(80)] public string Position { get; set; }
}