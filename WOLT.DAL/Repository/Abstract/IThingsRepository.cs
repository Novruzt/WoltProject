using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;

namespace WOLT.DAL.Repository.Abstract
{
    public interface IThingsRepository
    {
        Task<UserComment> GetUserCommentAsync(int userId, int restId);
    }
}
