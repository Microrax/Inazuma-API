using InazumaAPI.Application.QueryBuss;
using InazumaAPI.Domain.Aggregates.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Application.Querys
{
    public class GetPlayerQuery : IQuery<PlayerModel>
    {
        public GetPlayerQuery(string nombreId) 
        {
            this.NombreId = nombreId;
        }

        public string NombreId { get; set; }
    }
}
