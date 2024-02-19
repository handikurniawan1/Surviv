using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunculinLaser3 : MonoBehaviour
{
    public GameObject laser;
    public float waktumin;
    public float waktumaks;
    public float makspos, minpos;
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
        Instantiate(laser, transform.position+ Vector3.right * Random.Range(minpos, makspos), Quaternion.Euler(90, 90, 0));
        yield return new WaitForSeconds(Random.Range(waktumin, waktumaks));
        StartCoroutine(MunculLaser());
    }
}
