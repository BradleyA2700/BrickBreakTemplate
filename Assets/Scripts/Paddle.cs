using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float bounceMultiplyer = 1f, moveSpeed = 5f, restraint = 6.45f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Controls collision with ball to send it flying the away based on where it landed on the padle
        if (collision.gameObject.GetComponent<Rigidbody2D>() == null) { return; }
        float bounceDir = 0;
        float bounceCheck = collision.transform.position.x - transform.position.x;
        if (bounceCheck < 0)
        {
            bounceDir = -4 + bounceCheck;
        } else if (bounceCheck > 0) { bounceDir = 4 + bounceCheck; }
        // Sets the velocity of the ball when it lands
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(bounceDir,4);
    }

    private void FixedUpdate()
    {
        //Controles padle movement with constraints
        if (transform.position.x >= restraint)
        {
            transform.position = new Vector2(restraint, -4.3f);
        }
        else if (transform.position.x <= -restraint)
        {
            transform.position = new Vector2(-restraint, -4.3f);
        }
        if ((transform.position.x < restraint && Input.GetAxis("Horizontal") > 0) || (transform.position.x > -restraint && Input.GetAxis("Horizontal") < 0)) { transform.Translate(moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0); }
    }
}
