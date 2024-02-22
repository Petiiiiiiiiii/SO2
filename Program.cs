using CA240222;
using System.ComponentModel;

static void Beolvasas(List<Nap> lista) 
{
	try
	{
        StreamReader sr = new(@"..\..\..\src\SO2.txt");
        while (!sr.EndOfStream) lista.Add(new Nap(sr.ReadLine()));
        sr.Close();
        Console.WriteLine("\tSikeres fájl beolvasás!");
    }
	catch
	{
        Console.WriteLine("\tHiba a fájl beolvasása során!");
    }
}

static void Feladat3(List<Nap> lista) 
{
    var kiirando = lista
        .SelectMany(x => x.OrakEsDB, (p, i) => new { Peldany = p, Ora = i.Key, Db = i.Value })
        .Where(x => x.Db >= 250)
        .DistinctBy(x => x.Peldany)
        .Select(x => $"Máricus {lista.IndexOf(x.Peldany)+1}.")
        .ToList();

    try
    {
        StreamWriter sw = new(@"..\..\..\src\Feladat3.txt");
        kiirando.ForEach(x => sw.WriteLine(x));
        sw.Close();
        Console.WriteLine("\tSikeres fájlba való kiírás!");

    }
    catch
    {
        Console.WriteLine("Hiba a fájlba való kiírás során!");
    }
}

static (int nap,int ora) Feladat4(List<Nap> lista) 
{
    var cucc = lista
        .SelectMany(x => x.OrakEsDB, (p, i) => new { Peldany = p, Ora = i.Key, Db = i.Value })
        .Where(x => x.Db == lista.SelectMany(x => x.OrakEsDB.Values).Max()).First();

    return (lista.IndexOf(cucc.Peldany)+1,cucc.Ora);
}

static int Feladat5(List<Nap> lista) 
{
    return lista
        .SelectMany(x => x.OrakEsDB, (p, i) => new { Peldany = p, Ora = i.Key, Db = i.Value })
        .Where(x => x.Db < 100)
        .Count();
}

static double Feladat6(List<Nap> lista) 
{
    return lista
        .SelectMany(x => x.OrakEsDB, (p,i) => new {Peldany=p,Ora=i.Key,Db=i.Value})
        .Average(x => x.Db);
}

static void Feladat7(List<Nap> lista) 
{
    var asd = lista
        .IndexOf(
            lista
            .SelectMany(x => x.OrakEsDB, (p,i) => new {Peldany=p,Ora=i.Key,Db=i.Value})
            .GroupBy(x => x.Peldany)
        );

        

}

//Main
List<Nap> napok = new();

//1.feladat
Console.WriteLine("1.feladat:");
Beolvasas(napok);

//2.feladat
Console.WriteLine("\n2.feladat:");
napok.ForEach(beolvasas => Console.WriteLine("\t"+beolvasas));

//3.feladat
Console.WriteLine("\n3.feladat:");
Feladat3(napok);

//4.feladat
Console.WriteLine("\n4.feladat:");
Console.WriteLine($"\t{Feladat4(napok).nap}.nap {Feladat4(napok).ora}.órájában mérték a legmagasabb szennyezettséget!");

//5.feladat
Console.WriteLine("\n5.feladat:");
Console.WriteLine($"\t{Feladat5(napok)} db olyan óra volt amikor 100 µg/m3 alá süllyedt!");

//6.feladat
Console.WriteLine("\n6.feladat:");
Console.WriteLine($"\t{Feladat6(napok)} µg/m3 a havi átlag koncentráció!");