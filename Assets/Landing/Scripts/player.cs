using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float trailOffset = -1.7f;
    [SerializeField]
    private GameObject _trailPrefab;
    [SerializeField]
    private GameObject _trailContainer;

    bool _stopSpawn = false;

    void Start()
    {
        //intitial position
       // transform.position = new Vector3(0, 0.80f, 0);
    }

    private void Update()
    {
        drawtail();
    }

    //spawning the trail under the player
    public void drawtail()
    {
        if (_stopSpawn == false)
        {
            //creating trails and storing them in trail container;
            GameObject newTrail = Instantiate(_trailPrefab, transform.position + new Vector3(0, trailOffset, .5f), Quaternion.identity);
            newTrail.transform.parent = _trailContainer.transform;
        }
    }

    public void stopTrail()
    {
        _stopSpawn = true;
    }
    
}
