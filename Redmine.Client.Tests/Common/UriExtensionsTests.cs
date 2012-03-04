namespace Redmine.Client.Tests.Common
{
    using System;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UriExtensionsTests
    {
        [TestMethod]
        public void ShouldMatchPageNameIfUriWithParameters()
        {
            var pageUri = new Uri("/Pages/TestPage.xaml?id=1", UriKind.Relative);
            var pageName = pageUri.ExtractPageName();

            pageName.Should().Be("TestPage");
        }

        [TestMethod]
        public void ShouldMatchPageNameIfPageNameWithoutExtension()
        {
            var pageUri = new Uri("/Pages/TestPage?id=1", UriKind.Relative);
            var pageName = pageUri.ExtractPageName();

            pageName.Should().Be("TestPage");
        }

        [TestMethod]
        public void ShouldMatchUriParameters()
        {
            var pageUri = new Uri("/Pages/TestPage?id=1", UriKind.Relative);
            var parameters = pageUri.ExtractParameters();

            parameters.Count.Should().Be(1);
            parameters.First().Key.Should().Be("id");
            parameters.First().Value.Should().Be("1");
        }

        [TestMethod]
        public void ShouldMatchNoUriParameters()
        {
            var pageUri = new Uri("/Pages/TestPage", UriKind.Relative);
            var parameters = pageUri.ExtractParameters();

            parameters.Count.Should().Be(0);
        }
    }
}