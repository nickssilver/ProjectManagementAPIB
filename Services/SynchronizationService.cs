//using Microsoft.EntityFrameworkCore;
//using ProjectManagementAPIB.Data;
//using ProjectManagementAPIB.Models;
//using System.Threading.Tasks;
//using System.Linq;

//namespace ProjectManagementAPIB.Services
//{
//    public interface ISynchronizationService
//    {
//        Task<SynchronizationResult> SynchronizeAwardCenterAsync();
//    }

//    public class SynchronizationService : ISynchronizationService
//    {
//        private readonly ProjectManagementContext _context;

//        public SynchronizationService(ProjectManagementContext context)
//        {
//            _context = context;
//        }

//        public async Task<SynchronizationResult> SynchronizeAwardCenterAsync()
//        {
//            int totalRecords = 0;
//            int updatedRecords = 0;

//            // Get all Award Centers
//            var awardCenters = await _context.AwardCenters.ToListAsync();
//            totalRecords = awardCenters.Count;

//            // Get all stages, statuses, and types
//            var stages = await _context.AwardCenterStages.ToListAsync();
//            var statuses = await _context.AwardCenterStatus.ToListAsync();
//            var types = await _context.AwardCTypes.ToListAsync();

//            foreach (var awardCenter in awardCenters)
//            {
//                bool updated = false;

//                // Check and update StageID
//                var currentStage = stages.FirstOrDefault(s => s.StageID == awardCenter.StageID);
//                if (currentStage == null)
//                {
//                    var newStage = stages.FirstOrDefault(s => s.StageName == awardCenter.StageID);
//                    if (newStage != null)
//                    {
//                        awardCenter.StageID = newStage.StageID;
//                        updated = true;
//                    }
//                }

//                // Check and update StatusID
//                var currentStatus = statuses.FirstOrDefault(s => s.StatusID == awardCenter.StatusID);
//                if (currentStatus == null)
//                {
//                    var newStatus = statuses.FirstOrDefault(s => s.StatusName == awardCenter.StatusID);
//                    if (newStatus != null)
//                    {
//                        awardCenter.StatusID = newStatus.StatusID;
//                        updated = true;
//                    }
//                }

//                // Check and update AwardCTypeID
//                var currentType = types.FirstOrDefault(t => t.AwardCTypeID == awardCenter.AwardCTypeID);
//                if (currentType == null)
//                {
//                    var newType = types.FirstOrDefault(t => t.CenterName == awardCenter.AwardCTypeID.ToString());
//                    if (newType != null)
//                    {
//                        awardCenter.AwardCTypeID = newType.AwardCTypeID;
//                        updated = true;
//                    }
//                }

//                if (updated)
//                {
//                    _context.AwardCenters.Update(awardCenter);
//                    updatedRecords++;
//                }
//            }

//            await _context.SaveChangesAsync();

//            return new SynchronizationResult
//            {
//                TotalRecords = totalRecords,
//                UpdatedRecords = updatedRecords
//            };
//        }
//    }

//    public class SynchronizationResult
//    {
//        public int TotalRecords { get; set; }
//        public int UpdatedRecords { get; set; }
//    }
//}