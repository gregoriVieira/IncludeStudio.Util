using Microsoft.VisualStudio.TestTools.UnitTesting;
using IncludeStudio.Util.Radar;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncludeStudio.Util.Radar.Tests
{
    [TestClass()]
    public class LoggerTests
    {
        [TestMethod()]
        public void StartRadar_WithOut_AuthKey()
        {
            //Arrange
            string authKey = string.Empty;
            string baseUrl = string.Empty;
            string jsonPath = string.Empty;
            string description = string.Empty;

            //Act & Assert
            Assert.ThrowsException<Exception>(() => Logger.StartRadar(authKey, baseUrl, jsonPath, description));
        }

        [TestMethod()]
        public void StartRadar_WithOut_BaseUrl()
        {
            //Arrange
            string authKey = string.Empty;
            string baseUrl = string.Empty;
            string jsonPath = string.Empty;
            string description = string.Empty;

            //Act & Assert
            Assert.ThrowsException<Exception>(() => Logger.StartRadar(authKey, baseUrl, jsonPath, description));
        }

        [TestMethod()]
        public void StartRadar_WithOut_JsonPath()
        {
            //Arrange
            string authKey = string.Empty;
            string baseUrl = string.Empty;
            string jsonPath = string.Empty;
            string description = string.Empty;

            //Act & Assert
            Assert.ThrowsException<Exception>(() => Logger.StartRadar(authKey, baseUrl, jsonPath, description));
        }

        [TestMethod()]
        public void StartRadar_WithInvalid_JsonPath()
        {
            //Arrange
            string authKey = string.Empty;
            string baseUrl = string.Empty;
            string jsonPath = "teste";
            string description = string.Empty;

            //Act & Assert
            Assert.ThrowsException<Exception>(() => Logger.StartRadar(authKey, baseUrl, jsonPath, description));
        }

        [TestMethod()]
        public void TrackTest()
        {
            //Arrange

            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void InformationTest()
        {
            //Arrange

            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void ErrorTest()
        {
            //Arrange

            //Act

            //Assert
            Assert.Fail();
        }
    }
}