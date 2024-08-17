using System;
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
            Source = queryParameters[UtmComponents.Source] ?? string.Empty,
            Medium = queryParameters[UtmComponents.Medium] ?? string.Empty,
            Campaign = queryParameters[UtmComponents.Campaign] ?? string.Empty,
            Term = queryParameters[UtmComponents.Term] ?? string.Empty,
            Content = queryParameters[UtmComponents.Content] ?? string.Empty
        };

        return utm;
    }
}