using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Main Manager Bus (holds all manager refs) & Singleton Instance.
/// </summary>
public class GameMaster : SingletonClass<GameMaster>
{

    [SerializeField]
    private PauseManager pauseManager;

    public PauseManager PauseManager
    {
        get { return pauseManager; }
        private set
        {
            pauseManager = value;
        }
    }
}
