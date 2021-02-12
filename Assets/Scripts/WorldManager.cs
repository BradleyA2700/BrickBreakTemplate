using UnityEngine;
using UnityEngine.SceneManagement;

// Holds information about the number of balls and destroyable blocks in the game
public class WorldManager : MonoBehaviour
{
    static int balls = 1, objects = 0;
    public void SetBalls(int nBalls) { balls = nBalls; }
    public int GetBalls() { return balls; }
    public void Setobjects(int nObjects) { objects = nObjects; }
    public int Getobjects() { return objects; }
    private void LateUpdate()
    {
        if (balls <= 0 && SceneManager.GetActiveScene().name != "MainMenu") { SceneManager.LoadScene("MainMenu");}
        if (objects <= 0 && SceneManager.GetActiveScene().name != "MainMenu") { SceneManager.LoadScene("MainMenu"); }
    }
}
