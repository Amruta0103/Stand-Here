using UnityEngine;

public class Tile : MonoBehaviour
{
    public Material greenMaterial;
    public Material redMaterial;
    public Material blackMaterial;

    private Renderer tileRenderer;
    public bool isSafeTile = false;

    public enum TileState
    {
        Green,
        Red,
        Black
    }

    void Awake()
    {
        tileRenderer = GetComponent<Renderer>();
    }

    public void SetState(TileState state)
    {
        isSafeTile = (state == TileState.Green);

        switch (state)
        {
            case TileState.Green:
                tileRenderer.material = greenMaterial;
                break;

            case TileState.Red:
                tileRenderer.material = redMaterial;
                break;

            case TileState.Black:
                tileRenderer.material = blackMaterial;
                break;
        }
    }
}