using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ControlMode {Keyboard = 1, Touch = 2}

public class InputMobile : MonoBehaviour
{
    public ControlMode control;
    public float LeftButton;
    public float RightButton;
    public float LookUpButton;
    public float LookDownButton;
    public float JumpButton;
    public GameObject UI;
    public void LeftButtonInput(float input) { LeftButton = input; } 
    public void RightButtonInput(float input) { RightButton = input; }
    public void LookUpButtonInput(float input) { LookUpButton = input; }
    public void LookDownButtonInput(float input) { LookDownButton = input; }
    public void JumpButtonInput(float input) { JumpButton = input; }
    PlayerMovement Player;
    
    void Start()
    {
        Player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(control == ControlMode.Keyboard)
        {
            LeftButton = Input.GetAxis("Vertical");
            RightButton = Input.GetAxis("Vertical");
            LookUpButton = Input.GetAxis("Horizontal");
            LookDownButton = Input.GetAxis("Horizontal");
            JumpButton = Input.GetAxis("Horizontal");
            UI.SetActive(false);
        }
        else
        {
            UI.SetActive(true);
        }
        
    }

    private void FixedUpdate()
    {
        //Player.MovePlayer();
    }
}
