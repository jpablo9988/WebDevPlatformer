using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// InputMaster is a Monobehaviour bus that deals with all Scripts that use inputs (and are registered). 
/// Juan Pablo Amorocho - 301410163
/// </summary>
public class InputMaster : SingletonClass<InputMaster>
{
    private List<IControlInput> inputManagers;
    [SerializeField]
    Joystick joystick;
    [SerializeField]
    private bool mobileControls;
    public bool MobileControls { get { return mobileControls; } private set { mobileControls = value;  } }

    protected override void Awake()
    {
        base.Awake();
        inputManagers = GetComponents<IControlInput>().ToList();
        // -- Setup Scene Joystick -- //
    }

    private void Start()
    {
        PopulateJoystick();
    }
    private void PopulateJoystick()
    {
        foreach (IControlInput manager in inputManagers)
        {
            manager.SetJoystick(this.joystick);
        }
    }
    /// <summary>
    /// Call this to pause all registeted scripts that are type IControlInput.
    /// </summary>
    /// <param name="pausing"></param>
    public void PauseInputs(bool pausing)
    {
        foreach(IControlInput manager in inputManagers)
        {
            manager.ActivateControls(!pausing);
        }
    }
    public void KillInputs()
    {
        foreach (IControlInput manager in inputManagers)
        {
            manager.KillControls();
        }
    }
}
