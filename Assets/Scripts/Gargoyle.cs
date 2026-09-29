using UnityEngine;

public class Gargoyle : MonoBehaviour
{

    [SerializeField]
    Transform EyeTreansform;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //트리거 안에 다른 콜라이더가 들어왔을때
    {
        print("Gargoyle");
        if (other.gameObject.CompareTag("Player"))  //벽 뒤에 있을땐 안걸리게 하기
        {
            GameObject player = other.gameObject;
            Vector3 direction = player.transform.position - EyeTreansform.position;
            Ray ray = new Ray(EyeTreansform.position,direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.gameObject == player)
                {
                    print("i get you");
                }
            }
        }
    }

   /*** private void OnTriggerExit(Collider other) //콜라이더가 나갔을때 "한번"
    {
        
    }
   ***/
}
