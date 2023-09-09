using System;

namespace PxPre.Datum
{
    public class AstSetFromName : Ast
    {
        public enum Where
        { 
            Existing,
            TopContext,
            Global
        }

        

        public string varName;
        public Val varExpr;
        public Where where;
        public Ctx.Rule rule;
        public bool evaluate;

        public AstSetFromName(string varName, bool evaluate, Val varExpr, Where where, Ctx.Rule rule)
        {
            this.varName = varName;
            this.varExpr = varExpr;
            this.evaluate = evaluate;
            this.where = where;
            this.rule = rule;
        }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            Val valToSet = 
                evaluate ? 
                    this.varExpr.Execute(ctx, out var _) : 
                    this.varExpr;

            switch(this.where)
            { 
                case Where.Existing:
                    ctx.SetInContextChain(this.varName, valToSet, false);
                    break;

                case Where.TopContext:
                    if(rule == Ctx.Rule.MustExist)
                        ctx.SetInContextChain(this.varName, valToSet, true);
                    else
                        ctx.Set(this.varName, valToSet, this.rule);
                    break;

                case Where.Global:
                    ctx.GetRoot().Set(this.varName, valToSet, this.rule);
                    break;
            }

            evalTy = EvalTy.Transform;
            return valToSet;
        }
    }
}