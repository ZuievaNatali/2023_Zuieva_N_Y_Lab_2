using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class OwnershipType
{
    [Required] public int OwnershipTypeId { get; set; }
    [Required][MaxLength(80)] public string Ownership { get; set; }
}