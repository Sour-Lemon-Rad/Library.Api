using Library.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private static readonly List<Author> _authors = new List<Author> //list na simulaci dat, později bude DB
        {
            new Author { Id = 1, FirstName = "Karel", LastName="Čapek", BirthYear = 1890},
            new Author { Id = 2, FirstName = "Božena", LastName="Němcová", BirthYear = 1820}
        };

        [HttpGet]
        public ActionResult<List<Author>> GetAll()
        {
            //Actionresult protože nevime zda se vysledek povede, muze byt ok (200) nebo nejaka chyba třeba not found (404)
            return Ok(_authors);// vysledek se musi zabalit do spravneho resultu v tomto pripade Ok
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetById(int id)
            {
                foreach (var a in _authors)
                {
                    if (a.Id == id)
                    {
                       return Ok(a); //povedlo se najit, vratim 200
                    }
                    
                }
            return NotFound(); //404
        }
        
    }
}
