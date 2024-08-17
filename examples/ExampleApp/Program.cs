// See https://aka.ms/new-console-template for more information

using X.Web.UTM;

Console.WriteLine("Hello, UTM!");

Example1();
Example2();
Example3();
Example4();

void Example1()
{
    Console.WriteLine("Example 1");
    
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
}

void Example2()
{
    Console.WriteLine("Example 2");
    
    var parser = new UTMParser();
    var parsedUtm = parser.Parse("https://example.com/?utm_source=google&utm_medium=cpc&utm_campaign=spring_sale&utm_term=running+shoes&utm_content=banner_ad");

    Console.WriteLine(parsedUtm.Source); // Output: google
    Console.WriteLine(parsedUtm.Medium); // Output: cpc
}

void Example3()
{
    Console.WriteLine("Example 3");
    
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
}

void Example4()
{
    Console.WriteLine("Example 4");
    
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
}
