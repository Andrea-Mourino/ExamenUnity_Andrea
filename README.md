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


'''
public Transform bola;
    public float velocidad = 3f; 
    public float distanciaLimite = 5f;
    '''

- La variable bola (de tipo Transform) sirve para indicarle al enemigo quién es su objetivo; en Unity tendrás que arrastrar a tu jugador a este hueco para que el enemigo sepa a quién mirar.
- La variable velocidad define lo rápido que se moverá en su persecución. Por último, distanciaLimite crea una especie de "radio de visión" o zona de alerta invisible de 5 unidades: si el jugador entra en ese radio, el enemigo lo detectará

'''
void Update() { 
        float distancia = Vector3.Distance(transform.position, bola.position);

'''

-Lo primero que hace la IA en cada instante es usar la herramienta matemática Vector3.Distance. Esta función traza una línea invisible entre la posición actual del enemigo (transform.position) y la posición exacta del jugador (bola.position) para medir cuánta distancia los separa. Ese valor numérico se guarda en la variable interna llamada distancia

'''
if (distancia < distanciaLimite) { 
            Debug.Log("Estado: CERCA - Persiguiendo");  
            transform.position = Vector3.MoveTowards(transform.position, bola.position, velocidad * Time.deltaTime); 
        } else { 
            Debug.Log("Estado: LEJOS - Esperando"); 
        } 
    }
'''

-El bloque if comprueba si la distancia actual es menor que el límite de alerta que le pusimos (5 metros). Si es así, manda un mensaje a la consola indicando que ha visto a su objetivo y usa Vector3.MoveTowards para empujar suavemente al enemigo un paso más hacia la posición del jugador. La multiplicación por Time.deltaTime es fundamental aquí: asegura que el movimiento sea fluido e independiente de si tu ordenador va a 30 o a 144 fotogramas por segundo. Si el jugador está lejos de ese radio, el código salta a la opción else, se queda quieto y avisa de que está esperando

'''
private void OnCollisionEnter(Collision collision) { 
        if (collision.gameObject.CompareTag("Player")) { 
            Debug.Log("¡CONTACTO DETECTADO! La bola ha tocado al cubo."); 
        } 
    }
'''

- Por último, tenemos el método OnCollisionEnter, que funciona como un sensor de impactos físicos. A diferencia del OnTriggerEnter del script anterior, este detecta choques sólidos en los que los objetos rebotan. Cuando el enemigo se choca contra algo, revisa si ese algo tiene la etiqueta "Player". Si es así, suelta un aviso en la consola confirmando el impacto
