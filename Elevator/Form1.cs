using ElevatorProj.Business;
using ElevatorProj.Business.Entities;
using ElevatorProj.Business.Entities.BuildingEntity;
using ElevatorProj.Business.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorApp
{
    public partial class Form1 : Form
    {
        Building building;
        log4net.ILog log;
        public Form1()
        {
            //log4net.Config.XmlConfigurator.Configure();
            log4net.Config.BasicConfigurator.Configure();
            log = log4net.LogManager.GetLogger(typeof(Program));
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitBuildingElevatorsAndFloors();
            // Initialize a request from Floor 3 and press Down 
            ElevatorOutsideRequest CurrentRequest = new ElevatorOutsideRequest(new Floor { FloorNumber = 3 }, Direction.Down);

            // 3 Elevators init 
            building.Elevators[0].CurrentDirection = Direction.Down;
            building.Elevators[1].CurrentDirection = Direction.Up;
            building.Elevators[2].CurrentDirection = Direction.Down;

            try
            {
                //get the best fit elevator based on the conditions 
                var elevatorName = building.FindBestLift(CurrentRequest);
                MessageBox.Show("Elevator Selected = " + elevatorName.ToString());


            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
            }

            
        }

        private void InitBuildingElevatorsAndFloors()
        {
            BuildingDataMock buildingDataMock = new BuildingDataMock();

            // Create Building ,elevators and floors based on the inputs

            building = buildingDataMock.CreateBuildingWithElivatorsAndFloors(Convert.ToInt32(txtElevators.Text.ToString()), Convert.ToInt32(txtFloor.Text.ToString()));

            //Set up the initial elivators in to floors 

            Elevator E1 = building.Elevators[0] as Elevator;
            E1.ElevatorName = " Elevator1";
            E1.CurrentFloor.FloorNumber = 5;

            Elevator E2 = building.Elevators[1] as Elevator;
            E2.ElevatorName = " Elevator2";
            E2.CurrentFloor.FloorNumber = 9;

            Elevator E3 = building.Elevators[2] as Elevator;
            E3.ElevatorName = " Elevator2";
            E3.CurrentFloor.FloorNumber = 7;

            //Setup the internal pending requests  for the elivations

            E1.PendingRequestsInside.Add(BuildingDataMock.CreateMockPendingRequestInSide(7, Direction.Down)); //request from 7th floor to up
            E1.PendingRequestsInside.Add(BuildingDataMock.CreateMockPendingRequestInSide(9, Direction.Down));


            E2.PendingRequestsInside.Add(BuildingDataMock.CreateMockPendingRequestInSide(3, Direction.Down)); //request from 3rd floor to Down
            E2.PendingRequestsInside.Add(BuildingDataMock.CreateMockPendingRequestInSide(6, Direction.Down));


            E3.PendingRequestsInside.Add(BuildingDataMock.CreateMockPendingRequestInSide(4, Direction.Up));
            E3.PendingRequestsInside.Add(BuildingDataMock.CreateMockPendingRequestInSide(12, Direction.Up));


            // Actual request for selecting elivator 

            //E1.PendingRequestsOutside.Add(BuildingDataMock.CreateMockPendingRequestOutSide(2, 3)); //Person want to go from 2nd floor to 3rd
            //E1.PendingRequestsOutside.Add(BuildingDataMock.CreateMockPendingRequestOutSide(3, 5));
            //E1.PendingRequestsOutside.Add(BuildingDataMock.CreateMockPendingRequestOutSide(7, 9));
        }


        
    }
}


