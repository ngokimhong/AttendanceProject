using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;
using Contracts;

namespace AttendanceProject.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class WorkShiftsController : ControllerBase
    {
        
        private IRepositoryWrapper _repoWrapper;

        public WorkShiftsController(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapper = repositoryWrapper;
        }

        // GET: api/WorkShifts
        [HttpGet]
        public async Task<ActionResult> GetWorkShifts([FromQuery] WorkShiftParameters workShiftParameters)
        {
            var workShift = await _repoWrapper.WorkShift.GetAllWorkShiftAsync(workShiftParameters);
            return Ok(workShift);
        }

        // GET: api/WorkShifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkShift>> GetWorkShift(Guid id)
        {
            var workShift = await _repoWrapper.WorkShift.GetWorkShiftByIdAsync(id);

            if (workShift == null)
            {
                return NotFound();
            }

            return workShift;
        }

        // PUT: api/WorkShifts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkShift(Guid id, WorkShift workShift)
        {
            if (id != workShift.ShiftId)
            {
                return BadRequest();
            }

            _repoWrapper.WorkShift.Update(workShift);

            try
            {
                await _repoWrapper.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkShiftExists(id))
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

        // POST: api/WorkShifts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WorkShift>> PostWorkShift(WorkShift workShift)
        {
            _repoWrapper.WorkShift.CreateWorkShift(workShift);
            try
            {
                await _repoWrapper.save();
            }
            catch (DbUpdateException)
            {
                if (WorkShiftExists(workShift.ShiftId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWorkShift", new { id = workShift.ShiftId }, workShift);
        }

        // DELETE: api/WorkShifts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkShift>> DeleteWorkShift(Guid id)
        {
            var workShift = await _repoWrapper.WorkShift.GetWorkShiftByIdAsync(id);
            if (workShift == null)
            {
                return NotFound();
            }

            _repoWrapper.WorkShift.DeleteWorkShift(workShift);
            await _repoWrapper.save();

            return workShift;
        }

        private bool WorkShiftExists(Guid id)
        {
            return _repoWrapper.WorkShift.GetWorkShiftByIdAsync(id) != null;
        }
    }
}
