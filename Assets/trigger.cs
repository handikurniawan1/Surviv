using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class trigger : MonoBehaviour
{
    public Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection, Space.World);

        if(Input.GetKeyDown(KeyCode.R)){
            Application.LoadLevel(Application.loadedLevel);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("MainMenu");
        }
        Destroy(gameObject, 13f);
    }
    
    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Player")){
            Destroy(collider.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
