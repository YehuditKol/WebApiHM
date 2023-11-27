using ourProject.ourModels.Interfaces;
using ourProject.ourModels.models;

namespace ourProject.ourServices.Services
{
    public class Pizza2Service : IPizza
    {
        public DateTime createDate { get; set; }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> Get()
        {
            throw new NotImplementedException();
        }

        public Pizza GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string Getstring(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Pizza pizza)
        {
            throw new NotImplementedException();
        }

        bool IPizza.Update(int id, Pizza pizza)
        {
            throw new NotImplementedException();
        }
    }
}
