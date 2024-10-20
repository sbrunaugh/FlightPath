using System;
using UnityEngine;
using Assets.Scripts.Models;

namespace Assets.Scripts
{
    internal static class FlightPath
    {
        // Roll == hyzer and Pitch == nose angle
        internal static Func<float, Vector3> CalculateFlightPath(
            Disc disc, 
            DiscOrientation discOrientation, 
            LaunchAngle launchAngle,
            Vector3 originPoint,
            float velocity) // Any float value between 0f and 144f (kmph)
        {
            // Just going to hard-code as many variables as possible for now
            // Using Dynamic Discs Truth
            disc.Speed = Speed.Speed5;
            disc.Glide = Glide.Glide5;
            disc.Turn = Turn.Turn0;
            disc.Fade = Fade.Fade2;

            // Completely flat disc nose angle and no hyzer/anhyzer
            discOrientation.DiscRoll = 0f;
            discOrientation.DiscPitch = 0f;

            // For discs, optimal launch angle is between 15 and 30 degrees
            launchAngle.PolarAngle = 60f;
            launchAngle.AzimuthalAngle = 90f; // Thrown straight towards positive z.

            // Semi-average disc speed
            velocity = 100f; // Measured in kmph

            originPoint = new Vector3(0,0,0);

            // TODO: Adjust the 3 equations of the parametric curve based on the above parameters.
            Func<float, Vector3> parametricCurve = (t) =>
            {
                // 10 * sin(-0.05t)
                float x = 10f * Mathf.Sin(-0.05f * t);
                // 1.2t
                float y = 1.2f * t;
                // if(t<100, 0.235t, -0.05(t-100)^2 + 23.5)
                float z = t < 100 ? 0.235f * t : -0.05f * Square(t - 100) + 23.5f;
                return new Vector3(x, y, z);
            };

            return parametricCurve;
        }

        private static float Square(float num)
        {
            return (float)Math.Pow(num, 2);
        }

        private static float Negative(float num)
        {
            return -num;
        }
    }
}