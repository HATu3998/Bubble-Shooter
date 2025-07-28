using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private float ballSize = 0.75f;
    private int numberBallInRow;
    public Vector3 spawnPosition;
    private GameObject[,] listBall;
    private int indexRow;
    public GameObject ballPool;
    public static BallSpawner Spawner;

    private void Awake()
    {
        Spawner = this;
    }

    private void Start()
    {
        float height, width;
        GetScreenSize(out height, out width);
        Debug.Log("Height: " + height);
        Debug.Log("Width: " + width);

        numberBallInRow = Mathf.FloorToInt(width / ballSize / 2);

        Vector3 topCenter = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, 10f));
        spawnPosition = new Vector3(
            topCenter.x - (numberBallInRow * ballSize / 2) + ballSize / 2,
            topCenter.y - ballSize,
            0
        );

        listBall = new GameObject[1000, numberBallInRow];
        int numRow = Mathf.FloorToInt(height / ballSize);
        SpawnGrid(numRow);

        StartCoroutine(LoopEach5Second());
    }

    private void GetScreenSize(out float height, out float width)
    {
        height = Camera.main.orthographicSize * 2;
        width = height * Screen.width / Screen.height;
    }

    private void SpawnRow()
    {
        Vector3 pos = spawnPosition;
        if (indexRow > 0)
        {
            pos.y = listBall[indexRow - 1, 0].transform.position.y + ballSize;
        }
        else
        {
            pos.y += ballSize;
        }

        if (indexRow % 2 == 0)
        {
            for (int i = 0; i < numberBallInRow; i++)
            {
                GameObject ball = BallController.controller.GetRamDownBall();
                ball.transform.position = pos;
                listBall[indexRow, i] = ball;
                pos.x += ballSize;
                ball.transform.parent = ballPool.transform;
            }
        }
        else
        {
            pos.x += ballSize / 2;
            for (int i = 0; i < numberBallInRow - 1; i++)
            {
                GameObject ball = BallController.controller.GetRamDownBall();
                ball.transform.position = pos;
                listBall[indexRow, i] = ball;
                pos.x += ballSize;
                ball.transform.parent = ballPool.transform;
            }
        }

        indexRow++;
    }

    private void SpawnGrid(int numberRow)
    {
        for (int j = 0; j < numberRow; j++)
        {
            Vector3 pos = spawnPosition;
            if (indexRow > 0)
            {
                pos.y = listBall[indexRow - 1, 0].transform.position.y + ballSize;
            }
            else
            {
                pos.y += ballSize;
            }

            if (indexRow % 2 == 0)
            {
                for (int i = 0; i < numberBallInRow; i++)
                {
                    GameObject ball = new GameObject("Ball");
                    ball.transform.position = pos;
                    listBall[indexRow, i] = ball;
                    pos.x += ballSize;
                    ball.transform.parent = ballPool.transform;
                }
            }
            else
            {
                pos.x += ballSize / 2;
                for (int i = 0; i < numberBallInRow - 1; i++)
                {
                    GameObject ball = new GameObject("Ball");
                    ball.transform.position = pos;
                    listBall[indexRow, i] = ball;
                    pos.x += ballSize;
                    ball.transform.parent = ballPool.transform;
                }
            }

            indexRow++;
        }

        Vector3 poolPos = ballPool.transform.position;
        poolPos.y -= ballSize * (numberRow - 1);
        ballPool.transform.position = poolPos;
    }

    private void GetIndex(GameObject ball, out int row, out int col)
    {
        row = -1;
        col = -1;
        for (int i = 0; i < listBall.GetLength(0); i++)
        {
            for (int j = 0; j < listBall.GetLength(1); j++)
            {
                if (listBall[i, j] == ball)
                {
                    row = i;
                    col = j;
                    return;
                }
            }
        }
    }

    public void SoftBall(GameObject ballShot, GameObject ballInPool)
    {
        int row, col;
        GetIndex(ballInPool, out row, out col);

        if (row < 0 || col < 0) return;

        for (int i = Mathf.Max(0, row - 1); i <= Mathf.Min(listBall.GetLength(0) - 1, row + 1); i++)
        {
            for (int j = Mathf.Max(0, col - 1); j <= Mathf.Min(listBall.GetLength(1) - 1, col + 1); j++)
            {
                if (listBall[i, j] == null) continue;
                float distance = Vector3.Distance(ballShot.transform.position, listBall[i, j].transform.position);
                if (distance < ballSize)
                {
                    ballShot.transform.position = listBall[i, j].transform.position;
                    listBall[i, j] = ballShot;
                    return;
                }
            }
        }
    }

    private IEnumerator LoopEach5Second()
    {
        while (true)
        {
            SpawnRow();
            yield return new WaitForSeconds(5);
        }
    }
}