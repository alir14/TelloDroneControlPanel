using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TelloDroneDriver;
using TelloDroneDriver.Manager;
using TelloDroneDriver.Model;

namespace TelloDroneControlPanel
{
    public partial class Form1 : Form
    {
        CommandModel DroneCommand { get; set; } = new CommandModel();
        Coordinate DroneCordinate { get; set; } = new Coordinate(0,0,0);
        

        private readonly CancellationTokenSource cts = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            DroneCommand.Coordinate = new Coordinate(5, 0, 0);
            DroneCommand.Command = DroneCommandEnum.UP;
            DroneCommand.CommandType = CommandMode.Control;

            CommandPipeLine.Instance.AddCommandToPipeLine(DroneCommand);
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            DroneCommand.Coordinate = new Coordinate(5, 0, 0);
            DroneCommand.Command = DroneCommandEnum.RIGHT;
            DroneCommand.CommandType = CommandMode.Control;

            CommandPipeLine.Instance.AddCommandToPipeLine(DroneCommand);
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            DroneCommand.Coordinate = new Coordinate(5, 0, 0);
            DroneCommand.Command = DroneCommandEnum.LEFT;
            DroneCommand.CommandType = CommandMode.Control;

            CommandPipeLine.Instance.AddCommandToPipeLine(DroneCommand);
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            DroneCommand.Coordinate = new Coordinate(5, 0, 0);
            DroneCommand.Command = DroneCommandEnum.DOWN;
            DroneCommand.CommandType = CommandMode.Control;

            CommandPipeLine.Instance.AddCommandToPipeLine(DroneCommand);
        }

        private void BtnEmergency_Click(object sender, EventArgs e)
        {
            ControlManager.Instance.EmergencyStop();
        }

        private void BtnLand_Click(object sender, EventArgs e)
        {
            DroneCommand.Command = DroneCommandEnum.LAND;
            DroneCommand.CommandType = CommandMode.CommandMode;

            CommandPipeLine.Instance.AddCommandToPipeLine(DroneCommand);
        }

        private void BtnTakeOff_Click(object sender, EventArgs e)
        {
            DroneCommand.Command = DroneCommandEnum.TAKEOFF;
            DroneCommand.CommandType = CommandMode.CommandMode;

            CommandPipeLine.Instance.AddCommandToPipeLine(DroneCommand);
        }

        private void BtnCommand_Click(object sender, EventArgs e)
        {
        }

        private void BtnOn_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(CommandExecuteManager.Instance.Start), cts.Token);
        }

        private void BtnOff_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            cts.Dispose();
        }

        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            timer1.Interval = (int)TimeSpan.FromSeconds(3).TotalSeconds;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CommandExecuteManager.Instance.Response == DroneResponse.OK)
            {
                lblConnection.Text = "Connected";
                lblConnection.BackColor = Color.Green;
            }
            else
            {
                lblConnection.Text = "Connected";
                lblConnection.BackColor = Color.Red;
            }
        }
    }
}
