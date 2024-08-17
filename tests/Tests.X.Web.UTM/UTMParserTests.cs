using System;
using Xunit;
using X.Web.UTM;

namespace Tests.X.Web.UTM;

public class UTMParserTests
{
    [Fact]
    public void Parse_ValidUrlWithAllParameters_ReturnsCorrectUTM()
    {
        var parser = new UTMParser();
        var testUrl = "http://example.com?utm_source=google&utm_medium=cpc&utm_campaign=test_campaign&utm_term=test_term&utm_content=test_content";

        var result = parser.Parse(testUrl);

        Assert.NotNull(result);
        Assert.Equal("google", result.Source);
        Assert.Equal("cpc", result.Medium);
        Assert.Equal("test_campaign", result.Campaign);
        Assert.Equal("test_term", result.Term);
        Assert.Equal("test_content", result.Content);
    }

    [Fact]
    public void Parse_ValidUriWithAllParameters_ReturnsCorrectUTM()
    {
        var parser = new UTMParser();
        var testUri = new Uri("https://example.com?utm_source=google&utm_medium=cpc&utm_campaign=test_campaign&utm_term=test_term&utm_content=test_content");

        var result = parser.Parse(testUri);

        Assert.NotNull(result);
        Assert.Equal("google", result.Source);
        Assert.Equal("cpc", result.Medium);
        Assert.Equal("test_campaign", result.Campaign);
        Assert.Equal("test_term", result.Term);
        Assert.Equal("test_content", result.Content);
    }

    [Theory]
    [InlineData("http://example.com", "", "", "", "", "")]
    [InlineData("http://example.com?utm_source=", "", "", "", "", "")]
    [InlineData("http://example.com?utm_medium=&utm_campaign=&utm_term=&utm_content=", "", "", "", "", "")]
    public void Parse_UrlWithMissingOrEmptyUtmParameters_ReturnsUtmWithEmptyFields(string url, string expectedSource, string expectedMedium, string expectedCampaign, string expectedTerm, string expectedContent)
    {
        var parser = new UTMParser();

        var result = parser.Parse(url);

        Assert.NotNull(result);
        Assert.Equal(expectedSource, result.Source);
        Assert.Equal(expectedMedium, result.Medium);
        Assert.Equal(expectedCampaign, result.Campaign);
        Assert.Equal(expectedTerm, result.Term);
        Assert.Equal(expectedContent, result.Content);
    }
}
