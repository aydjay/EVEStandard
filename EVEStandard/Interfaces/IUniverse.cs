using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Universe = EVEStandard.API.Universe;

namespace EVEStandard.Interfaces
{
    public interface IUniverse
    {
        /// <summary>
        /// Get all character ancestries.
        /// <para>GET /universe/ancestries/</para>
        /// </summary>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of ancestries.</returns>
        Task<ESIModelDTO<List<Ancestry>>> GetAncestriesV1Async(string language = Language.English, string ifNoneMatch=null);

        /// <summary>
        /// Get information on an asteroid belt.
        /// <para>GET /universe/asteroid_belts/{asteroid_belt_id}/</para>
        /// </summary>
        /// <param name="asteroidBeltId">The asteroid belt identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about an asteroid belt.</returns>
        Task<ESIModelDTO<AsteroidBelt>> GetAsteroidBeltV1Async(int asteroidBeltId, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of bloodlines.
        /// <para>GET /universe/bloodlines/</para>
        /// </summary>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bloodlines.</returns>
        Task<ESIModelDTO<List<Bloodline>>> GetBloodlinesV1Async(string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of item categories.
        /// <para>GET /universe/categories/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of item category ids.</returns>
        Task<ESIModelDTO<List<int>>> GetItemCategoriesV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Get information of an item category.
        /// <para>GET /universe/categories/{category_id}/</para>
        /// </summary>
        /// <param name="categoryId">An Eve item category ID.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about an item category.</returns>
        Task<ESIModelDTO<Category>> GetItemCategoryInfoV1Async(int categoryId, string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of constellations.
        /// <para>GET /universe/constellations/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of constellation ids.</returns>
        Task<ESIModelDTO<List<int>>> GetConstellationsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Get information on a constellation.
        /// <para>GET /universe/constellations/{constellation_id}/</para>
        /// </summary>
        /// <param name="constellationId">The constellation identifier.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a constellation.</returns>
        Task<ESIModelDTO<Constellation>> GetConstellationV1Async(int constellationId, string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of factions.
        /// <para>GET /universe/factions/</para>
        /// </summary>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of factions.</returns>
        Task<ESIModelDTO<List<Faction>>> GetFactionsV2Async(string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of graphics.
        /// <para>GET /universe/graphics/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of graphic ids.</returns>
        Task<ESIModelDTO<List<int>>> GetGraphicsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Get information on a graphic.
        /// <para>GET /universe/graphics/{graphic_id}/</para>
        /// </summary>
        /// <param name="graphicId">The graphic identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a graphic.</returns>
        Task<ESIModelDTO<Graphic>> GetGraphicV1Async(int graphicId, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of item groups.
        /// <para>GET /universe/groups</para>
        /// </summary>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of item group ids.</returns>
        Task<ESIModelDTO<List<int>>> GetItemGroupsV1Async(int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Get information on an item group.
        /// <para>GET /universe/groups/{group_id}/</para>
        /// </summary>
        /// <param name="groupId">An Eve item group ID.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of factions.</returns>
        Task<ESIModelDTO<Group>> GetItemGroupV1Async(int groupId, string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// Resolve a set of names to IDs in the following categories: agents, alliances, characters, constellations, corporations factions, inventory_types, regions, stations, and systems. 
        /// Only exact matches will be returned. All names searched for are cached for 12 hours.
        /// <para>POST /universe/ids/</para>
        /// </summary>
        /// <param name="names">The names to resolve.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of factions.</returns>
        Task<ESIModelDTO<Models.Universe>> BulkNamesToIdsV1Async(List<string> names, string language = Language.English);

        /// <summary>
        /// Get information on a moon.
        /// <para>GET /universe/moons/{moon_id}/</para>
        /// </summary>
        /// <param name="moonId">The moon identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a moon.</returns>
        Task<ESIModelDTO<Moon>> GetMoonInfoV1Async(long moonId, string ifNoneMatch = null);

        /// <summary>
        /// Resolve a set of IDs to names and categories. Supported ID’s for resolving are: Characters, Corporations, Alliances, Stations, Solar Systems, Constellations, Regions, Types, Factions.
        /// <para>POST /universe/names/</para>
        /// </summary>
        /// <param name="ids">The ids to resolve.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of id/name associations for a set of ID’s. All ID’s must resolve to a name, or nothing will be returned.</returns>
        Task<ESIModelDTO<List<UniverseIdsToNames>>> GetNamesAndCategoriesFromIdsV3Async(List<int> ids);

        /// <summary>
        /// Get information on a planet.
        /// <para>GET /universe/planets/{planet_id}/</para>
        /// </summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a planet.</returns>
        Task<ESIModelDTO<Planet>> GetPlanetInfoV1Async(long planetId, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of character races.
        /// <para>GET /universe/races/</para>
        /// </summary>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of character races.</returns>
        Task<ESIModelDTO<List<Race>>> GetCharacterRacesV1Async(string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of regions.
        /// <para>GET /universe/regions</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of region ids.</returns>
        Task<ESIModelDTO<List<int>>> GetRegionsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Get information on a region.
        /// <para>GET /universe/regions/{region_id}/</para>
        /// </summary>
        /// <param name="regionId">The region identifier.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a region.</returns>
        Task<ESIModelDTO<Region>> GetRegionInfoV1Async(int regionId, string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// Get information on a stargate.
        /// <para>GET /universe/stargates/{stargate_id}/</para>
        /// </summary>
        /// <param name="stargateId">The stargate identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a region.</returns>
        Task<ESIModelDTO<Stargate>> GetStargateInfoV1Async(int stargateId, string ifNoneMatch = null);

        /// <summary>
        /// Get information on a star.
        /// <para>GET /universe/stars/{star_id}/</para>
        /// </summary>
        /// <param name="starId">The star identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a star.</returns>
        Task<ESIModelDTO<Star>> GetStarInfoV1Async(int starId, string ifNoneMatch = null);

        /// <summary>
        /// Get information on a station.
        /// <para>GET /universe/structures/</para>
        /// </summary>
        /// <param name="stationId">The station identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a station.</returns>
        Task<ESIModelDTO<Station>> GetStationInfoV2Async(int stationId, string ifNoneMatch = null);

        /// <summary>
        /// List all public structures.
        /// <para>GET /universe/structures</para>
        /// </summary>
        /// <param name="filter">Optional param to return structures that only have a market or basic manufacturing.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of public structure IDs.</returns>
        Task<ESIModelDTO<List<long>>> ListAllPublicStructuresV1Async(Universe.StructureHas filter, string ifNoneMatch = null);

        /// <summary>
        /// Returns information on requested structure, if you are on the ACL. Otherwise, returns “Forbidden” for all inputs.
        /// <para>GET /universe/structures/{structure_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="structureId">An Eve structure ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing data about a structure.</returns>
        Task<ESIModelDTO<Structure>> GetStructureInfoV2Async(AuthDTO auth, long structureId, string ifNoneMatch = null);

        /// <summary>
        /// Get the number of jumps in solar systems within the last hour ending at the timestamp of the Last-Modified header, excluding wormhole space. Only systems with jumps will be listed.
        /// <para>GET /universe/system_jumps/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of systems and number of jumps.</returns>
        Task<ESIModelDTO<List<SystemJumps>>> GetSystemJumpsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Get the number of ship, pod and NPC kills per solar system within the last hour ending at the timestamp of the Last-Modified header, excluding wormhole space. Only systems with kills will be listed.
        /// <para>GET /universe/system_kills/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of systems and number of ship, pod and NPC kills.</returns>
        Task<ESIModelDTO<List<SystemKills>>> GetSystemKillsV2Async(string ifNoneMatch = null);

        /// <summary>
        /// Get a list of solar systems.
        /// <para>GET /universe/systems/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of solar system ids.</returns>
        Task<ESIModelDTO<List<int>>> GetSolarSystemsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Get information on a solar system. NOTE: This route does not work with abyssal systems.
        /// <para>GET /universe/systems/{system_id}/</para>
        /// </summary>
        /// <param name="systemId">The system identifier.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a solar system.</returns>
        Task<ESIModelDTO<Models.System>> GetSolarSystemInfoV4Async(int systemId, string language = Language.English, string ifNoneMatch = null);

        /// <summary>
        /// Get a list of type ids.
        /// <para>GET /universe/types</para>
        /// </summary>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of type ids.</returns>
        Task<ESIModelDTO<List<int>>> GetTypesV1Async(int page = 1, string ifNoneMatch = null);

        /// <summary>
        /// Get information on a type.
        /// <para>GET /universe/types/{type_id}/</para>
        /// </summary>
        /// <param name="typeId">An Eve item type ID.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a type.</returns>
        Task<ESIModelDTO<Type>> GetTypeInfoV3Async(int typeId, string language = Language.English, string ifNoneMatch = null);
    }
}