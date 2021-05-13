using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtGO : MonoBehaviour
{
    #region f/p
    public Transform Target;
    #endregion

    #region unity_methods
    void Update()
    {
        transform.LookAt(Target);
    }
    #endregion
    
}
