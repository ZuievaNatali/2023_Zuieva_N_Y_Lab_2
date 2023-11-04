using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class Accounting
{
    [Required] public int AccountingId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}