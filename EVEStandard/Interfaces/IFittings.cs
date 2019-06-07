using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IFittings
    {
        /// <summary>
        /// Delete a fitting from a character.
        /// <para>DELETE /characters/{character_id}/fittings/{fitting_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fittingId">ID for a fitting of this character.</param>
        /// <returns></returns>
        Task DeleteFittingV1Async(AuthDTO auth, long fittingId);

        /// <summary>
        /// Return fittings of a character.
        /// <para>GET /characters/{character_id}/fittings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fittings.</returns>
        Task<ESIModelDTO<List<ShipFitting>>> GetFittingsV2Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Save a new fitting for a character.
        /// <para>POST /characters/{character_id}/fittings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fitting">Details about the new fitting.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fittings.</returns>
        Task<ESIModelDTO<ShipFittingCreated>> CreateFittingV2Async(AuthDTO auth, ShipFitting fitting);
    }
}