using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPIB.Services;
using System;

namespace ProjectManagementAPIB.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class SynchronizationController : ControllerBase
    {
        private readonly ISynchronizationService _synchronizationService;

        public SynchronizationController(ISynchronizationService synchronizationService)
        {
            _synchronizationService = synchronizationService;
        }

        [HttpPost("sync-award-centers")]
        public async Task<IActionResult> SyncAwardCenters()
        {
            try
            {
                var result = await _synchronizationService.SynchronizeAwardCenterAsync();
                return Ok(new { result.TotalRecords, result.UpdatedRecords, message = "Synchronization completed successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Synchronization failed. Please try again." });
            }
        }
    }
}
