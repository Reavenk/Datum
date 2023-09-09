using System;
using System.Collections.Generic;

namespace PxPre.Datum
{
    public class AstIfChain : Ast
    {
        public struct Possibility
        {
            public Val predicate;
            public List<Val> instr;
        }

        public Possibility ifPossibility;
        public List<Possibility> elseChain = new List<Possibility>();

        public AstIfChain()
        { }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            Val ifPred = ifPossibility.predicate.Execute(ctx, out var _);
            if(ifPred.GetBool() == true)
            {
                throw new NotImplementedException();
            }
            else
            { 
                foreach(Possibility p in elseChain)
                { 
                    if(p.predicate == null || p.predicate.Execute(ctx, out var _).GetBool() == true)
                    { 
                        throw new NotImplementedException();
                    }
                }
            }
            evalTy = EvalTy.Transform;
            return ValNone.Inst;
        }
    }
}