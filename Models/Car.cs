using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class Car
{
    [Required] public int CarId { get; set; }
    [Required] public int MarkId { get; set; }
    [Required] public int ModelId { get; set; }
    [Required] public int ColorId { get; set; }
    [Required] public int AccountingId { get; set; }
    [Required] public int CarNumberId { get; set; }
    [Required] public int CategoriesId { get; set; }
    [Required] public int BodyTypeId { get; set; }
    [Required] public int EngineTypeId { get; set; }
    [Required] public int OwnershipTypeId { get; set; }
    [Required][MaxLength(80)] public string Sit { get; set; }
}