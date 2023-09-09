using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre.Datum
{
    public interface IParseDst
    {
        void Insert(Val val);
    }

    public class ParseDstUtil : IParseDst
    {
        public ParseDstUtil(Action<Val> fn)
        { 
            onInsert = fn;
        }

        Action<Val> onInsert;
        public void Insert(Val v){ onInsert.Invoke(v); }
    }
}