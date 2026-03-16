using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    public float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed;
    }

    void OnMove(InputValue value)
    {
        //Debug.Log("move");
        //Debug.Log(value.Get<Vector2>());
        direction = value.Get<Vector2>(); 
    }
}
