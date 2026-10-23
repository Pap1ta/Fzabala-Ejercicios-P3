using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;

namespace api_gestion_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ILogger<CourseController> _logger;
    private readonly CourseDAO _courseDAO;

    public CourseController(ILogger<CourseController> logger, CourseDAO courseDAO)
    {
        _logger = logger;
        _courseDAO = courseDAO;
    }

    // GET /Course  ->  200 OK con la lista completa
    [HttpGet]
    public ActionResult<List<Course>> GetAll()
    {
        _logger.LogInformation("Consultando todos los registros de Course");
        return Ok(_courseDAO.GetAllCourses());
    }

    // GET /Course/1  ->  200 OK si existe, 404 Not Found si no
    [HttpGet("{id}")]
    public ActionResult<Course> GetById(long id)
    {
        var course = _courseDAO.ReadCourseById(id);
        if (course == null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    // POST /Course  ->  201 Created con el registro creado
    [HttpPost]
    public ActionResult<Course> Create(Course course)
    {
        var created = _courseDAO.CreateCourse(course);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT /Course/1  ->  204 No Content si se actualizó, 400 si los ids no coinciden, 404 si no existe
    [HttpPut("{id}")]
    public IActionResult Update(long id, Course course)
    {
        if (id != course.Id)
        {
            return BadRequest();
        }

        if (!_courseDAO.UpdateCourse(course))
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE /Course/1  ->  204 No Content si se borró, 404 si no existe
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        if (!_courseDAO.DeleteCourseById(id))
        {
            return NotFound();
        }

        return NoContent();
    }
}
