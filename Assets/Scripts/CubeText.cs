using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeText : MonoBehaviour
{
    public Text nameLable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Position = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLable.transform.position = Position;
    }
}
