using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g������
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;
    //�e�������̌X��
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJoint�R���|�[�l���g�擾
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        int i;
        bool leftTouch = false, rightTouch = false;

        //�^�b�`����
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
                //���t���b�p�[�𓮂���
                SetAngle(this.flickAngle);
            }
            else
            {
                //���t���b�p�[��߂�
                SetAngle(this.defaultAngle);
            }
        }
        else if (tag == "RightFripperTag")
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)
               || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)
               || rightTouch) 
            {
                //�E�t���b�p�[�𓮂���
                SetAngle(this.flickAngle);
            }
            else
            {
                //�E�t���b�p�[��߂�
                SetAngle(this.defaultAngle);
            }
        }
    }

    //�t���b�p�[�̌X����ݒ�
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}