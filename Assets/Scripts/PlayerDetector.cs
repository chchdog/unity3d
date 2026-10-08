using UnityEngine;

public class PlayerDetector : MonoBehaviour
{

    [SerializeField]
    Transform EyeTransform;

    


    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) //트리거 안에 다른 콜라이더가 들어왔을때
    {

        if (other.gameObject.CompareTag("Player"))  //벽 뒤에 있을땐 안걸리게 하기
        {
            GameObject player = other.gameObject;
            Vector3 direction = player.transform.position - EyeTransform.position;
            Ray ray = new Ray(EyeTransform.position, direction);
            RaycastHit hit;

            //print(LayerMask.NameToLayer("Character"));
            int layerMask = 1 << LayerMask.NameToLayer("Character");
            if (Physics.Raycast(ray, out hit, direction.magnitude, layerMask))
            {
                print(hit.collider.gameObject.name);
                if (hit.collider.gameObject == player)
                {
                    print("you got me");
                }
            }








            //if (Physics.Raycast(ray, out raycastHit))
            //{
            //if (raycastHit.collider.gameObject == player)
            // {
            //print("i get you");
            // }
            //}
        }
    }


}
