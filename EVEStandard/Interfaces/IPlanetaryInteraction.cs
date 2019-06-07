using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IPlanetaryInteraction
    {
        /// <summary>
        /// Returns a list of all planetary colonies owned by a character.
        /// <para>GET /characters/{character_id}/planets/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of colonies.</returns>
        Task<ESIModelDTO<List<Colony>>> GetColoniesV1Async(AuthDTO auth, string ifNoneMatch=null);

        /// <summary>
        /// Returns full details on the layout of a single planetary colony, including links, pins and routes. 
        /// Note: Planetary information is only recalculated when the colony is viewed through the client. 
        /// Information will not update until this criteria is met.
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="planetId">Planet id of the target planet.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a colony layout.</returns>
        Task<ESIModelDTO<ColonyLayout>> GetColonyLayoutV3Async(AuthDTO auth, int planetId, string ifNoneMatch = null);

        /// <summary>
        /// Get information on a planetary factory schematic.
        /// <para>GET /universe/schematics/{schematic_id}/</para>
        /// </summary>
        /// <param name="schematicId">A PI schematic ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing public data about a schematic.</returns>
        Task<ESIModelDTO<FactorySchematic>> GetSchematicInfoV1Async(int schematicId, string ifNoneMatch=null);

        /// <summary>
        /// Lists the corporation customs offices v1 asynchronous.
        /// <para>GET /corporations/{corporation_id}/customs_offices/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">The corporation identifier.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of customs offices and their settings.</returns>
        Task<ESIModelDTO<List<CustomsOffice>>> ListCorporationCustomsOfficesV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch=null);
    }
}