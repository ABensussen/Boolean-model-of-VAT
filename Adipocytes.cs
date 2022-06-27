// See https://aka.ms/new-console-template for more information

string filepath = @"C:\Users\anton\OneDrive\Escritorio\Adipocytes.txt";


//*****************
#region
//Step 1: Declaring control variables
List<string> intialConditions = new List<string>();
List<string> fixedPoints = new List<string>();
StreamWriter outcomeModel = new StreamWriter(filepath);

int numberNodes = 16;
int maxN = (int)Math.Pow(2, numberNodes);
int n = 0;
int iterationN = 10;


//Step 2: Creating all initial states of the network
for (int i = 0; i < maxN; i++)
{
    n = i;
    string bin = Convert.ToString(n, 2).PadLeft(numberNodes, '0');
    intialConditions.Add(bin);
}
#endregion
//*****************

//Step 4: Searching for the fixed points
for (int h = 0; h < maxN; h++)
{
    //*****************
    #region
    //Subprocess 1: Picking an initial condition
    string sentence = intialConditions[h];
    char[] charArr = sentence.ToCharArray();
    int[] xS = Array.ConvertAll(charArr, c => (int)Char.GetNumericValue(c));
    //Gene network

    int TNFe = 01;
    int TNFR2 = 01;
    int IL4e = 0;
    int IL6e = 0;
    int IL10e = 0;
    int IFNG = 0;
    int Insulin = 01;
    int CeramideExt = 0;
    int Pressure = 0;
    int CTGFR = 01;

    List<int> IL1b = new List<int>();
    List<int> IL6 = new List<int>();
    List<int> IL8 = new List<int>();
    List<int> TNF = new List<int>();
    List<int> IL10 = new List<int>();
    List<int> IL4 = new List<int>();
    List<int> AP1 = new List<int>();
    List<int> PPARg = new List<int>();
    List<int> CTGF = new List<int>();
    List<int> Akt = new List<int>();
    List<int> Resistin = new List<int>();
    List<int> Adiponectin = new List<int>();
    List<int> Ceramide = new List<int>();
    List<int> ROS = new List<int>();
    List<int> sFFA = new List<int>();
    List<int> GLUT4 = new List<int>();


    IL1b.Add(xS[0]);
    IL6.Add(xS[1]);
    IL8.Add(xS[2]);
    TNF.Add(xS[3]);
    IL10.Add(xS[4]);
    IL4.Add(xS[5]);
    AP1.Add(xS[6]);
    PPARg.Add(xS[7]);
    CTGF.Add(xS[8]);
    Akt.Add(xS[9]);
    Resistin.Add(xS[10]);
    Adiponectin.Add(xS[11]);
    Ceramide.Add(xS[12]);
    ROS.Add(xS[13]);
    sFFA.Add(xS[14]);
    GLUT4.Add(xS[15]);




    //Subprocess 2: Simulation of the boolean model

    #endregion
    //****************
    for (int u = 1; u < iterationN; u++)
    {
        //***********
        #region
        //Logic rule for IL1b
        if ((Akt[u - 1] == 1 ||
            Resistin[u - 1] == 1 ||
            TNF[u - 1] == 1
            ) && PPARg[u - 1] == 0) { IL1b.Add(1); }
        else { IL1b.Add(0); }


        //Logic rule for IL6
        if ((Akt[u - 1] == 1 ||
            Resistin[u - 1] == 1 ||
            TNF[u - 1] == 1 ||
            IL6e == 1) && PPARg[u - 1] == 0) { IL6.Add(1); }
        else { IL6.Add(0); }


        //Logic rule for IL8
        if ((
            TNF[u - 1] == 1 ||
            Resistin[u - 1] == 1 ||
            Akt[u - 1] == 1) && PPARg[u - 1] == 0) { IL8.Add(1); }
        else { IL8.Add(0); }


        //Logic rule for TNF
        if ((Akt[u - 1] == 1 ||
            Resistin[u - 1] == 1 ||
            (TNF[u - 1] == 1 && TNFR2 == 1) ||
            (TNFe == 1 && TNFR2 == 1)) && PPARg[u - 1] == 0) { TNF.Add(1); }
        else { TNF.Add(0); }

        //Logic rule for IL10
        if ((Akt[u - 1] == 1 ||
            IL10[u - 1] == 1 ||
            IL4[u - 1] == 1 ||
            IL10e == 1)) { IL10.Add(1); }
        else { IL10.Add(0); }


        //Logic rule for IL4
        if ((IL4[u - 1] == 1 ||
            IL10[u - 1] == 1 ||
            IL4e == 1)) { IL4.Add(1); }
        else { IL4.Add(0); }


        //Logic rule for AP1
        if ((Insulin == 1) && PPARg[u - 1] == 0) { AP1.Add(1); }
        else { AP1.Add(0); }


        //Logic rule for PPARg
        if ((IL4[u - 1] == 1 ||
            IL10[u - 1] == 1) && !(TNF[u - 1] == 1 ||
            IL6[u - 1] == 1 ||
            IFNG == 1
            )) { PPARg.Add(1); }
        else { PPARg.Add(0); }


        //Logic rule for CTGF
        if ((ROS[u - 1] == 1) ||
            (CTGF[u - 1] == 1 && CTGFR == 1)) { CTGF.Add(1); }
        else { CTGF.Add(0); }


        //Logic rule for Akt
        if ((Insulin == 1) && Ceramide[u - 1] == 0) { Akt.Add(1); }
        else { Akt.Add(0); }


        //Logic rule for Resistin
        if (TNF[u - 1] == 1 && AP1[u - 1] == 1 && PPARg[u - 1] == 0) { Resistin.Add(1); }
        else { Resistin.Add(0); }


        //Logic rule for Adiponectin
        if (PPARg[u - 1] == 1 && TNF[u - 1] == 0) { Adiponectin.Add(1); }
        else { Adiponectin.Add(0); }


        //Logic rule for Ceramide
        if ((sFFA[u - 1] == 1 || ROS[u - 1] == 1 || TNF[u - 1] == 1 || CeramideExt == 1) && Adiponectin[u - 1] == 0) { Ceramide.Add(1); }
        else { Ceramide.Add(0); }


        //Logic rule for ROS
        if ((PPARg[u - 1] == 0 || Pressure == 1) && Ceramide[u - 1] == 1) { ROS.Add(1); }
        else { ROS.Add(0); }


        //Logic rule for sFFA
        if (Akt[u - 1] == 0 && Ceramide[u - 1] == 1) { sFFA.Add(1); }
        else { sFFA.Add(0); }


        //Logic rule for GLUT4
        if (Akt[u - 1] == 1 && Ceramide[u - 1] == 0) { GLUT4.Add(1); }
        else { GLUT4.Add(0); }


        #endregion
    }

    //Subprocess 3: Saving data
    var node1 = IL1b.Select(x => Convert.ToString(x)).ToList();
    var node2 = IL6.Select(x => Convert.ToString(x)).ToList();
    var node3 = IL8.Select(x => Convert.ToString(x)).ToList();
    var node4 = TNF.Select(x => Convert.ToString(x)).ToList();
    var node5 = IL10.Select(x => Convert.ToString(x)).ToList();
    var node6 = IL4.Select(x => Convert.ToString(x)).ToList();
    var node7 = AP1.Select(x => Convert.ToString(x)).ToList();
    var node8 = PPARg.Select(x => Convert.ToString(x)).ToList();
    var node9 = CTGF.Select(x => Convert.ToString(x)).ToList();
    var node10 = Akt.Select(x => Convert.ToString(x)).ToList();
    var node11 = Resistin.Select(x => Convert.ToString(x)).ToList();
    var node12 = Adiponectin.Select(x => Convert.ToString(x)).ToList();
    var node13 = Ceramide.Select(x => Convert.ToString(x)).ToList();
    var node14 = ROS.Select(x => Convert.ToString(x)).ToList();
    var node15 = sFFA.Select(x => Convert.ToString(x)).ToList();
    var node16 = GLUT4.Select(x => Convert.ToString(x)).ToList();

    List<string> Nodes = new List<string>();

    for (int w = 0; w < node1.Count; w++)
    {
        Nodes.Add(node1[w] + "  " +
            node2[w] + "  " +
            node3[w] + "  " +
            node4[w] + "  " +
            node5[w] + "  " +
            node6[w] + "  " +
            node7[w] + "  " +
            node8[w] + "  " +
            node9[w] + "  " +
            node10[w] + "  " +
            node11[w] + "  " +
            node12[w] + "  " +
            node13[w] + "  " +
            node14[w] + "  " +
            node15[w] + "  " +
            node16[w]);

    }

    // Subprocess 4: Identifying an attractor (fixed points only)
    for (int z = 0; z < Nodes.Count - 1; z++)
    {
        if (Nodes[z + 1] == Nodes[z])
        {
            fixedPoints.Add(Nodes[z]);
            break;
        }
    }
}

//Local
int xTNF_xCTGF_xGLUT4 = 0;
int xTNF_xCTGF_GLUT4 = 0;
int xTNF_CTGF_xGLUT4 = 0;
int TNF_xCTGF_xGLUT4 = 0;
int xTNF_CTGF_GLUT4 = 0;
int TNF_CTGF_xGLUT4 = 0;
int TNF_xCTGF_GLUT4 = 0;
int TNF_CTGF_GLUT4 = 0;
int totalTNF = 0;
int totalCTGF = 0;
int totalGLUT4 = 0;
int totalEnd = 0;
int totalRes = 0;
int totalAdipo = 0;

if (fixedPoints.Count == 0) { fixedPoints.Add("null"); }

//Step 4: Calculating the size of the basin of attraction of each fixed point
var q = from x in fixedPoints
        group x by x into g
        let count = g.Count()
        orderby count descending
        select new { Value = g.Key, Count = count };

//Step 5: Presentation of results
outcomeModel.Write("      Nodes ID: {0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15}\n");

foreach (var x in q)
{
    Console.WriteLine("Fixed point in: {" + x.Value + "}  Size of its basin of attraction: {" + x.Count + "}");
    outcomeModel.Write("Fixed point in: {" + x.Value + "}  Size of its basin of attraction: {" + x.Count + "}\n");

    //classification and sum
    string ste = x.Value.Replace("  ", "");
    char[] Repase = ste.ToCharArray();
    Console.WriteLine(Repase.Length);

    if (Repase[3] == '0' && Repase[8] == '0' && Repase[15] == '0')
    {
        xTNF_xCTGF_xGLUT4 = xTNF_xCTGF_xGLUT4 + x.Count;
    }
    if (Repase[3] == '0' && Repase[8] == '0' && Repase[15] == '1')
    {
        xTNF_xCTGF_GLUT4 = xTNF_xCTGF_GLUT4 + x.Count;
    }
    if (Repase[3] == '0' && Repase[8] == '1' && Repase[15] == '0')
    {
        xTNF_CTGF_xGLUT4 = xTNF_CTGF_xGLUT4 + x.Count;
    }
    if (Repase[3] == '1' && Repase[8] == '0' && Repase[15] == '0')
    {
        TNF_xCTGF_xGLUT4 = TNF_xCTGF_xGLUT4 + x.Count;
    }
    if (Repase[3] == '0' && Repase[8] == '1' && Repase[15] == '1')
    {
        xTNF_CTGF_GLUT4 = xTNF_CTGF_GLUT4 + x.Count;
    }
    if (Repase[3] == '0' && Repase[8] == '1' && Repase[15] == '1')
    {
        xTNF_CTGF_GLUT4 = xTNF_CTGF_GLUT4 + x.Count;
    }
    if (Repase[3] == '1' && Repase[8] == '0' && Repase[15] == '1')
    {
        TNF_xCTGF_GLUT4 = TNF_xCTGF_GLUT4 + x.Count;
    }
    if (Repase[3] == '1' && Repase[8] == '1' && Repase[15] == '0')
    {
        TNF_CTGF_xGLUT4 = TNF_CTGF_xGLUT4 + x.Count;
    }
    if (Repase[3] == '1' && Repase[8] == '1' && Repase[15] == '1')
    {
        TNF_CTGF_GLUT4 = TNF_CTGF_GLUT4 + x.Count;
    }

    if (Repase[3] == '1')
    {
        totalTNF = totalTNF + x.Count;
    }

    if (Repase[8] == '1')
    {
        totalCTGF = totalCTGF + x.Count;
    }

    if (Repase[15] == '1')
    {
        totalGLUT4 = totalGLUT4 + x.Count;
    }

    if (Repase[10] == '1')
    {
        totalRes = totalRes + x.Count;
    }
    if (Repase[11] == '1')
    {
        totalAdipo = totalAdipo + x.Count;
    }

} //maxN.ToString()

totalEnd = xTNF_xCTGF_xGLUT4 + xTNF_xCTGF_GLUT4 + xTNF_CTGF_xGLUT4 + TNF_xCTGF_xGLUT4 + xTNF_CTGF_GLUT4 + TNF_CTGF_xGLUT4 + TNF_xCTGF_GLUT4 + TNF_CTGF_GLUT4;

outcomeModel.Write("\n");
outcomeModel.Write("\n");
outcomeModel.WriteLine("Total GLUT4(+): " + totalGLUT4);
outcomeModel.WriteLine("Total CTGF(+): " + totalCTGF);
outcomeModel.WriteLine("Total TNF(+): " + totalTNF);
outcomeModel.WriteLine("Total: " + totalEnd);
outcomeModel.Write("\n");

outcomeModel.WriteLine("TNF(-) CTGF(-) GLUT4(-): " + xTNF_xCTGF_xGLUT4);
outcomeModel.WriteLine("TNF(-) CTGF(-) GLUT4(+): " + xTNF_xCTGF_GLUT4);
outcomeModel.WriteLine("TNF(-) CTGF(+) GLUT4(-): " + xTNF_CTGF_xGLUT4);
outcomeModel.WriteLine("TNF(+) CTGF(-) GLUT4(-): " + TNF_xCTGF_xGLUT4);
outcomeModel.WriteLine("TNF(-) CTGF(+) GLUT4(+): " + xTNF_CTGF_GLUT4);
outcomeModel.WriteLine("TNF(+) CTGF(-) GLUT4(+): " + TNF_xCTGF_GLUT4);
outcomeModel.WriteLine("TNF(+) CTGF(+) GLUT4(-): " + TNF_CTGF_xGLUT4);
outcomeModel.WriteLine("TNF(+) CTGF(+) GLUT4(+): " + TNF_CTGF_GLUT4);

outcomeModel.Write("\n");
outcomeModel.Write("Total amount of initial states: " + maxN.ToString());
outcomeModel.Write("\n");
outcomeModel.Write("Legend:\n");
outcomeModel.Write("\n");
outcomeModel.Write(" IL1b: {0}\n IL6: {1}\n IL8: {2}\n TNF: {3}\n IL10: {4}\n");
outcomeModel.Write(" IL4: {5}\n AP1: {6}\n PPARg: {7}\n CTGF: {8}\n Akt: {9}\n");
outcomeModel.Write(" Resistin: {10}\n Adiponectin: {11}\n Ceramide: {12}\n ROS: {13}\n sFFA: {14}\n GLUT4: {15}\n");

outcomeModel.Close();
Console.WriteLine(" ");
Console.WriteLine("The report is ready");


