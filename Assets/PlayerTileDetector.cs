using UnityEngine;

public class PlayerTileDetector : MonoBehaviour
{
    public Tile currentTile;
    public float detectionRadius = 0.35f;

    private Tile[] tiles;

    void Start()
    {
        tiles = FindObjectsByType<Tile>();
    }

void Update()
{
    if (tiles == null)
    {
        Debug.LogError("Tiles array is NULL!");
        return;
    }

    currentTile = null;

    foreach (Tile tile in tiles)
    {
        if (tile == null)
            continue;

        Vector3 offset = transform.position - tile.transform.position;
        offset.y = 0;

        if (Mathf.Abs(offset.x) <= 0.4f &&
            Mathf.Abs(offset.z) <= 0.4f)
        {
            currentTile = tile;
            break;
        }
    }
}
}