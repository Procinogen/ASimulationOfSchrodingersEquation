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

    public IEnumerator DeformObject(GameObject toDeform, Vector3 newScale, float duration, bool isFinal)
    {
        float journey = 0f;
        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);

            toDeform.transform.localScale = Vector3.Lerp(toDeform.transform.localScale, newScale, percent);

            yield return null;
        }
        
        if (isFinal)
        {
            acting = false;
        }
    }

    public IEnumerator AnimateObject(GameObject toMove, Vector3 newPos, float duration, bool isFinal)
    {
        float journey = 0f;
        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);

            toMove.transform.position = Vector3.Lerp(toMove.transform.position, newPos, percent);

            yield return null;
        }

        if (isFinal)
        {
            acting = false;
        }
    }

}
