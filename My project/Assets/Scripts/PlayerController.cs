using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10f;

    public TMP_Text ScoreText;
    public TMP_Text WinText;
    public GameObject Gate;

    private Rigidbody rb;
    private int Score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Score = 0;

        if (WinText != null)
            WinText.text = "";

        SetScoreText();
    }

    void FixedUpdate() // ✅ лучше для физики
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * Speed);
    }

    void Update()
    {
        // Restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            Score++;
            SetScoreText();

            if (Score >= 5 && Gate != null)
            {
                Gate.SetActive(false);
            }
        }

        if (other.CompareTag("danger"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void SetScoreText()
    {
        if (ScoreText != null)
            ScoreText.text = "Score: " + Score.ToString();

        if (Score == 10 && WinText != null)
        {
            WinText.text = "You win! Press R to restart or ESC to quit";
        }
    }
}