using UnityEngine;

public class ShotBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject gameShot, gameReLoad;
    void Start()
    {
        ReLoadBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ReLoadBall()
    {
        GameObject ball = BallController.controller.GetRamDownBall();
        ball.transform.parent = gameShot.transform;
        ball.transform.localPosition = Vector3.zero;
    }
}
