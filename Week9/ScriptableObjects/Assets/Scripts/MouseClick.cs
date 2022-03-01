using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClick : MonoBehaviour
{
    public Camera mainCamera;

    [SerializeField]
    private Text _nameText;

    [SerializeField]
    private Text _costText;

    [SerializeField]
    private Text _damageText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f) && hit.transform.tag == "Weapon")
            {
                // Update the UI to show the selected weapon stats
            }
        }
    }
}
