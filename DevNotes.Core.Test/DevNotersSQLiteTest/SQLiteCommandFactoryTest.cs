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
        public void TestAnInvalidConnectionThrowsException()
        {
            // Arrange
            var uut = CreateUnitUnderTest();

            // Act
            // Assert
            Assert.ThrowsException<Exception>(() => uut.CreateSQLiteCommand());
        }

        private SQLiteCommandFactory CreateUnitUnderTest()
        {
            return new SQLiteCommandFactory(devNotesSQLiteConnection.Object);
        }
    }
}
