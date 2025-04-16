using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Domain.Aggregates.Players
{
    public interface IPlayerModelRepository
    {
        Task AddAsync(PlayerModel player);
        Task<bool> DeleteAsync(string id);
        Task<bool> UpdateAsync(PlayerModel player);
    }
}
