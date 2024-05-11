# X.Web.UTM

**X.Web.UTM** is a versatile .NET library designed for efficiently handling Urchin Tracking Module (UTM) parameters, crucial for tracking web traffic sources in digital marketing. This library allows developers to parse, construct, and append UTM parameters to URLs, enhancing the capability to track the effectiveness of online advertising campaigns directly through the URL's query string.

## Key Features:
- **Flexible UTM Parameter Management:** Easily create and manage UTM parameters with the `UrchinTrackingModule` class, which supports setting and retrieving properties such as `Source`, `Medium`, `Campaign`, `Term`, and `Content`.
- **Dynamic URL Building:** Utilize the `UTMBuilder` class to seamlessly append UTM parameters to existing URIs, ensuring all marketing and tracking information is accurately included in URLs.
- **Robust Error Handling:** Implements checks and throws exceptions to prevent errors in URL construction when essential parameters are missing.

## Use Cases:
- **Campaign Tracking:** Perfect for marketers and developers looking to gauge the effectiveness of various marketing campaigns by tracking where traffic is coming from.
- **A/B Testing:** Optimize digital marketing strategies by adjusting UTM parameters for different ad variants and directly measuring performance.
