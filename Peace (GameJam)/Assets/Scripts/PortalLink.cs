using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLink : MonoBehaviour
{
    [SerializeField] GameObject otherPortal;
    [Tooltip("This is the tag of the other portal.")]
    [SerializeField] string Tag;

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
        Vector3 previousVelocity = collision.GetComponent<Rigidbody>().velocity;
        StartCoroutine(teleport(collision));
        collision.GetComponent<Rigidbody>().velocity = previousVelocity;
    }
    
    IEnumerator teleport(Collider2D collision)
    {
        yield return new WaitForSeconds(0.1f);
        if (currentlyCollding)
        {
            collision.transform.position = otherPortal.transform.position;
        }
    }
}
