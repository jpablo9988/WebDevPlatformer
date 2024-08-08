using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayerMovement : MonoBehaviour, IControlInput
{
    [SerializeField]
    private PlayerMovement movement;
    
    private bool activateControls = true;
    private Joystick joystick;
    public void ActivateControls(bool activate)
    {
        activateControls = activate;
    }

    public void KillControls()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activateControls)
        {
            float direction;
            if (InputMaster.Instance.MobileControls)
            {
                direction = joystick.Horizontal;
            }
            else
            {
                direction = Input.GetAxis("Horizontal");
            }
            movement.MovePlayer(direction);
            if (Input.GetButtonDown("Jump"))
            {
                movement.PlayerJump();
            }
        }
    }
    public void Jump()
    {
        if (activateControls)
        {
            movement.PlayerJump();
        }
    }

    public void SetJoystick(Joystick joystick)
    {
        this.joystick = joystick;
    }
}
