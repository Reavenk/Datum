using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre.Datum
{
    public interface IPrototype
    {
        Val GetPrototypeMember(Val invoker, string memberName);
    }
}