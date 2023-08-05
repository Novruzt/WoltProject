using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.Others;

namespace Wolt.BLL.Services.Abstract
{
    public interface IThingsService
    {
        Task<UserCommentDTO> GetUserCommentAsync(int UserId, int RestId);
    }
}
