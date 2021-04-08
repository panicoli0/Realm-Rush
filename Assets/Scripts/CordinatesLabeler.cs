using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways] //lo corre siempre
public class CordinatesLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;
    

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordenates();
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordenates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordenates();
            UpdateObjectName();
        }

        ColorCoordenates();
        ToogleLabel();
    }

   void ColorCoordenates()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else { label.color = blockedColor; }
    }

    void ToogleLabel()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            label.enabled = !label.IsActive();
        }
      
    }

    void DisplayCoordenates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        

        label.text = coordinates.x + ":" + coordinates.y;
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

}
