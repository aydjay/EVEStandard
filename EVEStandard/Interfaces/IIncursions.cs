using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IIncursions
    {
        /// <summary>
        /// Return a list of current incursions.
        /// <para>GET /incursions/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of incursions.</returns>
        Task<ESIModelDTO<List<Models.Incursion>>> ListIncursionsV1Async(string ifNoneMatch = null);
    }
}