using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IContracts
    {
        /// <summary>
        /// Returns contracts available to a character, only if the character is issuer, acceptor or assignee. 
        /// Only returns contracts no older than 30 days, or if the status is "in_progress".
        /// <para>GET /characters/{character_id}/contracts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contracts.</returns>
        Task<ESIModelDTO<List<Contract>>> GetContractsV1Async(AuthDTO auth, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Lists items of a particular contract.
        /// <para>GET /characters/{character_id}/contracts/{contract_id}/items/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contractId">ID of a contract.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of items in this contract.</returns>
        Task<ESIModelDTO<List<ContractItem>>> GetContractItemsV1Async(AuthDTO auth, int contractId, string ifNoneMatch = null);

        /// <summary>
        /// Lists bids on a particular auction contract.
        /// <para>GET /characters/{character_id}/contracts/{contract_id}/bids/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contractId">ID of a contract.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bids.</returns>
        Task<ESIModelDTO<List<ContractBid>>> GetContractBidsV1Async(AuthDTO auth, int contractId, string ifNoneMatch = null);

        /// <summary>
        /// Returns a paginated list of all public contracts in the given region.
        /// <para>GET /v1/contracts/public/{region_id}/</para>
        /// </summary>
        /// <param name="regionId">An EVE region id.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contracts.</returns>
        Task<ESIModelDTO<List<Contract>>> GetPublicContractsV1Async(int regionId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Lists bids on a public auction contract.
        /// <para>GET /v1/contracts/public/bids/{contract_id}/</para>
        /// </summary>
        /// <param name="contractId">ID of a contract.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bids.</returns>
        Task<ESIModelDTO<List<ContractBid>>> GetPublicContractBidsV1Async(int contractId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Lists items of a public contract.
        /// </summary>
        /// <param name="contractId">ID of a contract.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of items in this contract.</returns>
        Task<ESIModelDTO<List<ContractItem>>> GetPublicContractItemsV1Async(int contractId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Returns contracts available to a corporation, only if the corporation is issuer, acceptor or assignee. 
        /// Only returns contracts no older than 30 days, or if the status is "in_progress".
        /// <para>GET /corporations/{corporation_id}/contracts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contracts.</returns>
        Task<ESIModelDTO<List<Contract>>> GetCorporationContractsV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Lists items of a particular contract.
        /// <para>GET /corporations/{corporation_id}/contracts/{contract_id}/items/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contractId">ID of a contract.</param>
        /// <param name="corporationId">An EVE corporation ID</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of items in this contract.</returns>
        Task<ESIModelDTO<List<ContractItem>>> GetCorporationContractItemsV1Async(AuthDTO auth, int contractId, int corporationId, string ifNoneMatch = null);

        /// <summary>
        /// Lists bids on a particular auction contract.
        /// <para>GET /corporations/{corporation_id}/contracts/{contract_id}/bids/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contractId">ID of a contract.</param>
        /// <param name="corporationId">An EVE corporation ID</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bids.</returns>
        Task<ESIModelDTO<List<ContractBid>>> GetCorporationContractBidsV1Async(AuthDTO auth, int contractId, int corporationId, int page = 1, string ifNoneMatch = null);
    }
}