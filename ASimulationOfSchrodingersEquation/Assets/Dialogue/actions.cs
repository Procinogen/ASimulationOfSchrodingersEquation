using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actions : MonoBehaviour
{

    public static bool acting = false;

    public IEnumerator AnimateMove(Vector3 origin, Vector3 target, float duration, ElecStates actor, bool isFinal)
    {
        actor.setToMoving();
        float journey = 0f;
        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);

            actor.gameObject.transform.position = Vector3.Lerp(origin, target, percent);

            yield return null;
        }
        actor.setToIdle();
        if (isFinal)
        {
            acting = false;
        }
    }

    public IEnumerator TeleportObject(Vector3 target, GameObject actor, bool isFinal)
    {
        actor.transform.position = target;
        if (isFinal)
        {
            acting = false;
        }
        yield return null;
    }

}
