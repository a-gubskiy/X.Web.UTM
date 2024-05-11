using System;
using X.Web.UTM;
using Xunit;

namespace Tests.X.Web.UTM
{
    public class UTMBuilderTests
    {
        private readonly UTMBuilder _utmBuilder;

        public UTMBuilderTests()
        {
            _utmBuilder = new UTMBuilder();
        }

        [Fact]
        public void Build_WithValidInput_ShouldAppendUTMParameters()
        {
            // Arrange
            var baseUri = new Uri("https://example.com");
            var utm = new UrchinTrackingModule
            {
                Source = "google",
                Medium = "email",
                Campaign = "newsletter",
                Term = "2024_spring",
                Content = "link_click"
            };

            // Act
            var resultUri = _utmBuilder.Build(baseUri, utm);

            // Assert
            Assert.Equal("https://example.com/?utm_source=google&utm_medium=email&utm_campaign=newsletter&utm_term=2024_spring&utm_content=link_click", resultUri.ToString());
        }

        [Fact]
        public void Build_WithExistingQuery_ShouldAppendUTMParametersCorrectly()
        {
            // Arrange
            var baseUri = new Uri("https://example.com?existing=param");
            var utm = new UrchinTrackingModule
            {
                Source = "google",
                Medium = "email",
                Campaign = "newsletter",
                Term = "2024_spring",
                Content = "link_click"
            };

            // Act
            var resultUri = _utmBuilder.Build(baseUri, utm);

            // Assert
            Assert.Equal("https://example.com/?existing=param&utm_source=google&utm_medium=email&utm_campaign=newsletter&utm_term=2024_spring&utm_content=link_click", resultUri.ToString());
        }

        [Fact]
        public void Build_WithNullUri_ShouldThrowArgumentNullException()
        {
            // Arrange
            Uri baseUri = null;
            var utm = new UrchinTrackingModule();

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _utmBuilder.Build(baseUri, utm));
            Assert.Equal("uri", exception.ParamName);
        }

        [Fact]
        public void Build_WithNullUTM_ShouldThrowArgumentNullException()
        {
            // Arrange
            var baseUri = new Uri("https://example.com");

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _utmBuilder.Build(baseUri, null));
            Assert.Equal("utm", exception.ParamName);
        }
    }
}
