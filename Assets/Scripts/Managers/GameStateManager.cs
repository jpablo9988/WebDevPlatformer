using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField]
    private GameOverManager gameOverMenu;
    [SerializeField]
    private GameOverManager winGameManager;

    public void GameOver()
    {
        //Activate completely the inputs. 
        InputMaster.Instance.KillInputs();
        //Bring up GameOver Menu
        gameOverMenu.BringGameOver();
    }
    public void WinGame()
    {
        //Activate completely the inputs. 
        InputMaster.Instance.KillInputs();
        //Bring up GameOver Menu
        winGameManager.BringGameOver();
    }
}
