using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;

namespace api_gestion_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
    private readonly ILogger<TeamController> _logger;
    private readonly TeamDAO _teamDAO;

    public TeamController(ILogger<TeamController> logger, TeamDAO teamDAO)
    {
        _logger = logger;
        _teamDAO = teamDAO;
    }

    // GET /Team  ->  200 OK con la lista completa
    [HttpGet]
    public ActionResult<List<Team>> GetAll()
    {
        _logger.LogInformation("Consultando todos los registros de Team");
        return Ok(_teamDAO.GetAllTeams());
    }

    // GET /Team/1  ->  200 OK si existe, 404 Not Found si no
    [HttpGet("{id}")]
    public ActionResult<Team> GetById(long id)
    {
        var team = _teamDAO.ReadTeamById(id);
        if (team == null)
        {
            return NotFound();
        }

        return Ok(team);
    }

    // POST /Team  ->  201 Created con el registro creado
    [HttpPost]
    public ActionResult<Team> Create(Team team)
    {
        var created = _teamDAO.CreateTeam(team);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT /Team/1  ->  204 No Content si se actualizó, 400 si los ids no coinciden, 404 si no existe
    [HttpPut("{id}")]
    public IActionResult Update(long id, Team team)
    {
        if (id != team.Id)
        {
            return BadRequest();
        }

        if (!_teamDAO.UpdateTeam(team))
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE /Team/1  ->  204 No Content si se borró, 404 si no existe
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        if (!_teamDAO.DeleteTeamById(id))
        {
            return NotFound();
        }

        return NoContent();
    }
}
