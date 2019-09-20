using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelloDroneDriver;
using TelloDroneDriver.Functions;

namespace TelloDroneControlPanel
{
    public partial class Form1 : Form
    {
        private readonly DroneConnection _baseDroneFeature = new DroneConnection();
        private readonly DronTaxiFeature _taxiFeature = new DronTaxiFeature();
        private readonly DroneMovementFeature _movement = new DroneMovementFeature();

        DroneResponse Response { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Response = _baseDroneFeature.ConnectWithCommand();

            if (Response == DroneResponse.OK)
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

        private void btnUp_Click(object sender, EventArgs e)
        {
            _movement.MoveUp(50);
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            _movement.MoveRight(50);
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            _movement.MoveLeft(50);
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            _movement.MoveDown(50);
        }

        private void BtnEmergency_Click(object sender, EventArgs e)
        {
            _movement.EmergencyStop();
        }

        private void BtnLand_Click(object sender, EventArgs e)
        {
            _taxiFeature.AutoLand();
        }

        private void BtnTakeOff_Click(object sender, EventArgs e)
        {
            _taxiFeature.TakeOff();
        }

        private void BtnCommand_Click(object sender, EventArgs e)
        {
            _taxiFeature.InitializeToSendCommnd();
        }
    }
}
