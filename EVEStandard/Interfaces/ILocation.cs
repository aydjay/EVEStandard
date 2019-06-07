using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface ILocation
    {
        /// <summary>
        /// Information about the characters current location. Returns the current solar system id, and also the current station or structure ID if applicable.
        /// <para>GET /characters/{character_id}/location/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about the characters current location. Returns the current solar system id, and also the current station or structure ID if applicable.</returns>
        Task<ESIModelDTO<CharacterLocation>> GetCharacterLocationV1Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Get the current ship type, name and id.
        /// <para>GET /characters/{character_id}/ship/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the current ship type, name and id.</returns>
        Task<ESIModelDTO<CharacterShip>> GetCurrentShipV1Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Checks if the character is currently online.
        /// <para>GET /characters/{character_id}/online/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing object describing the character’s online status.</returns>
        Task<ESIModelDTO<CharacterOnline>> GetCharacterOnlineV2Async(AuthDTO auth, string ifNoneMatch = null);
    }
}