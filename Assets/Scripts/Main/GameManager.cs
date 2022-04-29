using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Menu bowlingGame = new Menu();
    public bool roundIsStart = false;


    private void Awake()
    {
        bowlingGame.Game();


    }


}
