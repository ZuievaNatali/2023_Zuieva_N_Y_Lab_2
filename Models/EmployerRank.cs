using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class EmployerRank
{
    [Required] public int EmployerRankId { get; set; }
    [Required][MaxLength(80)] public string Rank { get; set; }
}