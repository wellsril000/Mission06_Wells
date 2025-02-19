using System.ComponentModel.DataAnnotations;

namespace Mission06_Wells.Models;

public class NewMovie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [Required]
    public string category { get; set; }
    
    [Required]
    public string title { get; set; }
    
    [Required]
    public string Year { get; set; }
    
    [Required]
    public string Director { get; set; }
    
    [Required]
    public string Rating { get; set; }
    
    public bool? Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    [MaxLength(25)]
    public string? Notes { get; set; }
    
}