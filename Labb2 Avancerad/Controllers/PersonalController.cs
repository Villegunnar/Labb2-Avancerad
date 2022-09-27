using Labb2_Avancerad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Labb2_Avancerad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : Controller
    {
        private readonly IPersonalRepository _personalRepository;
        public PersonalController(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllPersonal()
        {
            try
            {
                return Ok(_personalRepository.GetAllPersonals.ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPersonalById(int personalId)
        {

            try
            {
                var result = _personalRepository.GetPersonalById(personalId);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddPersonal(Personal personal)
        {
            try
            {
                if (personal == null)
                    return BadRequest();

                var createdPersonal = _personalRepository.AddPersonal(personal);

                return Ok(CreatedAtAction(nameof(GetPersonalById),
                    new { id = createdPersonal.PersonalId }, createdPersonal));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePersonal(int personalId,Personal personal)
        {


            try
            {
                if (personalId != personal.PersonalId)
                    return BadRequest("Employee ID mismatch");

                var personalToUpdate =  _personalRepository.GetPersonalById(personalId);

                if (personalToUpdate == null)
                    return NotFound($"Employee with Id = {personalId} not found");

                _personalRepository.UpdatePersonal(personal);

                return Ok(personalToUpdate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int personalId)
        {
            try
            {
                var personalDelete = _personalRepository.GetPersonalById(personalId);

                if (personalDelete ==  null)
                {
                    return NotFound($"Employee with Id = {personalId} not found");
                }
                _personalRepository.DeletePersonal(personalId);


                return Ok(personalDelete);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting data");
            }

        }
    }
}
