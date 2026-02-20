Primero cree un Plano donde sera el mapa del juego(sin Tag)

Cree una esfera que sera el jugador con un Tag: Player. Cree un Script PlayerControler

'''
public float speed = 15f; 
private Rigidbody rb;
'''

- una variable pública llamada speed que determina la rapidez del jugador

- se reserva un espacio privado llamado rb para guardar el Rigidbody, que es el componente esencial de Unity para aplicar leyes físicas

'''
void FixedUpdate() { 
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical"); 
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); 
        rb.AddForce(movement * speed); //Aqui va la fuerza aplicada
    }
'''

- Dentro de este bloque, el código "escucha" si el usuario está pulsando las flechas del teclado o las teclas WASD, capturando esa intención de movimiento en los ejes horizontal y vertica





Luego cree el Enemy que es un cubo con un Script llamado EnemyIA (sin Tag)

(meter script)

