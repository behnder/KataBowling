using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class TestKataBowling
    {
        private Menu menu;

        [SetUp]
        public void Setup()
        {
            menu = new Menu();
        }


        [Test]
        public void Should_throw_more_than_one_and_less_than_eleven()
        {
            //Arrrange

            //Act
            var bowlTh = menu.FallenPines(10);//6
            bool isTrue = (bowlTh >= 0 && bowlTh <= 10);
            //Assert
            Assert.AreEqual(true, isTrue);

        }
        [Test]
        public void Should_be_score_zero_when_always_fail()
        {

            //Arrange
            List<List<int>> CompletlyGame = new List<List<int>>
                            {   new List<int>(){ 0,0,0},
                                new List<int>(){ 0,0,0},
                                new List<int>(){ 0,0,0},
                                new List<int>(){ 0,0,0},
                                new List<int>(){ 0,0,0},
                                new List<int>() { 0, 0, 0 },
                                new List<int>() { 0, 0, 0 },
                                new List<int>() { 0, 0, 0 },
                                new List<int>(){ 0, 0, 0 },
                                new List<int>(){0,0,0}
                            };

            //Act
            int totalScore = menu.GetTotalScore(CompletlyGame);
            //asset
            Assert.AreEqual(0, totalScore);
            
        }
        [Test]
        public void Should_be_add_points_when_not_have_strike_or_spare()
        {

            //Arrange
            List<List<int>> CompletlyGame = new List<List<int>>
                            {   new List<int>(){ 5,2,3},
                                new List<int>(){ 3,1,2},
                                new List<int>(){ 9,4,5},
                                new List<int>(){ 8,4,4},
                                new List<int>(){ 7,3,4},
                                new List<int>(){ 6, 3, 3 },
                                new List<int>(){ 6, 1, 5 },
                                new List<int>(){ 7, 1, 6 },
                                new List<int>(){ 4, 4, 0 },
                                new List<int>(){1,0,1}
                            };

            //Act
            int totalScore = menu.GetTotalScore(CompletlyGame);
            //asset
            Assert.AreEqual(56, totalScore);
        }
        [Test]
        public void Should_add_points_to_the_last_round_when_last_round_was_strike()
        {

            //Arrange
            List<List<int>> GameWithStrike = new List<List<int>>
                            {  
                                new List<int>(){ 10,10,0},
                                new List<int>(){ 4,2,2},
                            };

            //Act
             menu.rounds = GameWithStrike;
             var scoreRound= menu.SumWhenIsStrike(1);

            //asset
            Assert.AreEqual(14, scoreRound);
        }

        [Test]
        public void Should_add_points_to_the_last_round_when_last_round_was_spare()
        {

            //Arrange
            List<List<int>> GameWithSpare = new List<List<int>>
                            {
                                new List<int>(){ 10,6,4},
                                new List<int>(){ 4,2,2},
                            };

            menu.rounds = GameWithSpare;

            //Act
            var scoreRound = menu.SumWhenIsSpare(1);

            //asset
            Assert.AreEqual(12, scoreRound);
        }

        [Test]
        public void Should_be_strike_when_ten_pines_are_fallen_at_first_turn()
        {

            //Arrange
            List<int> GameWithStrike = new List<int> { 10, 10, 0 };
            //Act
            bool isStrike = menu.IsThisRoundStrike(GameWithStrike);

            //asset
            Assert.AreEqual(true, isStrike);
        }

        [Test]
        public void Should_be_spare_when_ten_pines_are_fallen_in_total_and_is_not_strike()
        {

            //Arrange
            List<int> GameWithSpare= new List<int> { 10, 1, 9 };
            //Act
            bool isSpare = menu.IsThisRoundSpare(GameWithSpare);

            //asset
            Assert.AreEqual(true, isSpare);
        }

        [Test]
        public void Should_be_add_points_when_not_have_strike_or_spare_in_one_round()
        {

            //Arrange
            List < int> oneRound= new List<int>() { 5, 2, 3 };

            //Act
            int totalScoreOfRound = menu.GetScoreInRound(oneRound);
            //asset
            Assert.AreEqual(5, totalScoreOfRound);
        }

        [Test]
        
        public void Should_be_add_two_more_rounds_when_last_round_is_strike()
        {

            //Arrange
            List<int> oneRound = new List<int>() { 5, 2, 3 };

            //Act
            int totalScoreOfRound = menu.GetScoreInRound(oneRound);
            //asset
            Assert.AreEqual(5, totalScoreOfRound);
        }


    }
}
