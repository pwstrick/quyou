using NUnit.Framework;
using QuyouCore.Core.Util;

namespace QuyouTests.core.Util
{
    [TestFixture]
    public class NHtmlFilterTest
    {
        private NHtmlFilter _target;

        [TestFixtureSetUp]
        public void Init()
        {
            _target = new NHtmlFilter();
        }
        [Test]
        public void TestFilter()
        {
            var input = "<div>dd</div><a id=\"testId\" href=\"http://code.google.com/p/nhtmlfilter\" onclick=\"return 123;\">nhtmlfilter</a>";
            var expected = "dd<a href=\"http://code.google.com/p/nhtmlfilter\">nhtmlfilter</a>";
            Assert.AreEqual(expected, _target.filter(input));
        }
    }
}
