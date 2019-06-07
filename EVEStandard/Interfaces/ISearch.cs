using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface ISearch
    {
        /// <summary>
        /// Search for entities that match a given sub-string.
        /// <para>GET /characters/{character_id}/search/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="categories">Type of entities to search for. Available values : agent, alliance, character, constellation, corporation, faction, inventory_type, region, solar_system, station, structure.</param>
        /// <param name="search">The string to search on.</param>
        /// <param name="strict">Whether the search should be a strict match. Default value : false.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of search results.</returns>
        Task<ESIModelDTO<CharacterSearch>> SearchCharacterV3Async(AuthDTO auth, List<string> categories, string search, bool strict = false, string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// Search for entities that match a given sub-string.
        /// </summary>
        /// <param name="categories">Type of entities to search for. Available values : agent, alliance, character, constellation, corporation, faction, inventory_type, region, solar_system, station, structure.</param>
        /// <param name="search">The string to search on.</param>
        /// <param name="strict">Whether the search should be a strict match. Default value : false.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of search results.</returns>
        Task<ESIModelDTO<Models.Search>> SearchV2Async(List<string> categories, string search, bool strict = false, string language = Language.English, string ifNoneMatch=null);
    }
}