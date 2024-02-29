using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortalManager : MonoBehaviour
{
    public GameObject portalOne;
    public GameObject portalTwo;



    void Update()
    {
        shootPortal();
    }

    void shootPortal()
    {
        Vector3 shootDirection = Input.mousePosition;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection.z = 0f;
        shootDirection -= transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            generatePortalOne(shootDirection);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            generatePortalTwo(shootDirection);
        }
    }

    void generatePortalOne(Vector3 shootDirection)
    {
        GameObject previousPortal = GameObject.FindGameObjectWithTag("Portal1");

        if(previousPortal != null)
        {
            Destroy(previousPortal);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, shootDirection, Mathf.Infinity);

        if(hit)
        {
            GameObject portal = Instantiate(portalOne, hit.point, hit.collider.transform.rotation);
        }
        
    }

    void generatePortalTwo(Vector3 shootDirection)
    {

    }
}
