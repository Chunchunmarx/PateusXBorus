using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField]
    Logger logger;
    [SerializeField]
    A prefabA;
    [SerializeField]
    B prefabB;

    // Start is called before the first frame update
    void Start()
    {
        A refA = Instantiate(prefabA);
        B refB = Instantiate(prefabB);

        refA.logger = logger;
        refB.logger = logger;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
