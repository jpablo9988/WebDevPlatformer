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
    [SerializeField]
    private CheckpointManager checkpointManager;
    [SerializeField]
    private GameStateManager gameStateManager;
    [SerializeField]
    private SFXManager sFXManager;

    public PauseManager PauseManager
    {
        get { return pauseManager; }
        private set
        {
            pauseManager = value;
        }
    }
    public Checkpoint ActiveCheckpoint
    {
        get { return checkpointManager.GetActiveCheckpoint(); }
        private set { }
    }
    public void GameOver()
    {
        gameStateManager.GameOver();
    }
    public void WinGame()
    {
        gameStateManager.WinGame();
    }
    public void PlaySfx(AudioClip clip)
    {
        sFXManager.PlaySFX(clip);
    }
}
