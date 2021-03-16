using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Contracts;

namespace AttendanceProject.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public AttendancesController( IRepositoryWrapper repositoryWrapper)

        {
            _repoWrapper = repositoryWrapper;
        }

        // GET: api/Attendances
        [HttpGet]
        public async Task<IActionResult> GetAttendances([FromQuery] AttendanceParameters attendanceParameters)
        {
            var attendances =  await _repoWrapper.Attendance.GetAllAttendanceAsync(attendanceParameters);

            return Ok(attendances);
            
        }

        // GET: api/Attendances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendance(Guid id)
        {
            var attendance = await _repoWrapper.Attendance.GetAttendanceByIdAsync(id);

            if (attendance == null)
            {
                return NotFound();
            }

            return Ok(attendance);
           
        }

        // PUT: api/Attendances/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendance(Guid id, Attendance attendance)
        {
            if (id != attendance.AttendanceId)
            {
                return BadRequest();
            }

            _repoWrapper.Attendance.UpdateAttendance(attendance);

            try
            {
                await _repoWrapper.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Attendances
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Attendance>> PostAttendance(Attendance attendance)
        {
            _repoWrapper.Attendance.CreateAttendance(attendance);
            try
            {
                await _repoWrapper.save();
            }
            catch (DbUpdateException)
            {
                if (AttendanceExists(attendance.AttendanceId))
                {
                 
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAttendance", new { id = attendance.AttendanceId }, attendance);
        }

        // DELETE: api/Attendances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Attendance>> DeleteAttendance(Guid id)
        {
            var attendance = await _repoWrapper.Attendance.GetAttendanceByIdAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }

            _repoWrapper.Attendance.Delete(attendance);
            await _repoWrapper.save();

            return attendance;
        }

        private bool AttendanceExists(Guid id)
        {
            return _repoWrapper.Attendance.GetAttendanceByIdAsync(id) != null;
        }
    }
}
