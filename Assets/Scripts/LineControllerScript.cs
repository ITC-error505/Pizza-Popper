using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;

public class LineController : MonoBehaviour
{
    private LineRenderer line;
    // private UnityEngine.Vector3 screenPosition;
    // private Camera main = Camera.main;
    
    [SerializeField]
    private GameObject player;
    // [SerializeField]
    // private bool isRight;

    private void Awake() {
        line = GetComponent<LineRenderer>();
        // screenPosition = main.WorldToScreenPoint(transform.position);

        float width = Screen.width*0.01f, height = Screen.height*-0.01f;
    }

     public void SetUpLine() {
        line.SetPosition(0, player.transform.position);
    }

    private void Update() {
        line.SetPosition(0, player.transform.position);
    }
}
