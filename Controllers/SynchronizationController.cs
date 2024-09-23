//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using ProjectManagementAPIB.Services;
//using System;
//using System.Threading.Tasks;

//namespace ProjectManagementAPIB.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class SynchronizationController : ControllerBase
//    {
//        private readonly ISynchronizationService _synchronizationService;
//        private readonly ILogger<SynchronizationController> _logger;

//        public SynchronizationController(ISynchronizationService synchronizationService, ILogger<SynchronizationController> logger)
//        {
//            _synchronizationService = synchronizationService;
//            _logger = logger;
//        }

//        [HttpPost("sync-award-centers")]
//        public async Task<IActionResult> SyncAwardCenters()
//        {
//            try
//            {
//                var result = await _synchronizationService.SynchronizeAwardCenterAsync();
//                _logger.LogInformation($"Synchronization completed. Total records: {result.TotalRecords}, Updated records: {result.UpdatedRecords}");
//                return Ok(new { result.TotalRecords, result.UpdatedRecords, message = "Synchronization completed successfully." });
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Synchronization failed");
//                return StatusCode(500, new { message = "Synchronization failed. Please check the logs for more details." });
//            }
//        }
//    }
//}