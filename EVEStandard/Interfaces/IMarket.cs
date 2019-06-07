using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IMarket
    {
        /// <summary>
        /// Return a list of prices.
        /// <para>GET /markets/prices/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of prices.</returns>
        Task<ESIModelDTO<List<MarketPrice>>> ListMarketPricesV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Return a list of orders in a region.
        /// <para>GET /markets/{region_id}/orders/</para>
        /// </summary>
        /// <param name="regionId">Return orders in this region.</param>
        /// <param name="typeId">Return orders only for this type.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="orderType">Filter buy/sell orders, return all orders by default. If you query without type_id, we always return both buy and sell orders. Available values : buy, sell, all. Default value: all.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of orders.</returns>
        Task<ESIModelDTO<List<MarketOrder>>> ListOrdersInRegionV1Async(int regionId, long? typeId = null, int page = 1, string orderType = OrderType.All, string ifNoneMatch = null);

        /// <summary>
        /// Return a list of historical market statistics for the specified type in a region.
        /// <para>GET /markets/{region_id}/history/</para>
        /// </summary>
        /// <param name="regionId">Return statistics in this region.</param>
        /// <param name="typeId">Return statistics for this type.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of historical market statistics.</returns>
        Task<ESIModelDTO<List<MarketRegionHistory>>> ListHistoricalMarketStatisticsInRegionV1Async(int regionId, int typeId, string ifNoneMatch = null);

        /// <summary>
        /// Return all orders in a structure.
        /// <para>GET /markets/structures/{structure_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="structureId">Return orders in this structure.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of orders.</returns>
        Task<ESIModelDTO<List<MarketOrder>>> ListOrdersInStructureV1Async(AuthDTO auth, long structureId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of item groups.
        /// <para>GET /markets/groups/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of item group ids.</returns>
        Task<ESIModelDTO<int>> GetItemGroupsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Get information on an item group.
        /// </summary>
        /// <param name="marketGroupId">An Eve item group ID.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about an item group.</returns>
        Task<ESIModelDTO<MarketGroup>> GetItemGroupInfoV1Async(int marketGroupId, string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// List open market orders placed by a character.
        /// <para>GET /characters/{character_id}/orders/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing open market orders placed by a character.</returns>
        Task<ESIModelDTO<List<CharacterMarketOrder>>> ListOpenOrdersFromCharacterV2Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// List cancelled and expired market orders placed by a character up to 90 days in the past.
        /// <para>GET /characters/{character_id}/orders/history/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing expired and cancelled market orders placed by a character.</returns>
        Task<ESIModelDTO<List<CharacterMarketOrderHistory>>> ListHistoricalOrdersByCharacterV1Async(AuthDTO auth, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Return a list of type IDs that have active orders in the region, for efficient market indexing.
        /// <para>GET /markets/{region_id}/types/</para>
        /// </summary>
        /// <param name="regionId">Return statistics in this region.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of type IDs.</returns>
        Task<ESIModelDTO<List<long>>> ListTypeIdsRelevantToMarketV1Async(int regionId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// List open market orders placed on behalf of a corporation.
        /// <para>GET /corporations/{corporation_id}/orders/</para>
        /// <para>Requires one of the following EVE corporation role(s): Accountant, Trader</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of open market orders.</returns>
        Task<ESIModelDTO<List<CorporationMarketOrder>>> ListOpenOrdersFromCorporationV3Async(AuthDTO auth, int corporationId, int page  = 1, string ifNoneMatch = null);

        /// <summary>
        /// List cancelled and expired market orders placed on behalf of a corporation up to 90 days in the past.
        /// <para>GET /corporations/{corporation_id}/orders/history/</para>
        /// <para>Requires one of the following EVE corporation role(s): Accountant, Trader</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing expired and cancelled market orders placed on behalf of a corporation.</returns>
        Task<ESIModelDTO<List<CorporationMarketOrderHistory>>> ListHistoricalOrdersByCorporationV2Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);
    }
}