using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    public Logger logger;

    void Start()
    {
        // Înregistr?m un comportament specific pentru A
        logger.RegisterCaller<A>(message => $"A says: {message.ToUpper()}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            logger.Log("Hello from A"); // F?r? <A>
    }
}
