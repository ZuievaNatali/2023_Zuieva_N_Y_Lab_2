using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class Categories
{ 
    [Required] public int CategoriesId { get; set; }
    [Required][MaxLength(80)] public string CategoriesType { get; set; }
}