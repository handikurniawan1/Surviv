using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitButton(){
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame(){
        SceneManager.LoadScene("SampleScene");
    }
    public void Mainmenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
