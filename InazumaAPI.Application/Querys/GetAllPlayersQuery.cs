using InazumaAPI.Application.QueryBuss;
using InazumaAPI.Domain.Aggregates.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Application.Querys
{
    public class GetAllPlayersQuery : IQuery<IEnumerable<PlayerModel>>
    {
        public GetAllPlayersQuery(string stat)
        {
            this.Stat = stat;
        }

        public string Stat { get; set; }
    }
}
