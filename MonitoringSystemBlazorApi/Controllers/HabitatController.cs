using Microsoft.AspNetCore.Mvc;
using MonitoringSystemBlazorApi.Models;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitatController : Controller
    {
        private readonly IHabitatRepository _habitatRepository;

        public HabitatController(IHabitatRepository habitatRepository)
        {
            _habitatRepository = habitatRepository;
        }

        /// <summary>
        /// Gets all Habitats located in the Data Repository
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllHabitats()
        {
            return Ok(_habitatRepository.GetAllHabitats());
        }

        /// <summary>
        /// Locates an Habitat by Id and returns it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetHabitatById(int id)
        {
            return Ok(_habitatRepository.GetHabitatById(id));
        }

        /// <summary>
        /// Add a new Habitat to the Repository
        /// </summary>
        /// <param name="habitat"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateHabitat([FromBody] Habitat habitat)
        {
            if (habitat == null)
                return BadRequest();

            if (habitat.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdHabitat = _habitatRepository.AddHabitat(habitat);

            return Created("habitat", createdHabitat);
        }

        /// <summary>
        /// Updates the selected Habitat data in the Repository, if it exists
        /// </summary>
        /// <param name="habitat"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateHabitat([FromBody] Habitat habitat)
        {
            if (habitat == null)
                return BadRequest();

            if (habitat.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var habitatToUpdate = _habitatRepository.GetHabitatById(habitat.Id);

            if (habitatToUpdate == null)
                return NotFound();

            _habitatRepository.UpdateHabitat(habitat);

            return NoContent(); //success
        }

        /// <summary>
        /// Locates an Habitat by Id and removes it from the Repository
        /// </summary>
        /// <param name="habitatId"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteHabitat(int id)
        {
            if (id == 0)
                return BadRequest();

            var habitatToDelete = _habitatRepository.GetHabitatById(id);
            if (habitatToDelete == null)
                return NotFound();

            _habitatRepository.DeleteHabitat(id);

            return NoContent();//success
        }
    }
}

