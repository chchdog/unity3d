using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GamelLifeTimeScope : LifetimeScope
{
    [SerializeField]
    UIManager uIManager;
   

    protected override void Configure(IContainerBuilder builder)
    {
        

        //uiManager 인스턴스를 IUuManager로 만든 변수에 [Inject] 어트리뷰트가 붙었을때 값을 넣어주기
        builder.RegisterComponent(uIManager).As<IUiManager>();

        PlayerDetector[] allDetector = Object.FindObjectsByType<PlayerDetector>(FindObjectsSortMode.None);
        foreach (PlayerDetector detector in allDetector)
        {
            builder.RegisterComponent(detector);
        }
    }
}
