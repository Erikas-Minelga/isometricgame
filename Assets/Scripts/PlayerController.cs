using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 3.0f;

    private Vector2 _movement;
    private Rigidbody2D _rb;
    private Animator _anim;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _movement = new Vector2(0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animate();
    }

    void Move()
    {
        _movement.x = Input.GetAxis("Horizontal") * speed;
        _movement.y = Input.GetAxis("Vertical") * speed;
        _rb.velocity = _movement;
    }

    void Animate()
    {
        _anim.SetFloat("MovementX", _movement.x);
        _anim.SetFloat("MovementY", _movement.y);
        _anim.SetFloat("MovementMag", _movement.magnitude);

        float rawAxisHor = Input.GetAxisRaw("Horizontal");
        float rawAxisVer = Input.GetAxisRaw("Vertical");

        if(rawAxisHor == 1 || rawAxisHor == -1 || rawAxisVer == 1 || rawAxisVer == -1)
        {
            _anim.SetFloat("LastX", rawAxisHor);
            _anim.SetFloat("LastY", rawAxisVer);
        }
    }
}
