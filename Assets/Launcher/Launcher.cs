using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Projectile projectile;

    public Vector3 offset;

    public Quaternion angle { get; private set;}

    [Range(1f, 89f)]public float pitch;

    public float anglePitch {get; private set;}

    //public float theta;

    private Vector3 _target;
    public Vector3 target {get {
        return _target;
    } set {
        _target = value;

        Vector3 dir = target - offset;
        Vector3 dirFlat = new Vector3(dir.x, 0, dir.z);
        
        angle = Quaternion.LookRotation(dirFlat, Vector3.up);
        float distance = dir.magnitude;
        float groundDistance = dirFlat.magnitude;


        // velocity = 50;
        // float v = velocity;
        // float sqrt = Mathf.Sqrt(v*v*v*v - Physics.gravity.y * (Physics.gravity.y * groundDistance*groundDistance + 2*dir.y*v*v));
        // float theta2 =  Mathf.Atan((v*v + sqrt)/(Physics.gravity.y * groundDistance)) * Mathf.Rad2Deg;
        // float theta = Mathf.Atan((v*v - sqrt)/(Physics.gravity.y * groundDistance)) * Mathf.Rad2Deg;
        // angle *= Quaternion.AngleAxis(-theta, Vector3.right);

        // theta = Mathf.Atan((dir.y/groundDistance) + Mathf.Sqrt(((dir.y*dir.y)/(groundDistance*groundDistance)) + 1));
        


        float height = Mathf.Tan(pitch * Mathf.Deg2Rad) * distance;
        double startVelocityY = Math.Sqrt(-Physics.gravity.y*height);
        double startVelocityX = (distance*startVelocityY)/(2*height);
        velocity = (float) Math.Sqrt(startVelocityX*startVelocityX + startVelocityY*startVelocityY);
        anglePitch = Mathf.Atan((float) startVelocityY/ (float) startVelocityX) * Mathf.Rad2Deg;
        angle *= Quaternion.AngleAxis(-anglePitch, Vector3.right);
    
        float d = (value - transform.position).magnitude;
        if ( d> aggroRadius )
            aggroRadius = d;
    }}

    public float velocity { get; private set; }

    private float _aggroRadius = 10;
    public float aggroRadius {get {
        return _aggroRadius;
    } set {
        _aggroRadius = value;
        if ((target - transform.position).magnitude > value )
        {
            target *= value/(target - transform.position).magnitude;
        }
    }}

    [ContextMenu("Fire")]
    public void Fire()
    {
        // var body = Instantiate(
        //     projectile, 
        //     transform.TransformPoint(offset), 
        //     transform.rotation);
        // body.velocity = Vector3.forward * velocity;
    }
}