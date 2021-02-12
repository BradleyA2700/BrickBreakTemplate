using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballForce = 200f;
    Rigidbody2D rb2D;
    GameObject mainCamera;
    WorldManager world;

    void Awake()
    {
        // Sets default values
        if (GameObject.Find("WorldManager").GetComponent<WorldManager>() != null) { world = GameObject.Find("WorldManager").GetComponent<WorldManager>(); }   
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(new Vector2(0,ballForce));
    }
    private void LateUpdate()
    {
        // Checks for if the ball has left the map and makes it inactive and tells the world there is one less ball to track
        if (transform.position.y < -15) { world.SetBalls(world.GetBalls() - 1); gameObject.SetActive(false); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Causes impact effects
        mainCamera.GetComponent<ScreenShake>().StartShake(0.1f,0.4f);
        GetComponent<AudioSource>().Play(); 
    }
}
