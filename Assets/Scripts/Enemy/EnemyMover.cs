using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _patrolPoints;

    private const string Speed = "Speed";

    private int _currentPatrolPoint = 0;

    private Transform _target;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _currentPatrolPoint = 0;

        if (_patrolPoints.Count > 0)
        {
            _target = _patrolPoints[_currentPatrolPoint];
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            _target = _patrolPoints[_currentPatrolPoint];

            Vector3 direction = (_target.position - transform.position).normalized;

            if (direction.x > 0)
            {
                _spriteRenderer.flipX = false;
               
            }
            else if (direction.x < 0)
            {
                _spriteRenderer.flipX = true;
            }

            _animator.SetFloat(Speed, _speed);
            transform.Translate(_speed * direction.x * Time.deltaTime, 0, 0);

            if (Vector3.Distance(_target.position, transform.position) < 0.1f)
            {
                _currentPatrolPoint++;
                
                if(_currentPatrolPoint >= _patrolPoints.Count)
                {
                    _currentPatrolPoint = 0;
                }
            }
        }        
    }
}
