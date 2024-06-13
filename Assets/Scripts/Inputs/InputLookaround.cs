using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLookaround : MonoBehaviour, IControlInput
{
    [SerializeField]
    private ChangeLookDirection lookaround;

    private bool activateControls;
    private Vector2 movementAxis;
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
            movementAxis.x = Input.GetAxisRaw("Horizontal");
            movementAxis.y = Input.GetAxisRaw("Vertical");
            lookaround.MoveLookaround(movementAxis);
        }
    }
}
