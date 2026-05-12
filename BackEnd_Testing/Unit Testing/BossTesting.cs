using AutoFixture;
using BusinessLogic.Classes;
using BusinessLogic.DbCalls;
using BusinessLogic.DTO;
using BusinessLogic.Logic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_Testing.Unit_Testing
{
    [TestClass]
    public class BossTesting
    {
        private Fixture _dataCreator = new Fixture();
        //We follow the AAA method in unit testing here.

        #region Create Boss
        [TestMethod]
        public void SuccessfullyCreateABoss()
        {
            //Arrange
            var bossDbMock = new Mock<IBossCalls>();
            string name = "Asmodeus";
            string desc = "This will hold an explanation of the boss";
            int maxLife = 50000;
            int level = 90;
            BossCreateDTO input = new BossCreateDTO(name, desc, maxLife, level);
            bossDbMock.Setup(p => p.AddBoss(input)).Returns(
                                new Boss(new BossCreateDTO(name, desc, maxLife, level)));
            BossLogic logic = new BossLogic(bossDbMock.Object);

            //Act
            Boss result = logic.AddBoss(input);

            //Assert
            bossDbMock.Verify(p => p.AddBoss(input), Times.Once);
            Assert.AreEqual(name, result.Name);
            Assert.AreEqual(desc, result.Description);
            Assert.AreEqual(maxLife, result.MaxLife);
            Assert.AreEqual(level, result.Level);
        }

        [TestMethod]
        public void FailedCreateSinceBossIsNull()
        {
            //Arrange
            var bossDbMock = new Mock<IBossCalls>();
            BossLogic logic = new BossLogic(bossDbMock.Object);
            //Act
            try
            {
                //We attempt to make the logic crash out here
                Boss result = logic.AddBoss(null);
            }
            //assert
            catch (ArgumentNullException ex)
            {
                //Lets validate the correct argumentNullException is thrown
                Assert.AreEqual("Cannot create a new boss item due to the passed item being null.", ex.Message);
                Assert.AreEqual("BossCreateDTO", ex.ParamName);
            }
            catch (Exception ex)
            {
                //If a wrong exception is thrown the test will fail
                Assert.Fail();
            }
        }
            #endregion
    }
}
