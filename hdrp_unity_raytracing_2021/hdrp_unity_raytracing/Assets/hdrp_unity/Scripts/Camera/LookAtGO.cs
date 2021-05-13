using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtGO : MonoBehaviour
{
    #region f/p
    public Transform Target;
    public Vector3 Offset;
    private Vector3 newTarget;
    #endregion

    #region unity_methods

    private void Start()
    {
        newTarget = Target.transform.position + Offset;
    }

    void Update()
    {
        transform.LookAt(newTarget);
    }
    #endregion
    
}
