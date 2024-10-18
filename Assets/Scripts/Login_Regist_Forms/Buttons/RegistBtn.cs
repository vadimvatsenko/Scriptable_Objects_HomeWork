using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class RegistBtn : MonoBehaviour, IPointerClickHandler
{
    private FireBaseApi _fireBaseApi;
    private void Awake()
    {
        _fireBaseApi = GameObject.FindAnyObjectByType<FireBaseApi>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _fireBaseApi.RegistrationNewUser();
    }
}
