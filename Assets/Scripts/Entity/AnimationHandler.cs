using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMove = Animator.StringToHash("IsMove");
    private static readonly int MoveX = Animator.StringToHash("MoveX");
    private static readonly int MoveY = Animator.StringToHash("MoveY");

    private static readonly int DirX = Animator.StringToHash("DirX");
    private static readonly int DirY = Animator.StringToHash("DirY");

    protected Animator anim;

    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        anim.SetBool(IsMove, obj.magnitude > 0.5f);
        anim.SetFloat(MoveX, obj.x);
        anim.SetFloat(MoveY, obj.y);
    }

    public void Idle(Vector2 obj)
    {
        anim.SetFloat(DirX, obj.x);
        anim.SetFloat(DirY, obj.y);
    }
}
