using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre.Datum
{
    public class ScopeProgram : Scope
    {
        public List<Val> instrs = new List<Val>();

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            Val lastEval = ValNone.Inst;
            for(int i = 0; i < instrs.Count; ++i)
            { 
                lastEval = instrs[i].Execute(ctx,  out EvalTy exEvalTy);
            }
            evalTy = EvalTy.Transform;
            return lastEval;
        }
    }
}