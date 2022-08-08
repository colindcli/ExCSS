﻿using System;
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
    }
}
