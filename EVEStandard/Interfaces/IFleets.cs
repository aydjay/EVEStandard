using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IFleets
    {
        /// <summary>
        /// Return details about a fleet.
        /// <para>GET /fleets/{fleet_id}</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing details about a fleet.</returns>
        Task<ESIModelDTO<FleetInfo>> GetFleetInfoV1Async(AuthDTO auth, long fleetId, string ifNoneMatch = null);

        /// <summary>
        /// Update settings about a fleet.
        /// <para>PUT /fleets/{fleet_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="motd">New fleet MOTD in CCP flavoured HTML.</param>
        /// <param name="isFreeMove">Should free-move be enabled in the fleet.</param>
        /// <returns></returns>
        Task UpdateFleetV1Async(AuthDTO auth, long fleetId, string motd, bool? isFreeMove);

        /// <summary>
        /// Return the fleet ID the character is in, if any.
        /// <para>GET /characters/{character_id}/fleet/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing details about the character’s fleet.</returns>
        Task<ESIModelDTO<CharacterFleetInfo>> GetCharacterFleetInfoV2Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Return information about fleet members.
        /// <para>GET /fleets/{fleet_id}/members/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="language">Language to use in the response. Available values : de, en-us, fr, ja, ru, zh. Default value: en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fleet members.</returns>
        Task<ESIModelDTO<List<FleetMember>>> GetFleetMembersV1Async(AuthDTO auth, long fleetId, string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// Invite a character into the fleet. If a character has a CSPA charge set it is not possible to invite them to the fleet using ESI.
        /// <para>POST /fleets/{fleet_id}/members/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="invite">Details of the invitation.</param>
        /// <returns></returns>
        Task CreateFleetInvitationV1Async(AuthDTO auth, long fleetId, FleetInvitation invite);

        /// <summary>
        /// Kick a fleet member.
        /// <para>DELETE /fleets/{fleet_id}/members/{member_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="memberId">The character ID of a member in this fleet.</param>
        /// <returns></returns>
        Task KickFleetMemberV1Async(AuthDTO auth, long fleetId, int memberId);

        /// <summary>
        /// Move a fleet member around.
        /// <para>PUT /fleets/{fleet_id}/members/{member_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="memberId">The character ID of a member in this fleet.</param>
        /// <param name="movement">Details of the invitation.</param>
        /// <returns></returns>
        Task MoveFleetMemberV1Async(AuthDTO auth, long fleetId, int memberId, FleetMemberMove movement);

        /// <summary>
        /// Return information about wings in a fleet.
        /// <para>GET /fleets/{fleet_id}/wings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="language">Language to use in the response. Available values : de, en-us, fr, ja, ru, zh. Default value: en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fleet wings.</returns>
        Task<ESIModelDTO<List<FleetWing>>> GetFleetWingsV1Async(AuthDTO auth, long fleetId, string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// Create a new wing in a fleet.
        /// <para>POST /fleets/{fleet_id}/wings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fleet wing ids.</returns>
        Task<ESIModelDTO<long>> CreateFleetWingV1Async(AuthDTO auth, long fleetId);

        /// <summary>
        /// Delete a fleet wing, only empty wings can be deleted. The wing may contain squads, but the squads must be empty.
        /// <para>DELETE /fleets/{fleet_id}/wings/{wing_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="wingId">The wing to delete.</param>
        /// <returns></returns>
        Task DeleteFleetWingV1Async(AuthDTO auth, long fleetId, long wingId);

        /// <summary>
        /// Rename a fleet wing
        /// <para>PUT /fleets/{fleet_id}/wings/{wing_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="wingId">The wing to delete.</param>
        /// <param name="name">New name of the wing.</param>
        /// <returns></returns>
        Task RenameFleetWingV1Async(AuthDTO auth, long fleetId, long wingId, string name);

        /// <summary>
        /// Create a new squad in a fleet.
        /// <para>POST /fleets/{fleet_id}/wings/{wing_id}/squads/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fleet squad ids.</returns>
        Task<ESIModelDTO<long>> CreateFleetSquadV1Async(AuthDTO auth, long fleetId, long wingId);

        /// <summary>
        /// Delete a fleet squad, only empty squads can be deleted.
        /// <para>DELETE /fleets/{fleet_id}/squads/{squad_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="squadId">The squad to delete.</param>
        /// <returns></returns>
        Task DeleteFleetSquadV1Async(AuthDTO auth, long fleetId, long squadId);

        /// <summary>
        /// Rename a fleet squad.
        /// <para>PUT /fleets/{fleet_id}/squads/{squad_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="squadId">The squad to delete.</param>
        /// <param name="name">New name of the squad.</param>
        /// <returns></returns>
        Task RenameFleetSquadV1Async(AuthDTO auth, long fleetId, long squadId, string name);
    }
}