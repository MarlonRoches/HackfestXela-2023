// See https://aka.ms/new-console-template for more information
using HackFest;

Problema1();


void Problema1()
{
    var Rectangulos = new Dictionary<string, Rectangulo>();
    var Disyunciones = new Dictionary<string, int>();
    print("EJERCICIO 1");
    print("Ingrese la ruta del archivo a leer");

    var arregloCoordenadas = new string[1];
    try
    {
        //var ruta = read();
        var ruta = "/Users/marlonroches/Desktop/HackfestXela-2023/ej1Input.txt";
        arregloCoordenadas = new StreamReader(ruta).ReadToEnd().Split("\n");


        //  /Users/marlonroches/Desktop/HackfestXela-2023/ej1Input.txt
    }
    catch (Exception ex)
    {
        print("ERR!: Error al leer el archivo.");
    }


    //obtencion de coordenadas
    for (int i = 0; i < arregloCoordenadas.Length; i++)
    {
        Rectangulos.Add($"R{i + 1}", new Rectangulo(arregloCoordenadas[i]));
    }
    validarColisiones();


    void validarDisyuncion(string k1, string k2, int disyuncion)
    {
        if (Disyunciones.ContainsKey($"{k1}{k2}")|| Disyunciones.ContainsKey($"{k2}{k1}"))
        {

        }
        else
        {

            Disyunciones.Add($"{k1}{k2}", Math.Abs(disyuncion));
        }
    }
    void validarColisiones()
    {
        foreach (var actual in Rectangulos)
        {
            foreach (var item in Rectangulos)
            {
                if (item.Key != actual.Key)
                {
                    if (actual.Value.validarColision(item.Value))
                    {
                        //calcular disyuncion
                        //Disyunciones.Add( actual.Key+item.Key,actual.Value.CalcularDisyuncion(item.Value)) ;
                        validarDisyuncion(actual.Key, item.Key, actual.Value.CalcularDisyuncion(item.Value));

                    }
                    else
                    {
                        //Disyunciones.Add(actual.Key + item.Key, 0);KeyNotFoundException
                        validarDisyuncion(actual.Key, item.Key, 0);
                    }
                }
            }
        }  
    }

    int calcularArea()
    {
        var areatotal = 0;
        foreach (var item in Rectangulos)
        {
            areatotal += item.Value.area;
        }

        foreach (var item in Disyunciones)
        {
            areatotal -= item.Value;

        }

        return areatotal;
    }
    print($"El area total - las diyunciones =  {calcularArea()} unidades");
    var stop = 0;

}


void Problema2()
{

}


void print(string val)
{
    Console.WriteLine($"-> {val}");
}
string read()
{
    return Console.ReadLine();

}