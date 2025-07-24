using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float ballSize = 0.75f;
    private int NumberBallInRow;
    public Vector3 SpawnPosition;

    void Start()
    {
        float height, width;
        GetScreenSize(out height,out width);
        Debug.Log("height :" + height);
        Debug.Log("width :" + width);

        NumberBallInRow = Mathf.FloorToInt(width / ballSize / 2);
        SpawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, height, 0)); 
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GetScreenSize(out float height, out float width)
    {
        height = Camera.main.orthographicSize * 2;
        width = height * Screen.width / Screen.height;
    }
}