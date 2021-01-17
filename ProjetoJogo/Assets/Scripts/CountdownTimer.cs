using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime;
    public PlayerController movement;

    [SerializeField] Text Timer;
    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        Timer.text = currentTime.ToString("0");

        if (currentTime <= 10)
        {
            Timer.color = Color.red;
        }
        if (currentTime <= 0)
        {
            currentTime = 0;
            movement.moveSpeed = 0;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
