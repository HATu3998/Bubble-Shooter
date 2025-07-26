using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float ballSize = 0.75f;
    private int NumberBallInRow;
    public Vector3 SpawnPosition;
    GameObject[,] ListBall;
    int indexRow;
    public GameObject ballPool;

    void Start()
    {
        float height, width;
        GetScreenSize(out height, out width);
        Debug.Log("height :" + height);
        Debug.Log("width :" + width);

        NumberBallInRow = Mathf.FloorToInt(width / ballSize / 2);

        Vector3 topLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, Camera.main.nearClipPlane));
        SpawnPosition = new Vector3(topLeft.x + ballSize / 2, topLeft.y - ballSize, 0);

        //   SpawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, height, 0));
        SpawnPosition.x += ((ballSize / 2 + (width / 2 / 2)));
        SpawnPosition.z = 0;
        ListBall = new GameObject[1000, NumberBallInRow];
        StartCoroutine(LoopEach5Second());
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

    void SpawnRow()
    {
        Vector3 SpawnPosition = this.SpawnPosition;
        if (indexRow > 0)
        {
            SpawnPosition.y = ListBall[indexRow - 1, 0].transform.position.y + ballSize;
        }
        else
        {
            SpawnPosition.y += ballSize;
        }
        if (indexRow % 2 == 0)
        {
            for (int i = 0; i < NumberBallInRow; i++)
            {
                GameObject ballNew = BallController.controller.GetRamDownBall();
                ballNew.transform.position = SpawnPosition;
                ListBall[indexRow, i] = ballNew;
                SpawnPosition.x += ballSize;
                ballNew.transform.parent = ballPool.transform;
            }
        }
        else
        {
            SpawnPosition.x += ballSize / 2;
            for (int i = 0; i < NumberBallInRow - 1; i++)
            {
                GameObject ballNew = BallController.controller.GetRamDownBall();
                ballNew.transform.position = SpawnPosition;
                ListBall[indexRow, i] = ballNew;
                SpawnPosition.x += ballSize;
                ballNew.transform.parent = ballPool.transform;

            }
        }
            indexRow++;

        }

        IEnumerator LoopEach5Second()
        {
            while (true)
            {
                SpawnRow();
                yield return new WaitForSeconds(5);
            }
        }
    }
 