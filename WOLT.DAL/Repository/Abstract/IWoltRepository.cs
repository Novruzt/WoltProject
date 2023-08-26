using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.WoltEntities;

namespace WOLT.DAL.Repository.Abstract
{
    public interface IWoltRepository
    {
        public Task AddLogAsync(WoltLog log);
    }
}
