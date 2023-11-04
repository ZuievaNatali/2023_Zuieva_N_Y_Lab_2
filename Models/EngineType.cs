using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class EngineType
{
    [Required] public int EngineTypeId { get; set; }
    [Required][MaxLength(80)] public string EngineTypeName { get; set; }
}

