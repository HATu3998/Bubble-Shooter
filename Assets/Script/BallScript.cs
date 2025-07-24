using UnityEngine;

public class BallScript : MonoBehaviour
{
    public int speed =5;
    public Vector3 Direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Direction != Vector3.zero)
        {
            transform.Translate(Direction * Time.deltaTime * speed);
        }
    }
}
