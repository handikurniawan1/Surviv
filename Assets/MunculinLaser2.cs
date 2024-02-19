using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunculinLaser2 : MonoBehaviour
{
    public GameObject laser;
    public float waktumin;
    public float waktumaks;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MunculLaser());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MunculLaser(){
        Instantiate(laser, transform.position, Quaternion.Euler(90, 0, 0));
        yield return new WaitForSeconds(Random.Range(waktumin, waktumaks));
        StartCoroutine(MunculLaser());
    }
}
