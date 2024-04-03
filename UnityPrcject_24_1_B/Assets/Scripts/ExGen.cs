using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject item;
    public float checkTime;

    // Update is called once per frame
    void Update()
        
    {
        checkTime += Time.deltaTime;
        if(checkTime > 2.0f)
        {
            GameObject Temp = Instantiate(item);
            Temp.transform.position += new Vector3(0.0f, Random.Range(0, 4), 0.0f);
            Destroy(Temp, 20.0f);
            checkTime = 0.0f;
        }
    }
}
