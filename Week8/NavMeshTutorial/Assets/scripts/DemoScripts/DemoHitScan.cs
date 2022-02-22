using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoHitScan : MonoBehaviour
{
    public float shootRange = 5;
    public LayerMask hitMask;
    public Camera playerCamera;

    public Image reticle;
    public Color defaultReticleColor;
    public Color canHitReticleColor;

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(.5f, .5f, 0f));
        Debug.DrawRay(rayOrigin, playerCamera.transform.forward * shootRange, Color.red);

        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, shootRange, hitMask, QueryTriggerInteraction.Ignore) &&
            hit.transform.tag == "Enemy")
        {
            reticle.color = canHitReticleColor;

            if (Input.GetButtonDown("Fire1"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            reticle.color = defaultReticleColor;
        }
    }
}
