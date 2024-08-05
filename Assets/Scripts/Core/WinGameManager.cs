using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameManager : MonoBehaviour
{
    [SerializeField]
    private string NextLevelName;

    [SerializeField]
    private string SavedLevelFlag;

    public void GoToNextStage()
    {
        PlayerPrefs.SetString(SystemConstants.CURRENT_STAGE_KEY, SavedLevelFlag);
        SceneManager.LoadScene(NextLevelName);
    }
}
