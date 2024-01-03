using System.ComponentModel.DataAnnotations;

namespace ourProject.ourModels.models
{
public class Pizza{
    [Required]

    [StringLength(20, MinimumLength =2)]
    [RegularExpression(@"[^\d]+$")]
    public String Name { get; set; }
    
    [Required]
    public bool Gluten { get; set; }

    [RegularExpression(@"[\d]+$")]
    public int Id { get; set; }
   
 
}
}
