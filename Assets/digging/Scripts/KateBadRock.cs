using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KateBadRock : MonoBehaviour
{
 
     

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KatePlayer")
        {
            KatePlayer kateplayer = other.transform.GetComponent<KatePlayer>();
            if (kateplayer != null)
            {
                kateplayer.Damage();
            }


        }
    }
}
