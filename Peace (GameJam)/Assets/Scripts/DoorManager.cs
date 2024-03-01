using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public bool open = false;
    // Start is called before the first frame update

    public void checkIfOpen()
    {
        open = checkIfTrue();
        if (open)
        {    
            Destroy(gameObject);
        }
    }

    bool checkIfTrue()
    {
        foreach (GameObject button in buttons)
        {
            if (!button.GetComponent<ButtonManager>().pressed)
            {
                return false;
            }
        }
        return true;
    }
}
