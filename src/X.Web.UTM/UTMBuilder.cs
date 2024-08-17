using System;
using JetBrains.Annotations;

namespace X.Web.UTM;

/// <summary>
/// Provides methods to build and append Urchin Tracking Module (UTM) parameters to a given URI.
/// </summary>
[PublicAPI]
public class UTMBuilder
{
    
    /// <summary>
    /// Constructs a new URI with UTM parameters added to the query string.
    /// </summary>
    /// <param name="uri">The base URI to which UTM parameters will be added.</param>
    /// <param name="utm">The <see cref="UrchinTrackingModule"/> object containing UTM parameters.</param>
    /// <returns>A new <see cref="Uri"/> object with UTM parameters appended to the query string.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when either <paramref name="uri"/> or <paramref name="utm"/> is null.
    /// </exception>
    public Uri Build(string uri, UrchinTrackingModule utm)
    {
        return Build(new Uri(uri), utm);
    }
    
    /// <summary>
    /// Constructs a new URI with UTM parameters added to the query string.
    /// </summary>
    /// <param name="uri">The base URI to which UTM parameters will be added.</param>
    /// <param name="utm">The <see cref="UrchinTrackingModule"/> object containing UTM parameters.</param>
    /// <returns>A new <see cref="Uri"/> object with UTM parameters appended to the query string.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when either <paramref name="uri"/> or <paramref name="utm"/> is null.
    /// </exception>
    public Uri Build(Uri uri, UrchinTrackingModule utm)
    {
        if (uri == null || utm == null)
        {
            throw new ArgumentNullException(uri == null ? "uri" : "utm");
        }

        var uriBuilder = new UriBuilder(uri);
        var queryToAppend = utm.ToString();
        
        if (string.IsNullOrEmpty(uriBuilder.Query))
        {
            uriBuilder.Query = queryToAppend;
        }
        else
        {
            if (uriBuilder.Query.Length > 1)
            {
                uriBuilder.Query = uriBuilder.Query.Substring(1) + "&" + queryToAppend;
            }
            else
            {
                uriBuilder.Query = queryToAppend;
            }
        }

        return uriBuilder.Uri;
    }

    /// <summary>
    /// Constructs a new URI with UTM parameters added to the query string using individual parameter values.
    /// </summary>
    /// <param name="uri">The base URI to which UTM parameters will be added.</param>
    /// <param name="source">The source of the traffic, a required UTM parameter.</param>
    /// <param name="medium">The medium through which the traffic was generated (e.g., email, CPC).</param>
    /// <param name="campaign">The specific campaign that refers to the promotion of products.</param>
    /// <param name="term">Identifies paid search terms.</param>
    /// <param name="content">Used to differentiate similar content, or links within the same ad.</param>
    /// <returns>A new <see cref="Uri"/> object with UTM parameters appended to the query string.</returns>
    public Uri Build(Uri uri, string source, string medium, string campaign, string term, string content)
    {
        var utm = new UrchinTrackingModule
        {
            Campaign = campaign,
            Content = content,
            Medium = medium,
            Source = source,
            Term = term
        };
        
        return Build(uri, utm);
    }
}