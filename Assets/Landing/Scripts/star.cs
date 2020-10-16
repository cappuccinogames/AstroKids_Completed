using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    [SerializeField]
    private float _sspeed = 4f;
   

    // Update is called once per frame
    void Update()
    {
        
            transform.Translate(Vector3.up * _sspeed * Time.deltaTime);

            if (transform.position.y > 5f)
            {
            //also can make a random variable
            //transform.position = new Vector3(Random.Range(-9f, 9f), -6, 0);
            Destroy(this.gameObject);

            }
        
    }
}
