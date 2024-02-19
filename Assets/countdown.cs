using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class countdown : MonoBehaviour
{
    public float timeStart = 60;
    public Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();
        if(textBox.text == "0"){
            SceneManager.LoadScene("Win");
        }
    }
}
