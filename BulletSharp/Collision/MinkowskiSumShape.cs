using System;
using OpenTK.Mathematics;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class MinkowskiSumShape : ConvexInternalShape
	{
		public MinkowskiSumShape(ConvexShape shapeA, ConvexShape shapeB)
		{
			IntPtr native = btMinkowskiSumShape_new(shapeA.Native, shapeB.Native);
			InitializeCollisionShape(native);

			ShapeA = shapeA;
			ShapeB = shapeB;
		}

		public ConvexShape ShapeA { get; }

		public ConvexShape ShapeB { get; }

		public Matrix4 TransformA
		{
			get
			{
				Matrix4 value;
				btMinkowskiSumShape_getTransformA(Native, out value);
				return value;
			}
			set => btMinkowskiSumShape_setTransformA(Native, ref value);
		}

		public Matrix4 TransformB
		{
			get
			{
				Matrix4 value;
				btMinkowskiSumShape_GetTransformB(Native, out value);
				return value;
			}
			set => btMinkowskiSumShape_setTransformB(Native, ref value);
		}
	}
}
