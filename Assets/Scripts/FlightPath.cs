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
                // 0
                float x = 0;
                // -(0.1t - sqrt(20))^2 + 20
                float y = Negative(Square(0.1f * t - (float)Math.Sqrt(20f))) + 20f;
                // 0.1t^2
                float z = Square(-0.01f * t);
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