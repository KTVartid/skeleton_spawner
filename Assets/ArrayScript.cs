using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayScript : MonoBehaviour {

    private int frames = 0;


    public GameObject skeleton;
    public GameObject bones;
    public GameObject bonePrefab;




    // 3 diemsional struct, frist for the bodys, second for the points, third for the coords
    public int[,,] points = new int[,,] {
        {
        {428, 116, 0 },
        {443, 103, 0 },
        {416, 103, 0 },
        {464, 115, 0 },
        {399, 115, 0 },
        {503, 206, 0 },
        {361, 206, 0 },
        {485, 308, 0 },
        {339, 315, 0 },
        {376, 288, 0 },
        {436, 302, 0 },
        {453, 433, 0 },
        {368, 426, 0 },
        {445, 612, 0 },
        {355, 608, 0 },
        {430, 783, 0 },
        {373, 782, 0 }
        },

        {
        {450, 296, 0 },
        {471, 279, 0 },
        {432, 277, 0 },
        {492, 297, 0 },
        {404, 290, 0 },
        {535, 434, 0 },
        {337, 422, 0 },
        {556, 594, 0 },
        {286, 568, 0 },
        {529, 730, 0 },
        {286, 706, 0 },
        {475, 746, 0 },
        {349, 732, 0 },
        {460, 956, 0 },
        {307, 942, 0 },
        {439, 1133, 0 },
        {286, 1146, 0 }
        },

        {
        {143, 60, 0 },
        {150, 52, 0 },
        {135, 52, 0 },
        {161, 54, 0 },
        {125, 54, 0 },
        {183, 99, 0 },
        {110, 102, 0 },
        {216, 153, 0 },
        {65, 150, 0 },
        {190, 205, 0 },
        {69, 201, 0 },
        {158, 216, 0 },
        {109, 214, 0 },
        {187, 308, 0 },
        {99, 312, 0 },
        {219, 406, 0 },
        {92, 405, 0 }
        }
};



    void Start() {

        // first dimension (figures)
        int d1 = points.GetLength(0);
        // second dimension (points)
        int d2 = points.GetLength(1);
        // third dimension (coords)
        int d3 = points.GetLength(2);

        // create an empity gameObject (for parent) in unity
        skeleton = new GameObject("skeleton");
        bones = new GameObject("bones");



        // create the points in unity
        for(int n = 0; n < d2; n++) {

            GameObject point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Material sphereMat = Resources.Load("sphere_mat", typeof(Material)) as Material;
            point.transform.name = "s" + (1 + n);
            point.transform.SetParent(skeleton.transform);
            point.transform.position = new Vector3((points[0, n, 0]), (points[0, n, 1]), (points[0, n, 2]));
            point.transform.localScale = new Vector3(3, 3, 3);
            point.GetComponent<Renderer>().material = sphereMat;

        }



        for(int i = 0; i < 14; i++) {

            Instantiate(bonePrefab);
            GameObject actualBone = GameObject.Find("bonePrefab(Clone)");
            actualBone.transform.SetParent(bones.transform);
            actualBone.transform.name = "b" + (1 + i);
        }

    }



    void Update() {

        // first dimension (figures)
        int d1 = points.GetLength(0);
        // second dimension (points)
        int d2 = points.GetLength(1);





        for(int i = 0; i < d1; i++) {

            frames++;
            if(frames % 100 == 0) {


                for(int n = 0; n < d2; n++) {

                    GameObject point = GameObject.Find("s" + (1 + n));
                    point.transform.position = new Vector3((points[i, n, 0]), (points[i, n, 1]), (points[i, n, 2]));

                }


                Vector3[] targets = {
                    GameObject.Find("s2").transform.position,
                    GameObject.Find("s4").transform.position,
                    GameObject.Find("s3").transform.position,
                    GameObject.Find("s5").transform.position,
                    GameObject.Find("s8").transform.position,
                    GameObject.Find("s10").transform.position,
                    GameObject.Find("s9").transform.position,
                    GameObject.Find("s11").transform.position,
                    GameObject.Find("s14").transform.position,
                    GameObject.Find("s16").transform.position,
                    GameObject.Find("s15").transform.position,
                    GameObject.Find("s17").transform.position,
                    GameObject.Find("s13").transform.position,
                    GameObject.Find("s7").transform.position,
                };


                Vector3[] mids = new Vector3[14];

                Vector2[] midCoords = {
                    new Vector2(0, 1),
                    new Vector2(1, 3),
                    new Vector2(0, 2),
                    new Vector2(2, 4),
                    new Vector2(5, 7),
                    new Vector2(7, 9),
                    new Vector2(6, 8),
                    new Vector2(8, 10),
                    new Vector2(11, 13),
                    new Vector2(13, 15),
                    new Vector2(12, 14),
                    new Vector2(14, 16),
                    new Vector2(11, 12),
                    new Vector2(5, 6)
                };

                for(int n = 0; n < midCoords.Length; n++) {
                    float mid_x = (points[i, (int)midCoords[n].x, 0] + points[i, (int)midCoords[n].y, 0]) / 2f;
                    float mid_y = (points[i, (int)midCoords[n].x, 1] + points[i, (int)midCoords[n].y, 1]) / 2f;
                    float mid_z = (points[i, (int)midCoords[n].x, 2] + points[i, (int)midCoords[n].y, 2]) / 2f;
                    mids[n] = new Vector3(mid_x, mid_y, mid_z);
                }


                int m = mids.GetLength(0);



                for(int n = 0; n < m; n++) {

                    float dist = Vector3.Distance(mids[n], targets[n]);
                    var dir = targets[n] - mids[n];
                    GameObject bone = GameObject.Find("b" + (1 + n));
                    bone.transform.position = mids[n];
                    bone.transform.rotation = Quaternion.FromToRotation(Vector3.down, dir);
                    bone.transform.localScale = new Vector3(1, dist, 1);
                }

            }

        }

    }

}
