using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]public TMP_Text Text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Text.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Text.color = Color.white;
    }
}