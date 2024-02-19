using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class lavamati : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Player")){
            Destroy(collider.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
