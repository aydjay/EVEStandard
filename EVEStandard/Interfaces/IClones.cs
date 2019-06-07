using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.API;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IClones
    {
        /// <summary>
        /// A list of the character’s clones.
        /// <para>GET /characters/{character_id}/clones/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing clone information for the given character.</returns>
        Task<ESIModelDTO<Clones>> GetClonesV3Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Return implants on the active clone of a character.
        /// <para>GET /characters/{character_id}/implants/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of implant type ids.</returns>
        Task<ESIModelDTO<List<int>>> GetActiveImplantsV1Async(AuthDTO auth, string ifNoneMatch = null);
    }
}