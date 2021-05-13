using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CM_CurveManager : MonoBehaviour
{
    #region f/p
    public static event Action<List<CM_Curve>> OnInit = null; 
    public List<CM_Curve> Curves = new List<CM_Curve>();
    public List<CM_Agent> Agents = new List<CM_Agent>();
    #endregion

    
    #region custom methods

    public void AddAgent()
    {
        Agents.Add(new CM_Agent());
    }
    public void AddCurve() 
    {
        Curves.Add(new CM_Curve());
        
        Curves.Last().SetCurve();
    }
    
    public void RemoveCurve(int _index) => Curves.RemoveAt(_index);
    public void RemoveAgent(int _index) => Agents.RemoveAt(_index);
    public void ClearCurves() => Curves.Clear();
    public void ClearAgent() => Agents.Clear();
    
    public Vector3[] ComputeCurve(Vector3 _a, Vector3 _b, Vector3 _c, int _definition)
    {
        Vector3[] _curve = new Vector3[_definition+1];

        for (int i = 0; i < _definition; i++)
        {
            Vector3 _first = Vector3.Lerp(_a, _b, (float) i / _definition);
            Vector3 _second = Vector3.Lerp(_b, _c, (float) i / _definition);
            
            _curve[i] = Vector3.Lerp(_first, _second, (float) i/_definition);
        }

        _curve[_definition] = _c;
        return _curve;
    }
    #endregion


    #region unity methods

    private void Awake()
    {
        for (int i = 0; i < Agents.Count; i++)
        {
            // GameObject _temp = Instantiate(Agents[i].AgentToMove);
            GameObject _temp = Agents[i].AgentToMove;
            CM_AgentFollowCurve _script = _temp.AddComponent<CM_AgentFollowCurve>();
           _script.SpeedMove = Agents[i].SpeedMove;
           //_script.SpeedRotation = Agents[i].SpeedRotation;
           _script.CurveID = Agents[i].CurveID;
        }
    }

    private void Start()
    {
        OnInit?.Invoke(Curves);
    }

    #endregion
    
    
    #region debug
    private void OnDrawGizmos()
    {
        for (int i = 0; i < Curves.Count; i++)
        {
            
            Gizmos.color = Color.white;
            Curves[i].DrawGizmos();
        }
    }
    #endregion
}