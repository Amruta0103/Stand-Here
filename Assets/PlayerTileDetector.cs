using UnityEngine;

public class PlayerTileDetector : MonoBehaviour
{
    public Tile currentTile;
    public float detectionRadius = 0.28f;

    private Tile[] tiles;

    void Start()
    {
        tiles = FindObjectsByType<Tile>();
    }

void Update()
{
    bool foundTile = false;

    foreach (Tile tile in tiles)
    {
        if (tile == null)
            continue;

        Vector3 offset = transform.position - tile.transform.position;
        offset.y = 0;

        if (Mathf.Abs(offset.x) <= detectionRadius &&
            Mathf.Abs(offset.z) <= detectionRadius)
        {
            currentTile = tile;
            foundTile = true;
            break;
        }
    }

    if (!foundTile)
        currentTile = null;
}
}