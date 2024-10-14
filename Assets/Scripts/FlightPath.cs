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
            float velocity)
        {
            // TODO: Adjust the 3 equations of the parametric curve based on the above parameters.
            Func<float, Vector3> parametricCurve = (t) =>
            {
                float x = 0;
                float y = t * (t * 0.5f);
                float z = -0.01f * (float)Math.Pow(t - 10, 2) + (0.3f * t) + 2.1f;
                return new Vector3(x, y, z);
            };

            return parametricCurve;
        }
    }
}