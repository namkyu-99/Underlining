using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*
 * Wire
 *   · Layer - Grab 추가
 *   · Rigidbody - Use Gravity ☐ 체크 해제, Constraints 전부 ☑ 체크
 *   · XR Grab Interactable - Select Mode - Multiple (양손 Grab)
 *   · XR Grab Interactable - Track Position, Track Rotation, Throw On Detach ☐ 체크 해제
 *   · XR Direct Interactor - Interactable Events - Select Entered 추가
 *
 * XR Origin
 *   · Rigidbody - Drag 적절한 값(현재 3)으로 설정
 *   · Rigidbody - Constraints - Freeze Rotation 전부 ☑ 체크 (Shake 때문에 Rotation 고정 필요)
 *
 * Left/RightHand Direct Interactor
 *   · Layer - Grab 추가
 *   · XR Direct Interactor - Interactor Events - Select Entered 추가
 * 
 * Edit - Project Settings - Physics - Layer Collision Matrix
 *   · Grab - Grab ☑ 체크, 나머지 전부 ☐ 체크 해제
 */

public class Player : MonoBehaviour
{
    public GameObject Wire;
    public GameObject MainCamera;
    public GameObject LeftHand;
    public GameObject RightHand;
    public bool UseShake = true;

    XRGrabInteractable WireXR;
    XRDirectInteractor LeftXR;
    XRDirectInteractor RightXR;
    Vector3 previousLeftHandPosition;
    Vector3 previousRightHandPosition;
    Vector3 randomPosition;
    Vector3 totalRandomPosition;
    
    const float HEIGHT_ALLOWANCE = 0.1f;
    const float SHAKE_AND_HAPTIC_TIME = 1f;

    void Start()
    {
        WireXR = Wire.GetComponent<XRGrabInteractable>();
        LeftXR = LeftHand.GetComponent<XRDirectInteractor>();
        RightXR = RightHand.GetComponent<XRDirectInteractor>();
        previousLeftHandPosition = LeftHand.transform.position;
        previousRightHandPosition = RightHand.transform.position;
    }
    
    void Update()
    {
        if(WireXR.isSelected && LeftXR.selectTarget != null && LeftHand.transform.position.y > MainCamera.transform.position.y - HEIGHT_ALLOWANCE)
        {
            Vector3 LeftHandMovement = LeftHand.transform.position - previousLeftHandPosition;
            this.transform.position -= LeftHandMovement;
            this.transform.position += randomPosition;
        }
        else if(WireXR.isSelected && RightXR.selectTarget != null && RightHand.transform.position.y > MainCamera.transform.position.y - HEIGHT_ALLOWANCE)
        {
            Vector3 RightHandMovement = RightHand.transform.position - previousRightHandPosition;
            this.transform.position -= RightHandMovement;
            this.transform.position += randomPosition;
        }
        previousLeftHandPosition = LeftHand.transform.position;
        previousRightHandPosition = RightHand.transform.position;
    }

    public void Shake()
    {
        if(UseShake) StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        float shakeAmount = 0.01f;
        float timer = 0.0f;
        float limit = 0.1f;
        
        while (timer <= SHAKE_AND_HAPTIC_TIME)
        {
            while(true)
            {
                randomPosition = (Vector3) Random.insideUnitCircle * shakeAmount;
                totalRandomPosition += randomPosition;
                if(Mathf.Abs(totalRandomPosition.x) < limit && Mathf.Abs(totalRandomPosition.y) < limit)
                    break;
                else
                    totalRandomPosition -= randomPosition;
            }
            Wire.transform.position += randomPosition;
            timer += Time.deltaTime;
            yield return null;
        }
        randomPosition = Vector3.zero;
    }

    public void LeftHaptic()
    {
    LeftXR.SendHapticImpulse(0.2f, SHAKE_AND_HAPTIC_TIME);
    }

    public void RightHaptic()
    {
    RightXR.SendHapticImpulse(0.2f, SHAKE_AND_HAPTIC_TIME);
    }
}