using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IDogma
    {
        /// <summary>
        /// Get a list of dogma attribute ids.
        /// <para>GET /dogma/attributes</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of dogma attribute ids.</returns>
        Task<ESIModelDTO<List<int>>> GetAttributesV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Get information on a dogma attribute.
        /// <para>GET /dogma/attributes/{attribute_id}/</para>
        /// </summary>
        /// <param name="attributeId">A dogma attribute ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a dogma attribute.</returns>
        Task<ESIModelDTO<DogmaAttribute>> GetAttributeInfoV1Async(int attributeId, string ifNoneMatch = null);

        /// <summary>
        /// Returns info about a dynamic item resulting from mutation with a mutaplasmid.
        /// <para>GET /dogma/dynamic/items/{type_id}/{item_id}/</para>
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing details about a dynamic item.</returns>
        Task<ESIModelDTO<DogmaDynamicItem>> GetDynamicItemInfoV1Async(int typeId, long itemId, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of dogma effect ids.
        /// <para>GET /dogma/effects/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of dogma effect ids.</returns>
        Task<ESIModelDTO<List<int>>> GetEffectsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Get information on a dogma effect.
        /// <para>GET /dogma/effects/{effect_id}</para>
        /// </summary>
        /// <param name="effectId">A dogma effect ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a dogma effect.</returns>
        Task<ESIModelDTO<DogmaEffect>> GetEffectInfoV2Async(int effectId, string ifNoneMatch = null);
    }
}