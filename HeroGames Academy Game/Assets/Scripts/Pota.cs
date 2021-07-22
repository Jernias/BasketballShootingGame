using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pota : MonoBehaviour
{
    public GameObject pota;
    // Start is called before the first frame update
    void Start()
    {
        pota.transform.position = new Vector3(0, -4, 10 + LevelEnd.level);
    }

}
