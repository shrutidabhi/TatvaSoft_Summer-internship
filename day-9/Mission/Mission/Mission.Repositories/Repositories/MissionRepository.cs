using Microsoft.EntityFrameworkCore;

namespace Mission.Repositories.Repositories
{
    public class MissionRepository(MissionDbContext): IMissionRepository

    {
        public List<Missions> GetAllMissions()
        {
           
            return DbContext.Missions.Where(x => x.IsActive).ToList();
        }
    }
}
