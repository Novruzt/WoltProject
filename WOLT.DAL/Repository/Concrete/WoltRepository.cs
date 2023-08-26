using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.WoltEntities;
using WOLT.DAL.DATA;
using WOLT.DAL.Repository.Abstract;

namespace WOLT.DAL.Repository.Concrete
{
    public class WoltRepository : IWoltRepository
    {
        private readonly DataContext _ctx;
        public WoltRepository(DataContext context)
        {
            _ctx = context;
        }
        public async Task AddLogAsync(WoltLog log)
        {
            await _ctx.AddAsync(log);
        }
    }
}
