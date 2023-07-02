using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerMover : PhysicsMovement
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpVelocity;

    private const string Speed = "Speed";

    private int _raycastDirection = 1;

    private float _raycastOffsetX = 0.5f;

    private Vector3 _raycastPosition;

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
            _raycastDirection = 1;

            TargetVelocity = new Vector2(_speed, 0);
            _spriteRenderer.flipX = false;
            _animator.SetFloat(Speed, _speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _raycastDirection = -1;

            TargetVelocity = new Vector2(-_speed, 0);
            _spriteRenderer.flipX = true;
            _animator.SetFloat(Speed, _speed);
        }
        else
        {
            TargetVelocity = new Vector2(0, 0);
            _animator.SetFloat(Speed, 0);
        }

        _raycastPosition = transform.position;
        _raycastPosition.x += _raycastOffsetX * _raycastDirection;

        Debug.DrawRay(_raycastPosition, Vector2.down, Color.red);

        if (Input.GetKey(KeyCode.Space) && Grounded)
            Velocity.y = _jumpVelocity;
    }
}
