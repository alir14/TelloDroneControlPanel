using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelloDroneDriver.Model;

namespace TelloDroneDriver
{

    public interface ICommandPipeLine
    {
        void AddCommandToPipeLine(CommandModel command);
        void RemoveCommandFromPipeLine(CommandModel command);
        void ResetCommandsInPipeLine();
        CommandModel GetCommandInThePipeLine(int index);
        List<CommandModel> CommandList { get; }
    }
    public class CommandPipeLine : ICommandPipeLine
    {
        private readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static CommandPipeLine instance;
        private static volatile object lockObject = new object();
        private readonly List<CommandModel> commandList;

        private CommandPipeLine()
        {
            commandList = new List<CommandModel>();
        }

        public static CommandPipeLine Instance
        {
            get
            {
                if(instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new CommandPipeLine();
                        }
                    }
                }

                return instance;
            }
        }

        public List<CommandModel> CommandList
        {
            get { return commandList; }
        }

        public void AddCommandToPipeLine(CommandModel command)
        {
            try
            {
                if (commandList != null && command != null 
                    && !string.IsNullOrEmpty(command.Command))
                {
                    command.Id = GetUiqueId();
                    command.Time = DateTime.UtcNow.TimeOfDay;
                    commandList.Add(command);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveCommandFromPipeLine(CommandModel command)
        {
            try
            {
                if (commandList != null)
                {
                    var index = commandList.FindIndex(x => x.Id == command.Id);
                    if (index > -1)
                        commandList.RemoveAt(index);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public CommandModel GetCommandInThePipeLine(int index)
        {
            try
            {
                if (commandList != null && index < commandList.Count)
                    return commandList[index];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return default;
        }

        private int GetUiqueId()
        {
            return (int)(DateTime.UtcNow - epoch).TotalSeconds;
        }

        public void ResetCommandsInPipeLine()
        {
            if (commandList != null)
                commandList.Clear();
        }
    }
}
