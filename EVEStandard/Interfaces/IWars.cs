using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IWars
    {
        /// <summary>
        /// Return a list of wars.
        /// <para>GET /wars/</para>
        /// </summary>
        /// <param name="maxWarId">Only return wars with ID smaller than this.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of war IDs, in decending order by war_id.</returns>
        Task<ESIModelDTO<List<int>>> ListWarsV1Async(int? maxWarId, string ifNoneMatch=null);

        /// <summary>
        /// Return details about a war.
        /// <para>GET /wars/{war_id}/</para>
        /// </summary>
        /// <param name="warId">ID for a war.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing details about a war.</returns>
        Task<ESIModelDTO<War>> GetWarInformationV1Async(int warId, string ifNoneMatch = null);

        /// <summary>
        /// Return a list of kills related to a war.
        /// <para>GET /wars/{war_id}/killmails/</para>
        /// </summary>
        /// <param name="warId">A valid war ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of killmail IDs and hashes.</returns>
        Task<ESIModelDTO<List<KillmailIndex>>> ListKillsForWarV1Async(int warId, int page = 1, string ifNoneMatch = null);
    }
}