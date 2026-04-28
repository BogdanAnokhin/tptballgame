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
    public GameObject explosionEffect;

    public int CoinsToOpenGate = 5; // сколько нужно для ворот
    public int TotalCoins = 10;     // сколько нужно для победы

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

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * Speed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

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

        // открытие ворот
        if (Score >= CoinsToOpenGate && Gate != null)
        {
            Instantiate(explosionEffect, Gate.transform.position, Quaternion.identity);
            Gate.SetActive(false);
        }

        // победа
        if (Score >= TotalCoins && WinText != null)
        {
            WinText.text = "You win! Press R to restart or ESC to quit";
        }
    }
}
