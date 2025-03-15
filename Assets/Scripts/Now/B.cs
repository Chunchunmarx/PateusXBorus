using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : MonoBehaviour
{
    public Logger logger;

    void Start()
    {
        // Înregistr?m un comportament specific pentru B
        logger.RegisterCaller<B>(message => $"B whispers: {message.ToLower()}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            logger.Log("Hello from B"); // F?r? <B>
    }
}
