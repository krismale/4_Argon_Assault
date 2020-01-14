using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] float selfDestructTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, selfDestructTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
