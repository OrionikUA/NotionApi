using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotionAPI.Tests
{
    public class JsonParserTestCases : DataTestMethodAttribute, ITestDataSource
    {
        private List<string> _paths = new List<string>()
        {
            "RetrieveAPageTest1",
        };

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(directory, "TestFiles");

            return _paths.Select(x => new object[] { Path.Combine(path, $"{x}.json") });
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            return data[0].ToString();
        }
    }
}
