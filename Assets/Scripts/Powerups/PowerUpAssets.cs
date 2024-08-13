using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAssets : MonoBehaviour
{
    public static PowerUpAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform PowerUps;

    public Sprite smallHealthSprite;
    public Sprite bigHealthSprite;
    public Sprite fasterMovementSprite;
}
