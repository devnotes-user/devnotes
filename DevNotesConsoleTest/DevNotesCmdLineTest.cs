using System;
using System.Collections.Generic;
using Moq;
using DevNotesConsole.ConsoleInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevNotesConsoleTest
{
    [TestClass]
    public class DevNotesCmdLineTest
    {
        private Mock<ICollection<string>> args;

        [TestInitialize]
        public void Initialize()
        {
            args = new Mock<ICollection<string>>();
        }

        [TestMethod]
        public void AnEmptyCmdLineArgIsReceivedAsAnUnknownOperation()
        {
            args.Setup(object.);
            var uut = CreateUnitUnderTest();
        }

        private DevNotesCommand CreateUnitUnderTest()
        {
            return new DevNotesCommand(args);
        }
    }
}
