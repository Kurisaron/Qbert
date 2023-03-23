using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection
{
    Forward,
    Backward,
    Left,
    Right
}

public abstract class Mover : MonoBehaviour
{
    protected bool isPlayer = false;
    protected bool canMove;
    
    // Movement directions
    protected Vector3 gravityDirection;
    protected Vector3 forwardDirection, leftDirection, rightDirection, backDirection;

    protected Action<MovementDirection> fallOff;
    protected Action fallOffEnd;
    protected Action<Cube> cubeLanding;
    protected Action<WarpPlatform> warpPlatformLanding;

    protected abstract void Awake();

    public void Move(MovementDirection moveDirection)
    {
        if (!canMove)
        {
            Debug.Log("Cannot move");
            return;
        }

        transform.LookAt(transform.position + GetMovementDirectionVector(moveDirection), -gravityDirection);

        if (!Ascend(moveDirection))
        {
            Move_NoAscend(moveDirection);
        }
    }

    private bool Ascend(MovementDirection moveDirection)
    {
        if (Physics.Raycast(transform.position, GetMovementDirectionVector(moveDirection), out RaycastHit hit, 1.0f))
        {
            StartCoroutine(MoveRoutine(hit.collider.gameObject));
            return true;
        }

        return false;
    }

    private void Move_NoAscend(MovementDirection movementDirection)
    {
        if (Physics.Raycast(transform.position + GetMovementDirectionVector(movementDirection), gravityDirection, out RaycastHit hit, 2.5f))
        {
            if (hit.collider.gameObject.GetComponent<WarpPlatform>() != null && !isPlayer) return;
            
            StartCoroutine(MoveRoutine(hit.collider.gameObject));
        }
        else
        {
            fallOff(movementDirection);
        }
    }

    private Vector3 GetMovementDirectionVector(MovementDirection moveDirection)
    {
        Vector3 directionVector;
        switch (moveDirection)
        {
            case MovementDirection.Forward:
                directionVector = forwardDirection;
                break;
            case MovementDirection.Backward:
                directionVector = backDirection;
                break;
            case MovementDirection.Left:
                directionVector = leftDirection;
                break;
            case MovementDirection.Right:
                directionVector = rightDirection;
                break;
            default:
                Debug.LogError("Movement Direction Invalid");
                return Vector3.zero;
        }

        return directionVector;
    }

    private IEnumerator MoveRoutine(GameObject targetPlatform)
    {
        canMove = false;
        float time = 0.0f;

        Vector3 startPostion = transform.position;
        Vector3 endPosition = targetPlatform.transform.position + (-gravityDirection * 0.5f);
        Vector3 midArcPosition = startPostion + ((endPosition - startPostion) / 2);
        midArcPosition += -gravityDirection * 0.5f;

        while(time < 0.5f)
        {
            transform.position = Vector3.Lerp(startPostion, midArcPosition, time * 2.0f);
            time += Time.deltaTime;
            yield return null;
        }

        while(time < 1.0f)
        {
            transform.position = Vector3.Lerp(midArcPosition, endPosition, (time - 0.5f) * 2.0f);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;

        if (targetPlatform.GetComponent<Cube>() != null)
        {
            cubeLanding(targetPlatform.GetComponent<Cube>());
        }
        else
        {
            Debug.Log("Platform is not cube");
        }

        if (targetPlatform.GetComponent<WarpPlatform>() != null)
        {
            warpPlatformLanding(targetPlatform.GetComponent<WarpPlatform>());
        }

        canMove = true;
    }

    protected IEnumerator FallOffRoutine(MovementDirection movementDirection)
    {
        canMove = false;
        float time = 0.0f;

        Vector3 startPostion = transform.position;
        Vector3 endPosition = startPostion + GetMovementDirectionVector(movementDirection);
        Vector3 midArcPosition = startPostion + ((endPosition - startPostion) / 2);
        midArcPosition += -gravityDirection * 0.5f;

        while (time < 0.5f)
        {
            transform.position = Vector3.Lerp(startPostion, midArcPosition, time * 2.0f);
            time += Time.deltaTime;
            yield return null;
        }

        while (time < 1.0f)
        {
            transform.position = Vector3.Lerp(midArcPosition, endPosition, (time - 0.5f) * 2.0f);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;

        while (transform.position.y > -5.0f)
        {
            yield return null;
        }

        fallOffEnd();

        Destroy(gameObject);
    }
}
