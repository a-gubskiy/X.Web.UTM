using System.Web;

namespace X.Web.UTM;

public class UTMParser
{
    public UrchinTrackingModule Parse(string url)
    {
        if (url == null)
        {
            throw new ArgumentNullException(nameof(url));
        }

        return Parse(new Uri(url));
    }

    public UrchinTrackingModule Parse(Uri url)
    {
        if (url == null)
        {
            throw new ArgumentNullException(nameof(url));
        }

        var queryParameters = HttpUtility.ParseQueryString(url.Query);
        
        var utm = new UrchinTrackingModule
        {
            Source = queryParameters["utm_source"] ?? string.Empty,
            Medium = queryParameters["utm_medium"] ?? string.Empty,
            Campaign = queryParameters["utm_campaign"] ?? string.Empty,
            Term = queryParameters["utm_term"] ?? string.Empty,
            Content = queryParameters["utm_content"] ?? string.Empty
        };

        return utm;
    }
}