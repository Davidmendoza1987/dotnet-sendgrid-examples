using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SendGrid;
using SendGridExample.Net6.V1.Models;
using SendGridExample.Net6.V1.Repositories;

namespace SendGridExample.Net6.Controllers;

/// <summary>
/// Class SendGridController.
/// Implements the <see cref="ControllerBase" />
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("[controller]")]
public class SendGridController : ControllerBase
{
    /// <summary>
    /// The send grid repository
    /// </summary>
    private readonly ISendGridRepository sendGridRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="SendGridController"/> class.
    /// </summary>
    /// <param name="sendGridRepository">The send grid repository.</param>
    public SendGridController(ISendGridRepository sendGridRepository) => this.sendGridRepository = sendGridRepository;

    /// <summary>
    /// Sends the email.
    /// PlainTextContent or HtmlContent is required.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>ActionResult&lt;Response&gt;.</returns>
    [HttpPost("send-email")]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<ActionResult<Response>> SendEmail([FromBody, BindRequired] SendEmailRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.PlainTextContent) &&
            string.IsNullOrWhiteSpace(request.HtmlContent))
        {
            return BadRequest("Either PlainTextContent or HtmlContent must be provided.");
        }

        var response = await sendGridRepository.SendTransactionEmailAsync(request);
        return StatusCode((int)response.StatusCode, response);
    }
}
