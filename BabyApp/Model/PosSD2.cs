using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyApp.Models
{
  public class PosSD2
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    public int Id { get; set; }
    public double Weight { get; set; }
    public double Age { get; set; }
  }
}
    