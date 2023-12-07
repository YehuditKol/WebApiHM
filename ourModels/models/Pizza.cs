namespace ourProject.ourModels.models
{
public class Pizza{
    // [Required]

    // [StringLength(20, MinimumLength = 2)]
    public String? Name { get; set; }
    // [Required]
    public bool Gluten { get; set; }
    // [Required]
    public int Id { get; set; }
   
 
}
}
