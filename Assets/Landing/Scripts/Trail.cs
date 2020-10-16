using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField]
    float _speed = 5f;
    float scaleChange = -.075f;


   
    void Update()
    {
        //controls the trail to move down, shrink, then get deleted
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        transform.localScale += new Vector3(scaleChange, scaleChange, scaleChange);

        if (transform.localScale.y < .3||transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
