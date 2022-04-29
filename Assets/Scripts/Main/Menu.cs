using System.Collections.Generic;
using UnityEngine;

public class Menu // : MonoBehaviour
{

    public const int MAX_PINES = 10;


    public List<List<int>> rounds = new List<List<int>>();


    private void Awake()
    {

        Game();
    }


    public int FallenPines(int maxPines)
    {

        return Random.Range(0, maxPines + 1);


    }

    public void Game()
    {
        for (int i = 0; i < 9; i++)
        {
            rounds.Add(PlayOneRound());
            if (i > 0)
            {
                if (IsThisRoundStrike(rounds[i - 1]))
                {
                    SumWhenIsStrike(i);
                }
                else if (IsThisRoundSpare(rounds[i - 1]))
                {
                    SumWhenIsSpare(i);
                }

            }
        }
        rounds.Add(PlayOneRound());
        CheckBonus();
    }

    public void CheckBonus()
    {
        var totalBonificacion = 0;
        if (IsThisRoundStrike(rounds[rounds.Count - 1]))
        {

            totalBonificacion = PlayOneRound()[0];

        }
        else if (IsThisRoundSpare(rounds[rounds.Count - 1]))
        {
            totalBonificacion = PlayOneRound()[1];
        }

        rounds[rounds.Count - 1][0] += totalBonificacion;
    }

    public int GetTotalScore(List<List<int>> completlyGame)
    {
        var score = 0;

        foreach (var round in completlyGame)
        {
            score += round[0];
        }
        return score;


    }

    public bool IsThisRoundStrike(List<int> round)
    {

        if (round[1] == 10)
        {

            return true;
        }
        return false;

    }

    public int SumWhenIsStrike(int i)
    {
        return rounds[i - 1][0] += rounds[i][1] + rounds[i][2];
    }

    public int SumWhenIsSpare(int i)
    {
        return rounds[i - 1][0] += rounds[i][1];
    }

    public bool IsThisRoundSpare(List<int> gameWithSpare)
    {

        if (gameWithSpare[1] < 10 && gameWithSpare[1] + gameWithSpare[2] == 10)
        {
            return true;
        }


        return false;
    }

    public int GetScoreInRound(List<int> oneRound)
    {
        return (oneRound[1] + oneRound[2]);
    }

    public List<int> PlayOneRound()
    {

        List<int> oneRound = new List<int>();
        int PinesFallenFirstTry = 0, PinesFallenSecondTry = 0;

        PinesFallenFirstTry = FallenPines(MAX_PINES);
        PinesFallenSecondTry = FallenPines(MAX_PINES - PinesFallenFirstTry);


        oneRound.Add(0);
        oneRound.Add(PinesFallenFirstTry);
        oneRound.Add(PinesFallenSecondTry);
        oneRound[0] = GetScoreInRound(oneRound);

        return oneRound;

    }

}