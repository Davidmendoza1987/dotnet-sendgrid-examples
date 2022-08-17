using SendGrid;
using SendGrid.Helpers.Mail;
using SendGridExample.Net6.V1.Models;

namespace SendGridExample.Net6.V1.Repositories;

/// <summary>
/// Interface ISendGridRepository
/// </summary>
public interface ISendGridRepository
{
    /// <summary>
    /// Sends the transaction email asynchronous.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>Task&lt;Response&gt;.</returns>
    Task<Response> SendTransactionEmailAsync(SendEmailRequest request);
}

/// <summary>
/// Class SendGridRepository.
/// Implements the <see cref="ISendGridRepository" />
/// </summary>
/// <seealso cref="ISendGridRepository" />
public class SendGridRepository : ISendGridRepository
{
    /// <summary>
    /// The send grid client
    /// </summary>
    private readonly ISendGridClient sendGridClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="SendGridRepository"/> class.
    /// </summary>
    /// <param name="sendGridClient">The send grid client.</param>
    public SendGridRepository(ISendGridClient sendGridClient) => this.sendGridClient = sendGridClient;

    /// <summary>
    /// Send transaction email as an asynchronous operation.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>A Task&lt;Response&gt; representing the asynchronous operation.</returns>
    public async Task<Response> SendTransactionEmailAsync(SendEmailRequest request)
    {
        var toAddresses = request.To.Select(n => new EmailAddress(n)).ToList();
        var fromAddress = new EmailAddress(request.From, request.FromName);
        var msg = MailHelper.CreateSingleEmailToMultipleRecipients(fromAddress, toAddresses, request.Subject, request.PlainTextContent, request.HtmlContent, request.ShowAllRecipients!.Value);

        return await sendGridClient.SendEmailAsync(msg);
    }
}
