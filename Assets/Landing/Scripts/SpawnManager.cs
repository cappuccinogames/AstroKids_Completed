using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _starPrefab;
    //[SerializeField]
    //private GameObject _enemyContainer;
    private bool _stopSpawn = false;

    //this is all to spawn the stars
    void Start()
    {
        StartCoroutine(SpawnRoutine());

    }    
    IEnumerator SpawnRoutine()
        {
            while (_stopSpawn == false)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), -6, 1);
                GameObject newEnemy = Instantiate(_starPrefab, posToSpawn, Quaternion.identity);
               
                yield return new WaitForSeconds(.5f);
            }
        }
    public void ActionDone()
    {
        _stopSpawn = true;
    }



}
