using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface ISkills
    {
        /// <summary>
        /// List all trained skills for the given character.
        /// <para>GET characters/{character_id}/skills/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing known skills for the character.</returns>
        Task<ESIModelDTO<CharacterSkills>> GetCharacterSkillsV4Async(AuthDTO auth, string ifNoneMatch=null);

        /// <summary>
        /// Return attributes of a character.
        /// <para>GET /characters/{character_id}/attributes/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing attributes of a character.</returns>
        Task<ESIModelDTO<CharacterAttributes>> GetCharacterAttributesV1Async(AuthDTO auth, string ifNoneMatch=null);

        /// <summary>
        /// List the configured skill queue for the given character.
        /// <para>GET /characters/{character_id}/skillqueue/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the current skill queue, sorted ascending by finishing time.</returns>
        Task<ESIModelDTO<List<SkillQueue>>> GetCharacterSkillQueueV2Async(AuthDTO auth, string ifNoneMatch=null);
    }
}