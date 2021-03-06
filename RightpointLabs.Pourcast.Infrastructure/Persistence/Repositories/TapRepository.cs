using System;

namespace RightpointLabs.Pourcast.Infrastructure.Persistence.Repositories
{
    using System.Linq;

    using RightpointLabs.Pourcast.Domain.Models;
    using RightpointLabs.Pourcast.Domain.Repositories;
    using RightpointLabs.Pourcast.Infrastructure.Persistence.Collections;

    public class TapRepository : EntityRepository<Tap>, ITapRepository
    {
        public TapRepository(TapCollectionDefinition tapCollectionDefinition)
            : base(tapCollectionDefinition)
        {
        }

        public Tap GetByKegId(string kegId)
        {
            return Queryable.Single(t => t.KegId == kegId);
        }

        public Tap GetByName(string name)
        {
            try
            {
                return Queryable.Single(t => t.Name == name);
            }
            catch (Exception ex)
            {
                // Probably blew up cause it didn't find anything. 
                // Not sure why mongodb doesn't just return null
                return null;
            }
        }
    }
}