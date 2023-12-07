using ourProject.FileService;
using ourProject.ourModels.Interfaces;
using ourProject.ourModels.models;

namespace ourProject.ourServices
{
    public class PizzaService : IPizza
    {
        private Ifile _fileService;

        public DateTime createDate { get; set; }

        //     private static readonly List<Pizza> pizzas = new List<Pizza>()
        //   {
        //    new Pizza(){Id = 1, Gluten = true,Name="italky"},
        //    new Pizza(){Id = 2, Gluten = false,Name="olive"}

        //   };

        //private List<Pizza> pizzas; // This is the backing field
        //private List<Pizza> pizzas
        //{
        //    get { return _fileService.Get<Pizza>(); }
        //    set { this.pizzas = value; }
        //}
        private List<Pizza> pizzas { get; set; }

        public PizzaService(Ifile fileService)
        {
            _fileService = fileService;
            pizzas =  _fileService.Get<Pizza>();
        }
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
            _fileService.AddItem<Pizza>(pizza);
            // pizzas.Add(new Pizza() { Gluten = pizza.Gluten, Id = pizza.Id, Name = pizza.Name });
        }

        public bool Update(int id, Pizza pizza)
        {
            var index = pizzas.FindIndex(pizza => pizza.Id == id);
            if (index != -1)
            {
                pizzas[index].Id = pizza.Id;
                pizzas[index].Name = pizza.Name;
                pizzas[index].Gluten = pizza.Gluten;

                _fileService.Update(pizzas);
                return true;
            }
            return false;
        }

        void IPizza.Delete(int id)
        {
            var existPizza = pizzas.FirstOrDefault(pizza => pizza.Id == id);
            if (existPizza != null) pizzas.Remove(existPizza);
            _fileService.Update(pizzas);
        }
    }
}
