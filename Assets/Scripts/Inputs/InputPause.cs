using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPause : MonoBehaviour, IControlInput
{
    private bool areControlsActive;

    private PauseManager pauseManager;


    private void Awake()
    {
        pauseManager = GameMaster.Instance.PauseManager;
    }
    public void ActivateControls(bool activate)
    {
        areControlsActive = activate;
    }

    void Update()
    {
        //Ignores pause behavior.
        if (Input.GetButtonDown("Cancel"))
        {
            pauseManager.PauseGameWithMenu();
        }
    }

    public void KillControls()
    {
        this.gameObject.SetActive(false);
    }
    public void SetJoystick(Joystick joystick)
    {
        // -- Unimplemented -- No need for joystick .
    }
}
