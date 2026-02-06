using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clean.CORE.Entities;
using Clean.SERVICE;
using System.Linq;
using System;
using Clean.CORE.Services;
using Clean.CORE.DTO;
using AutoMapper;
using Clean.API.Models;

namespace WebApplication1.Controllers
{


    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

            /// <summary>
            /// שליפת כל העובדים
            /// </summary>
            [HttpGet]
            public async Task<IActionResult> GetAllEmployees()
            {
                return Ok(await _service.GetAllAsync());
            }

            /// <summary>
            /// שליפת עובד לפי מזהה
            /// </summary>
            [HttpGet("{id}")]
            public async Task<IActionResult> GetEmployeeByIdAsync(int id)
            {
                var employee = await _service.GetByIdAsync(id);
                if (employee == null)
                    return NotFound("עובד לא נמצא");

                return Ok(employee);
            }

        /// <summary>
        /// שליפת עובד עם שיוכים
        /// </summary>
        [HttpGet("{id}/assignments")]
        public async Task<IActionResult> GetEmployeeWithAssignmentsAsync(int id)
        {
            var employee = await _service.GetEmployeeWithAssignmentsAsync(id);
            if (employee == null)
                return NotFound("עובד לא נמצא");

            return Ok(employee);
        }

        ///// <summary>
        ///// הוספת שיוך לעובד (שליחת projectId ו-roleInProject בגוף הבקשה)
        ///// </summary>
        //[HttpPost("{employeeId}/assignments")]
        //public IActionResult AddAssignmentToEmployee(int employeeId, [FromBody] ProjectAssignementDto dto)
        //{
        //    _service.AddAssignment();
        //    return NoContent();
        //}

        /// <summary>
        /// הוספת עובד חדש
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(EmployeePost employee)
        {
            var added = await _service.AddAsync(_mapper.Map<Employee>(employee));
            return Ok(added);
        }

        /// <summary>
        /// עדכון עובד קיים
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, EmployeePost updated)
        {
            var employee = await _service.UpdateAsync(id, _mapper.Map<Employee>(updated));
            if (employee == null)
                return NotFound("עובד לא נמצא");

            return Ok(employee);
        }
        /// <summary>
        /// מחיקת עובד לפי מזהה
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound("עובד לא נמצא");

            return Ok($"העובד עם מזהה {id} נמחק בהצלחה");
        }

        /// <summary>
        /// פעולה נוספת: שליפת רשימת העובדים לפי תפקיד
        /// </summary>
        [HttpGet("by-role/{role}")]
        public async Task<IActionResult> GetByRoleAsync(string role)
        {
            var list = await _service.GetByRoleAsync(role);
            return Ok(list);
        }



        //special
        [HttpGet("recommendations/{projectId}")]
        public async Task<IActionResult> GetRecommendationsAsync(int projectId, string requiredRole)
        {
            var result = await _service.GetRecommendedEmployeesAsync(projectId, requiredRole);
            return Ok(result);
        }

    }
    }

