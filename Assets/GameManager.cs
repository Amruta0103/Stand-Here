using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Tile[] tiles;

    public float roundTime = 5f;
    public float detectionRadius = 0.28f;

    private float timer;
    private bool gameOver = false;

    public PlayerTileDetector player;
    private UIManager uiManager;

    void Start()
    {
        tiles = FindObjectsByType<Tile>();
        uiManager = FindAnyObjectByType<UIManager>();
        player = FindAnyObjectByType<PlayerTileDetector>();
        StartRound();
    }

    void Update()
    {
        if (gameOver)
        {
          return;
        }

        timer -= Time.deltaTime;
        uiManager.UpdateTimer(timer);

        // WIN
        if (player.currentTile != null &&
            player.currentTile.isSafeTile)
        {
            Vector3 offset = player.transform.position - player.currentTile.transform.position;
            offset.y = 0;

            if (Mathf.Abs(offset.x) <= detectionRadius &&
                Mathf.Abs(offset.z) <= detectionRadius)
            {
                gameOver = true;
                uiManager.ShowWin();
                Time.timeScale = 0f;
            }
        }

        // LOSE
        if (timer <= 0f)
        {
            gameOver = true;
            uiManager.ShowLoss();
            Time.timeScale = 0f;
        }
    }

    void StartRound()
    {
      Time.timeScale = 1f;

      timer = roundTime;
      uiManager.UpdateTimer(timer);

      foreach (Tile tile in tiles)
      {
          if (Random.value < 0.7f)
              tile.SetState(Tile.TileState.Red);
          else
              tile.SetState(Tile.TileState.Black);
      }

      Tile safeTile;

      do
      {
        safeTile = tiles[Random.Range(0, tiles.Length)];
      }
      while (safeTile.name == "TileR3_2");

      safeTile.SetState(Tile.TileState.Green);
    }
}