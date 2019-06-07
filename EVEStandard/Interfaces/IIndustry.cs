using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IIndustry
    {
        /// <summary>
        /// Return a list of industry facilities.
        /// <para>GET /industry/facilities/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of facilities.</returns>
        Task<ESIModelDTO<List<IndustryFacility>>> ListIndustryFacilitiesV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Return cost indices for solar systems.
        /// <para>GET /industry/systems/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of cost indicies.</returns>
        Task<ESIModelDTO<List<IndustrySystem>>> ListSolarSystemCostIndiciesV1Async(string ifNoneMatch = null);

        /// <summary>
        /// List industry jobs placed by a character.
        /// <para>GET /characters/{character_id}/industry/jobs/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="includeCompleted">Whether retrieve completed character industry jobs as well.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing industry jobs placed by a character.</returns>
        Task<ESIModelDTO<List<IndustryJob>>> ListCharacterIndustryJobsV1Async(AuthDTO auth, bool includeCompleted, string ifNoneMatch = null);

        /// <summary>
        /// Paginated record of all mining done by a character for the past 30 days.
        /// <para>GET /characters/{character_id}/mining/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing mining ledger of a character.</returns>
        Task<ESIModelDTO<List<CharacterMining>>> CharacterMiningLedgerV1Async(AuthDTO auth, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Paginated list of all entities capable of observing and recording mining for a corporation.
        /// <para>GET /corporation/{corporation_id}/mining/observers/</para>
        /// <para>Requires one of the following EVE corporation role(s): Accountant</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing observer list of a corporation.</returns>
        Task<ESIModelDTO<List<CorporationMiningObserver>>> CorporationMiningObserversV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Paginated record of all mining seen by an observer.
        /// <para>GET /corporation/{corporation_id}/mining/observers/{observer_id}/</para>
        /// <para>Requires one of the following EVE corporation role(s): Accountant</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="observerId">A mining observer id.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing mining ledger of an observer.</returns>
        Task<ESIModelDTO<List<CorporationObservedMining>>> ObservedCorporationMiningV1Async(AuthDTO auth, int corporationId, long observerId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// List industry jobs run by a corporation.
        /// <para>GET /corporations/{corporation_id}/industry/jobs/</para>
        /// <para>Requires one of the following EVE corporation role(s): FactoryManager</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="includeCompleted">Whether retrieve completed industry jobs as well. Default value: false.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation industry jobs.</returns>
        Task<ESIModelDTO<List<IndustryJob>>> ListCorporationIndustryJobsV1Async(AuthDTO auth, int corporationId, int page = 1, bool includeCompleted = false, string ifNoneMatch = null);

        /// <summary>
        /// Extraction timers for all moon chunks being extracted by refineries belonging to a corporation.
        /// <para>GET /corporation/{corporation_id}/mining/extractions/</para>
        /// <para>Requires one of the following EVE corporation role(s): Structure_manager</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="includeCompleted">Whether retrieve completed character industry jobs as well.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of chunk timers.</returns>
        Task<ESIModelDTO<List<MiningExtraction>>> MoonExtractionTimersV1Async(AuthDTO auth, int corporationId, int page = 1, bool includeCompleted = false, string ifNoneMatch = null);
    }
}