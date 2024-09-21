using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Data;
using System.Threading.Tasks;
using System.Linq;

namespace ProjectManagementAPIB.Services
{
    public interface ISynchronizationService
    {
        Task<SynchronizationResult> SynchronizeAwardCenterAsync();
    }

    public class SynchronizationService : ISynchronizationService
    {
        private readonly ProjectManagementContext _context;

        public SynchronizationService(ProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<SynchronizationResult> SynchronizeAwardCenterAsync()
        {
            int totalRecords = 0;
            int updatedRecords = 0;

            // Get all Award Centers that need to be updated
            var awardCenters = await _context.AwardCenters
                .Include(ac => ac.AwardCenterStage) // Assuming navigation property
                .Include(ac => ac.AwardCenterStatus) // Assuming navigation property
                .Include(ac => ac.AwardCType) // Assuming navigation property
                .ToListAsync();

            totalRecords = awardCenters.Count;

            foreach (var awardCenter in awardCenters)
            {
                var updated = false;

                // Sync the Stage if it has changed
                var stage = await _context.AwardCenterStages.FindAsync(awardCenter.StageID); // Assuming you have StageID as FK
                if (stage != null && awardCenter.AwardCenterStage.StageName != stage.StageName)
                {
                    awardCenter.AwardCenterStage.StageName = stage.StageName; // Assuming navigation property for StageName
                    updated = true;
                }

                // Sync the Status if it has changed
                var status = await _context.AwardCenterStatus.FindAsync(awardCenter.StatusID); // Assuming you have StatusID as FK
                if (status != null && awardCenter.AwardCenterStatus.StatusName != status.StatusName)
                {
                    awardCenter.AwardCenterStatus.StatusName = status.StatusName; // Assuming navigation property for StatusName
                    updated = true;
                }

                // Sync the AwardCType if it has changed
                var awardCType = await _context.AwardCTypes.FindAsync(awardCenter.AwardCTypeID); // Assuming AwardCTypeID as FK
                if (awardCType != null && awardCenter.AwardCType.CenterName != awardCType.CenterName)
                {
                    awardCenter.AwardCType.CenterName = awardCType.CenterName; // Assuming navigation property for CenterName
                    updated = true;
                }

                if (updated)
                {
                    _context.AwardCenters.Update(awardCenter);
                    updatedRecords++;
                }
            }

            await _context.SaveChangesAsync();

            return new SynchronizationResult
            {
                TotalRecords = totalRecords,
                UpdatedRecords = updatedRecords
            };
        }
    }

    public class SynchronizationResult
    {
        public int TotalRecords { get; set; }
        public int UpdatedRecords { get; set; }
    }
}
