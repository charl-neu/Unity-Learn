using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Actor))]
public class PlayerController : MonoBehaviour
{
    Actor actor;

    IMovable movable;
    IAttackable attackable;
    IJumpable jumpable;
    ISprintable sprintable;

    private void Awake()
    {
        actor = GetComponent<Actor>();

        movable = actor as IMovable;
        attackable = actor as IAttackable;
        jumpable = actor as IJumpable;
        sprintable = actor as ISprintable;
    }
    void OnJump()
    {
        jumpable?.Jump();
    }

    void OnAttack()
    {
        attackable?.Attack();
    }

    void OnSprint()
    {
        sprintable?.StartSprint();
    }
    
    void OnMove(InputValue value) 
    {
        Vector2 input = value.Get<Vector2>();
        movable?.Move(new Vector3(input.x, 0, input.y));
    }
            
    
}
