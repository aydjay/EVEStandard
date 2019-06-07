using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface ICorporation
    {
        /// <summary>
        /// Return the current shareholders of a corporation.
        /// <para>GET /corporations/{corporation_id}/shareholders/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of shareholders.</returns>
        Task<ESIModelDTO<List<Shareholder>>> GetCorporationShareholdersV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Public information about a corporation.
        /// <para>GET /corporations/{corporation_id}/</para>
        /// </summary>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing public information about a corporation.</returns>
        Task<ESIModelDTO<CorporationInfo>> GetCorporationInfoV4Async(int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of all the alliances a corporation has been a member of.
        /// <para>GET /corporations/{corporation_id}/alliancehistory/</para>
        /// </summary>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing alliance history for the given corporation.</returns>
        Task<ESIModelDTO<List<AllianceHistory>>> GetAllianceHistoryV2Async(int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Return the current member list of a corporation, the token’s character need to be a member of the corporation.
        /// <para>GET /corporations/{corporation_id}/members/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of member character IDs.</returns>
        Task<ESIModelDTO<List<int>>> GetCorporationMembersV3Async(AuthDTO auth, int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Return the roles of all members if the character has the personnel manager role or any grantable role.
        /// <para>GET /corporations/{corporation_id}/roles/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of member character ID’s and roles.</returns>
        Task<ESIModelDTO<List<CorporationRoles>>> GetCorporationMemberRolesV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Return how roles have changed for a coporation’s members, up to a month.
        /// <para>GET /corporations/{corporation_id}/roles/history/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of role changes.</returns>
        Task<ESIModelDTO<List<CorporationRoleHistory>>> GetCorporationMemberRolesHistoryV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Get the icon urls for a corporation.
        /// <para>GET /corporations/{corporation_id}/icons/</para>
        /// </summary>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing urls for icons for the given corporation id and server.</returns>
        Task<ESIModelDTO<Icons>> GetCorporationIconV1Async(int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of npc corporations.
        /// <para>GET /corporations/npccorps/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of npc corporation ids.</returns>
        Task<ESIModelDTO<List<int>>> GetNPCCorporationsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Get a list of corporation structures.
        /// <para>GET /corporations/{corporation_id}/structures/</para>
        /// <para>Requires one of the following EVE corporation role(s): StationManager</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <param name="language">Language to use in the response</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation structures’ information.</returns>
        Task<ESIModelDTO<List<CorporationStructure>>> GetCorporationStructuresV3Async(AuthDTO auth, int corporationId, int page = 1, string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// Returns additional information about a corporation’s members which helps tracking their activities.
        /// <para>GET /corporations/{corporation_id}/membertracking/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of member character IDs.</returns>
        Task<ESIModelDTO<List<CorporationMemberTracking>>> TrackCorporationMembersV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Return corporation hangar and wallet division names, only show if a division is not using the default name.
        /// <para>GET /corporations/{corporation_id}/divisions/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation division names.</returns>
        Task<ESIModelDTO<CorporationDivision>> GetCorporationDivisionsV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Return a corporation’s member limit, not including CEO himself.
        /// <para>GET /corporations/{corporation_id}/members/limit/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the corporation’s member limit.</returns>
        Task<ESIModelDTO<int>> GetCorporationMemberLimitV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Returns a corporation’s titles.
        /// <para>GET /corporations/{corporation_id}/titles/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of titles.</returns>
        Task<ESIModelDTO<List<CorporationTitle>>> GetCorporationTitlesV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Returns a corporation’s members’ titles.
        /// <para>GET /corporations/{corporation_id}/members/titles/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of members and theirs titles.</returns>
        Task<ESIModelDTO<List<CorporationMemberTitles>>> GetCorporationsMembersTitlesV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Returns a list of blueprints the corporation owns.
        /// <para>GET /corporations/{corporation_id}/blueprints/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation blueprints.</returns>
        Task<ESIModelDTO<List<Blueprint>>> GetCorporationBlueprintsV2Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Return corporation standings from agents, NPC corporations, and factions.
        /// <para>GET /corporations/{corporation_id}/standings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of standings.</returns>
        Task<ESIModelDTO<List<Standing>>> GetStandingsV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Returns list of corporation starbases (POSes).
        /// <para>GET /corporations/{corporation_id}/starbases/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of starbases (POSes).</returns>
        Task<ESIModelDTO<List<Starbase>>> GetCorporationStarbasesV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Returns various settings and fuels of a starbase (POS).
        /// <para>GET /corporations/{corporation_id}/starbases/{starbase_id}/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="starbaseId">An EVE starbase (POS) ID.</param>
        /// <param name="systemId">The solar system this starbase (POS) is located in.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of starbases (POSes).</returns>
        Task<ESIModelDTO<StarbaseDetail>> GetStarbaseDetailV1Async(AuthDTO auth, int corporationId, long starbaseId, long systemId, string ifNoneMatch = null);

        /// <summary>
        /// Returns logs recorded in the past seven days from all audit log secure containers (ALSC) owned by a given corporation.
        /// <para>GET /corporations/{corporation_id}/containers/logs/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation ALSC logs.</returns>
        Task<ESIModelDTO<List<ContainerLogs>>> GetAllCorporationALSCLogsV2Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Return a corporation’s facilities.
        /// <para>GET /corporations/{corporation_id}/facilities/</para>
        /// <para>Requires one of the following EVE corporation role(s): Factory_Manager</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation facilities.</returns>
        Task<ESIModelDTO<List<Facility>>> GetCorporationFacilitiesV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Returns a corporation’s medals.
        /// <para>GET /corporations/{corporation_id}/medals/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of medals.</returns>
        Task<ESIModelDTO<List<CorporationMedal>>> GetCorporationMedalsV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Returns medals issued by a corporation.
        /// <para>GET /corporations/{corporation_id}/medals/issued/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of issued medals.</returns>
        Task<ESIModelDTO<List<CorporationMedalIssued>>> GetCorporationIssuedMedalsV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);
    }
}