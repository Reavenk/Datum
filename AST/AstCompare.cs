using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre.Datum
{
    public abstract class AstCompare : Ast
    {
        public Val left;
        public Val right;

        public AstCompare(Val left, Val right)
        { 
            this.left = left;
            this.right = right;
        }
    }
}
