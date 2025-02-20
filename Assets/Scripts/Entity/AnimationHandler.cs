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

    //  벡터의 크기가 0.5이상이면 움직이는 애니메이션을 호출, float값으로 상하좌우를 판단해 다른 애니메이션을 호출 (블렌드 트리)
    public void Move(Vector2 obj)
    {
        anim.SetBool(IsMove, obj.magnitude > 0.5f);
        anim.SetFloat(MoveX, obj.x);
        anim.SetFloat(MoveY, obj.y);
    }

    //  가만히 서 있을 때 호출되는 애니메이션, float값으로 상하좌우를 판단해 다른 애니메이션을 호출 (블렌드 트리)
    public void Idle(Vector2 obj)
    {
        anim.SetFloat(DirX, obj.x);
        anim.SetFloat(DirY, obj.y);
    }
}
