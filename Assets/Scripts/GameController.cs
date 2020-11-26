using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject GameAreaGroundTile;
    public GameObject BackgroundGroundTile;

    public float LevelDistance;

    private Vector3 _origin = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
        GeneratePlayingArea();
        GenerateBackground();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void GeneratePlayingArea()
    {
        if (GameAreaGroundTile == null)
        {
            Debug.Break();
            throw new MissingReferenceException("Game area failed to generate - no game area ground tile found.");
        }

        var renderer = GameAreaGroundTile.GetComponent<Renderer>();

        if (renderer == null)
        {
            Debug.Break();
            throw new MissingComponentException("Game area failed to generate - no renderer found on ground tile.");
        }

        var minimumBoundingPoint = renderer.bounds.min;
        var maximumBoundingPoint = renderer.bounds.max;

        // @TODO Make it so that the game area ground tile is generated starting at max bounding point for next tile but then terminates once level distance is reached
    }

    private void GenerateBackground()
    {
        if (BackgroundGroundTile == null)
        {
            Debug.Break();
            throw new MissingReferenceException("Background area failed to generate - no background ground tile found.");
        }
    }
}
