using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swiggity : MonoBehaviour
{
    public float freq = 10.0f; //how fast it zigs and zags
    public float amp = 5.0f; //how wide it swings
    public float cycleSpeed = 5.0f; //how far forward towards a target, opposite axis of amp
    public Vector3 pos;
    public Vector3 axis;
    public float repathTimeCurr = 0.0f;
    public float repathTimeEnd = 3.0f; //Time before recalculating next move
    public float actionWindowCurr = 0.0f;
    public float actionWindowEnd = 2.0f;
    public Transform target;
    private Vector3 perpToTarget;
    private Vector3 currentTargPos;

    // Start is called before the first frame update
    void Start()
    {       
            pos = transform.position;
            currentTargPos =  target.position.normalized;
            axis = new Vector3(currentTargPos.y, -currentTargPos.x, 0); //the object will move perpendicular to this axis, don't point this at the target, point a perpendicular vector instead.
    }

    void ZigZog() {
        
        pos += currentTargPos * Time.deltaTime * cycleSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * freq) * amp;
    }

    void attackWindow() {

        if(actionWindowCurr >= actionWindowEnd) {
            currentTargPos =  target.position.normalized;
            axis = new Vector3(currentTargPos.y, -currentTargPos.x, 0);
            repathTimeCurr = 0.0f;
            actionWindowCurr = 0.0f;
        }
        else {
            Debug.Log("prepping for a shot");
            actionWindowCurr += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(repathTimeCurr >= repathTimeEnd){
            attackWindow();
        } else {
            ZigZog();
            repathTimeCurr += Time.deltaTime;
        }
    }
}
