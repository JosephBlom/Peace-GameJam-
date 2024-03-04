using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLink : MonoBehaviour
{
    [SerializeField] GameObject otherPortal;
    [Tooltip("This is the tag of the other portal.")]
    [SerializeField] string Tag;
    [SerializeField] float portalDelay = 0.3f;

    bool currentlyCollding;

    void Update()
    {
        otherPortal = GameObject.FindGameObjectWithTag(Tag);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentlyCollding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentlyCollding = true;
        StartCoroutine(teleport(collision));
    }
    
    IEnumerator teleport(Collider2D collision)
    {
        yield return new WaitForSeconds(portalDelay);
        if (currentlyCollding && otherPortal != null && collision.tag != "NonTeleport")
        {
            collision.transform.position = otherPortal.transform.position;
        }
    }
}
