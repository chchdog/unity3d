using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Animator))]
public class Joncontroler : MonoBehaviour
{
    Transform MyTransform;
    [SerializeField]
    float speed = 1f;

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

    private void FixedUpdate()
    {
        Vector3 NewPosition = new Vector3(
            transform.position.x + input.x * speed * Time.deltaTime,
            transform.position.y,
            transform.position.z + input.y * speed * Time.deltaTime
            );
        rigidbody.MovePosition(NewPosition);
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

            Quaternion rotaton = Quaternion.LookRotation(new Vector3(input.x, 0, input.y));
            transform.rotation = rotaton;

        }
        
        
    }

}
