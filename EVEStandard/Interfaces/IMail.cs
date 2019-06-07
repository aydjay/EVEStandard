using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Mail = EVEStandard.API.Mail;

namespace EVEStandard.Interfaces
{
    public interface IMail
    {
        /// <summary>
        /// Return the 50 most recent mail headers belonging to the character that match the query criteria. 
        /// Queries can be filtered by label, and last_mail_id can be used to paginate backwards.
        /// <para>GET /characters/{character_id}/mail/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="labels">Fetch only mails that match one or more of the given labels.</param>
        /// <param name="lastMailId">List only mail with an ID lower than the given ID, if present.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the requested mail.</returns>
        Task<ESIModelDTO<List<Mail>>> ReturnMailHeadersV1Async(AuthDTO auth, List<long> labels, long lastMailId, string ifNoneMatch = null);

        /// <summary>
        /// Create and send a new mail.
        /// <para>POST /characters/{character_id}/mail/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mail">The mail to send.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the id of the sent mail.</returns>
        Task<ESIModelDTO<int>> SendNewMailV1Async(AuthDTO auth, NewMail mail);

        /// <summary>
        /// Return a list of the users mail labels, unread counts for each label and a total unread count.
        /// <para>GET /characters/{character_id}/mail/labels/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of mail labels and unread counts.</returns>
        Task<ESIModelDTO<UnreadMail>> GetMailLabelsAndUnreadCountsV3Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Create a mail label.
        /// <para>POST /characters/{character_id}/mail/labels/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="labelName">Label to create.</param>
        /// <param name="labelHexColor">Hexadecimal string representing label color, in RGB format.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing id of the created label.</returns>
        Task<ESIModelDTO<long>> CreateMailLabelV2Async(AuthDTO auth, string labelName, string labelHexColor);

        /// <summary>
        /// Delete a mail label.
        /// <para>DELETE /characters/{character_id}/mail/labels/{label_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="labelId">An EVE label id.</param>
        /// <returns></returns>
        Task DeleteMailLabelV1Async(AuthDTO auth, long labelId);

        /// <summary>
        /// Return all mailing lists that the character is subscribed to.
        /// <para>GET /characters/{character_id}/mail/lists/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing mailing lists.</returns>
        Task<ESIModelDTO<List<MailList>>> ReturnMailingListSubscriptionsV1Async(AuthDTO auth, string ifNoneMatch = null);

        /// <summary>
        /// Delete a mail.
        /// <para>DELETE /characters/{character_id}/mail/{mail_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mailId">An EVE mail ID.</param>
        /// <returns></returns>
        Task DeleteMailV1Async(AuthDTO auth, long mailId);

        /// <summary>
        /// Return the contents of an EVE mail.
        /// <para>GET /characters/{character_id}/mail/{mail_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mailId">An EVE mail ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing contents of a mail.</returns>
        Task<ESIModelDTO<MailContent>> ReturnMailV1Async(AuthDTO auth, long mailId, string ifNoneMatch = null);

        /// <summary>
        /// Update metadata about a mail.
        /// <para>PUT /characters/{character_id}/mail/{mail_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mailId">An EVE mail ID.</param>
        /// <param name="contents">Data used to update the mail.</param>
        /// <returns></returns>
        Task UpdateMetadataAboutMailV1Async(AuthDTO auth, long mailId, UpdateMailMetadata contents);
    }
}