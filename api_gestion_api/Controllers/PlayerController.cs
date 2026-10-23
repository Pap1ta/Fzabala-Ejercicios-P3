using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;

namespace api_gestion_api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;
    private readonly PlayerDAO _playerDAO;

    public PlayerController(ILogger<PlayerController> logger, PlayerDAO playerDAO)
    {
        _logger = logger;
        _playerDAO = playerDAO;
    }

    // GET /Player  ->  200 OK con la lista completa
    [HttpGet]
    public ActionResult<List<Player>> GetAll()
    {
        _logger.LogInformation("Consultando todos los registros de Player");
        return Ok(_playerDAO.GetAllPlayers());
    }

    // GET /Player/1  ->  200 OK si existe, 404 Not Found si no
    [HttpGet("{id}")]
    public ActionResult<Player> GetById(long id)
    {
        var player = _playerDAO.ReadPlayerById(id);
        if (player == null)
        {
            return NotFound();
        }

        return Ok(player);
    }

    // POST /Player  ->  201 Created con el registro creado
    [HttpPost]
    public ActionResult<Player> Create(Player player)
    {
        var created = _playerDAO.CreatePlayer(player);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT /Player/1  ->  204 No Content si se actualizó, 400 si los ids no coinciden, 404 si no existe
    [HttpPut("{id}")]
    public IActionResult Update(long id, Player player)
    {
        if (id != player.Id)
        {
            return BadRequest();
        }

        if (!_playerDAO.UpdatePlayer(player))
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE /Player/1  ->  204 No Content si se borró, 404 si no existe
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        if (!_playerDAO.DeletePlayerById(id))
        {
            return NotFound();
        }

        return NoContent();
    }
}
