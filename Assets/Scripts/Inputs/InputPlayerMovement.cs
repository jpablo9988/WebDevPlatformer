using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayerMovement : MonoBehaviour, IControlInput
{
    [SerializeField]
    private PlayerMovement movement;
    private bool activateControls = true;
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
            float direction = Input.GetAxis("Horizontal");
            movement.MovePlayer(direction);
            if (Input.GetButtonDown("Jump"))
            {
                movement.PlayerJump();
            }
        }
    }
}
