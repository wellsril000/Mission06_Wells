using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Wells.Models;

public class NewMovie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; } 
    public Category? Category { get; set; }
    
    [Required]
    public string? title { get; set; }
    
    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set;}
    public string? Director { get; set; }
    
    [Required]
    public string? Rating { get; set; }
    
    [Required]
    public int?Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    [Required(ErrorMessage = "You must make a selection.")]
    public int? CopiedToPlex { get; set; }
    
    [MaxLength(25)]
    public string? Notes { get; set; }
    
}