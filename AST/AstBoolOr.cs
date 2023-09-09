namespace PxPre.Datum
{
    public class AstBoolOr : AstMathBin
    {
        public AstBoolOr(Val left, Val right)
            : base(left, right)
        { 
        }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            Val lres = this.left.Execute(ctx, out var _);
            Val rres = this.right.Execute(ctx, out var _);

            evalTy = EvalTy.Transform;
            return Make(lres.GetBool() || rres.GetBool());
        }
    }
}