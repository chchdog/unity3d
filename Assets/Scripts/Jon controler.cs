using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class Joncontroler : MonoBehaviour
{
    Transform MyTransform;
    [SerializeField]
    float speed = 1f;

    Vector2 input;
    
    Rigidbody rigidbody;
    void Start()
    {
         MyTransform = GetComponent<Transform>();
         rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector2 input = new Vector2(horizontal, vertical);
        input.Normalize();
        print(input);

        

           Vector3 NewPosition = new Vector3(
            MyTransform.position.x+input.x*speed*Time.deltaTime,
            MyTransform.position.y,
            MyTransform.position.z+input.y*speed*Time.deltaTime);

            rigidbody.MovePosition(NewPosition);


        //더하기 연산으로 문자열 붙이기
        //print("("+horizontal+", "+vertical+")"); //문자열 더하기 연산

        //c#에서 지원하는 새로운 방법으로 변수 출력하기
        //print($"({horizontal}, {vertical})"); // 문자열 보관 *추천

       
    }

    private void FixedUpdate()
    {
        MyTransform = GetComponent<Transform>();

        Vector3 NewPosition = new Vector3(
            MyTransform.position.x + input.x * speed * Time.deltaTime,
            MyTransform.position.y,
            MyTransform.position.z + input.y * speed * Time.deltaTime);

        rigidbody.MovePosition(NewPosition);
    }



}
