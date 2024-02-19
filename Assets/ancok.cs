using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ancok : MonoBehaviour
{
    public float fallTime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.gameObject.CompareTag("hancur")){
            StartCoroutine(Fall(fallTime));
        }
    }


    IEnumerator Fall(float time)
	{
		yield return new WaitForSeconds(time);
		Destroy (GameObject.FindWithTag("hancur"));
	}
}
