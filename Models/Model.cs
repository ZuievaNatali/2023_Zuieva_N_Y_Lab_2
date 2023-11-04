using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class Model
{
    [Required] public int ModelId { get; set; }
    [Required][MaxLength(80)] public string ModelName { get; set; }
    [Required] public int MarkId { get; set; }
}