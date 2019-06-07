using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IContacts
    {
        /// <summary>
        /// Bulk delete contacts.
        /// <para>DELETE /characters/{character_id}/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contactIds">A list of contacts to delete.</param>
        /// <returns></returns>
        Task DeleteContactsV2Async(AuthDTO auth, List<int> contactIds);

        /// <summary>
        /// Return contacts of a character.
        /// <para>GET /characters/{character_id}/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contacts.</returns>
        Task<ESIModelDTO<List<CharacterContact>>> GetContactsV2Async(AuthDTO auth, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Bulk add contacts with same settings.
        /// <para>POST /characters/{character_id}/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contactIds">A list of contacts.</param>
        /// <param name="labelIds">Add custom labels to the new contact.</param>
        /// <param name="standing">Standing for the contact.</param>
        /// <param name="isWatched">Whether the contact should be watched, note this is only effective on characters Default value: false.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contact ids that successfully created.</returns>
        Task<ESIModelDTO<List<int>>> AddContactsV2Async(AuthDTO auth, List<int> contactIds, List<long> labelIds, float standing, bool isWatched=false);

        /// <summary>
        /// Bulk edit contacts with same settings.
        /// <para>PUT /characters/{character_id}/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contactIds">A list of contacts.</param>
        /// <param name="labelIds">Add custom labels to the new contact.</param>
        /// <param name="standing">Standing for the contact.</param>
        /// <param name="isWatched">Whether the contact should be watched, note this is only effective on characters Default value: false.</param>
        /// <returns></returns>
        Task EditContactsV2Async(AuthDTO auth, List<int> contactIds, List<long> labelIds, float standing, bool isWatched=false);

        /// <summary>
        /// Return contacts of a corporation.
        /// <para>GET /corporations/{corporation_id}/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contacts.</returns>
        Task<ESIModelDTO<List<CorporationContact>>> GetCorporationContactsV2Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Return contacts of an alliance.
        /// <para>/alliances/{alliance_id}/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="allianceId">An EVE alliance ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contacts.</returns>
        Task<ESIModelDTO<List<AllianceContact>>> GetAllianceContactsV2Async(AuthDTO auth, int allianceId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Return custom labels for a character’s contacts.
        /// <para>GET /characters/{character_id}/contacts/labels/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contact labels.</returns>
        Task<ESIModelDTO<List<ContactLabel>>> GetContactLabelsV1Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Return custom labels for an alliance’s contacts.
        /// <para>GET /alliances/{alliance_id}/contacts/labels/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of alliance contact labels.</returns>
        Task<ESIModelDTO<List<ContactLabel>>> GetAllianceContactLabelsV1Async(AuthDTO auth, int allianceId, string ifNoneMatch = null);

        /// <summary>
        /// Return custom labels for a corporation’s contacts.
        /// <para>GET /corporations/{corporation_id}/contacts/labels/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation contact labels.</returns>
        Task<ESIModelDTO<List<ContactLabel>>> GetCorporationContactLabelsV1Async(AuthDTO auth, int corporationId);
    }
}