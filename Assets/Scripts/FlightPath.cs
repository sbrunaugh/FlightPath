using System;
using UnityEngine;
using Assets.Scripts.Models;

namespace Assets.Scripts
{
    public static class FlightPath
    {
        // Roll == hyzer and Pitch == nose angle
        public static Func<float, Vector3> CalculateFlightPath(
            Disc disc, 
            DiscOrientation discOrientation, 
            LaunchAngle launchAngle,
            Vector3 originPoint,
            float velocity) // Any float value between 0f and 144f (kmph)
        {
            // TODO: Adjust the 3 equations of the parametric curve based on the above parameters.
            Func<float, Vector3> parametricCurve = (t) =>
            {
                // X == left/right; Z == forward; Y == up/down 

                // 10 * sin(-0.05t)
                float x = 10f * Mathf.Sin(-0.04f * t);

                // 1.2t
                float z = t; // 0 * (float)Math.Sqrt(t);
                
                // if(t<100, 0.235t, -0.05(t-100)^2 + 23.5)
                float y = t < 100 
                    ? (float)Math.Sqrt(t) 
                    : -0.005f * (t - 100f).Squared() + 10f;

                return new Vector3(x, y, z) + originPoint;
            };

            return parametricCurve;
        }

        private static float Squared(this float num)
        {
            return (float)Math.Pow(num, 2);
        }

        private static float Negative(float num)
        {
            return -num;
        }
    }
}