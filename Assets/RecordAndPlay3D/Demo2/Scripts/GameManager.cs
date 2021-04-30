using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RecordAndPlay.Record;

namespace RecordAndPlay.Demo2
{

    public class GameManager : MonoBehaviour
    {
        private GameObject pointCollection;

        [SerializeField]
        private GameObject particlePrefab;

        [SerializeField]
        private int numberOfParticles;

        private float durationToRecord;

        Recorder recorder;

        private float startTime;

        // Start is called before the first frame update
        void Start()
        {
            BuildPointsLatice(numberOfParticles, 1, 30, 10);
            recorder = ScriptableObject.CreateInstance<Recorder>();
            SetUpObjectsToTrack(recorder);
            durationToRecord = 60f;
            startTime = UnityEngine.Time.time;
            recorder.Start();
        }

        void Update()
        {
            var particles = pointCollection.transform.Find("Points").GetComponentsInChildren<Rigidbody2D>();

            foreach (var p in particles)
            {
                p.velocity = p.velocity.normalized * 10f;
            }

            if (UnityEngine.Time.time - startTime > durationToRecord)
            {
                var recording = recorder.Finish();
                recording.SaveToAssets(string.Format("{0} Particles over {1} seconds small", numberOfParticles, durationToRecord));
                Destroy(pointCollection);
                Destroy(this);
            }
        }

        private GameObject BuildCircularContainer(Vector2 center, float radius)
        {
            GameObject container = new GameObject("Container");
            container.transform.position = new Vector3(center.x, center.y, 0);

            var edgeCollider = container.AddComponent<EdgeCollider2D>();
            var lineRenderer = container.AddComponent<LineRenderer>();
            lineRenderer.useWorldSpace = false;

            int pointsOnCircle = 128;

            var points = new Vector2[pointsOnCircle];
            var points3 = new Vector3[pointsOnCircle];
            var radAndAHalf = (radius + .5f);
            for (int i = 0; i < pointsOnCircle - 1; i++)
            {
                var angle = (i / (float)pointsOnCircle) * Mathf.PI * 2;
                points[i] = new Vector2(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius);
                points3[i] = new Vector3(Mathf.Cos(angle) * radAndAHalf, Mathf.Sin(angle) * radAndAHalf, 0);
            }
            points[pointsOnCircle - 1] = new Vector2(Mathf.Cos(0) * radius, Mathf.Sin(0) * radius);
            points3[pointsOnCircle - 1] = new Vector3(Mathf.Cos(0) * radAndAHalf, Mathf.Sin(0) * radAndAHalf, 0);
            lineRenderer.positionCount = pointsOnCircle;
            lineRenderer.SetPositions(points3);
            edgeCollider.points = points;

            return container;
        }


        private GameObject BuildPointsLatice(int numberOfPoints, float pointSize, float cubeWallSize, float initialVelocity)
        {

            pointCollection = new GameObject("Sim");
            var pointResults = new GameObject("Points");
            float diskRadius = 0.4f / Mathf.Sqrt(numberOfPoints);

            for (float i = 0; i < numberOfPoints; i += 1.0f)
            {
                GameObject point = Instantiate(particlePrefab);
                point.transform.name = string.Format("Point: {0}", i);

                float r = Mathf.Sqrt((i + 0.5f) / numberOfPoints);
                // r = (1 - diskRadius) * r;
                float theta = Mathf.PI * (1f + Mathf.Sqrt(5f)) * (i + .5f);

                point.transform.position = new Vector3(
                   r * Mathf.Cos(theta),
                   r * Mathf.Sin(theta),
                    0
                );

                point.transform.localScale *= diskRadius * 2;
                point.transform.SetParent(pointResults.transform);

                var rb2 = point.GetComponent<Rigidbody2D>();
                rb2.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * initialVelocity;
            }

            pointResults.transform.localScale *= pointSize / (diskRadius * 2f);

            var container = BuildCircularContainer(Vector2.one * (cubeWallSize / 2.0f), cubeWallSize / 2.0f);

            pointResults.transform.position = new Vector3(container.transform.position.x, container.transform.position.y, 0);
            pointResults.transform.SetParent(pointCollection.transform);
            container.transform.SetParent(pointCollection.transform);
            return pointCollection;
        }

        private void SetUpObjectsToTrack(Recorder recorder)
        {
            Rigidbody2D[] rigidbodies = pointCollection.GetComponentsInChildren<Rigidbody2D>();
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                SubjectBehavior.Build(rigidbodies[i].gameObject, recorder);
                rigidbodies[i].AddForce(new Vector2(
                    Random.Range(-1.0f, 1.0f),
                    Random.Range(-1.0f, 1.0f)
                ).normalized * 500);
            }
        }


    }

}