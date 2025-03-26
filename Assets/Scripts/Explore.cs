using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explore : MonoBehaviour
{
    private float interactionRange = 1.5f;
    public ExploreData exploreData;
    private void Update()
    {
        float distanceExplore = Vector3.Distance(transform.position, exploreData.transform.position);

        if (Input.GetKeyDown(KeyCode.F) && distanceExplore <= interactionRange)
        {
            switch (exploreData.exploreType)
            {
                case ExploreType.puzzle:
                    Debug.Log("ÆÛÁñ ¹ß°ß");
                    break;


            }
                
        }
    }
}
