using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    //public GameObject winTextObject;
    public MenuController menuController;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        //winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        countText.text = "Cantidad Recolectados: " + count.ToString();
        if(count >= 13)
        {
            // winTextObject.SetActive(true);
            menuController.WinGame();
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
       
        
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            EndGame();
        }
    }
    
    void EndGame()
    {
        menuController.LoseGame();
        gameObject.SetActive(false);
    }

}
