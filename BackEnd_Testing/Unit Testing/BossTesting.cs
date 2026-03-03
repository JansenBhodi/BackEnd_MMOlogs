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
        public void 
        #endregion
    }
}
