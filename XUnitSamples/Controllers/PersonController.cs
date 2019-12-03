using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using XUnitSamples.Core.Interfaces;
using XUnitSamples.Models;

namespace XUnitSamples.Controllers
{
[Route("api/[controller]")]
[ApiController()]
public class PersonController : Controller
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }
    // GET: api/Person
    [HttpGet]
    public IActionResult GetPersons()
    {
        return Ok(_personService.AllPersons());
    }

    // GET: api/Person/5
    [HttpGet("{id}")]
    public ActionResult<PersonModel> GetPerson(int id)
    {
        var person = _personService.FindPerson(id);

        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }
}
}
