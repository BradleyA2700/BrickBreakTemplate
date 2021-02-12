using UnityEngine;

public class BoxScript : MonoBehaviour
{
    float deathTime = 1;
    bool dying = false;

    SpriteRenderer sr;
    GameObject ball;
    Vector3 startScale;
    WorldManager world;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball" ) {
            if (Random.Range(0f, 1f) > 0.9f) // Random chance to spawn a new ball
            {
                ball = collision.gameObject;
                Instantiate(ball, transform.position, Quaternion.identity); // Spawns in the ball
                world.SetBalls(world.GetBalls()+1); // Notifies the world that there is a extra ball to track
            }
            world.Setobjects(world.Getobjects() - 1); // tells the world there is one less object to track
            GetComponent<BoxCollider2D>().enabled = false; // Disables collision
            dying = true; // Starts the death process
        }
    }
    private void Awake()
    {
        // Sets default Values and Object References
        startScale = transform.localScale;
        sr = GetComponent<SpriteRenderer>();
        world = GameObject.Find("WorldManager").GetComponent<WorldManager>();

        world.Setobjects(world.Getobjects() +1);// Tells the world it exists

        sr.color = CreateNewColour();
    }
    /*
     * Creates a random colour with high saturation for the block
     * returns Color, The newly made colour for the block
     */
    Color CreateNewColour()
    {
        Color newColour = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)); // Creates a new colour for the block
        float highestColour = newColour.r; // sets the red value to be the highest value
        int colRef = 1; // Marks the red value to be the current value
        //Checks for what colour value is the most saturated and sets colRef to match the colour R - 1, G - 2, B - 3
        if (newColour.g > highestColour) { colRef = 2; highestColour = newColour.g; }
        if (newColour.b > highestColour) { colRef = 3; }
        //Gets the colour value that is the highest and sets it to 1 to give a more saturated look
        switch (colRef)
        {
            case 1:
                newColour.r = 1;
                break;
            case 2:
                newColour.g = 1;
                break;
            case 3:
                newColour.b = 1;
                break;
            default:
                break;
        }
        return newColour;
    }
    private void Update()
    {
        // Death manger
        if (dying == true)
        {
            deathTime -= Time.deltaTime; // reduces time till complete death
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, deathTime); // lower alpha to match death time
            transform.localScale = startScale * deathTime; // shrinks box till dead
        }
        if (deathTime <= 0) { gameObject.SetActive(false); } // disables the object
    }
}
