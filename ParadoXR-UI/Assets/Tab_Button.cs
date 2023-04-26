using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class Tab_Button : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{

    public TabGroup tabGroup;

    public Image background;

    public UnityEvent onTabSelected;
    public UnityEvent onTabDeselected;
   
   public void OnPointerClick(PointerEventData eventData)
   {
        tabGroup.OnTabSelected(this);
   }

   public void OnPointerEnter(PointerEventData eventData)
   {
        tabGroup.OnTabEnter(this);
   }
   
   public void OnPointerExit(PointerEventData eventData)
   {
        tabGroup.OnTabExit(this);
   }
   
   
   
   
    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static implicit operator TabButton(Tab_Button v)
    {
        throw new NotImplementedException();
    }


    public void Select(){
        if(onTabSelected != null){
            onTabSelected.Invoke();
        }
    }

    public void Deselect(){
        if(onTabDeselected != null){
            onTabDeselected.Invoke();

        }
    }
}
