using UnityEngine;

public class BallPoolScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, (float)(Time.deltaTime * speed * -0.1), 0));
    }
}
