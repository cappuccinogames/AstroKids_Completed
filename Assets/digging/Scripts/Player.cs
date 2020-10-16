using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    private Rigidbody _rigidbody;
    [SerializeField] private float _movementForce = 10f;
    
    private void Awake() => _rigidbody = GetComponent<Rigidbody>();
    [SerializeField]
    private int _lives = 1;

    public KateUIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
    }
    void CalculateMovement()
    {
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }


        if (transform.position.x >= 11f)
        {
            transform.position = new Vector3(-11f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11f)
        {
            transform.position = new Vector3(11f, transform.position.y, 0);
        }
    }
    //private void OnTriggerEnter(Collider other)
    
        //Debug.Log(other.name);

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(_movementForce * Vector3.up);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.AddForce(_movementForce * Vector3.down);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(_movementForce * Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(_movementForce * Vector3.right);
        }
    }
    public void Damage()
    {
        _lives -= 1;
        if(_lives < 1)
        {
            uIManager.PlayerDies();
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Prize")
        {
            Destroy(this.gameObject);
        }
    }

}
