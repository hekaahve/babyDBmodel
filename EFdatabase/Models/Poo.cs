using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFdatabase.Models
{
  public class Poo
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public string Color { get; set; }   
    public string Quality { get; set; }
    public string Delivery {get; set;}
  }
}