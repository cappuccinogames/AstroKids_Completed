using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KateGrid : MonoBehaviour
{
    //start at central position - vector2.zero ex.
    //2 loops
    public int GridX = 10; //can change # in editor
    public int GridY = 10;
    public int TotalPrizeCount = 5;
    public List<GameObject> prefabList = new List<GameObject>();
    public GameObject DirtBlock;
    public GameObject BadBlock;
    public GameObject[,] GridObjects;
    public GameObject Prize;
    public List<GameObject> PrizeObjectsList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        //function to create grid at right of game object 
        CreateGrid();


        SpawnPrizes();

    }
    public void CreateGrid()
    {
        GridObjects = new GameObject[GridX, GridY];
        //at start calls to create grid
        for (int i = 0; i < GridX; i++)
        {
            for (int j = 0; j < GridY; j++)
            {
                //create dirt and bad blocks randomly

                GameObject block = Instantiate(prefabList[UnityEngine.Random.Range(0, prefabList.Count)]);
                block.transform.position = transform.position + Vector3.right * i + Vector3.down * j;
                GridObjects[i, j] = block;

                //check every time create cube if there are 3 neighbor bad blocks

                if (!CheckNeighbors(i, j))
                {
                    Destroy(block);
                    block = Instantiate(DirtBlock);
                    block.transform.position = transform.position + Vector3.right * i + Vector3.down * j;
                    GridObjects[i, j] = block;
                }
            }
        }
    }

    public bool CheckNeighbors(int x, int y)
    {

        int NeighbourBadRockCount = 0;

        if (x == 0)
        {
            return true;
        }
        if (y == 0)
        {
            return true;
        }

        if (x == GridObjects.GetLength(0) - 1)
        {
            return true;
        }

        if (y == GridObjects.GetLength(1) - 1)
        {
            return true;
        }


        if (GridObjects[x + 1, y - 1] != null && GridObjects[x + 1, y - 1].CompareTag("BadRock"))
        {
            NeighbourBadRockCount = NeighbourBadRockCount + 1;
        }
        if (GridObjects[x - 1, y + 1] != null && GridObjects[x - 1, y + 1].CompareTag("BadRock"))
        {
            NeighbourBadRockCount += 1;
        }
        if (GridObjects[x - 1, y - 1] != null && GridObjects[x - 1, y - 1].CompareTag("BadRock"))
        {
            NeighbourBadRockCount += 1;
        }
        if (GridObjects[x + 1, y + 1] != null && GridObjects[x + 1, y + 1].CompareTag("BadRock"))
        {
            NeighbourBadRockCount += 1;
        }

        if (GridObjects[x, y - 1] != null && GridObjects[x, y - 1].CompareTag("BadRock"))
        {
            NeighbourBadRockCount = NeighbourBadRockCount + 1;
        }
        if (GridObjects[x, y + 1] != null && GridObjects[x, y + 1].CompareTag("BadRock"))
        {
            NeighbourBadRockCount += 1;
        }
        if (GridObjects[x - 1, y] != null && GridObjects[x - 1, y].CompareTag("BadRock"))
        {
            NeighbourBadRockCount += 1;
        }
        if (GridObjects[x + 1, y] != null && GridObjects[x + 1, y].CompareTag("BadRock"))
        {
            NeighbourBadRockCount += 1;
        }
        Debug.Log(NeighbourBadRockCount);


        if (NeighbourBadRockCount > 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    public void SpawnPrizes()
    {
        for (int prizeCount = 0; prizeCount < TotalPrizeCount; prizeCount++) 
        {
            int prizeX = 0;
            int prizeY = 0;
            Vector3 prizePosition = Vector3.zero;

            bool isFound = false;
            do
            {
                isFound = true;

                prizeX = Random.Range(0, GridX);
                prizeY = Random.Range(0, GridY);

                prizePosition = transform.position + Vector3.right * prizeX + Vector3.down * prizeY;

                if (GridObjects[prizeX, prizeY].CompareTag("BadRock"))
                {
                    isFound = false;
                    continue;
                }

                foreach (GameObject prizeObj in PrizeObjectsList)
                {
                    if (prizeObj.transform.position == prizePosition)
                    {
                        isFound = false;
                        break;
                    }

                }

            } while (isFound == false);


            GameObject newPrize = Instantiate(Prize, prizePosition, Quaternion.identity);

            PrizeObjectsList.Add(newPrize);

        }

    }

}
