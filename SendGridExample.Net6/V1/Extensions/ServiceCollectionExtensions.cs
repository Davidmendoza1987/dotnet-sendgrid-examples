using SendGrid;
using SendGrid.Extensions.DependencyInjection;
using SendGridExample.Net6.V1.Repositories;

namespace SendGridExample.Net6.V1.Extensions;

/// <summary>
/// Class ServiceCollectionExtensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the third party services.
    /// </summary>
    /// <param name="servicesCollection">The services collection.</param>
    /// <returns>IServiceCollection.</returns>
    /// <exception cref="System.ArgumentNullException">SendGrid API key has not been configured</exception>
    public static IServiceCollection AddThirdPartyServices(this IServiceCollection servicesCollection)
    {
        var sendGridApiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        if (sendGridApiKey is null)
        {
            throw new ArgumentNullException(sendGridApiKey, "SendGrid API key has not been configured"); 
        }

        servicesCollection.AddSendGrid(options => options.ApiKey = sendGridApiKey);

        return servicesCollection;
    }

    /// <summary>
    /// Adds the repositories.
    /// </summary>
    /// <param name="servicesCollection">The services collection.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddTransient<ISendGridRepository, SendGridRepository>(x =>
            new SendGridRepository(x.GetRequiredService<ISendGridClient>()));

        return servicesCollection;
    }

}
