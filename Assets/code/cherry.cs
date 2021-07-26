using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherry : MonoBehaviour
{
    public void got()
    {
        FindObjectOfType<codes>().cherrycount();
        Destroy(gameObject);
    }
}
