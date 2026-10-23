using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;

namespace api_gestion_api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly StudentDAO _studentDAO;

    public StudentController(ILogger<StudentController> logger, StudentDAO studentDAO)
    {
        _logger = logger;
        _studentDAO = studentDAO;
    }

    // GET /Student  ->  200 OK con la lista completa
    [HttpGet]
    public ActionResult<List<Student>> GetAll()
    {
        _logger.LogInformation("Consultando todos los registros de Student");
        return Ok(_studentDAO.GetAllStudents());
    }

    // GET /Student/1  ->  200 OK si existe, 404 Not Found si no
    [HttpGet("{id}")]
    public ActionResult<Student> GetById(long id)
    {
        var student = _studentDAO.ReadStudentById(id);
        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    // POST /Student  ->  201 Created con el registro creado
    [HttpPost]
    public ActionResult<Student> Create(Student student)
    {
        var created = _studentDAO.CreateStudent(student);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT /Student/1  ->  204 No Content si se actualizó, 400 si los ids no coinciden, 404 si no existe
    [HttpPut("{id}")]
    public IActionResult Update(long id, Student student)
    {
        if (id != student.Id)
        {
            return BadRequest();
        }

        if (!_studentDAO.UpdateStudent(student))
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE /Student/1  ->  204 No Content si se borró, 404 si no existe
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        if (!_studentDAO.DeleteStudentById(id))
        {
            return NotFound();
        }

        return NoContent();
    }
}
