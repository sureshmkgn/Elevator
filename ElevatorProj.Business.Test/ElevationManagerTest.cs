using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevatorProj.Business.Test
{
    [TestClass]
    public class ElevationManagerTest
    {
        
        List<ITimeForEachElevator> timeForEachElevators;

        [TestInitialize()]
        public void TestInitialize()
        {
          
            var timeForEachElevatorsFirst = new TimeForEachElevator();
            var timeForEachElevatorsSecond = new TimeForEachElevator();
            timeForEachElevators = new List<ITimeForEachElevator>();
            timeForEachElevators.Add(timeForEachElevatorsFirst);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ElevationManager_ConstructorTest_with_ElevatorTimeListNull()
        {
            ElevationManager elevationManager = new ElevationManager(null);
        }

        [TestMethod]
       
        public void ElevationManager_ConstructorTest_with_ValidElevatorTimeList()
        {
            ElevationManager elevationManager = new ElevationManager(timeForEachElevators);
            Assert.IsNotNull(elevationManager);
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            timeForEachElevators = null;
        }

    }
}
