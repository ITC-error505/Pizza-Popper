using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineController : MonoBehaviour
{
    private LineRenderer line;
    
    [SerializeField]
    private GameObject player;

    private void Awake() {
        line = GetComponent<LineRenderer>();

        float width = Screen.width*0.01f, height = Screen.height*-0.01f;
    }

     public void SetUpLine() {
        line.SetPosition(0, player.transform.position);
    }

    private void Update() {
        line.SetPosition(0, player.transform.position);
    }
}
