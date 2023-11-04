using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class Employer
{
    [Required] public int EmployerId { get; set; }
    [Required] public int EmployerPositionId { get; set; }
    [Required] public int EmployerRankId { get; set; }
}