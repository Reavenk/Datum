using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre.Datum
{
    public class ScopeFunction : Scope
    {
        public List<string> argumentNameRemaps = new List<string>();
        public List<Val> instrs = new List<Val>();

        public ScopeFunction()
        { }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            // Make it so the instructions can access the function arguments
            // as named arguments.
            Ctx ctxArgs = new Ctx(ctx);
            int toRemap = Mathf.Min(argumentNameRemaps.Count, ctx.args.Count);
            for(int i = 0; i < toRemap; ++i)
            {
                ctxArgs.members[argumentNameRemaps[i]] = ctx.args[i];
            }

            // Run the instructions of the function
            Val lastEval = ValNone.Inst;
            evalTy = EvalTy.Transform;
            for (int i = 0; i < instrs.Count; ++i)
            {
                lastEval = instrs[i].Execute(ctxArgs, out EvalTy exEvalTy);
                if(evalTy == EvalTy.Return)
                    break;
            }
            return lastEval;
        }
    }
}