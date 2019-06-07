using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IInsurance
    {
        /// <summary>
        /// Return available insurance levels for all ship types.
        /// <para>GET /insurance/prices/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of insurance levels for all ship types.</returns>
        Task<ESIModelDTO<List<InsurancePrice>>> ListInsuranceLevelsV1Async(string ifNoneMatch = null);
    }
}