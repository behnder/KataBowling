using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundScore : MonoBehaviour
{

    GameManager CompleteGame;
    List<int> myRound = new List<int>();
    [SerializeField] int roundPosition;
    [SerializeField] int elementOfRound;


    void Start()
    {

        CompleteGame = GameObject.Find("Manager").GetComponent<GameManager>();

    }
    private void Update()
    {
        if (CompleteGame.roundIsStart)
        {
            myRound = CompleteGame.bowlingGame.rounds[roundPosition];
            gameObject.GetComponent<Text>().text = myRound[elementOfRound].ToString();
        }
    }


}
