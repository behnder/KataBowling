using UnityEngine;

public class StartButton : MonoBehaviour
{
    GameManager CompleteGame;

    // Start is called before the first frame update
    void Start()
    {
        CompleteGame = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {

        CompleteGame.roundIsStart = true;
    }
}
