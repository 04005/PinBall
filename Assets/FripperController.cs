using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        int i;
        bool leftTouch = false, rightTouch = false;

        //タッチ操作
        Touch[] myTouches = Input.touches;
        for (i = 0; i < Input.touchCount; i++)
        {
            if (myTouches[i].phase == TouchPhase.Moved || myTouches[i].phase == TouchPhase.Stationary) 
            {
                if (myTouches[i].position.x < Screen.width / 2) 
                {
                    leftTouch = true;
                }
                else
                {
                    rightTouch = true;
                }
            }
        }

        if (tag == "LeftFripperTag")
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)
                || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)
                || leftTouch) 
            {
                //左フリッパーを動かす
                SetAngle(this.flickAngle);
            }
            else
            {
                //左フリッパーを戻す
                SetAngle(this.defaultAngle);
            }
        }
        else if (tag == "RightFripperTag")
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)
               || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)
               || rightTouch) 
            {
                //右フリッパーを動かす
                SetAngle(this.flickAngle);
            }
            else
            {
                //右フリッパーを戻す
                SetAngle(this.defaultAngle);
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}