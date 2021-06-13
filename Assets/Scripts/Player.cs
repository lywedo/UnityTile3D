using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 主角脚本
/// </summary>
public class Player : MonoBehaviour
{
    // 移动速度
    public float speed = 1f;
    // 转向速度
    public float turnSpeed = 20f;
    


    public Animator anim;
    // 跟节点
    public Transform rootTrans;
    // 模型节点
    public Transform modelTrans;
    // 导航Agent
    public NavMeshAgent navAgent;
    
    // 是否在移动
    private bool moving = false;
    // 移动向量
    private Vector3 moveDirection = Vector3.zero;
    // 是否可移动
    private bool canMove = true;

    void Update()
    {
        if (canMove && moving)
        {
            anim.SetInteger("AnimationPar", 1);

            rootTrans.position += moveDirection * speed * Time.deltaTime;
            modelTrans.forward = Vector3.Lerp(modelTrans.forward, moveDirection, turnSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }
    }

    public void Move(Vector3 direction)
    {
        moveDirection = direction;
        moving = true;
    }

    public void Stand()
    {
        moving = false;
    }

    /// <summary>
    /// 去广州塔顶部
    /// </summary>
    public void GoToCantonTowerTop(Transform towerTop)
    {
        canMove = false;
        navAgent.enabled = false;
        rootTrans.position = towerTop.position;
        rootTrans.forward = towerTop.forward;
    }

    /// <summary>
    /// 从广州塔顶部回来
    /// </summary>
    /// <param name="towerBottom"></param>
    public void BackToGroundFromCantonTower(Transform towerBottom)
    {
        canMove = true;
        rootTrans.position = towerBottom.position;
        navAgent.enabled = true;
    }

}
