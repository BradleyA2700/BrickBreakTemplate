using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    float shakePower, shakeTime, shakeFade;
    /*
     * Causes the camera to shake giving impact to the ball
     * @Param power, Controls the strength of the shaking
     * @Param time, Controls how long the screen will shake for
     */
    public void StartShake(float power, float time)
    {
        shakePower = power;
        shakeTime = time;
        shakeFade = power / time;
    }
    private void Update()
    {
        // Resets the camera position to the center
        if (transform.position.x != 0 || transform.position.y != 0) { transform.position = new Vector3(0, 0, transform.position.z); }
    }
    private void LateUpdate()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;

            transform.position += new Vector3(Random.Range(-1f, 1f) * shakePower, Random.Range(-1f, 1f) * shakePower, 0);

            //Smoorthing so that the shake starts strong but smoothes out near the end
            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFade * Time.deltaTime);
        }
    }
}
