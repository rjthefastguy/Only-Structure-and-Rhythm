using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusGizmo : MonoBehaviour
{
    public float alpha = 1f;
    public float red = 1f;
    public float green= 1f;
    public float blue = 1f;


    private void OnDrawGizmos()
    {
        // Set the color with custom alpha.
        Gizmos.color = new Color(red, green, blue, alpha); // Red with custom alpha

        // Draw the sphere.
        Gizmos.DrawSphere(transform.position, transform.localScale.y/2);

        // Draw wire sphere outline.
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, transform.localScale.y/2);
    }
}
