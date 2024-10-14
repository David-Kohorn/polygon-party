using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timeRemaining = 5;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText;
    public GameObject player1;
    public GameObject player2;
    public TextMeshProUGUI timer;
    //public DoorScript door;

    // Start is called before the first frame update
    void Start()
    {
        timer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (player1 == null || player2 == null)
        {
            timer.gameObject.SetActive(false);
        }*/

        if (player1.transform.position.x > 28f || player2.transform.position.x > 28f)
        {
            timer.gameObject.SetActive(true);
            timerIsRunning = true;
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimer(timeRemaining);
            }

            else if (player1.transform.position.x > 60 && player2.transform.position.x > 60)
            {
                timerIsRunning = false;
                timer.gameObject.SetActive(false);
            }
            
            else
            {
               
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
            currentTime += 1;

            float seconds = Mathf.FloorToInt(currentTime % 60);

            timerText.text = string.Format("{00}", seconds);
    }
}
