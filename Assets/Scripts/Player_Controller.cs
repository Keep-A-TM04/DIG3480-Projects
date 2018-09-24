using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text scoreText;
    public Text winText;

    public GameObject Player;

    private Rigidbody rb;
    private int count;
    private int score;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetAllText();
        //winText.text = "";
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            score++;
            SetAllText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            score--;
            SetAllText();
        }

        if (count == 12)
        {
            transform.position = new Vector3(16.0f, Player.transform.position.y, 8.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Wall"))
        {
            score--;
            SetAllText();
        }
    }

    void SetAllText()
    {
        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();
        if (count >= 25)
        {
            winText.text = "You won with a score of: " + score.ToString();
        }
        else
        {
            winText.text = "";
        }
    }
}
