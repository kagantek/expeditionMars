using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 20f;

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D body;
    private Ground ground;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;
    public static Vector3 initialTransform; 

    private Animator playerAnimation;
    public Text scoreText;
    
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        playerAnimation = GetComponent<Animator>();
        scoreText.text = "Score: " + Scoring.totalScore;
        initialTransform = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = input.RetrieveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - ground.GetFriction(), 0f);
        
        if (direction.x > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        
        if (direction.x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        
        playerAnimation.SetFloat("speed", Mathf.Abs(body.velocity.x));
        playerAnimation.SetBool("onGround", onGround);
        scoreText.text = "Score: " + Scoring.totalScore;
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = body.velocity;

        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        body.velocity = velocity;
        
        if (direction.x > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        
        if (direction.x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        
        playerAnimation.SetFloat("speed", Mathf.Abs(body.velocity.x));
        playerAnimation.SetBool("onGround", onGround);
    }

    public static Vector3 getStartPosition()
    {
        return initialTransform;
    }

    
}
