using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;

public class ObjectMovementScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f; //2 is good base speed, rando from 2-3 in beginning then amp up to 10 (beyond 10 should have the game ending)
    
    [SerializeField]
    private bool isChance; //true for chanced spawnings
    [SerializeField]
    private int chance; //true for chanced spawnings
    
    [SerializeField]
    private float increment;

    [SerializeField]
    private GameObject pizza;

    private UnityEngine.Vector3 moveDirection;
    private Camera main;

    private float randomAngle;
    private float randomY;
    private int diceRoll = 0;

    public UnityEvent loseOneHp, asteroidDestroyed;

    private void Start() {
        main = Camera.main;

        randomY = Random.Range(-4.5f, 4.5f);
        float temp = randomY * 0.1f;

        if(randomY >= 0) { //offsetting the angle asteroid moves in to ensure it doesn't go off screen too soon
            randomAngle = Random.Range(-0.5f, 0.4f-temp);
        }
        else {
            randomAngle = Random.Range(-0.5f-temp, 0.5f);
        }

        UnityEngine.Vector3 startingPoint = new UnityEngine.Vector3(8f, randomY, 0f); //spawn point
        transform.position = startingPoint;

        moveDirection.Set(-0.5f, randomAngle, 0f);

        moveSpeed+=increment; //both are serialized fields in unity
    }

    void Update()
    {
        if(isChance) {
            if(diceRoll != 1) {
                StartCoroutine(wait());
                diceRoll = Random.Range(1, chance);
            }

            if(diceRoll == 1) {
                pizza.SetActive(true);
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime); //moves the sprite accordingly 
            }
        }
        else {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime); //moves the sprite accordingly
        }
        
        OffScreenDetect();
    }

    private void OffScreenDetect() {
        UnityEngine.Vector2 screenPosition = main.WorldToScreenPoint(transform.position);

        if(screenPosition.x < 0 || screenPosition.y > Screen.height || screenPosition.y < 0) {
            Start();
            print(Screen.width + ", " + Screen.height);

            loseOneHp?.Invoke();

            if(isChance) {
                diceRoll = 0;
                pizza.SetActive(false);
            }
        }
    }

    public void SpriteClicked() {
        Debug.Log("Sprite clicked!");
        Start();

        asteroidDestroyed?.Invoke();

        if(isChance) {
            diceRoll = 0;
        }
    }

    public void StopAsteroid() {
        moveSpeed = 0;
    }
    
    IEnumerator wait() {
        yield return new WaitForSeconds(60f);
    }
}
