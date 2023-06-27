using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    private Animator _animator;
    private bool _isAttack;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _isAttack = false;
    }

    private void Update()
    {
        if (_isAttack)
        {
            if (!Input.GetKey(KeyCode.K))
            {
                _isAttack = false;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.K))
            {
                _animator.SetTrigger("Attack");
                _isAttack = true;
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            _animator.SetFloat("Speed", 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetFloat("Speed", 1);
        }

        if (Input.GetKey(KeyCode.E))
        {
            _animator.SetFloat("Speed", 2);
        }
    }
}