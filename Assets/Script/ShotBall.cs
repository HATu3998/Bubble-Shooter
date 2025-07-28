using UnityEngine;

public class ShotBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject BallShot, BallReLoad;
    void Start()
    {
        ReLoadBall();
        ChangeBallReLoad();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBall();
            soundController.Instance.PlayFireSound();
        }
    }
    void ChangeBallReLoad()
    {
        GameObject ball = BallReLoad.transform.GetChild(0).gameObject;
        ball.transform.parent = BallShot.transform;
        ball.transform.localPosition = Vector3.zero;
        ReLoadBall();
    }
    void ReLoadBall()
    {
        GameObject ball = BallController.controller.GetRamDownBall();
        ball.transform.parent = BallReLoad.transform;
        ball.transform.localPosition = Vector3.zero;
    }
    void ShootBall()
    {
        if(BallShot.transform.childCount != 0)
        {
            Vector3 PositionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PositionMouse.z = 0;
            Vector3 direction = (PositionMouse - BallShot.transform.GetChild(0).position).normalized;

            BallShot.transform.GetChild(0).GetComponent<BallScript>().Direction = direction;
            BallShot.transform.GetChild(0).parent = null;
            ChangeBallReLoad();
        }
    }
}
