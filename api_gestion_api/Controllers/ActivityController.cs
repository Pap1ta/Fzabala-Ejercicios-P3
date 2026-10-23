using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;

namespace api_gestion_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivityController : ControllerBase
{
    private readonly ILogger<ActivityController> _logger;
    private readonly ActivityDAO _activityDAO;

    public ActivityController(ILogger<ActivityController> logger, ActivityDAO activityDAO)
    {
        _logger = logger;
        _activityDAO = activityDAO;
    }

    // GET /Activity  ->  200 OK con la lista completa
    [HttpGet]
    public ActionResult<List<Activity>> GetAll()
    {
        _logger.LogInformation("Consultando todos los registros de Activity");
        return Ok(_activityDAO.GetAllActivities());
    }

    // GET /Activity/1  ->  200 OK si existe, 404 Not Found si no
    [HttpGet("{id}")]
    public ActionResult<Activity> GetById(long id)
    {
        var activity = _activityDAO.ReadActivityById(id);
        if (activity == null)
        {
            return NotFound();
        }

        return Ok(activity);
    }

    // POST /Activity  ->  201 Created con el registro creado
    [HttpPost]
    public ActionResult<Activity> Create(Activity activity)
    {
        var created = _activityDAO.CreateActivity(activity);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT /Activity/1  ->  204 No Content si se actualizó, 400 si los ids no coinciden, 404 si no existe
    [HttpPut("{id}")]
    public IActionResult Update(long id, Activity activity)
    {
        if (id != activity.Id)
        {
            return BadRequest();
        }

        if (!_activityDAO.UpdateActivity(activity))
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE /Activity/1  ->  204 No Content si se borró, 404 si no existe
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        if (!_activityDAO.DeleteActivityById(id))
        {
            return NotFound();
        }

        return NoContent();
    }
}
