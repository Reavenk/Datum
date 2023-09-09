using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre.Datum
{
    public class AstCreateList : Ast
    { 
        public List<Val> entryInitializers = new List<Val>();

        public AstCreateList()
        {}

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            ValIdxObject ret = new ValIdxObject();

            foreach(Val v in this.entryInitializers)
            { 
                Val vEvaled = v.Execute(ctx, out var _);
                ret.array.Add(vEvaled);
            }

            evalTy = EvalTy.Transform;
            return ret;
        }
    }
}