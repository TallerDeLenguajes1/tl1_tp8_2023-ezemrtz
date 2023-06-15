using EspacioTarea;
string path;
Console.WriteLine("Ingrese el path de una carpeta: ");
path = Console.ReadLine();

if(Directory.Exists(path)){
    var files = Directory.EnumerateFiles(path, "*.txt");
    Console.WriteLine("=============");
    foreach (string item in files){
        Console.WriteLine("Archivo: {0}", item.Substring(path.Length+1));
    }
    Console.WriteLine("=============");
    var archivo = new StreamWriter("index.csv");
    string[] fileSplit;
    int i = 0;
    foreach (string item in files){
        fileSplit = item.Substring(path.Length+1).Split(".");
        archivo.WriteLine("{0},{1},{2}",i , fileSplit[0], fileSplit.Last());
        i++;
    }
    archivo.Close();
}else{
    Console.WriteLine("La ruta ingresada no existe");
}



