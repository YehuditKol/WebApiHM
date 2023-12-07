using Microsoft.AspNetCore.Mvc;
using ourProject.ourModels.Interfaces;
using ourProject.ourModels.models;

namespace ourProject.pizzaProject.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{

    private IPizza _pizzaService;
    public PizzaController(IPizza pizzaService)
    {
        _pizzaService = pizzaService;
        _pizzaService.createDate = DateTime.Now;
        Console.WriteLine(_pizzaService.createDate);
    }

    [HttpGet]
    public List<Pizza> Get()
    {
        return _pizzaService.Get();
    }

    [HttpGet]
    [Route("getName")]
    public IActionResult Getstring(int id)
    {
        var pizzaName = _pizzaService.Getstring(id);
        return pizzaName != null ? Ok(pizzaName) : NotFound();
    }


    [HttpGet("{id}")]
    public ActionResult<Pizza> GetById(int id)
    {
        var pizza = _pizzaService.GetById(id);
        if (pizza == null)
            return NotFound();

        return pizza;
    }


    [HttpPost]
    // [Authorize(Policy = "SuperWorker")]
    public ActionResult Post(Pizza pizza)
    {
        _pizzaService.Add(pizza);
        return Ok();
    }


    [HttpPut("{id}")]

    //  [Authorize(Policy = "SuperWorker")]
    public ActionResult Put(int id, Pizza pizza)
    {
        var isPizzaUpdate = _pizzaService.Update(id, pizza);
        if (isPizzaUpdate)
            return Ok();
        return NotFound();
    }



    [HttpDelete("{id}")]
    //  [Authorize(Policy = "SuperWorker")]
    public ActionResult Delete(int id)
    {
        _pizzaService.Delete(id);
        return Ok();
    }

}