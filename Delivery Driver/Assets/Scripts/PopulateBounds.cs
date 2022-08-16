using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            float upperBoundX = child.GetComponent<Renderer>().bounds.center.x + child.GetComponent<Renderer>().bounds.extents.x;
            float lowerBoundX = child.GetComponent<Renderer>().bounds.center.x - child.GetComponent<Renderer>().bounds.extents.x;
            float upperBoundY = child.GetComponent<Renderer>().bounds.center.y + child.GetComponent<Renderer>().bounds.extents.y;
            float lowerBoundY = child.GetComponent<Renderer>().bounds.center.y - child.GetComponent<Renderer>().bounds.extents.y;

            for (int i = 0; i < 40; i++){
                float randomPositionX = Random.Range(lowerBoundX, upperBoundX);
                float randomPositionY = Random.Range(lowerBoundY, upperBoundY);
                
                GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
                int randomTree = Random.Range(0,3);

                GameObject newTree = GameObject.Instantiate(trees[randomTree]);
                newTree.transform.position = new Vector3(randomPositionX, randomPositionY, 0);
            }            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
