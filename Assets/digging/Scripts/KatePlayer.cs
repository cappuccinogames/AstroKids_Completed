using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using System;

public class KatePlayer : MonoBehaviour
{

    [SerializeField]
    private float _speed = 3.5f;

    private Rigidbody2D _rigidbody;
    [SerializeField] private float _movementForce = 10f;

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();
    [SerializeField]
    private int _lives = 1;

    public KateUIManager uIManager;
    public KatePrize katePrize;
    [SerializeField]
    private int _prizes = 10;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 1, 0);

        TouchManager.Instance.onTouchMoved += OnMoved;

    }
    private void OnDestroy()
    {
        TouchManager.Instance.onTouchMoved -= OnMoved;
    }

    private void OnMoved(TouchInput touch)
    {
        Vector3 newPosX = transform.position + touch.DeltaScreenPosition.x * Vector3.right * Time.deltaTime*0.5f;
        Vector3 newPosY = transform.position + touch.DeltaScreenPosition.y * Vector3.up * Time.deltaTime * 0.5f;
        newPosX.x = Mathf.Clamp(newPosX.x, -2.85f, 22.05f);
        newPosY.y = Mathf.Clamp(newPosY.y, -10.6f, 1.72f);
        transform.position = Vector3.Lerp(transform.position, new Vector3(newPosX.x,newPosY.y,transform.position.z), _speed);
        
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
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
    

    private void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    _rigidbody.AddForce(_movementForce * Vector3.up);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    _rigidbody.AddForce(_movementForce * Vector3.down);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    _rigidbody.AddForce(_movementForce * Vector3.left);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    _rigidbody.AddForce(_movementForce * Vector3.right);
        //}
    }
    public void Damage()
    {
        _lives -= 1;
        if (_lives < 1)
        {
            uIManager.PlayerDies();
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Prize")
        {
            Destroy(other.gameObject);
            PrizeNumber();
        }
        
    }
    public void PrizeNumber()
    {
        _prizes -= 1;
        if (_prizes < 1)
        {
            uIManager.PrizeCollect();
            gameObject.SetActive(false);
        }
    }
    
}
