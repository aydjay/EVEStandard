using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IBookmarks
    {
        /// <summary>
        /// A list of your character’s personal bookmarks.
        /// <para>GET /characters/{character_id}/bookmarks/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bookmarks.</returns>
        Task<ESIModelDTO<List<Bookmark>>> ListBookmarksV2Async(AuthDTO auth, int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// A list of your character’s personal bookmark folders.
        /// <para>GET /characters/{character_id}/bookmarks/folders/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bookmark folders.</returns>
        Task<ESIModelDTO<List<BookmarkFolder>>> ListBookmarkFoldersV2Async(AuthDTO auth, int page=1, string ifNoneMatch = null);

        /// <summary>
        /// A list of your corporation’s bookmarks.
        /// <para>GET /corporations/{corporation_id}/bookmarks/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation owned bookmarks.</returns>
        Task<ESIModelDTO<List<Bookmark>>> ListCorporationBookmarksV1Async(AuthDTO auth, int corporationId, int page=1, string ifNoneMatch = null);

        /// <summary>
        /// A list of your corporation’s bookmark folders.
        /// <para>GET /corporations/{corporation_id}/bookmarks/folders/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation owned bookmark folders.</returns>
        Task<ESIModelDTO<List<BookmarkFolder>>> ListCorporationBookmarkFoldersV1Async(AuthDTO auth, int corporationId, int page=1, string ifNoneMatch = null);
    }
}