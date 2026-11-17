# X.Web.UTM

[![NuGet Version](https://img.shields.io/nuget/v/X.Web.UTM?style=for-the-badge&label=NuGet&color=004880&logo=nuget&logoColor=white)](https://www.nuget.org/packages/X.Web.UTM)
[![NuGet Downloads](https://img.shields.io/nuget/dt/X.Web.UTM?style=for-the-badge&label=Downloads&color=004880&logo=nuget&logoColor=white)](https://www.nuget.org/packages/X.Web.UTM)
[![Sponsor on GitHub](https://img.shields.io/badge/Sponsor_on_GitHub-ff7f00?style=for-the-badge&logo=github&logoColor=white)](https://github.com/sponsors/a-gubskiy)
[![Subscribe on X](https://img.shields.io/badge/Subscribe_on_X-000000?style=for-the-badge&logo=x&logoColor=white)](https://x.com/andrew_gubskiy)

**X.Web.UTM** is a versatile .NET library designed to efficiently handle Urchin Tracking Module (UTM) parameters, 
which are crucial for tracking web traffic sources in digital marketing. This library allows developers to parse, 
construct, and append UTM parameters to URLs, enhancing the capability to track the effectiveness of online advertising
campaigns directly through the URL's query string.

## Key Features
- **Flexible UTM Parameter Management:** Easily create and manage UTM parameters with the `UrchinTrackingModule` class, which supports setting and retrieving properties such as `Source`, `Medium`, `Campaign`, `Term`, and `Content`.
- **Dynamic URL Building:** Utilize the `UTMBuilder` class to seamlessly append UTM parameters to existing URIs, ensuring all marketing and tracking information is accurately included in URLs.
- **UTM Parsing:** Use the `UTMParser` class to extract UTM parameters from an existing URL into an `UrchinTrackingModule` object.
- **Replacing Existing UTM Parameters:** `UTMBuilder` removes any UTM parameters already present in the URL before appending the new ones, while keeping other query parameters intact.
- **Standard Medium Values:** The `UtmMedium` class provides constants for common `utm_medium` values (`Email`, `CPC`, `Social`, `Referral` and more).
- **Error Handling:** `UTMBuilder.Build` throws `ArgumentNullException` when the URI or the `UrchinTrackingModule` is `null`.

## Use Cases
- **Campaign Tracking:** Perfect for marketers and developers looking to gauge the effectiveness of various marketing campaigns by tracking where traffic is coming from.
- **A/B Testing:** Optimize digital marketing strategies by adjusting UTM parameters for different ad variants and directly measuring performance.

## Installation

You can install the library via NuGet:

```bash
dotnet add package X.Web.UTM
```

Targets `netstandard2.0`, `netstandard2.1`, `net10.0` and `net11.0`.

## Usage Samples

All types live in the `X.Web.UTM` namespace.

### 1. Building a URL with UTM Parameters

```csharp
using X.Web.UTM;

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

`Build` also accepts the base URL as a `string`: `builder.Build("https://example.com", utm)`.

### 2. Parsing UTM Parameters from an Existing URL

```csharp
var parser = new UTMParser();
var parsedUtm = parser.Parse("https://example.com/?utm_source=google&utm_medium=cpc&utm_campaign=spring_sale&utm_term=running+shoes&utm_content=banner_ad");

Console.WriteLine(parsedUtm.Source); // Output: google
Console.WriteLine(parsedUtm.Medium); // Output: cpc
Console.WriteLine(parsedUtm.Term);   // Output: running shoes
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

## License

This project is licensed under the terms of the [LICENSE.md](LICENSE.md) file.
