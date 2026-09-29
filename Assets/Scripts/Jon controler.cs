using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class Joncontroler : MonoBehaviour
{
    Transform MyTransform;
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    float turnspeed = 2f;
    Vector2 input;
    
    Rigidbody rigidbody;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
         rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
    }

    private void FixedUpdate() //물리계산이 들어감 <- Update 와의 차이
    {
        Vector3 NewPosition = new Vector3(
            transform.position.x + input.x * speed * Time.deltaTime,
            transform.position.y,
            transform.position.z + input.y * speed * Time.deltaTime
            );
        rigidbody.MovePosition(NewPosition);

        Vector3 moveDirection = new Vector3(input.x, 0, input.y); //캐릭터가 회전할때 부드럽게 회전
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, moveDirection, turnspeed * Time.fixedDeltaTime, 0f); //델타 타임에 Fixed를 붙이면 물리 계산이 들어감
        Quaternion rotaton = Quaternion.LookRotation(desiredForward);
        rigidbody.MoveRotation(rotaton);

    }

    void OnMove(InputValue inputValue)
    {
        input = inputValue.Get<Vector2>();
        if (input == Vector2.zero)
        {
            animator.SetBool("ismove", false);
        }
        else
        {
            animator.SetBool("ismove", true); 
            
        }
        
        
    }

}
