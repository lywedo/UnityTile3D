using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public Player player;
    public CameraControler camCtrler;
    public JointedArm leftJointedArm;
    public JointedArm rightJointedArm;

    private Transform playerTrans;
    private Transform camTrans;

    private void Awake()
    {
        playerTrans = player.transform;
        camTrans = camCtrler.transform;
    }

    private void Start()
    {
        // ×óÒ¡¸Ë -------------------------------------------
        leftJointedArm.onDragCb = (direction) =>
        {
            var realDirect = camTrans.localToWorldMatrix * new Vector3(direction.x, 0, direction.y);
            realDirect.y = 0;
            realDirect = realDirect.normalized;
            player.Move(realDirect);
        };
        leftJointedArm.onStopCb = () => { player.Stand(); };

        // ÓÒÒ¡¸Ë ------------------------------------------
        rightJointedArm.onDragCb = (direction) =>
        {
            camCtrler.RotateCam(direction);
        };
        rightJointedArm.onStopCb = () => { camCtrler.StopRotate(); };
    }
}
