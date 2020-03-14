using DevNotes.DevNotesSQLite;
using DevNotes.Project;
using DevNotes.Task;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DevNotesConsoleTest.DevNotesSQLiteTest
{
    /// <summary>
    /// Test of functionality for SQLiteRepository
    /// </summary>
    [TestClass]
    public class SQLiteRepositoryTest
    {
        private Mock<IDevNotesSQLiteConnection> connectionWrapper;
        private Mock<IDevNotesSQLiteCommand> commandWrapper;
        private Mock<IDevNotesSQLiteDataReader> dataReader;
        private Mock<IProjectEntity> projectEntity;
        private Mock<IList<ITaskEntity>> taskEntity;

        [TestInitialize]
        public void Initialize()
        {
            connectionWrapper = new Mock<IDevNotesSQLiteConnection>();
            commandWrapper = new Mock<IDevNotesSQLiteCommand>();
            dataReader = new Mock<IDevNotesSQLiteDataReader>();
            projectEntity = new Mock<IProjectEntity>();
            taskEntity = new Mock<IList<ITaskEntity>>();
        }

        /// <summary>
        /// Given: a project entity
        /// When: It is added to the repository
        /// Then: It exists in the repository
        /// </summary>
        [TestMethod]
        public void TestAProjectCanBeFoundAfterAddingItToTheRepository()
        {
            // Arrange
            var addSQLCommand = new Mock<IDevNotesSQLiteCommand>();
            var fakeDB = new Dictionary<string, IProjectEntity>();
            fakeDB.Add("Test", projectEntity.Object);
            addSQLCommand.Setup(o => o.ExecuteNonQuery()).Callback(() => fakeDB);
            commandWrapper.SetupGet(o => o.CommandText).Returns("select * from Projects where ProjectName=Test");
            connectionWrapper.Setup(o => o.CreateCommand()).Returns(commandWrapper.Object);
            var uut = CreateUnitUnderTest();

            // Act
            uut.Add(projectEntity.Object);

            // Assert
            Assert.IsTrue(uut.FindByKey("Test").ProjectName == "Test");
        }

        [TestMethod]
        public void TestWhenDatabaseContainsProjectNameItExistsInTheRepo()
        {
            // Arrange
            connectionWrapper.Setup(o => o.CreateCommand()).Returns(commandWrapper.Object);
            commandWrapper.SetupGet(o => o.CommandText).Returns("select * from Projects where ProjectName=Test");
            commandWrapper.Setup(o => o.ExecuteReader()).Returns(dataReader.Object);
            dataReader.SetupGet(o => o.HasRows).Returns(true);
            var testEntity = new ProjectEntity("0", "Test", taskEntity.Object);
            var uut = CreateUnitUnderTest();

            // Act
            var result = uut.Exists(testEntity);

            // Assert
            Assert.IsTrue(result);
        }


        private ProjectRepository CreateUnitUnderTest()
        {
            return new ProjectRepository(connectionWrapper.Object);
        }
    }
}
