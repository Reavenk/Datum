using System;
using UnityEngine;

namespace PxPre.Datum
{
    public class AstMathPow : AstMathBin
    {
        public AstMathPow(Val left, Val right)
        : base(left, right)
        { }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            Val lres = this.left.Execute(ctx, out var _);
            Val rres = this.right.Execute(ctx, out var _);

            evalTy = EvalTy.Transform;
            if (lres.wrapType == Type.Float64 || rres.wrapType == Type.Float64)
                return Val.Make(Math.Pow(lres.GetFloat64(), rres.GetFloat64()));

            if (lres.wrapType == Type.Float || rres.wrapType == Type.Float)
                return Val.Make(Mathf.Pow(lres.GetFloat(), rres.GetFloat()));

            if (lres.wrapType == Type.Int64 || rres.wrapType == Type.Int64)
                return Val.Make((long)Math.Pow(lres.GetInt64(), rres.GetInt64()));

            if (lres.wrapType == Type.Int || rres.wrapType == Type.Int)
                return Val.Make((int)Mathf.Pow(lres.GetInt(), rres.GetInt()));

            if (lres.wrapType == Type.UInt || rres.wrapType == Type.UInt)
                return Val.Make((uint)(Mathf.Pow(lres.GetUInt(), rres.GetUInt())));

            throw new NotImplementedException("Addition of unknown types");
        }
    }
}
