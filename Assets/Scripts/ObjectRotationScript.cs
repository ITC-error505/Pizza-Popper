using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;

public class ObjectRotationScript : MonoBehaviour, IPointerDownHandler
{
    private float rotateSpeed;

    public UnityEvent clicked;

    // Update is called once per frame
    void Start() {
        RandomizeSpeed();
    }
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    public void StopRotate() {
        rotateSpeed = 0;
    }

    public void OnPointerDown(PointerEventData eventData) {
        clicked?.Invoke();
        RandomizeSpeed();
    }

    private void RandomizeSpeed() {
        rotateSpeed = Random.Range(100, 600);
    }
}
