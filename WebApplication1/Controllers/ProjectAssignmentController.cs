using Microsoft.AspNetCore.Mvc;
using Clean.CORE.Entities;
using Clean.CORE.Services;
using System;
using AutoMapper;
using Clean.API.Models;
using Clean.CORE.DTO;

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
        private readonly IMapper _mapper;

        /// <summary>
        /// קונסטרקטור - מקבל את מקור הנתונים דרך Dependency Injection
        /// </summary>
        /// <param name="service">מקור הנתונים המוזרק</param>
        public ProjectAssignmentController(IProjectAssignmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// שליפת כל השיוכים
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAssignments()
        {
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        /// שליפת שיוך בודד לפי מזהה
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignmentById(int id)
        {
            var assignment = await _service.GetByIdAsync(id);
            if (assignment == null)
                return NotFound("שיוך לא נמצא");

            return Ok(assignment);
        }

        /// <summary>
        /// שליפת כל השיוכים של עובד מסוים
        /// </summary>
        [HttpGet("by-employee/{employeeId}")]
        public  async Task<IActionResult> GetAssignmentsByEmployee(int employeeId)
        {
            var list = await _service.GetAssignmentsByEmployeeAsync(employeeId);
            return Ok(list);
        }

        /// <summary>
        /// שליפת כל השיוכים של פרויקט מסוים
        /// </summary>
        [HttpGet("by-project/{projectId}")]
        public async Task<IActionResult> GetAssignmentsByProject(int projectId)
        {
            var list = await _service.GetAssignmentsByProjectAsync(projectId);
            return Ok(list);
        }

        /// <summary>
        /// הוספת שיוך חדש בין עובד לפרויקט
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddAssignment(ProjectAssignmentPost assignment)
        {
            var added = await _service.AddAsync(_mapper.Map<ProjectAssignment>(assignment));
            return Ok(added);
        }

        /// <summary>
        /// עדכון נתוני שיוך קיים
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, ProjectAssignmentPost updated)
        {
            var assignment = await _service.UpdateAsync(id, _mapper.Map<ProjectAssignment>(updated));
            if (assignment == null)
                return NotFound("שיוך לא נמצא");

            return Ok(assignment);
        }

        /// <summary>
        /// מחיקת שיוך
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound("שיוך לא נמצא");

            return Ok("נמחק בהצלחה");
        }
    }
}

