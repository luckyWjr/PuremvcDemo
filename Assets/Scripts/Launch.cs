using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    void Start()
    {
        ApplicationFacade.applicationInstance.Launch();
    }

}
