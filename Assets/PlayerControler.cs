using UnityEngine; 
 
public class PlayerControler : MonoBehaviour { 
    public float speed = 15f; 
    private Rigidbody rb; 
 
    void Start() { 
        rb = GetComponent<Rigidbody>();
    } 
 
    void FixedUpdate() { 
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical"); 
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); 
        rb.AddForce(movement * speed); //Aqui va la fuerza aplicada
    } 
 
} 