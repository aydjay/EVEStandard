using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IAssets
    {
        /// <summary>
        /// Return a list of the characters assets.
        /// <para>GET /characters/{character_id}/assets/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a flat list of the user's assets.</returns>
        Task<ESIModelDTO<List<Asset>>> GetCharacterAssetsV3Async(AuthDTO auth, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Return a list of the corporation assets.
        /// <para>GET /corporations/{corporation_id}/assets/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of assets.</returns>
        Task<ESIModelDTO<List<Asset>>> GetCorporationAssetsV3Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Return names for a set of item ids, which you can get from character assets endpoint. 
        /// Typically used for items that can customize names, like containers or ships.
        /// <para>POST /characters/{character_id}/assets/names/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="itemIds">A list of item ids.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of asset names.</returns>
        Task<ESIModelDTO<List<AssetName>>> GetCharacterAssetNamesV1Async(AuthDTO auth, List<long> itemIds);

        /// <summary>
        /// Return locations for a set of item ids, which you can get from character assets endpoint. 
        /// Coordinates for items in hangars or stations are set to (0,0,0).
        /// <para>POST /characters/{character_id}/assets/locations/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="itemIds">A list of item ids.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of asset locations.</returns>
        Task<ESIModelDTO<List<AssetLocation>>> GetCharacterAssetLocationsV2Async(AuthDTO auth, List<long> itemIds);

        /// <summary>
        /// Return names for a set of item ids, which you can get from corporation assets endpoint. 
        /// Only valid for items that can customize names, like containers or ships.
        /// <para>POST /corporations/{corporation_id}/assets/names</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="itemIds">A list of item ids.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of asset names.</returns>
        Task<ESIModelDTO<List<AssetName>>> GetCorporationAssetNamesV1Async(AuthDTO auth, int corpId, List<long> itemIds);

        /// <summary>
        /// Return locations for a set of item ids, which you can get from corporation assets endpoint. 
        /// Coordinates for items in hangars or stations are set to (0,0,0).
        /// <para>POST /corporations/{corporation_id}/assets/locations</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="itemIds">A list of item ids.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of asset locations.</returns>
        Task<ESIModelDTO<List<AssetLocation>>> GetCorporationAssetLocationsV2Async(AuthDTO auth, int corpId, List<long> itemIds);
    }
}