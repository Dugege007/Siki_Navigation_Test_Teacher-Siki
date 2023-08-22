using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlaceBuilder : MonoBehaviour
{
    public GameObject builderPrefab;
    private NavMeshSurface surface;

    private void Start()
    {
        surface = GetComponent<NavMeshSurface>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject newBuilding = Instantiate(builderPrefab, hit.point + Vector3.up, Quaternion.identity);
                newBuilding.transform.parent = transform;
                surface.BuildNavMesh();
            }
        }
    }
}
