using System.Threading.Tasks;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IStatus
    {
        /// <summary>
        /// EVE Server status.
        /// <para>GET /status/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing server status.</returns>
        Task<ESIModelDTO<Models.Status>> GetStatusV1Async(string ifNoneMatch=null);
    }
}