using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManegement;
using TMPro

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TMP_Text ScoreText;
    public TMP_Text WinText;
    public GameObject Gate;
    private Rigidbody rb;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComonent<Rigidbody>();
        Score = 0;
        SetScoreText();
        WinText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        
        //Restart Level
        if (input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //Quit Game
        if (input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        )
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            Score++;
            SetScoreText();
            if (Score >= 5)
            {
                Gate.gameObject.SetActive(false);
            }
        }
    }
}

