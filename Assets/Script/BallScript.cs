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
    private void OnTriggerEnter2D(Collider2D col )
    {
        if(col.transform.parent ==null && gameObject.transform.parent.name == "BallPool")
        {
            col.transform.parent = gameObject.transform.parent;
            col.GetComponent<BallScript>().Direction = Vector3.zero;

            BallSpawner.Spawner.SoftBall(col.gameObject, gameObject);
        }
    }
}
