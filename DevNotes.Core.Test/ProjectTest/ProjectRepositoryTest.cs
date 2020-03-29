using DevNotes.Core.DevNotesSQLite;
using DevNotes.Core.Project;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevNotes.Core.Test.ProjectTest
{
    [TestClass]
    public class ProjectRepositoryTest
    {
        private string projectName;
        private Mock<IDevNotesSQLiteConnection> sqlConnection;

        [TestInitialize]
        public void Initialize()
        {
            sqlConnection = new Mock<IDevNotesSQLiteConnection>();
        }


        [TestMethod]
        public void TestSettingNameOfCurrentProjectAllowsItToBeRetrieved()
        {
            // Arrange + Act
            projectName = "Test";
            var uut = CreateUnitUnderTest();

            // Assert
            Assert.AreEqual("Test", uut.ProjectName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ProjectRepository CreateUnitUnderTest()
        {
            return new ProjectRepository(projectName, sqlConnection.Object);
        }
    }
}
