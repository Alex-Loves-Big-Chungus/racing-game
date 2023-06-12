using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    public WheelCollider WheelColliderLeftFront,WheelColliderRightFront, WheelColliderLeftBack, WheelColliderRightBack;
    public Transform WheelLeftFront, WheelRightFront, WheelLeftBack, WheelRightBack, centerOfMass;
    public float motorTorque = -100f, maxSteer = 20f;
    private Rigidbody Rb;

    void Start() {
        Rb = GetComponent<Rigidbody>();
        Rb.centerOfMass = centerOfMass.localPosition;
    }

    void FixedUpdate() {
        WheelColliderLeftBack.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        WheelColliderRightBack.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        WheelColliderLeftFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
        WheelColliderRightFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
    }

    void Update() {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        WheelColliderLeftFront.GetWorldPose(out pos, out rot);
        WheelLeftFront.position = pos;
        WheelLeftFront.rotation = rot;

        WheelColliderRightFront.GetWorldPose(out pos, out rot);
        WheelRightFront.position = pos;
        WheelRightFront.rotation = rot * Quaternion.Euler(0, 180, 0);

        WheelColliderLeftBack.GetWorldPose(out pos, out rot);
        WheelLeftBack.position = pos;
        WheelLeftBack.rotation = rot;

        WheelColliderRightBack.GetWorldPose(out pos, out rot);
        WheelRightBack.position = pos;
        WheelRightBack.rotation = rot * Quaternion.Euler(0, 180, 0);
    }
}
