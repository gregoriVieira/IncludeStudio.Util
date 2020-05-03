using Microsoft.VisualStudio.TestTools.UnitTesting;
using IncludeStudio.Util.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using IncludeStudio.Util.Domain.Entities;

namespace IncludeStudio.Util.Domain.Data.Tests
{
    [TestClass()]
    public class FireBaseTests
    {
        [TestMethod()]
        public void InsertData_WithOut_StartRadar()
        {
            //Arrange
            var details = new Details()
            {
                RadarType = "TestType",
                Description = "TestDescription",
                VariableType = "TestVariableType",
                Value = "TestValue",
                FileName = "FileNameTest",
                Method = "MethodTest",
                Environment = Environment.MachineName
            };

            //Act & Assert
            Assert.ThrowsException<UriFormatException>(() => FireBase.InsertData(details));
        }


        [TestMethod()]
        public void InsertData_Throws()
        {
            //Arrange & Act & Assert
            Assert.ThrowsException<Exception>(() => FireBase.InsertData(null));
        }
    }
}