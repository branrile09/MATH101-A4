using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH101_A4
{

    struct Vec 
    {
        public float X=0;
        public float Y;
        public Vec(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public Vec()
        {
            X = 0.0f;
            Y = 0.0f;
        }

    }

    struct Obj
    {
        public Vec positionFromOrigin;
        public float sizeInRadius;
        public Obj(Vec position, float size = 0.0f)
        {
            positionFromOrigin = position;
            sizeInRadius = size;
        }
    }


    abstract class mathLib
    {
        
        internal static Vec scaleVector(Vec vector, float scale)
        {
            float X = vector.X * scale;
            float Y = vector.Y * scale;

            // create vector and return
            Vec returningVector = new(X, Y);
            return returningVector;
        }


        internal static Vec vectorFrom2Points(Vec point1,Vec point2)
        {
            float X = point2.X - point1.X;
            float Y = point2.Y - point1.Y;
            Vec newVector = new (X, Y);
            return newVector;
        }

        internal static Vec addVectorsTogether(Vec v1 , Vec v2, Vec v3, Vec v4)
        {
            float X = v1.X + v2.X + v3.X + v4.X;
            float Y = v1.Y + v2.Y + v3.Y + v4.Y;
            Vec returningVector = new(X, Y);
            return returningVector;
        }
        internal static Vec addVectorsTogether(Vec v1, Vec v2)
        {            
            return addVectorsTogether(v1, v2, new Vec(), new Vec());
        }
        internal static Vec addVectorsTogether(Vec v1, Vec v2, Vec v3)
        {
            return addVectorsTogether(v1, v2, v3, new Vec());
        }




        internal static float Magnitude(Vec vector)
        {
            float Magnitude = MathF.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y));
            return Magnitude;
        }

        internal static Vec Normalize(Vec vector)
        {
            float Magnitude = mathLib.Magnitude(vector);
            float normalizedX = vector.X / Magnitude;
            float normalizedY = vector.Y / Magnitude;

            Vec normalized = new Vec(normalizedX, normalizedY);

            return normalized;
        }

        internal static Vec genFromAngle(float Degrees, float magnitude = 5.0f)
        {
            // degrees to radians
            float Radians = Degrees * (3.14159265f) / 180;
            float X = magnitude * MathF.Cos(Radians);
            float Y = magnitude * MathF.Sin(Radians);

            // create vector and return
            Vec returningVector = new Vec(X, Y);

            return returningVector;
        }



        internal static float Collision(Obj object1, Obj object2)
        {
            Vec vectorBetween2Points = vectorFrom2Points(object1.positionFromOrigin, object2.positionFromOrigin);
            float distance = Magnitude(vectorBetween2Points);

            float distanceBeforeCollision = object1.sizeInRadius + object2.sizeInRadius;

            float collision = distanceBeforeCollision - distance;
            // float collision = distance;
            // float collision = distanceBeforeCollision;

            return collision;
        }

        internal static float DotProduct(Vec vector1, Vec vector2)
        {

            // normalize our vector
            Vec normalizedVector1 = Normalize(vector1);
            Vec normalizedVector2 = Normalize(vector2);

            // dot product
            float percentage = normalizedVector1.X * -normalizedVector2.X +
                               normalizedVector1.Y * -normalizedVector2.Y;

            // gives value 0-1

            // this is the step that i missed
            percentage *= 100.0f;
            return percentage;
        }
    }
}
