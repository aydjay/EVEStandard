using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface ICharacter
    {
        /// <summary>
        /// Returns aggregate yearly stats for a character.
        /// <para>GET /characters/{character_id}/stats/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing character stats.</returns>
        Task<ESIModelDTO<List<AggregateStats>>> YearlyAggregateStatsV2Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Public information about a character.
        /// <para>GET /characters/{character_id}/</para>
        /// </summary>
        /// <param name="characterId">An EVE character ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing public data for the given character.</returns>
        Task<ESIModelDTO<CharacterInfo>> GetCharacterPublicInfoV4Async(int characterId, string ifNoneMatch = null);

        /// <summary>
        /// Bulk lookup of character IDs to corporation, alliance and faction.
        /// <para>POST /characters/affiliation/</para>
        /// </summary>
        /// <param name="characterIds">The character IDs to fetch affiliations for. All characters must exist, or none will be returned.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing character corporation, alliance and faction IDs.</returns>
        Task<ESIModelDTO<List<CharacterAffiliation>>> AffiliationV1Async(List<int> characterIds);

        /// <summary>
        /// Takes a source character ID in the url and a set of target character ID’s in the body, returns a CSPA charge cost.
        /// <para>POST /characters/{character_id}/cspa/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="characterIds">The target characters to calculate the charge for.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing aggregate cost of sending a mail from the source character to the target characters, in ISK.</returns>
        Task<ESIModelDTO<float>> CalculateCSPAChargeCostV4Async(AuthDTO auth, List<int> characterIds);

        /// <summary>
        /// Get portrait urls for a character.
        /// <para>GET /characters/{character_id}/portrait/</para>
        /// </summary>
        /// <param name="characterId">An EVE character ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing public data for the given character.</returns>
        Task<ESIModelDTO<Icons>> GetCharacterPortraitsV2Async(int characterId, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of all the corporations a character has been a member of.
        /// <para>GET /characters/{character_id}/corporationhistory/</para>
        /// </summary>
        /// <param name="characterId">An EVE character ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing corporation history for the given character.</returns>
        Task<ESIModelDTO<List<CharacterCorporationHistory>>> GetCorporationHistoryV1Async(int characterId, string ifNoneMatch = null);

        /// <summary>
        /// Return a list of medals the character has.
        /// <para>GET /characters/{character_id}/medals/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of medals.</returns>
        Task<ESIModelDTO<List<CharacterMedals>>> GetMedalsV1Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Return character standings from agents, NPC corporations, and factions.
        /// <para>GET /characters/{character_id}/standings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of standings.</returns>
        Task<ESIModelDTO<List<Standing>>> GetStandingsV1Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Return a list of agents research information for a character. 
        /// The formula for finding the current research points with an agent is: 
        /// currentPoints = remainderPoints + pointsPerDay * days(currentTime - researchStartDate).
        /// <para>GET /characters/{character_id}/agents_research/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of agents research information.</returns>
        Task<ESIModelDTO<List<AgentResearch>>> GetAgentsResearchV1Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Return a list of blueprints the character owns.
        /// <para>GET /characters/{character_id}/blueprints/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of blueprints.</returns>
        Task<ESIModelDTO<List<Blueprint>>> GetBlueprintsV2Async(AuthDTO auth, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Return a character’s jump activation and fatigue information.
        /// <para>GET /characters/{character_id}/fatigue/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing jump activation and fatigue information.</returns>
        Task<ESIModelDTO<Fatigue>> GetJumpFatigueV1Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Return notifications about having been added to someone’s contact list.
        /// <para>GET /characters/{character_id}/notifications/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contact notifications.</returns>
        Task<ESIModelDTO<List<CharacterContactNotification>>> GetNewContactNotificationsV1Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Return character notifications.
        /// <para>GET /characters/{character_id}/notifications/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing your recent notifications.</returns>
        Task<ESIModelDTO<List<Notification>>> GetCharacterNotificationsV4Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Returns a character’s corporation roles.
        /// <para>GET /characters/{character_id}/roles/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the character’s roles in thier corporation.</returns>
        Task<ESIModelDTO<CharacterCorporationRoles>> GetCharacterCorporationRolesV2Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Returns a character’s titles.
        /// <para>GET /characters/{character_id}/titles/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of titles.</returns>
        Task<ESIModelDTO<List<CharacterTitle>>> GetCharacterCorporationTitlesV1Async(AuthDTO auth, string ifNoneMatch = null);
    }
}