using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    /*
     * Loads the game scene when button is pressed
     */
    public void StartGame() {
        SceneManager.LoadScene("Level_1_Scene");
        GameObject.Find("WorldManager").GetComponent<WorldManager>().SetBalls(1);
    }
}
