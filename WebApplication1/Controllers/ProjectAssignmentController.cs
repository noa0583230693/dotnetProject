using Microsoft.AspNetCore.Mvc;
using Clean.CORE.Entities;
using Clean.SERVICE;
using System.Linq;
using System.Collections.Generic;
using Clean.CORE.Services;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controller לניהול שיוכים בין עובדים לפרויקטים
    /// משתמש ב-Dependency Injection לקבלת מקור הנתונים
    /// </summary>
    [ApiController]
    [Route("api/assignments")]
    public class ProjectAssignmentController : ControllerBase
    {
        private readonly IProjectAssignmentService _service;

        /// <summary>
        /// קונסטרקטור - מקבל את מקור הנתונים דרך Dependency Injection
        /// </summary>
        /// <param name="service">מקור הנתונים המוזרק</param>
        public ProjectAssignmentController(IProjectAssignmentService service)
        {
            _service = service;
        }

        /// <summary>
        /// שליפת כל השיוכים
        /// </summary>
        [HttpGet]
        public IActionResult GetAllAssignments()
        {
            return Ok(_service.GetAll());
        }

        /// <summary>
        /// שליפת שיוך בודד לפי מזהה
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetAssignmentById(int id)
        {
            var assignment = _service.GetById(id);
            if (assignment == null)
                return NotFound("שיוך לא נמצא");

            return Ok(assignment);
        }

        /// <summary>
        /// הוספת שיוך חדש בין עובד לפרויקט
        /// </summary>
        [HttpPost]
        public IActionResult AddAssignment(ProjectAssignment assignment)
        {
            var added = _service.Add(assignment);
            return Ok(added);
        }

        /// <summary>
        /// עדכון נתוני שיוך קיים
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult UpdateAssignment(int id, ProjectAssignment updated)
        {
            var assignment = _service.Update(id, updated);
            if (assignment == null)
                return NotFound("שיוך לא נמצא");

            return Ok(assignment);
        }

        /// <summary>
        /// מחיקת שיוך
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteAssignment(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound("שיוך לא נמצא");

            return Ok("נמחק בהצלחה");
        }

        /// <summary>
        /// פעולה נוספת: שליפת כל השיוכים של פרויקט מסוים
        /// </summary>
        [HttpGet("by-project/{projectId}")]
        public IActionResult GetAssignmentsByProject(int projectId)
        {
            var list = _service.GetByProject(projectId);
            return Ok(list);
        }
    }
}

