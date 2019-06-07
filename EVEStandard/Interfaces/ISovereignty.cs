using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface ISovereignty
    {
        /// <summary>
        /// Shows sovereignty data for structures.
        /// <para>GET /sovereignty/structures/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of sovereignty structures.</returns>
        Task<ESIModelDTO<List<SovereigntyStructure>>> ListSovereigntyStructuresV1Async(string ifNoneMatch=null);

        /// <summary>
        /// Shows sovereignty data for campaigns.
        /// <para>GET /sovereignty/campaigns/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of sovereignty campaigns.</returns>
        Task<ESIModelDTO<List<SovereigntyCampaign>>> ListSovereigntyCampaignsV1Async(string ifNoneMatch = null);

        /// <summary>
        /// Shows sovereignty information for solar systems.
        /// <para>GET /sovereignty/map/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of sovereignty information for solar systems in New Eden.</returns>
        Task<ESIModelDTO<List<SovereigntyMap>>> ListSovereigntyOfSystemsV1Async(string ifNoneMatch = null);
    }
}