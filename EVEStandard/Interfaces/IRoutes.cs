using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IRoutes
    {
        /// <summary>
        /// Get the systems between origin and destination.
        /// <para>GET /route/{origin}/{destination}/</para>
        /// </summary>
        /// <param name="origin">Origin solar system ID.</param>
        /// <param name="destination">Destination solar system ID.</param>
        /// <param name="avoidSystems">Avoid solar system ID(s).</param>
        /// <param name="connections">Connected solar system pairs.</param>
        /// <param name="flag">Route security preference. Available values : shortest, secure, insecure. Default value: shortest.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing solar systems in route from origin to destination.</returns>
        Task<ESIModelDTO<List<int>>> GetRouteV1Async(int origin, int destination, List<int> avoidSystems = null, List<int> connections = null, string flag=RoutePreference.SHORTEST, string ifNoneMatch=null);
    }
}