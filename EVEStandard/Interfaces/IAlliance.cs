using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IAlliance
    {
        /// <summary>
        /// Public information about an alliance.
        /// <para>GET /alliances/{alliance_id}/</para>
        /// </summary>
        /// <param name="allianceId">An EVE alliance ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing public data about an alliance.</returns>
        Task<ESIModelDTO<Models.Alliance>> GetAllianceInfoV3Async(int allianceId, string ifNoneMatch = null);

        /// <summary>
        /// List all current member corporations of an alliance.
        /// <para>GET /alliances/{alliance_id}/corporations/</para>
        /// </summary>
        /// <param name="allianceId">An EVE alliance ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of corporation IDs</returns>
        Task<ESIModelDTO<List<int>>> ListAllianceCorporationsV1Async(int allianceId, string ifNoneMatch = null);

        /// <summary>
        /// Get the icon urls for a alliance.
        /// <para>GET /alliances/{alliance_id}/icons/</para>
        /// </summary>
        /// <param name="allianceId">An EVE alliance ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing icon URLs for the given alliance id.</returns>
        Task<ESIModelDTO<AllianceIcons>> GetAllianceIconV1Async(int allianceId, string ifNoneMatch = null);

        /// <summary>
        /// List all active player alliances.
        /// <para>GET /alliances/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of alliance IDs.</returns>
        Task<ESIModelDTO<List<int>>> ListAllAlliancesV1Async(string ifNoneMatch = null);
    }
}