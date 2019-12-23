using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TelloDroneDriver;
using TelloDroneDriver.Manager;
using TelloDroneDriver.Model;

namespace TelloDroneDriverUnitTests
{
    [TestClass]
    public class CommandPipeLineUnitTests
    {
        [TestMethod]
        public void AddCommandToPipeLine_ValidCommand_CommandListHas1Item()
        {
            var dummyModel = new CommandModel()
            {
                Id = -1,
                Command = DroneCommandEnum.TAKEOFF,
                CommandStatus = CommandStatuEnum.Pending,
                CommandType = CommandMode.CommandMode
            };

            CommandPipeLine.Instance.AddCommandToPipeLine(dummyModel);

            Assert.IsNotNull(CommandPipeLine.Instance.CommandList);
            Assert.IsTrue(CommandPipeLine.Instance.CommandList.Count > 0);
            var item = CommandPipeLine.Instance.CommandList[0];
            Assert.IsTrue(item.Id > 0);
            Assert.IsTrue(item.Time != TimeSpan.Zero);
            Assert.IsNotNull(item.Command);
        }

        [TestMethod]
        public void AddCommandToPipeLine_InValidCommand_CommandListDoesnotHaveItem()
        {
            CommandModel dummyModel = null;

            CommandPipeLine.Instance.AddCommandToPipeLine(dummyModel);

            Assert.IsNotNull(CommandPipeLine.Instance.CommandList);
            Assert.IsTrue(CommandPipeLine.Instance.CommandList.Count == 0);
        }

        [TestMethod]
        public void GetCommandInThePipeLine_CommandListHasItem_GetItemFromTheList()
        {
            var dummyModel = new CommandModel()
            {
                Command = DroneCommandEnum.TAKEOFF,
                CommandStatus = CommandStatuEnum.Pending,
                CommandType = CommandMode.CommandMode
            };

            CommandPipeLine.Instance.AddCommandToPipeLine(dummyModel);

            var iteminthelist = CommandPipeLine.Instance.GetCommandInThePipeLine(0);

            Assert.IsNotNull(CommandPipeLine.Instance.CommandList);
            Assert.IsTrue(iteminthelist.Id > 0);
            Assert.IsTrue(iteminthelist.Time != TimeSpan.Zero);

            Assert.IsTrue(iteminthelist.Command == dummyModel.Command);
            Assert.IsTrue(iteminthelist.CommandStatus == dummyModel.CommandStatus);
            Assert.IsTrue(iteminthelist.CommandType == dummyModel.CommandType);

        }

        [TestMethod]
        public void GetCommandInThePipeLine_IndexOutOfRange_GetItemFromTheList()
        {
            var dummyModel = new CommandModel()
            {
                Command = DroneCommandEnum.TAKEOFF,
                CommandStatus = CommandStatuEnum.Pending,
                CommandType = CommandMode.CommandMode
            };

            CommandPipeLine.Instance.AddCommandToPipeLine(dummyModel);

            var iteminthelist = CommandPipeLine.Instance.GetCommandInThePipeLine(10);

            Assert.IsNotNull(CommandPipeLine.Instance.CommandList);

            Assert.IsNull(iteminthelist);
        }

        [TestMethod]
        public void GetCommandInThePipeLine_CommandListIsEmpty_GetNoItem()
        {
            var iteminthelist = CommandPipeLine.Instance.GetCommandInThePipeLine(0);

            Assert.IsNull(iteminthelist);
        }

        [TestMethod]
        public void RemoveCommandFromPipeLine_CommandListHasItem_ItemwillbeRemovedFromList()
        {
            var dummyModel = new CommandModel()
            {
                Command = DroneCommandEnum.TAKEOFF,
                CommandStatus = CommandStatuEnum.Pending,
                CommandType = CommandMode.CommandMode
            };

            CommandPipeLine.Instance.AddCommandToPipeLine(dummyModel);

            var dummyIteminthelist = CommandPipeLine.Instance.GetCommandInThePipeLine(0);

            CommandPipeLine.Instance.RemoveCommandFromPipeLine(dummyIteminthelist);

            Assert.IsTrue(CommandPipeLine.Instance.CommandList.Count == 0);
        }

        [TestMethod]
        public void RemoveCommandFromPipeLine_CommandListIsEmpty_NoErrorAndNoActionIsRequired()
        {
            var dummyModel = new CommandModel()
            {
                Command = DroneCommandEnum.TAKEOFF,
                CommandStatus = CommandStatuEnum.Pending,
                CommandType = CommandMode.CommandMode
            };

            CommandPipeLine.Instance.RemoveCommandFromPipeLine(dummyModel);

            Assert.IsTrue(CommandPipeLine.Instance.CommandList.Count == 0);
        }

        [TestMethod]
        public void RemoveCommandFromPipeLine_ItemIsNotIntheList_NoErrorAndNoActionIsRequired()
        {
            var invalidModel = new CommandModel()
            {
                Id = 100000,
                Command = DroneCommandEnum.TAKEOFF,
                CommandStatus = CommandStatuEnum.Done,
                CommandType = CommandMode.Read
            };

            var dummyModel = new CommandModel()
            {
                Command = DroneCommandEnum.TAKEOFF,
                CommandStatus = CommandStatuEnum.Pending,
                CommandType = CommandMode.CommandMode
            };

            CommandPipeLine.Instance.AddCommandToPipeLine(dummyModel);

            CommandPipeLine.Instance.RemoveCommandFromPipeLine(invalidModel);

            Assert.IsTrue(CommandPipeLine.Instance.CommandList.Count == 1);
        }

        [TestCleanup]
        public void TestCleanUpdata()
        {
            CommandPipeLine.Instance.ResetCommandsInPipeLine();
        }
    }
}
