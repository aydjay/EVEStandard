using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface IUserInterface
    {
        /// <summary>
        /// Set a solar system as autopilot waypoint.
        /// <para>POST /ui/autopilot/waypoint/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="addToBeginning">Whether this solar system should be added to the beginning of all waypoints. Default value: false.</param>
        /// <param name="clearOtherWaypoints">Whether clean other waypoints beforing adding this one. Default value: false.</param>
        /// <param name="destinationId">The destination to travel to, can be solar system, station or structure’s id.</param>
        /// <returns></returns>
        Task SetAutopilotWaypointV2Async(AuthDTO auth, bool addToBeginning, bool clearOtherWaypoints, long destinationId);

        /// <summary>
        /// Open the contract window inside the client.
        /// <para>POST /ui/openwindow/contract/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contractId">The contract to open.</param>
        /// <returns></returns>
        Task OpenContractWindowV1Async(AuthDTO auth, int contractId);

        /// <summary>
        /// Open the information window for a character, corporation or alliance inside the client.
        /// <para>POST /ui/openwindow/information/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="targetId">The target to open.</param>
        /// <returns></returns>
        Task OpenInformationWindowV1Async(AuthDTO auth, long targetId);

        /// <summary>
        /// Open the market details window for a specific typeID inside the client.
        /// <para>GET /ui/openwindow/marketdetails/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="typeId">The item type to open in market window.</param>
        /// <returns></returns>
        Task OpenMarketDetailsV1Async(AuthDTO auth, long typeId);

        /// <summary>
        /// Open the New Mail window, according to settings from the request if applicable.
        /// <para>GET /ui/openwindow/newmail/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mail">The details of mail to create.</param>
        /// <returns></returns>
        Task OpenNewMailWindowV1Async(AuthDTO auth, UiNewMail mail);
    }
}