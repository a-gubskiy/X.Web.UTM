# X.Web.UTM

[![Sponsor on GitHub](https://img.shields.io/badge/Sponsor_on_GitHub-ff7f00?logo=github&logoColor=white&style=for-the-badge)](https://github.com/sponsors/a-gubskiy)
[![Subscribe on X](https://img.shields.io/badge/Subscribe_on_X-000000?logo=x&logoColor=white&style=for-the-badge)](https://x.com/andrew_gubskiy)
[![NuGet Downloads](https://img.shields.io/nuget/dt/X.Web.UTM?style=for-the-badge&label=NuGet%20Downloads&color=004880&logo=nuget&logoColor=white)](https://www.nuget.org/packages/X.Web.UTM)

**X.Web.UTM** is a versatile .NET library designed to efficiently handle Urchin Tracking Module (UTM) parameters, 
which are crucial for tracking web traffic sources in digital marketing. This library allows developers to parse, 
construct, and append UTM parameters to URLs, enhancing the capability to track the effectiveness of online advertising
campaigns directly through the URL's query string.

## Key Features:
- **Flexible UTM Parameter Management:** Easily create and manage UTM parameters with the `UrchinTrackingModule` class, which supports setting and retrieving properties such as `Source`, `Medium`, `Campaign`, `Term`, and `Content`.
- **Dynamic URL Building:** Utilize the `UTMBuilder` class to seamlessly append UTM parameters to existing URIs, ensuring all marketing and tracking information is accurately included in URLs.
- **Robust Error Handling:** Implements checks and throws exceptions to prevent errors in URL construction when essential parameters are missing.

## Use Cases:
- **Campaign Tracking:** Perfect for marketers and developers looking to gauge the effectiveness of various marketing campaigns by tracking where traffic is coming from.
- **A/B Testing:** Optimize digital marketing strategies by adjusting UTM parameters for different ad variants and directly measuring performance.

## Installation

You can install the library via NuGet:

```bash
dotnet add package X.Web.UTM
```

## Usage Samples

### 1. Building a URL with UTM Parameters

```csharp
var utm = new UrchinTrackingModule
{
    Source = "google",
    Medium = "cpc",
    Campaign = "spring_sale",
    Term = "running shoes",
    Content = "banner_ad"
};

var uri = new Uri("https://example.com");
var builder = new UTMBuilder();
var resultUri = builder.Build(uri, utm);

Console.WriteLine(resultUri);
// Output: https://example.com/?utm_source=google&utm_medium=cpc&utm_campaign=spring_sale&utm_term=running+shoes&utm_content=banner_ad
```


### 2. Parsing UTM Parameters from an Existing URL
```csharp
var parser = new UTMParser();
var parsedUtm = parser.Parse("https://example.com/?utm_source=google&utm_medium=cpc&utm_campaign=spring_sale&utm_term=running+shoes&utm_content=banner_ad");

Console.WriteLine(parsedUtm.Source); // Output: google
Console.WriteLine(parsedUtm.Medium); // Output: cpc
```

### 3. Building a URL with Individual Parameters

```csharp
var builder = new UTMBuilder();
var resultUri = builder.Build(
    new Uri("https://example.com"),
    source: "facebook",
    medium: "social",
    campaign: "summer_discount",
    term: "discount code",
    content: "promo_link"
);

Console.WriteLine(resultUri);
// Output: https://example.com/?utm_source=facebook&utm_medium=social&utm_campaign=summer_discount&utm_term=discount+code&utm_content=promo_link
```

### 4. Removing Existing UTM Parameters Before Appending New Ones
```csharp
var utm = new UrchinTrackingModule
{
    Source = "twitter",
    Medium = "social",
    Campaign = "new_product_launch"
};

var builder = new UTMBuilder();
var resultUri = builder.Build(new Uri("https://example.com/?utm_source=oldsource&utm_medium=oldmedium&utm_campaign=oldcampaign"), utm);

Console.WriteLine(resultUri);
// Output: https://example.com/?utm_source=twitter&utm_medium=social&utm_campaign=new_product_launch
```
