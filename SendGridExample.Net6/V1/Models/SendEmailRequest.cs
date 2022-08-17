using System.ComponentModel.DataAnnotations;

namespace SendGridExample.Net6.V1.Models;

/// <summary>
/// Class SendEmailRequest.
/// </summary>
public class SendEmailRequest
{
    /// <summary>
    /// Gets or sets to.
    /// </summary>
    /// <value>To.</value>
    [Required]
    public List<string> To { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets from.
    /// </summary>
    /// <value>From.</value>
    /// <example>Something</example>
    [Required]
    public string From { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets from name.
    /// </summary>
    /// <value>From name.</value>
    /// <example>Something</example>
    [Required]
    public string FromName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the subject.
    /// </summary>
    /// <value>The subject.</value>
    /// <example>Something</example>
    [Required]
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the content of the plain text.
    /// Will not appear if HTML Content is provided.
    /// </summary>
    /// <value>The content of the plain text.</value>
    /// <example>Something</example>
    public string? PlainTextContent { get; set; }

    /// <summary>
    /// Gets or sets the content of the HTML.
    /// Will override Plain Text Content.
    /// </summary>
    /// <value>The content of the HTML.</value>
    /// <example>Something</example>
    public string? HtmlContent { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [show all recipients].
    /// Defaults to <c>false</c>.
    /// </summary>
    /// <value><c>null</c> if [show all recipients] contains no value, <c>true</c> if [show all recipients]; otherwise, <c>false</c>.</value>
    /// <example>true</example>
    public bool? ShowAllRecipients { get; set; } = false;
}
