using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject door;
    public bool pressed;
    [Tooltip("Checks if the item pressing it has a specific tag.")]
    public bool checkTag;
    [Tooltip("This the tag that is looked for if checkTag is true. Otherwise leave empty.")]
    public string wantedTag;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Ground"))
        {
            if (checkTag)
            {
                if (collision.collider.CompareTag(wantedTag) && door != null)
                {
                    pressed = true;
                    door.GetComponent<DoorManager>().checkIfOpen();
                }
            }
            else if(door != null)
            {
                pressed = true;
                door.GetComponent<DoorManager>().checkIfOpen();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        pressed = false;
    }
}
