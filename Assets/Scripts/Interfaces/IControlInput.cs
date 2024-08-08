using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControlInput
{
    public void ActivateControls(bool activate);
    public void KillControls();

    public void SetJoystick(Joystick joystick);
}
