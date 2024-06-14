using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    public bool IsPaused { get; set; }
    private void Awake()
    {
        IsPaused = false;    }
    private void Start()
    {
        PauseGame(IsPaused);
    }
    public void PauseGameWithMenu()
    {
        IsPaused = !IsPaused;
        //Activate UI Panel here: 
        pauseMenu.SetActive(IsPaused);
        //Pause functions here:
        PauseGame(IsPaused);
    }
    public void PauseGame(bool input)
    {
        //Stop game time here: 
        if (input) Time.timeScale = 0f;
        else Time.timeScale = 1f;
        //Stop player inputs here: 
        InputMaster.Instance.PauseInputs(input);
    }
    public void ResumeGame()
    {
        PauseGameWithMenu();
    }
    public void ToMainMenu()
    {
        //Load Main Menu ... !
    }
}
