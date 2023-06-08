using EspacioTarea;

int cantidad, suma = 0;
bool anda;
Random rnd = new Random();

List<Tarea> pendientes = new List<Tarea>();
List<Tarea> realizadas = new List<Tarea>();

do{
    Console.WriteLine("Ingrese cuantas tareas quiere crear: ");
    anda = int.TryParse(Console.ReadLine(), out cantidad);
} while (!anda);
anda = false;

for (int i = 0; i < cantidad; i++){
    Console.WriteLine("======= Cargar tarea "+ (i+1) +" =======");
    Tarea tarea = new Tarea();
    tarea.Id = i+1;
    Console.WriteLine("Ingrese la descripcion de la tarea: ");
    tarea.Descripcion = Console.ReadLine();
    tarea.Duracion = rnd.Next(1, 100);
    suma += tarea.Duracion;
    pendientes.Add(tarea);
}
int opcion, respuesta;
string busqueda;
do
{
    Console.WriteLine("========= MENU =========");
    Console.WriteLine("1. Mover Tarea");
    Console.WriteLine("2. Buscar Tarea");
    Console.WriteLine("3. Salir");
    do{
        Console.WriteLine("Ingrese una opcion: ");
        anda = int.TryParse(Console.ReadLine(), out opcion);
    } while (!anda);
    anda = false;
    switch (opcion)
    {
        case 1:
            for (int i = 0; i < pendientes.Count; i++){
                Console.WriteLine("======= Tarea "+ (i+1) +" =======");
                Console.WriteLine("Id: {0}", pendientes[i].Id);
                Console.WriteLine("Descripcion: {0}", pendientes[i].Descripcion);
                Console.WriteLine("Duracion: {0}", pendientes[i].Duracion);
                Console.WriteLine("==================");
            }
            do{
                Console.WriteLine("Ingrese el id de la clase que quiere mover: ");
                anda = int.TryParse(Console.ReadLine(), out respuesta);
            }while(!anda);
            var tareaAux = pendientes.Find(t=> t.Id == respuesta);
            pendientes.Remove(tareaAux);
            realizadas.Add(tareaAux);
            
        break;
        case 2:
            Console.WriteLine("Ingrese la descripcion o parte de ella de la tarea que quiere buscar: ");
            busqueda = Console.ReadLine();
            int id;
            for (int i = 0; i < pendientes.Count; i++)
            {
                id = pendientes[i].Descripcion.IndexOf(busqueda);
                if(id != -1){
                    Console.WriteLine("======= Tarea =======");
                    Console.WriteLine("Id: {0}", pendientes[i].Id);
                    Console.WriteLine("Descripcion: {0}", pendientes[i].Descripcion);
                    Console.WriteLine("Duracion: {0}", pendientes[i].Duracion);
                    Console.WriteLine("==================");
                }
            }
            
        break;
        default:
        break;
    }
} while (opcion != 3);

var archivo = new StreamWriter("Sumatoria.txt");
archivo.WriteLine("Duracion total: {0}hs. \n", suma);
archivo.Close();



