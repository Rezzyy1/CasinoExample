using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotValue
{
    LetterA,
    PurpleHeart,
    Crown,
    LetterK,
    GoldCup,
    Cherry,
    RedHeart
}
public class Slot : MonoBehaviour
{

    private int randomValue;
    [HideInInspector]public float timeInterval;
    [HideInInspector] public SlotValue randItem;
    private float speed;
    public SlotValue stoppedSlot;
    private SlotMachine sm;

    private void Start()
    {
        sm = gameObject.GetComponentInParent<SlotMachine>();
    }
    public IEnumerator Spin()
    {
        timeInterval = sm.timeInterval;
        randomValue = Random.Range(0, 90);
        speed = 30f + randomValue;
        while(speed >= 10f)//for (int i = 0; i < 30+randomValue; i++)
        {
            speed = speed / 1.01f;
            transform.Translate(Vector2.up * Time.deltaTime * -speed);
            if (transform.localPosition.y <= -6.06f) //4.2
            {
                transform.localPosition = new Vector2(transform.localPosition.x, 1f);
            }

            yield return new WaitForSeconds(timeInterval);
        }
        StartCoroutine("EndSpin");
        yield return null;
    }
    /*public IEnumerator CheatSpin()
    {
        timeInterval = sm.timeInterval;
        randomValue = Random.Range(0, 90);
        speed = 30f + randomValue;
        while (speed >= 15f)
        {
            speed = speed / 1.01f;
            transform.Translate(Vector2.up * Time.deltaTime * -speed);
            if (transform.localPosition.y <= -2.5f)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, 2.17f);
            }

            yield return new WaitForSeconds(timeInterval);
        }
        while (speed >= 2f)
        {
            if (randItem == SlotValue.Crown)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -2.5f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -2.5f))
                {
                    speed = 0;
                }
            }
            else if (randItem == SlotValue.Diamond)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -1.55f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -1.55f))
                {
                    speed = 0;
                }
            }
            else if (randItem == SlotValue.Seven)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -0.6f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -0.6f))
                {
                    speed = 0;
                }
            }
            else if (randItem == SlotValue.Cherry)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, 0.4f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, 0.4f))
                {
                    speed = 0;
                }
            }
            else if (randItem == SlotValue.Bar)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, 1.35f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, 1.35f))
                {
                    speed = 0;
                }
            }
            speed = speed / 1.01f;
            yield return new WaitForSeconds(timeInterval);
        }
        speed = 0;
        CheckResults();
        yield return null;
    }*/
    private IEnumerator EndSpin()
    {
        while (speed >= 2f)
        {
            if (transform.localPosition.y < -5.06f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -6.06f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -6.06f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < -4.06f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -5.06f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -5.06f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < -3.06f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -4.06f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -4.06f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < -2f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -3.06f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -3.06f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < -1f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -2f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -2f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < 0f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -1f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -1f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < 1f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, 0f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, 0f))
                {
                    speed = 0;
                }
            }
            speed = speed / 1.01f;
            yield return new WaitForSeconds(timeInterval);
        }
        speed = 0;
        CheckResults();
        yield return null;
    }
    private void CheckResults()
    {
        if (transform.localPosition.y == -6.06f)
        {
            stoppedSlot = SlotValue.LetterA;
        }
        else if (transform.localPosition.y == -5.06f)
        {
            stoppedSlot = SlotValue.PurpleHeart;
        }
        else if (transform.localPosition.y == -4.06f)
        {
            stoppedSlot = SlotValue.Crown;
        }
        else if (transform.localPosition.y == -3.06f)
        {
            stoppedSlot = SlotValue.LetterK;
        }
        else if (transform.localPosition.y == -2f)
        {
            stoppedSlot = SlotValue.GoldCup;
        }
        else if (transform.localPosition.y == -1f)
        {
            stoppedSlot = SlotValue.Cherry;
        }
        else if (transform.localPosition.y == -0f)
        {
            stoppedSlot = SlotValue.RedHeart;
        }

        sm.WaitResults();
    }
}
