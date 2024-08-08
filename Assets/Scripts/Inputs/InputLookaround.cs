using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLookaround : MonoBehaviour, IControlInput
{
    [SerializeField]
    private ChangeLookDirection lookaround;

    private bool activateControls;
    private Vector2 movementAxis;
    private Joystick joystick;
    private void Awake()
    {
        activateControls = true;
        movementAxis = new(0, 0);
    }

    public void ActivateControls(bool activate)
    {
        activateControls = activate;
    }
    private void Update()
    {
        if (activateControls)
        {
            if (InputMaster.Instance.MobileControls)
            {
                movementAxis.x = joystick.Horizontal;
                movementAxis.y = joystick.Vertical;
            }
            else
            {
                movementAxis.x = Input.GetAxisRaw("Horizontal");
                movementAxis.y = Input.GetAxisRaw("Vertical");
            }
            lookaround.MoveLookaround(movementAxis);
        }
    }

    public void KillControls()
    {
        this.gameObject.SetActive(false);

    }
    public void SetJoystick(Joystick joystick)
    {
        this.joystick = joystick;
    }
}
