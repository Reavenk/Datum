using System.Collections.Generic;

namespace PxPre.Datum
{
    public class AstCallFn : Ast
    {
        public Val function;
        public List<Val> args = new List<Val>();
        public Dictionary<string, Val> kwargs = new Dictionary<string, Val>();

        public AstCallFn()
        { }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            Val retrievedFn = function.Execute(ctx, out var _);

            Ctx ctxFn = new Ctx(ctx);
            ctxFn.args = args;
            foreach (var kvp in kwargs)
            {
                Val keywordParam = kvp.Value.Execute(ctxFn, out var _);
                ctxFn.members.Add(kvp.Key, keywordParam);
            }

            evalTy = EvalTy.Transform;
            return retrievedFn.Execute(ctxFn, out var _);
        }
    }
}