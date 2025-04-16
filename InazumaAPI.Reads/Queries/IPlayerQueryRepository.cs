using InazumaAPI.Domain.Aggregates.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Reads.Queries
{
    public interface IPlayerQueryRepository : IQuery
    {
        Task<PlayerModel?> GetByNombreIdAsync(string NombreId);        
        Task<IEnumerable<PlayerModel?>> GetAllByStatAsync(string Stat);
    }}
