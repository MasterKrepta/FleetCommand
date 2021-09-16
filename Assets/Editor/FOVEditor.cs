using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(FOV))]
public class FOVEditor : Editor
{

    private void OnSceneGUI()
    {
        FOV fov = (FOV)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.Radius);

        Vector3 angle1 = dirFromAngle(fov.transform.eulerAngles.y, -fov.Angle / 2);
        Vector3 angle2 = dirFromAngle(fov.transform.eulerAngles.y, fov.Angle / 2);

        //Vector3 angle3 = dirFromAngle(fov.transform.eulerAngles.y, -fov.Angle / 2);
        //Vector3 angle4 = dirFromAngle(fov.transform.eulerAngles.y, fov.Angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + angle1 * fov.Radius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + angle2 * fov.Radius);


        //Handles.color = Color.blue;
        //Handles.DrawLine(fov.transform.position, fov.transform.position + angle3 * fov.Radius);
        //Handles.DrawLine(fov.transform.position, fov.transform.position + angle4 * fov.Radius);

        if (fov.targetInArc)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position, fov.target.position);
        }
    }

    Vector3 dirFromAngle(float eulerY, float angInDeg)
    {
        angInDeg += eulerY;

        return new Vector3(Mathf.Sin(angInDeg * Mathf.Deg2Rad), 0, Mathf.Cos(angInDeg * Mathf.Deg2Rad));
    }

}
