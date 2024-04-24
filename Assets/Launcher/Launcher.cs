using System;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [field: SerializeField] public Projectile Projectile { get; private set;}
    [field: SerializeField] public Vector3 Offset { get; set;}
    [field: SerializeField] public Quaternion Angle { get; private set;} = Quaternion.identity;
    [field: SerializeField] public float Velocity { get; private set; }
    [Min(1f), Range(1f, 89f)] public float pitch = 30f;

    private Vector3 _target;
    public Vector3 Target {get { return _target; } set {
        _target = value;
        UpdateValuesForTarget();
    }}

    private float _aggroRadius = 10;
    public float AggroRadius {get { return _aggroRadius; } set {
        _aggroRadius = value;
        LimitTargetToAggroRadius();
    }}

    private void LimitTargetToAggroRadius()
    {
        if ((Target - transform.position).magnitude > _aggroRadius)
            Target *= _aggroRadius/(Target - transform.position).magnitude;
    }

    private void UpdateValuesForTarget()
    {
        Vector3 dir = Target - Offset;
        Vector3 dirFlat = new(dir.x, 0, dir.z);
        
        Angle = Quaternion.LookRotation(dirFlat, Vector3.up);
        float distance = dir.magnitude;

        float height = Mathf.Tan(pitch * Mathf.Deg2Rad) * distance;
        double startVelocityY = Math.Sqrt(-Physics.gravity.y*height);
        double startVelocityX = (distance*startVelocityY)/(2*height);
        Velocity = (float) Math.Sqrt(startVelocityX*startVelocityX + startVelocityY*startVelocityY);
        float anglePitch = Mathf.Atan((float) startVelocityY/ (float) startVelocityX) * Mathf.Rad2Deg;
        Angle *= Quaternion.AngleAxis(-anglePitch, Vector3.right);
    
        float d = (Target - transform.position).magnitude;
        if ( d> AggroRadius )
            AggroRadius = d;
    }
}