using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IWallet
    {
        /// <summary>
        /// Returns a character’s wallet balance.
        /// <para>GET /characters/{character_id}/wallet/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing wallet balance.</returns>
        Task<ESIModelDTO<double>> GetCharacterWalletBalanceV1Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Retrieve the given character’s wallet journal going 30 days back.
        /// <para>GET /characters/{character_id}/wallet/journal/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing journal entries.</returns>
        Task<ESIModelDTO<List<CharacterWalletJournal>>> GetCharacterWalletJournalV6Async(AuthDTO auth, int page, string ifNoneMatch = null);

        /// <summary>
        /// Get wallet transactions of a character.
        /// <para>GET /characters/{character_id}/wallet/transactions/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fromId">Only show transactions happened before the one referenced by this id.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing wallet transactions.</returns>
        Task<ESIModelDTO<List<WalletTransaction>>> GetCharacterWalletTransactionsV1Async(AuthDTO auth, long fromId, string ifNoneMatch = null);

        /// <summary>
        /// Get a corporation’s wallets.
        /// <para>GET /corporations/{corporation_id}/wallets/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of corporation wallets.</returns>
        Task<ESIModelDTO<List<CorporationWallet>>> ReturnCorporationWalletBalanceV1Async(AuthDTO auth, int corpId, string ifNoneMatch = null);

        /// <summary>
        /// Retrieve the given corporation’s wallet journal for the given division going 30 days back.
        /// <para>GET /corporations/{corporation_id}/wallets/{division}/journal/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <param name="division">Wallet key of the division to fetch journals from.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing journal entries.</returns>
        Task<ESIModelDTO<List<CorporationWalletJournal>>> GetCorporationWalletJournalV4Async(AuthDTO auth, int corpId, int division, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Get wallet transactions of a corporation.
        /// <para>GET /corporations/{corporation_id}/wallets/{division}/transactions/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <param name="division">Wallet key of the division to fetch journals from.</param>
        /// <param name="fromId">Only show transactions happened before the one referenced by this id.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing wallet transactions.</returns>
        Task<ESIModelDTO<List<WalletTransaction>>> GetCorporationWalletTransactionsV1Async(AuthDTO auth, int corpId, int division, long fromId, string ifNoneMatch = null);
    }
}