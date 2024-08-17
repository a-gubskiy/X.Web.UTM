using JetBrains.Annotations;

namespace X.Web.UTM;

/// <summary>
/// Contains standard values for the "utm_medium" parameter used in UTM tracking.
/// </summary>
[PublicAPI]
public static class UtmMedium
{
    /// <summary>
    /// Email marketing campaigns.
    /// </summary>
    public const string Email = "email";

    /// <summary>
    /// Cost-per-click, typically used for paid search campaigns (e.g., Google Ads).
    /// </summary>
    public const string CPC = "cpc";

    /// <summary>
    /// Organic search traffic (non-paid).
    /// </summary>
    public const string Organic = "organic";

    /// <summary>
    /// Social media traffic, both paid and organic.
    /// </summary>
    public const string Social = "social";

    /// <summary>
    /// Referral traffic from another website through a link.
    /// </summary>
    public const string Referral = "referral";

    /// <summary>
    /// Display ads, such as banner ads.
    /// </summary>
    public const string Display = "display";

    /// <summary>
    /// Affiliate marketing efforts.
    /// </summary>
    public const string Affiliate = "affiliate";

    /// <summary>
    /// Video marketing efforts.
    /// </summary>
    public const string Video = "video";

    /// <summary>
    /// Push notifications.
    /// </summary>
    public const string Push = "push";

    /// <summary>
    /// Offline print materials, such as flyers or brochures.
    /// </summary>
    public const string Print = "print";

    /// <summary>
    /// SMS marketing campaigns.
    /// </summary>
    public const string SMS = "sms";

    /// <summary>
    /// Specifically for paid social media ads.
    /// </summary>
    public const string PaidSocial = "paid_social";
}