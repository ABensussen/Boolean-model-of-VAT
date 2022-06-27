// See https://aka.ms/new-console-template for more information

string filepath = @"C:\Users\anton\OneDrive\Escritorio\CD4_T_lymphocytes.txt";


//*****************
#region
//Step 1: Declaring control variables
List<string> intialConditions = new List<string>();
List<string> fixedPoints = new List<string>();
StreamWriter outcomeModel = new StreamWriter(filepath);

int numberNodes = 12;
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

    // Cellular inputs
    int IFNGe = 0;
    int IL12e = 0;
    int IL2e = 0;
    int IL4e = 0;
    int TGFBe = 0;
    int IL10e = 01;
    int IL6e = 0;
    int IL27e = 01;
    int INSULIN = 0;
    int Ceramide = 0;


    List<int> TBET = new List<int>();
    List<int> IFNG = new List<int>();
    List<int> GATA3 = new List<int>();
    List<int> IL2 = new List<int>();
    List<int> IL4 = new List<int>();
    List<int> RORGT = new List<int>();
    List<int> IL6 = new List<int>();
    List<int> FOXP3 = new List<int>();
    List<int> TGFB = new List<int>();
    List<int> IL10 = new List<int>();
    List<int> PU1 = new List<int>();
    List<int> IL9 = new List<int>();

    TBET.Add(xS[0]);
    IFNG.Add(xS[1]);
    GATA3.Add(xS[2]);
    IL2.Add(xS[3]);
    IL4.Add(xS[4]);
    RORGT.Add(xS[5]);
    IL6.Add(xS[6]);
    FOXP3.Add(xS[7]);
    TGFB.Add(xS[8]);
    IL10.Add(xS[9]);
    PU1.Add(xS[10]);
    IL9.Add(xS[11]);



    //Subprocess 2: Simulation of the boolean model
    #endregion
    //****************
    for (int u = 1; u < iterationN; u++)
    {
        //***********
        #region

        //Logic rule for TBET
        if (((IFNG[u - 1] == 1 || (
            IL12e == 1 && !(
            IL6[u - 1] == 1 ||
            IL4[u - 1] == 1 ||
            IL10[u - 1] == 1))) ||
            TBET[u - 1] == 1) && !(
            IL4[u - 1] == 1 ||
            GATA3[u - 1] == 1 ||
            IL6[u - 1] == 1)) { TBET.Add(1); }
        else { TBET.Add(0); }


        //Logic rule for IFNG
        if ((IFNGe == 1 || ((
            IFNG[u - 1] == 1 ||
            TBET[u - 1] == 1) && !(
            GATA3[u - 1] == 1 ||
            TGFB[u - 1] == 1))) && !(
            IL6[u - 1] == 1 ||
            IL4[u - 1] == 1 ||
            IL10[u - 1] == 1 || Ceramide == 1)) { IFNG.Add(1); }
        else { IFNG.Add(0); }


        //Logic rule for GATA3
        if (((IL2[u - 1] == 1 &&
            IL4[u - 1] == 1) ||
            GATA3[u - 1] == 1) && !(
            TBET[u - 1] == 1 ||
            TGFB[u - 1] == 1 ||
            IL6[u - 1] == 1 ||
            IFNG[u - 1] == 1 ||
            PU1[u - 1] == 1)) { GATA3.Add(1); }
        else { GATA3.Add(0); }


        //Logic rule for IL2
        if ((IL2e == 1 || (
            IL2[u - 1] == 1 &&
            FOXP3[u - 1] == 0)) && !(
            IFNG[u - 1] == 1 ||
            IL6[u - 1] == 1 || (
            IL10[u - 1] == 1 &&
            FOXP3[u - 1] == 0))) { IL2.Add(1); }
        else { IL2.Add(0); }


        //Logic rule for IL4
        if ((IL4e == 1 || (
            GATA3[u - 1] == 1 && (
            IL2[u - 1] == 1 ||
            IL4[u - 1] == 1) &&
            TBET[u - 1] == 0)) && !(
            IFNG[u - 1] == 1 ||
            IL6[u - 1] == 1 ||
            PU1[u - 1] == 1)) { IL4.Add(1); }
        else { IL4.Add(0); }


        //Logic rule for RORGT
        if ((IL6[u - 1] == 1 &&
            TGFB[u - 1] == 1) && !(
            TBET[u - 1] == 1 ||
            FOXP3[u - 1] == 1 ||
            GATA3[u - 1] == 1)) { RORGT.Add(1); }
        else { RORGT.Add(0); }


        //Logic rule for IL6
        if ((IL6e == 1 ||
            IL6[u - 1] == 1 ||
            RORGT[u - 1] == 1) && !(
            IFNG[u - 1] == 1 ||
            IL4[u - 1] == 1 ||
            IL10[u - 1] == 1 ||
            IL2[u - 1] == 1)) { IL6.Add(1); }
        else { IL6.Add(0); }


        //Logic rule for FOXP3
        if ((IL2[u - 1] == 1 && (Ceramide == 1 ||
            TGFB[u - 1] == 1 ||
            FOXP3[u - 1] == 1)) && !(
            IL6[u - 1] == 1 ||
            RORGT[u - 1] == 1 ||
            PU1[u - 1] == 1)) { FOXP3.Add(1); }
        else { FOXP3.Add(0); }


        //Logic rule for TGFB
        if (TGFBe == 1 || ((
            TGFB[u - 1] == 1 ||
            FOXP3[u - 1] == 1) &&
            IL6[u - 1] == 0)) { TGFB.Add(1); }
        else { TGFB.Add(0); }


        //Logic rule for IL10
        if (IL10e == 1 || (
            IL10[u - 1] == 1 && (
            IFNG[u - 1] == 1 ||
            IL6[u - 1] == 1 ||
            TGFB[u - 1] == 1 ||
            GATA3[u - 1] == 1 ||
            IL27e == 1) &&
            !(INSULIN == 1 || Ceramide == 1))) { IL10.Add(1); }
        else { IL10.Add(0); }

        //Logic rule for PU1
        if ((IL6[u - 1] == 1 ||
            TGFB[u - 1] == 1 ||
            PU1[u - 1] == 1) &&
            (IL2[u - 1] == 0)) { PU1.Add(1); }
        else { PU1.Add(0); }

        //Logic rule for IL9
        if (((IL4[u - 1] == 1 ||
            IL4e == 1) &&
            PU1[u - 1] == 1) &&
            TBET[u - 1] == 0) { IL9.Add(1); }
        else { IL9.Add(0); }



        #endregion
    }

    //Subprocess 3: Saving data
    var node1 = TBET.Select(x => Convert.ToString(x)).ToList();
    var node2 = IFNG.Select(x => Convert.ToString(x)).ToList();
    var node3 = GATA3.Select(x => Convert.ToString(x)).ToList();
    var node4 = IL2.Select(x => Convert.ToString(x)).ToList();
    var node5 = IL4.Select(x => Convert.ToString(x)).ToList();
    var node6 = RORGT.Select(x => Convert.ToString(x)).ToList();
    var node7 = IL6.Select(x => Convert.ToString(x)).ToList();
    var node8 = FOXP3.Select(x => Convert.ToString(x)).ToList();
    var node9 = TGFB.Select(x => Convert.ToString(x)).ToList();
    var node10 = IL10.Select(x => Convert.ToString(x)).ToList();
    var node11 = PU1.Select(x => Convert.ToString(x)).ToList();
    var node12 = IL9.Select(x => Convert.ToString(x)).ToList();


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
            node12[w]);

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
int Th0 = 0;
int Th1 = 0;
int Th2 = 0;
int Th9 = 0;
int Th17 = 0;
int Th1R = 0;
int Th2R = 0;
int iTreg = 0;
int Tr1 = 0;
int Th3 = 0;
int totalEnd = 0;


if (fixedPoints.Count == 0) { fixedPoints.Add("null"); }

//Step 4: Calculating the size of the basin of attraction of each fixed point
var q = from x in fixedPoints
        group x by x into g
        let count = g.Count()
        orderby count descending
        select new { Value = g.Key, Count = count };

//Step 5: Presentation of results
outcomeModel.Write("      Nodes ID: {0  1  2  3  4  5  6  7  8  9  10 11}\n");

foreach (var x in q)
{
    Console.WriteLine("Fixed point in: {" + x.Value + "}  Size of its basin of attraction: {" + x.Count + "}");
    outcomeModel.Write("Fixed point in: {" + x.Value + "}  Size of its basin of attraction: {" + x.Count + "}\n");

    //classification and sum
    string ste = x.Value.Replace("  ", "");
    char[] Repase = ste.ToCharArray();
    Console.WriteLine(Repase.Length);

    if (Repase[0] == '0' &&
        Repase[2] == '0' &&
        Repase[5] == '0' &&
        Repase[7] == '0' &&
        Repase[9] == '0' &&
        Repase[8] == '0' &&
        Repase[10] == '0')
    {
        Th0 = Th0 + x.Count;
    }
    if ((Repase[0] == '1' &&
            Repase[1] == '1') && !(
            Repase[9] == '1' ||
            Repase[8] == '1' ||
            Repase[7] == '1'))
    {
        Th1 = Th1 + x.Count;
    }
    if ((Repase[2] == '1' &&
            Repase[4] == '1') && !(
            Repase[9] == '1' ||
            Repase[8] == '1' ||
            Repase[7] == '1'))
    {
        Th2 = Th2 + x.Count;
    }
    if ((Repase[10] == '1' &&
            Repase[11] == '1') && !(
            Repase[4] == '1' ||
            Repase[1] == '1' ||
            Repase[0] == '1' ||
            Repase[2] == '1' ||
            Repase[5] == '1' ||
            Repase[7] == '1'))
    {
        Th9 = Th9 + x.Count;
    }
    if (Repase[5] == '1' &&
            Repase[6] == '1' &&
            Repase[9] == '0')
    {
        Th17 = Th17 + x.Count;
    }
    if (Repase[0] == '1' && (
            Repase[9] == '1' ||
            Repase[8] == '1' ||
            Repase[7] == '1'))
    {
        Th1R = Th1R + x.Count;
    }
    if (Repase[2] == '1' && (
            Repase[9] == '1' ||
            Repase[8] == '1' ||
            Repase[7] == '1'))
    {
        Th2R = Th2R + x.Count;
    }
    if (Repase[7] == '1' &&
            Repase[8] == '1' && !(
            Repase[0] == '1' ||
            Repase[2] == '1' ||
            Repase[5] == '1'))
    {
        iTreg = iTreg + x.Count;
    }
    if (Repase[9] == '1' && !(
            Repase[8] == '1' ||
            Repase[2] == '1' ||
            Repase[7] == '1' ||
            Repase[5] == '1'))
    {
        Tr1 = Tr1 + x.Count;
    }
    if (Repase[8] == '1' && !(
            Repase[0] == '1' ||
            Repase[2] == '1' ||
            Repase[7] == '1' ||
            Repase[5] == '1'))
    {
        Th3 = Th3 + x.Count;
    }


} 

totalEnd = Th0 + Th1 + Th2 + Th9 + Th17 + Th1R + Th2R + iTreg + Tr1 + Th3;

outcomeModel.Write("\n");
outcomeModel.Write("\n");
outcomeModel.WriteLine("Total count: " + totalEnd);


outcomeModel.Write("\n");

outcomeModel.WriteLine("Th0: " + Th0);
outcomeModel.WriteLine("Th1: " + Th1);
outcomeModel.WriteLine("Th2: " + Th2);
outcomeModel.WriteLine("Th9: " + Th9);
outcomeModel.WriteLine("Th17: " + Th17);
outcomeModel.WriteLine("Th1R: " + Th2R);
outcomeModel.WriteLine("Th2R: " + Th1R);
outcomeModel.WriteLine("iTreg: " + iTreg);
outcomeModel.WriteLine("Tr1: " + Tr1);
outcomeModel.WriteLine("Th3: " + Th3);
outcomeModel.Write("\n");



outcomeModel.Write("\n");
outcomeModel.Write("Total amount of initial states: " + maxN.ToString());
outcomeModel.Write("\n");
outcomeModel.Write("Legend:\n");
outcomeModel.Write("\n");
outcomeModel.Write(" TBET: {0}\n IFNG: {1}\n GATA3: {2}\n IL2: {3}\n IL4: {4}\n");
outcomeModel.Write(" RORGT: {5}\n IL6: {6}\n FOXP3: {7}\n TGFB: {8}\n IL10: {9}\n");
outcomeModel.Write(" PU1: {10}\n IL9: {11}\n");

outcomeModel.Close();
Console.WriteLine(" ");
Console.WriteLine("The report is ready");


