using UnityEngine;
using UnityEngine.EventSystems;

public class LoginBtn : MonoBehaviour, IPointerClickHandler
{
    private FireBaseApi _fireBaseApi;

    private void Awake()
    {
        _fireBaseApi = GameObject.FindAnyObjectByType<FireBaseApi>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _fireBaseApi.OnLoginUser();
    }
}
