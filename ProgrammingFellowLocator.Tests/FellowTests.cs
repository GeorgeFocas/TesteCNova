using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingFellowLocator.Core;

namespace ProgrammingFellowLocator.Tests
{
    [TestClass]
    public class FellowTests
    {
        [TestMethod]
        public void Should_return_closest_fellows_Fulano_Ciclano_Beltrano()
        {
            //ARRANGE
            string list = "Fulano:7,8;Ciclano:9,10;George:10,1;B:90,3;Beltrano:5,2;D:0,1";
            FellowLocatorManager manager = new FellowLocatorManager(list);

            //ACT
            List<Fellow> nearstFellows = manager.ClosestFellows("George");

            //ASSERT
            Assert.IsNotNull(nearstFellows.SingleOrDefault(p => p.Name == "Fulano"));
            Assert.IsNotNull(nearstFellows.SingleOrDefault(p => p.Name == "Beltrano"));
            Assert.IsNotNull(nearstFellows.SingleOrDefault(p => p.Name == "Ciclano"));
        }

        [TestMethod]
        public void FellowValidator_should_return_true()
        {
            //ARRANGE
            string fellowListOnString = "Fulano:7,8;Ciclano:9,10;George:10,1;B:90,3;Beltrano:5,2;D:0,1";

            //ACT
            bool result = FellowValidator.ValidateFellowListOnString(fellowListOnString);

            //ASSERT
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FellowValidator_should_return_false()
        {
            //ARRANGE
            string fellowListOnString = "Fulano:7,8;Ciclano:9,10;George:10,1;B:90,3oBeltrano:5,2;D:0,1";

            //ACT
            bool result = FellowValidator.ValidateFellowListOnString(fellowListOnString);

            //ASSERT
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FellowFactory_should_return_3_items()
        {
            //ARRANGE
            string fellowListOnString = "Fulano:7,8;Ciclano:9,10;George:10,1";

            //ACT
            List<Fellow> list = FellowFactory.CreateFellowList(fellowListOnString);

            //ASSERT
            Assert.IsTrue(list.Count == 3);
        }

        [TestMethod]
        public void FellowFactory_should_create_valid_fellow_object()
        {
            //ARRANGE
            string fellowString = "Fulano:7,8";

            //ACT
            Fellow fellow = FellowFactory.CreateFellow(fellowString);

            //ASSERT
            Assert.IsTrue(fellow.Name == "Fulano");
            Assert.IsTrue(fellow.Position.X == 7);
            Assert.IsTrue(fellow.Position.Y == 8);
        }
    }
}
