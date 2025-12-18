using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Valentim.Model;
using RestWithASPNET10Valentim.Services;

namespace RestWithASPNET10Valentim.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private IPersonServices _personService;

    public PersonController(IPersonServices personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var person = _personService.FindById(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        var createdPerson = _personService.Create(person);
        if (createdPerson == null) return NotFound();
        return Ok(createdPerson);
    }

    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
        var createdPerson = _personService.Update(person);
        if (createdPerson == null) return NotFound();
        return Ok(createdPerson);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _personService.Delete(id);
        return NoContent();
    }
}
