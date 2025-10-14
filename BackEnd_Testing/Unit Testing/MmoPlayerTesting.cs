using System;
using Moq;
using Moq.Protected;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Logic;
using BusinessLogic.DbCalls;
using BusinessLogic.Classes;

namespace BackEnd_Testing.Unit_Testing
{
    [TestClass]
    public class MmoPlayerTesting
    {
        //We follow the AAA method in unit testing here.
        #region Get Player by name tests
        //unit tests for the functionality surrounding getting a player by their unique name.
        [TestMethod]
        public void SuccessfullyRetrievePlayer()
        {
            //Arrange
            var playerDbMock = new Mock<ImmoPlayerCalls>();
            string name = "Charlie";
            playerDbMock.Setup(p => p.GetPlayerByName(name)).Returns(
                                new MmoPlayer(4, name, (Roleclass)5));
            PlayersLogic logic = new PlayersLogic(playerDbMock.Object);

            //Act
            MmoPlayer result = logic.GetPlayer(name);

            //Assert
            playerDbMock.Verify(p => p.GetPlayerByName(name), Times.Once);
            Assert.AreEqual(name, result.Name);
        }
        #endregion
    }
}
