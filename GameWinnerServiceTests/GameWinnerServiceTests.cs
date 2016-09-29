using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Services;

namespace TicTacToeTests
{
    [TestClass]
    public class GameWinnerServiceTests
    {

        IGameWinnerService _gameWinnerService;
        private char[,] _gameBoard;

        [TestInitialize]
        public void SetupUnitTests()
        {
            _gameWinnerService = new GameWinnerService();
            _gameBoard = new char[3, 3]{
                                      {' ', ' ', ' '},
                                      {' ', ' ', ' '},
                                      {' ', ' ', ' '},
            };
        }

        [TestMethod]
        public void NeitherPlayerHasThreeInARow()
        {
            const char expected = ' ';
            var gameBoard = new char[3, 3] { {' ', ' ', ' '},
                                             {' ', ' ', ' '},
                                             {' ', ' ', ' '}};
            var actual = _gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PlayerWithAllSpacesInTopRowIsWinner()
        {
            const char expected = 'X';
            var gameBoard = new char[3, 3]{ 
                                            {expected, expected, expected},
                                            {' ', ' ', ' '},
                                            {' ', ' ', ' '} };
            var actual = _gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithAllSpacesInBottomRowIsWinner()
        {
            const char expected = 'X';
            var gameBoard = new char[3, 3]{
                                            {' ', ' ', ' '},
                                            {' ', ' ', ' '},
                                            {expected, expected, expected} };
            var actual = _gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithAllSpacesInMiddleRowIsWinner()
        {
            const char expected = 'X';
            var gameBoard = new char[3, 3]{
                                            {' ', ' ', ' '},
                                            {expected, expected, expected},
                                            {' ', ' ', ' '} };
            var actual = _gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithAllSpacesInFirstColumnIsWinner()
        {
            const char expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                _gameBoard[columnIndex, 0] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithAllSpacesInThirdColumnIsWinner()
        {
            const char expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                _gameBoard[columnIndex, 2] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithAllSpacesInSecondColumnIsWinner()
        {
            const char expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                _gameBoard[columnIndex, 1] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyDownAndToRightIsWinner()
        {
            const char expected = 'X';
            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                _gameBoard[cellIndex, cellIndex] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyTopAndToLeftIsWinner()
        {
            const char expected = 'X';
            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                _gameBoard[cellIndex, (2 - cellIndex)] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}

