using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class Mark
{
    [Required] public int MarkId { get; set; }
    [Required][MaxLength(80)] public string MarkType { get; set; }
}