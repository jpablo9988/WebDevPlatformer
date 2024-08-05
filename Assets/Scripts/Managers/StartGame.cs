using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public string levelName;

    [SerializeField]
    private Button continueButton;

    void Start()
    {
        continueButton.interactable = PlayerPrefs.HasKey(SystemConstants.CURRENT_STAGE_KEY);
        Debug.Log(PlayerPrefs.HasKey(SystemConstants.CURRENT_STAGE_KEY));
    }

    public void LoadLevel()
    {
        PlayerPrefs.DeleteKey(SystemConstants.CURRENT_STAGE_KEY);
        SceneManager.LoadScene(levelName);
    }

    public void ContinueLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(SystemConstants.CURRENT_STAGE_KEY));
    }
}
