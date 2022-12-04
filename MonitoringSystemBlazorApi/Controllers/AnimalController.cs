using Microsoft.AspNetCore.Mvc;
using MonitoringSystemBlazorApi.Models;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            return Ok(_animalRepository.GetAllAnimals());
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            return Ok(_animalRepository.GetAnimalById(id));
        }

        [HttpPost]
        public IActionResult CreateAnimal([FromBody] Animal animal)
        {
            if (animal == null)
                return BadRequest();

            if (animal.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAnimal = _animalRepository.AddAnimal(animal);

            return Created("animal", createdAnimal);
        }

        [HttpPut]
        public IActionResult UpdateAnimal([FromBody] Animal animal)
        {
            if (animal == null)
                return BadRequest();

            if (animal.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var animalToUpdate = _animalRepository.GetAnimalById(animal.Id);

            if (animalToUpdate == null)
                return NotFound();

            _animalRepository.UpdateAnimal(animal);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            if (id == 0)
                return BadRequest();

            var animalToDelete = _animalRepository.GetAnimalById(id);
            if (animalToDelete == null)
                return NotFound();

            _animalRepository.DeleteAnimal(id);

            return NoContent();//success
        }
    }
}

