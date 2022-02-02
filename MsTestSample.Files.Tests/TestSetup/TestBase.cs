using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace MsTestSample.Files.Tests.TestSetup
{
    public abstract class TestBase
    {
        public TestContext TestContext { get; set; }

        protected const string BAD_FILE_NAME = @"D:\bad.filename";
        protected string GetParameterFromSetttingsFile(string propertyName)
        {
            var value = TestContext.Properties[propertyName].ToString();
            if (value.Contains("[AppPath]"))
            {
                value = value.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
            return value;
        }

        protected void WriteDescription(Type type)
        {
            var testName = TestContext.TestName;
            var method = type.GetMethod(testName);
            if (method != null) 
            {
                var attr = method.GetCustomAttribute(typeof(DescriptionAttribute));
                if (attr != null)
                {
                    var descriptionAttribute = (DescriptionAttribute)attr;
                    TestContext.WriteLine("Description : " + descriptionAttribute.Description);
                }
            }       
        
        }
    }
}