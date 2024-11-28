using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharMaterials : MonoBehaviour
{
    public Material M1;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material = M1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
