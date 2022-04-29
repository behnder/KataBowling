using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{

    GameManager CompleteGame;
    List<int> myRound = new List<int>();
    int totalScore;
    // Start is called before the first frame update
    void Start()
    {
        CompleteGame = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CompleteGame.roundIsStart)
        {
            totalScore = CompleteGame.bowlingGame.GetTotalScore(CompleteGame.bowlingGame.rounds);
            gameObject.GetComponent<Text>().text = totalScore.ToString();
        }
    }
}
