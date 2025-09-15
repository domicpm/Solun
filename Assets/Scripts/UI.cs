using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{
    public Button Returnbutton;
    public Vector3 newpos;
    public PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnReturnClicked()
    {
        Debug.Log("OnReturnClicked aufgerufen von: " + gameObject.name);

        if (pm.lastSquare != null)
        {
            pm.lastSquare.ReturnSquare();
            Debug.Log("sqp clicked");
        }
        else
        {
            Debug.Log("sqp is null");
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

}
