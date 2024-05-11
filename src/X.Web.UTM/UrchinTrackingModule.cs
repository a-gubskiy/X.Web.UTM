using JetBrains.Annotations;

namespace X.Web.UTM;

/// <summary>
/// https://en.wikipedia.org/wiki/UTM_parameters
/// </summary>
[PublicAPI]
public class UrchinTrackingModule
{
    public UrchinTrackingModule()
    {
        Source = string.Empty;
        Medium = string.Empty;
        Campaign = string.Empty;
        Term = string.Empty;
        Content = string.Empty;
    }

    /// <summary>
    /// utm_source	Identifies which site sent the traffic, and is a required parameter.
    /// Example: utm_source=google
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// utm_medium	Identifies what type of link was used, such as Pay-per-click or email.
    /// Example: utm_medium=ppc
    /// </summary>
    public string Medium { get; set; }

    /// <summary>
    /// utm_campaign identifies a specific product promotion or strategic campaign.
    /// Example: utm_campaign=spring_sale
    /// </summary>
    public string Campaign { get; set; }

    /// <summary>
    /// utm_term identifies search terms.	utm_term=running+shoes
    /// </summary>
    public string Term { get; set; }

    /// <summary>
    /// utm_content	identifies what specifically was clicked to bring the user to the site, such as a banner ad or
    /// a text link. It is often used for A/B testing and content-targeted ads.
    /// Example: utm_content=logolink or utm_content=textlink
    /// </summary>
    public string Content { get; set; }

    public override string ToString()
    {
        var components = new List<string>();

        if (!string.IsNullOrEmpty(Source))
        {
            components.Add($"utm_source={Source}");
        }
        
        if (!string.IsNullOrEmpty(Medium))
        {
            components.Add($"utm_medium={Medium}");
        }
        
        if (!string.IsNullOrEmpty(Campaign))
        {
            components.Add($"utm_campaign={Campaign}");
        }
        
        if (!string.IsNullOrEmpty(Term))
        {
            components.Add($"utm_term={Term}");
        }
        
        if (!string.IsNullOrEmpty(Content))
        {
            components.Add($"utm_content={Content}");
        }

        var result = string.Join("&", components);
        
        return result;
    }
}