using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayScript : MonoBehaviour {

    private int frames = 0;


    public GameObject skeleton;
    public GameObject bones;
    public GameObject bonePrefab;



    // create an array for the points - nem kell???
    //public GameObject[] myPoints;
    //public GameObject[] myMids;


    // 3 diemsional struct, frist for the bodys, second for the points, third for the coords
    public int[,,] points = new int[,,] {
        {
        {428, 116, 1 },
        {443, 103, 2 },
        {416, 103, 2 },
        {464, 115, 1 },
        {399, 115, 1 },
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
        {450, 296, 3 },
        {471, 279, 2 },
        {432, 277, 4 },
        {492, 297, 2 },
        {404, 290, 1 },
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
        {143, 60, 6 },
        {150, 52, 4 },
        {135, 52, 4 },
        {161, 54, 0 },
        {125, 54, 0 },
        {183, 99, 0 },
        {110, 102, 0 },
        {216, 153, 0 },
        {65, 150, 0 },
        {190, 205, 1 },
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


        // set the array size for the number of elements in the first dimension
        //myPoints = new GameObject[d2];

        // create the points in unity
        for(int n = 0; n < d2; n++) {

            GameObject point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Material sphereMat = Resources.Load("sphere_mat", typeof(Material)) as Material;
            point.transform.name = "s" + (1 + n);
            point.transform.SetParent(skeleton.transform);
            point.transform.position = new Vector3((points[0, n, 0]), (points[0, n, 1]), (points[0, n, 2]));
            point.transform.localScale = new Vector3(4, 4, 4);
            point.GetComponent<Renderer>().material = sphereMat;

        }


        //myMids = new GameObject[14]; - nem kell???

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


                for(int n = 0; n < d2; n++) {

                    GameObject point = GameObject.Find("s" + (1 + n));
                    point.transform.position = new Vector3((points[i, n, 0]), (points[i, n, 1]), (points[i, n, 2]));

                }


                #region midpoints

                // s1 -> s2
                int mid1_x = (points[i, 0, 0] + points[i, 1, 0]) / 2;
                int mid1_y = (points[i, 0, 1] + points[i, 1, 1]) / 2;
                int mid1_z = (points[i, 0, 2] + points[i, 1, 2]) / 2;
                Vector3 mid1 = new Vector3(mid1_x, mid1_y, mid1_z);

                // s2 -> s4
                int mid2_x = (points[i, 1, 0] + points[i, 3, 0]) / 2;
                int mid2_y = (points[i, 1, 1] + points[i, 3, 1]) / 2;
                int mid2_z = (points[i, 1, 2] + points[i, 3, 2]) / 2;
                Vector3 mid2 = new Vector3(mid2_x, mid2_y, mid2_z);

                // s1 -> s3
                int mid3_x = (points[i, 0, 0] + points[i, 2, 0]) / 2;
                int mid3_y = (points[i, 0, 1] + points[i, 2, 1]) / 2;
                int mid3_z = (points[i, 0, 2] + points[i, 2, 2]) / 2;
                Vector3 mid3 = new Vector3(mid3_x, mid3_y, mid3_z);

                // s3 -> s5
                int mid4_x = (points[i, 2, 0] + points[i, 4, 0]) / 2;
                int mid4_y = (points[i, 2, 1] + points[i, 4, 1]) / 2;
                int mid4_z = (points[i, 2, 2] + points[i, 4, 2]) / 2;
                Vector3 mid4 = new Vector3(mid4_x, mid4_y, mid4_z);

                // s6 -> s8
                int mid5_x = (points[i, 5, 0] + points[i, 7, 0]) / 2;
                int mid5_y = (points[i, 5, 1] + points[i, 7, 1]) / 2;
                int mid5_z = (points[i, 5, 2] + points[i, 7, 2]) / 2;
                Vector3 mid5 = new Vector3(mid5_x, mid5_y, mid5_z);

                // s8 -> s10
                int mid6_x = (points[i, 7, 0] + points[i, 9, 0]) / 2;
                int mid6_y = (points[i, 7, 1] + points[i, 9, 1]) / 2;
                int mid6_z = (points[i, 7, 2] + points[i, 9, 2]) / 2;
                Vector3 mid6 = new Vector3(mid6_x, mid6_y, mid6_z);

                // s7 -> s9
                int mid7_x = (points[i, 6, 0] + points[i, 8, 0]) / 2;
                int mid7_y = (points[i, 6, 1] + points[i, 8, 1]) / 2;
                int mid7_z = (points[i, 6, 2] + points[i, 8, 2]) / 2;
                Vector3 mid7 = new Vector3(mid7_x, mid7_y, mid7_z);

                // s9 -> s11
                int mid8_x = (points[i, 8, 0] + points[i, 10, 0]) / 2;
                int mid8_y = (points[i, 8, 1] + points[i, 10, 1]) / 2;
                int mid8_z = (points[i, 8, 2] + points[i, 10, 2]) / 2;
                Vector3 mid8 = new Vector3(mid8_x, mid8_y, mid8_z);

                // s12 -> s14
                int mid9_x = (points[i, 11, 0] + points[i, 13, 0]) / 2;
                int mid9_y = (points[i, 11, 1] + points[i, 13, 1]) / 2;
                int mid9_z = (points[i, 11, 2] + points[i, 13, 2]) / 2;
                Vector3 mid9 = new Vector3(mid9_x, mid9_y, mid9_z);

                // s14 -> s16
                int mid10_x = (points[i, 13, 0] + points[i, 15, 0]) / 2;
                int mid10_y = (points[i, 13, 1] + points[i, 15, 1]) / 2;
                int mid10_z = (points[i, 13, 2] + points[i, 15, 2]) / 2;
                Vector3 mid10 = new Vector3(mid10_x, mid10_y, mid10_z);

                // s13 -> s15
                int mid11_x = (points[i, 12, 0] + points[i, 14, 0]) / 2;
                int mid11_y = (points[i, 12, 1] + points[i, 14, 1]) / 2;
                int mid11_z = (points[i, 12, 2] + points[i, 14, 2]) / 2;
                Vector3 mid11 = new Vector3(mid11_x, mid11_y, mid11_z);

                // s15 -> s17
                int mid12_x = (points[i, 14, 0] + points[i, 16, 0]) / 2;
                int mid12_y = (points[i, 14, 1] + points[i, 16, 1]) / 2;
                int mid12_z = (points[i, 14, 2] + points[i, 16, 2]) / 2;
                Vector3 mid12 = new Vector3(mid12_x, mid12_y, mid12_z);

                // s12 -> s13
                int mid13_x = (points[i, 11, 0] + points[i, 12, 0]) / 2;
                int mid13_y = (points[i, 11, 1] + points[i, 12, 1]) / 2;
                int mid13_z = (points[i, 11, 2] + points[i, 12, 2]) / 2;
                Vector3 mid13 = new Vector3(mid13_x, mid13_y, mid13_z);

                // s6 -> s7
                int mid14_x = (points[i, 5, 0] + points[i, 6, 0]) / 2;
                int mid14_y = (points[i, 5, 1] + points[i, 6, 1]) / 2;
                int mid14_z = (points[i, 5, 2] + points[i, 6, 2]) / 2;
                Vector3 mid14 = new Vector3(mid14_x, mid14_y, mid14_z);

                #endregion

                Vector3[] mids = { mid1, mid2, mid3, mid4, mid5, mid6, mid7, mid8, mid9, mid10, mid11, mid12, mid13, mid14 };
                int m = mids.GetLength(0);


                for(int n = 0; n < m; n++) {

                    var dir =  targets[n] - mids[n];
                    GameObject bone = GameObject.Find("b" + (1 + n));
                    bone.transform.position = mids[n];
                    bone.transform.rotation = Quaternion.FromToRotation(Vector3.down, dir);
                    bone.transform.localScale = new Vector3(1,dir.magnitude,1);

                }

            }

        }

    }

}
