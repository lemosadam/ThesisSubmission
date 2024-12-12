using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PROTOTYPEenemyhptext : MonoBehaviour
{
    [SerializeField] private TMP_Text hpText;

    private Camera mainCamera;

    void Start()
    {
        if (hpText == null)
        {
            Debug.LogError("HP Text not assigned!");
        }
        mainCamera = Camera.main;
    }

    void Update()
    {
        DisplayUnitHPOnHover();
    }

    private void DisplayUnitHPOnHover()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Unit unit = hit.collider.GetComponent<Unit>();
            if (unit != null)
            {
                hpText.text = $" {unit.health}";
                return;
            }
        }
        hpText.text = "";
    }
}
