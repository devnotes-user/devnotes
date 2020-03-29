using DevNotes.Core.DevNotesSQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevNotes.Core.Test.DevNotersSQLiteTest
{
    [TestClass]
    public class SQLiteCommandFactoryTest
    {
        private Mock<IDevNotesSQLiteConnection> devNotesSQLiteConnection;

        [TestInitialize]
        public void Initialize()
        {
            devNotesSQLiteConnection = new Mock<IDevNotesSQLiteConnection>();
        }

        /// <summary>
        /// Given an invalid SQLiteConnection, an exception is produced.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAnInvalidConnectionThrowsException()
        {
            // Arrange
            devNotesSQLiteConnection.Setup(o => o.InErrorState()).Returns(true);
            var uut = CreateUnitUnderTest();

            // Act
            uut.CreateSQLiteCommand();

            // Assert
            Assert.ThrowsException<Exception>(() => uut.CreateSQLiteCommand());
        }

        private SQLiteCommandFactory CreateUnitUnderTest()
        {
            return new SQLiteCommandFactory(devNotesSQLiteConnection.Object);
        }
    }
}
