using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;

namespace api_gestion_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TrainerController : ControllerBase
{
    private readonly ILogger<TrainerController> _logger;
    private readonly TrainerDAO _trainerDAO;

    public TrainerController(ILogger<TrainerController> logger, TrainerDAO trainerDAO)
    {
        _logger = logger;
        _trainerDAO = trainerDAO;
    }

    // GET /Trainer  ->  200 OK con la lista completa
    [HttpGet]
    public ActionResult<List<Trainer>> GetAll()
    {
        _logger.LogInformation("Consultando todos los registros de Trainer");
        return Ok(_trainerDAO.GetAllTrainers());
    }

    // GET /Trainer/1  ->  200 OK si existe, 404 Not Found si no
    [HttpGet("{id}")]
    public ActionResult<Trainer> GetById(long id)
    {
        var trainer = _trainerDAO.ReadTrainerById(id);
        if (trainer == null)
        {
            return NotFound();
        }

        return Ok(trainer);
    }

    // POST /Trainer  ->  201 Created con el registro creado
    [HttpPost]
    public ActionResult<Trainer> Create(Trainer trainer)
    {
        var created = _trainerDAO.CreateTrainer(trainer);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT /Trainer/1  ->  204 No Content si se actualizó, 400 si los ids no coinciden, 404 si no existe
    [HttpPut("{id}")]
    public IActionResult Update(long id, Trainer trainer)
    {
        if (id != trainer.Id)
        {
            return BadRequest();
        }

        if (!_trainerDAO.UpdateTrainer(trainer))
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE /Trainer/1  ->  204 No Content si se borró, 404 si no existe
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        if (!_trainerDAO.DeleteTrainerById(id))
        {
            return NotFound();
        }

        return NoContent();
    }
}
