using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamond : MonoBehaviour
{
    public void got()
    {
        FindObjectOfType<codes>().diamondcount();
        Destroy(gameObject);
    }
}
