using ourProject.ourModels.models;

namespace ourProject.ourModels.Interfaces
{ 
public interface IPizza
{
    public DateTime createDate { get; set; }
    public List<Pizza> Get();
      public string Getstring(int id);
      public Pizza GetById(int id);
      public void Add(Pizza pizza);
      public bool Update(int id, Pizza pizza);
      public void Delete(int id);    
}
}
    

    