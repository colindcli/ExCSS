using System;
using System.Linq;

namespace ExCSS.Tests
{
    using ExCSS;
    using System.IO;
    using Xunit;

    public class SheetParseTests : CssConstructionFunctions
    {
        [Fact]
        public void Test1()
        {
            var path = Path.GetFullPath($"{AppDomain.CurrentDomain.BaseDirectory}..\\..\\..\\DataFiles\\index_1.css");
            var css = File.ReadAllText(path);
            var parser = new StylesheetParser();
            var sheet = parser.Parse(css);
            var total = sheet.Children.Count();
            Assert.True(total == 533);
        }

        [Fact]
        public void Test2()
        {
            var path = Path.GetFullPath($"{AppDomain.CurrentDomain.BaseDirectory}..\\..\\..\\DataFiles\\index_2.css");
            var css = File.ReadAllText(path);
            var parser = new StylesheetParser();
            var sheet = parser.Parse(css);

            var total = sheet.Children.Count();
            Assert.True(total == 345, total.ToString());
        }

        [Fact]
        public void Test3()
        {
            var path = Path.GetFullPath($"{AppDomain.CurrentDomain.BaseDirectory}..\\..\\..\\DataFiles\\index_3.css");
            var css = File.ReadAllText(path);
            var parser = new StylesheetParser();
            var sheet = parser.Parse(css);

            var total = sheet.Children.Count();
            Assert.True(total == 292, total.ToString());
        }

        [Fact]
        public void Test4()
        {
            var str = @"
:root {
    --layout: {
    }
    --layout-horizontal: {
        @apply (--layout);
    }
}";
            var parser = new StylesheetParser();
            //Can't parse this code, waiting for a long, long time
            var parse = parser.Parse(str);

            var b1 = parse.StyleRules.Count() == 0;
            Assert.True(b1);
        }

        [Fact]
        public void Test4A()
        {
            var str = @"
:root {
    --layout: {
    }
    --layout-horizontal: {
        @apply (--layout);
    }
}

.new{
    color: #ccc;
}
";
            var parser = new StylesheetParser();
            //Can't parse this code, waiting for a long, long time
            var parse = parser.Parse(str);

            var b1 = parse.StyleRules.Count() == 1;
            Assert.True(b1);
        }

        [Fact]
        public void Test5()
        {
            var str = @"
@media (max-width: 991px) {
    body {
        background-color: #013668;
    }
    ;
}

@media (max-width: 991px) {
    body {
        background: #FFF;
    }
}";
            var parser = new StylesheetParser();
            //Can't parse this code, waiting for a long, long time
            var parse = parser.Parse(str);

            var b1 = parse.MediaRules.Count() == 2;
            Assert.True(b1);
        }

        [Fact]
        public void Test6()
        {
            var path = Path.GetFullPath($"{AppDomain.CurrentDomain.BaseDirectory}..\\..\\..\\DataFiles\\index_4.css");
            var css = File.ReadAllText(path);
            var parser = new StylesheetParser();
            var sheet = parser.Parse(css);

            var total = sheet.Children.Count();
            Assert.True(total == 28, total.ToString());
        }
    }
}
