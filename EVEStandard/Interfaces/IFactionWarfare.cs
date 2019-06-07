using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IFactionWarfare
    {
        /// <summary>
        /// Data about which NPC factions are at war.
        /// <para>GET /fw/wars/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of NPC factions at war.</returns>
        Task<ESIModelDTO<List<FactionWarData>>> DataAboutFactionWarsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Statistical overviews of factions involved in faction warfare.
        /// <para>GET /fw/stats/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing per faction breakdown of faction warfare statistics.</returns>
        Task<ESIModelDTO<List<FactionWarStats>>> StatsAboutFactionWarsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// An overview of the current ownership of faction warfare solar systems.
        /// <para>GET /fw/systems/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing all faction warfare solar systems.</returns>
        Task<ESIModelDTO<List<FactionWarSystem>>> FactionWarSystemOwnershipV2Async(string ifNoneMatch = null);

        /// <summary>
        /// Top 4 leaderboard of factions for kills and victory points separated by total, last week and yesterday.
        /// <para>GET /fw/leaderboards/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing faction leaderboard of kills and victory points within faction warfare.</returns>
        Task<ESIModelDTO<FactionWarFactionLeaderboard>> TopFactionsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Top 100 leaderboard of pilots for kills and victory points separated by total, last week and yesterday.
        /// <para>GET /fw/leaderboards/characters/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing character leaderboard of kills and victory points within faction warfare.</returns>
        Task<ESIModelDTO<FactionWarPilotLeaderboard>> TopPilotsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Top 10 leaderboard of corporations for kills and victory points separated by total, last week and yesterday.
        /// <para>GET /fw/leaderboards/corporations/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing corporation leaderboard of kills and victory points within faction warfare.</returns>
        Task<ESIModelDTO<FactionWarCorporationLeaderboard>> TopCorporationsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Statistics about a corporation involved in faction warfare.
        /// <para>GET /corporations/{corporation_id}/fw/stats/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing faction warfare statistics for a given corporation.</returns>
        Task<ESIModelDTO<FactionWarCorporationStats>> CorporationOverviewInFactionWarsV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Statistical overview of a character involved in faction warfare.
        /// <para>GET /characters/{character_id}/fw/stats/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing faction warfare statistics for a given character.</returns>
        Task<ESIModelDTO<FactionWarCharacterStats>> CharacterOverviewInFactionWarsV1Async(AuthDTO auth, string ifNoneMatch = null);
    }
}