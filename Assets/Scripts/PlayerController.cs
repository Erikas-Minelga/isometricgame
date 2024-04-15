using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 3.0f;
    private float _movementX, _movementY;
    private Input _input;
    //private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        //_rb ??= GetComponent<Rigidbody2D>();
        _input = new Input();
        _input.Enable();
        _input.Ground.MoveX.performed += moving => {
            _movementX = moving.ReadValue<float>();
        };
        _input.Ground.MoveY.performed += moving => {
            _movementY = moving.ReadValue<float>();
        };
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(_movementX * speed * Time.deltaTime, _movementY * speed * Time.deltaTime, 0));
        //_rb.velocity = new Vector2(_movementX * speed, _movementY * speed);
    }
}
