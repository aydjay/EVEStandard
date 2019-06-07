﻿using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Interfaces;

namespace EVEStandard.API
{
    /// <summary>
    /// Fittings API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Fittings : APIBase, IFittings
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Fittings>();

        internal Fittings(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Delete a fitting from a character.
        /// <para>DELETE /characters/{character_id}/fittings/{fitting_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fittingId">ID for a fitting of this character.</param>
        /// <returns></returns>
        public async Task DeleteFittingV1Async(AuthDTO auth, long fittingId)
        {
            CheckAuth(auth, Scopes.ESI_FITTINGS_WRITE_FITTINGS_1);

            var responseModel = await DeleteAsync($"/v1/characters/{auth.CharacterId}/fittings/{fittingId}/", auth);

            CheckResponse("DeleteFittingV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Return fittings of a character.
        /// <para>GET /characters/{character_id}/fittings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fittings.</returns>
        public async Task<ESIModelDTO<List<ShipFitting>>> GetFittingsV2Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_FITTINGS_READ_FITTINGS_1);

            var responseModel = await GetAsync($"/v2/characters/{auth.CharacterId}/fittings/", auth, ifNoneMatch);

            CheckResponse(nameof(GetFittingsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<ShipFitting>>(responseModel);
        }

        /// <summary>
        /// Save a new fitting for a character.
        /// <para>POST /characters/{character_id}/fittings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fitting">Details about the new fitting.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fittings.</returns>
        public async Task<ESIModelDTO<ShipFittingCreated>> CreateFittingV2Async(AuthDTO auth, ShipFitting fitting)
        {
            CheckAuth(auth, Scopes.ESI_FITTINGS_READ_FITTINGS_1);

            var responseModel = await PostAsync($"/v2/characters/{auth.CharacterId}/fittings/", auth, fitting);

            CheckResponse(nameof(CreateFittingV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<ShipFittingCreated>(responseModel);
        }
    }
}
