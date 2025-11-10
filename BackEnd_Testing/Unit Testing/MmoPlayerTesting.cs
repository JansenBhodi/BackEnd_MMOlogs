using AutoFixture;
using BusinessLogic.Classes;
using BusinessLogic.DbCalls;
using BusinessLogic.Logic;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BackEnd_Testing.Unit_Testing
{
    [TestClass]
    public class MmoPlayerTesting
    {
        private Fixture _dataCreator = new Fixture();
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

        [TestMethod]
        public void PlayerNameEmpty()
        {
            //Arrange
            var playerDbMock = new Mock<ImmoPlayerCalls>();
            string name = "Charlie";
            playerDbMock.Setup(p => p.GetPlayerByName(name)).Returns(
                                new MmoPlayer(4, name, (Roleclass)5));
            PlayersLogic logic = new PlayersLogic(playerDbMock.Object);

            //Act
            try
            {
                MmoPlayer result = logic.GetPlayer("");
                //If an exception did not happen the logic failed.
                Assert.Fail();
            }
            //Assert
            catch (ArgumentException ex)
            {
                playerDbMock.Verify(p => p.GetPlayerByName(name), Times.Never);
            }
            catch (Exception)
            {
                //We are expecting the above exception to happen
                Assert.Fail();
            }
        }

        [TestMethod]
        public void NameDoesNotExist()
        {
            //Arrange
            var playerDbMock = new Mock<ImmoPlayerCalls>();
            string name = "Charlie";
            playerDbMock.Setup(p => p.GetPlayerByName(name)).Returns(
                                new MmoPlayer(4, name, (Roleclass)5));
            PlayersLogic logic = new PlayersLogic(playerDbMock.Object);
            MmoPlayer result;

            //Act
            try
            {
                result = logic.GetPlayer("Mikey");


                //Assert
                Assert.IsNull(result);
            }
            catch (Exception)
            {
                //During the answer the exception is transformed into a null state in code.
                Assert.Fail();
            }
        }

        #endregion

        #region Create player

        #endregion

        #region Get listed players
        //unit tests for getting all players 
        [TestMethod]
        public void SuccessfullyRetrieveListedPlayers()
        {
            //Arrange
            var playerDbMock = new Mock<ImmoPlayerCalls>();
            var input = _dataCreator.Build<MmoPlayer>().WithAutoProperties().CreateMany().ToList();
            playerDbMock.Setup(p => p.GetListedPlayers()).Returns(input);
            PlayersLogic logic = new PlayersLogic(playerDbMock.Object);

            //Act
            List<MmoPlayer> output = logic.GetListedPlayers();

            //Assert
            Assert.AreEqual(input.Count(), output.Count());
            CollectionAssert.AreEquivalent(input, output);
            for (int i = 0; i < input.Count(); i++)
            {
                Assert.AreEqual(input[i], output[i], $"Mismatch at index {i}");
            }
        }

        [TestMethod]
        public void DatabaseErrorRetrieveListedPlayers()
        {
            //Arrange
            var playerDbMock = new Mock<ImmoPlayerCalls>();
            var input = new InvalidOperationException(message: "Retrieval of data from database failed");
            playerDbMock.Setup(p => p.GetListedPlayers()).Throws(input);
            PlayersLogic logic = new PlayersLogic(playerDbMock.Object);

            //Act
            try
            {
                List<MmoPlayer> output = logic.GetListedPlayers();

                //If an error does not occur then something went wrong with the test.
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                //Check if the error message was properly attached. Follow it up with making sure the mock was used once.
                Assert.AreEqual("Retrieval of data from database failed", ex.Message);
                playerDbMock.Verify(p => p.GetListedPlayers(), Times.Once);
            }
            catch (Exception)
            {
                //If the previously expected error is not thrown then something went wrong.
                Assert.Fail();
            }

            //Assert

        }

        #endregion
    }
}
