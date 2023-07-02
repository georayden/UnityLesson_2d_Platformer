using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : PhysicsMovement
{
    private const string Speed = "Speed";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpVelocity;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
        
    private void Update()
    {  
        if (Input.GetKey(KeyCode.D))
        {
            TargetVelocity = new Vector2(_speed, 0);
            _spriteRenderer.flipX = false;
            _animator.SetFloat(Speed, _speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            TargetVelocity = new Vector2(-_speed, 0);
            _spriteRenderer.flipX = true;
            _animator.SetFloat(Speed, _speed);
        }
        else
        {
            TargetVelocity = new Vector2(0, 0);
            _animator.SetFloat(Speed, 0);
        }

        if (Input.GetKey(KeyCode.Space) && Grounded)
            Velocity.y = _jumpVelocity;
    }
}
