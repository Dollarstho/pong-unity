using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1Controller : MonoBehaviour
{
    public float speed;

     public string movementAxisName = "Vertical_2";
     public bool isPlayer2 = true; 
     public SpriteRenderer spriteRenderer;

     void Start()
  {
    if(isPlayer2)
    {
      spriteRenderer.color = SaveController.Instance.colorPlayer2;
    }
    else
    {
      spriteRenderer.color = Color.white;
    }
  }

    void Update()
    {
        float moveInput = Input.GetAxis(movementAxisName);
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime; 
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);
        
        transform.position = newPosition;
        
    }
}
