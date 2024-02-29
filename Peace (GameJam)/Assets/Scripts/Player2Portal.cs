using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Portal : MonoBehaviour
{
    public GameObject portalOne;
    public Camera playerCam;

    void Update()
    {
        shootPortal();
    }

    void shootPortal()
    {
        Vector3 shootDirection = Input.mousePosition;
        shootDirection = playerCam.ScreenToWorldPoint(shootDirection);
        shootDirection.z = 0f;
        shootDirection -= transform.position;

        if (Input.GetMouseButtonDown(1))
        {
            generatePortal(shootDirection);
        }
    }

    void generatePortal(Vector3 shootDirection)
    {
        GameObject previousPortal = GameObject.FindGameObjectWithTag("Portal2");

        if (previousPortal != null)
        {
            Destroy(previousPortal);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, shootDirection, Mathf.Infinity);

        if (hit)
        {
            GameObject portal = Instantiate(portalOne, hit.point, hit.collider.transform.rotation);
        }

    }
}
