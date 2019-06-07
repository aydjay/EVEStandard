using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IKillmails
    {
        /// <summary>
        /// Return a single killmail from its ID and hash.
        /// <para>GET /killmails/{killmail_id}/{killmail_hash}/</para>
        /// </summary>
        /// <param name="killmailId">The killmail ID to be queried.</param>
        /// <param name="killmailHash">The killmail hash for verification.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a killmail.</returns>
        Task<ESIModelDTO<Killmail>> GetKillmailV1Async(int killmailId, string killmailHash, string ifNoneMatch = null);

        /// <summary>
        /// Return a list of a character’s kills and losses going back 90 days.
        /// <para>GET /characters/{character_id}/killmails/recent/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of killmail IDs and hashes.</returns>
        Task<ESIModelDTO<List<KillmailIndex>>> GetCharacterKillsAndLossesV1Async(AuthDTO auth, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of a corporation’s kills and losses going back 90 days.
        /// <para>GET /corporations/{corporation_id}/killmails/recent/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of killmail IDs and hashes.</returns>
        Task<ESIModelDTO<List<KillmailIndex>>> GetCorporationKillsAndLossesV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);
    }
}