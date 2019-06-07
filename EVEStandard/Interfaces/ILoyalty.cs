using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface ILoyalty
    {
        /// <summary>
        /// Return a list of offers from a specific corporation’s loyalty store.
        /// <para>GET /loyalty/stores/{corporation_id}/offers/</para>
        /// </summary>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of offers.</returns>
        Task<ESIModelDTO<List<LoyaltyStoreOffer>>> ListLoyaltyStoreOffersV1Async(int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Return a list of loyalty points for all corporations the character has worked for.
        /// <para>GET /characters/{character_id}/loyalty/points/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of loyalty points.</returns>
        Task<ESIModelDTO<List<LoyaltyPoints>>> GetLoyaltyPointsV1Async(AuthDTO auth, string ifNoneMatch = null);
    }
}