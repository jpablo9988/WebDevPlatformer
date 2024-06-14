using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    private void Awake()
    {
        menu.SetActive(false);
    }
    public void BringGameOver()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ToMainMenu()
    {
        //Load Main Menu ... !
    }
}
