using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;

namespace EVEStandard.Interfaces
{
    public interface ICalendar
    {
        /// <summary>
        /// Get 50 event summaries from the calendar. 
        /// If no from_event ID is given, the resource will return the next 50 chronological event summaries from now. 
        /// If a from_event ID is specified, it will return the next 50 chronological event summaries from after that event.
        /// <para>GET /characters/{character_id}/calendar/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fromEventId">The event ID to retrieve events from.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a collection of event summaries.</returns>
        Task<ESIModelDTO<List<EventSummary>>> ListCalendarEventSummariesV1Async(AuthDTO auth, long? fromEventId = null, string ifNoneMatch = null);

        /// <summary>
        /// Get all the information for a specific event.
        /// <para>GET /characters/{character_id}/calendar/{event_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="eventId">The id of the event requested.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing full details of a specific event.</returns>
        Task<ESIModelDTO<Event>> GetAnEventV3Async(AuthDTO auth, long eventId, string ifNoneMatch = null);

        /// <summary>
        /// Set your response status to an event.
        /// <para>PUT /characters/{character_id}/calendar/{event_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="eventId">The id of the event requested.</param>
        /// <param name="response">The response value to set, overriding current value.</param>
        /// <returns></returns>
        Task RespondToAnEventV3Async(AuthDTO auth, long eventId, EventResponse response);

        /// <summary>
        /// Get all invited attendees for a given event.
        /// <para>GET /characters/{character_id}/calendar/{event_id}/attendees/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="eventId">The id of the event requested.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of attendees.</returns>
        Task<ESIModelDTO<List<EventAttendee>>> GetAttendeesV1Async(AuthDTO auth, long eventId, string ifNoneMatch = null);
    }
}