using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Application.QueryBuss
{
    public interface IQueryHandler<in TQuery, TRespose>
        where TQuery : IQuery<TRespose>
    {
        Task<TRespose> HandleAsync(TQuery query);
    }
}
