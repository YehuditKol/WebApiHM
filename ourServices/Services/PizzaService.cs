using ourProject.ourModels.Interfaces;
using ourProject.ourModels.models;

namespace ourProject.ourServices.Services
{
    public class PizzaService : IPizza
    {
        public DateTime createDate { get; set; }
        private static readonly List<Pizza> pizzas = new List<Pizza>()
      {
       new Pizza(){Id = 1, Gluten = true,Name="italky"},
       new Pizza(){Id = 2, Gluten = false,Name="olive"}
      };

        public List<Pizza> Get()
        {
            return pizzas;
        }
        string IPizza.Getstring(int id)
        {
            var existPizza = pizzas.FirstOrDefault(pizza => pizza.Id == id);
            return existPizza != null ? existPizza.Name : string.Empty;

        }

        Pizza IPizza.GetById(int id)
        {
            foreach (var pizza in pizzas)
            {
                if (pizza.Id == id)
                    return pizza;
            }
            return null;
        }

        public void Add(Pizza pizza)
        {
            pizzas.Add(new Pizza() { Gluten = pizza.Gluten, Id = pizza.Id, Name = pizza.Name });
        }

        public bool Update(int id, Pizza pizza)
        {
            var existPizza= pizzas.FirstOrDefault(pizza => pizza.Id == id);
            if(existPizza != null)
            {
                existPizza.Id = pizza.Id;
                existPizza.Name = pizza.Name;
                existPizza.Gluten = pizza.Gluten;
                return true;
            }
            return false;
        }

        void IPizza.Delete(int id)
        {
            var existPizza = pizzas.FirstOrDefault(pizza => pizza.Id == id);
            if (existPizza != null) pizzas.Remove(existPizza);
        }
    }
}
