using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

// Clase que representa un registro individual del dataset (UserId, ItemId, Rating, Timestamp)
public class RatingRecord
{
    public int UserId;
    public int ItemId;
    public int Rating;
    public long Timestamp;

    public RatingRecord(int userId, int itemId, int rating, long timestamp)
    {
        UserId = userId;
        ItemId = itemId;
        Rating = rating;
        Timestamp = timestamp;
    }

    // "Tarjeta de presentación" del objeto: enseña a C# a traducir este registro a un texto entendible al imprimirlo en pantalla
    public override string ToString()
    {
        return $"User: {UserId}, Item: {ItemId}, Rating: {Rating}, Timestamp: {Timestamp}";
    }
}

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // 1. Cronómetro de código: activa una marca de tiempo de alta precisión antes de ejecutar el programa
        long startTime = Stopwatch.GetTimestamp();

        ListaSimple lista = new ListaSimple();

        // Arreglo que simula las líneas del archivo TSV (separadas por tabulaciones '\t')
        string[] lineasDataset = {
            "196\t242\t3\t881250949",
            "186\t302\t3\t891717742",
            "22\t377\t1\t878887116"
        };

        foreach (string linea in lineasDataset)
        {
            // Cortar texto: usa las tabulaciones '\t' como tijeras para dividir la línea en partes individuales
            string[] campos = linea.Split('\t');

            // Convertir texto a números: transforma cada texto cortado a su tipo numérico real (int o long)
            RatingRecord registro = new RatingRecord(
                int.Parse(campos[0]),  // UserId
                int.Parse(campos[1]),  // ItemId
                int.Parse(campos[2]),  // Rating
                long.Parse(campos[3])   // Timestamp
            );

            lista.AddLast(registro);
        }

        lista.Count();
        lista.GetAt(0);
        lista.FindById(1);

        // 3. Calcula la diferencia entre el inicio y el final para obtener el tiempo exacto transcurrido
        TimeSpan elapsed = Stopwatch.GetElapsedTime(startTime);
        Console.WriteLine($"Time taken: {elapsed.TotalMilliseconds} ms");
    }
}

public class NodoSimple
{
    public RatingRecord Valor; //Valor que almacena el nodo, en este caso un RatingRecord
    public NodoSimple siguiente;
    // un objeto en NodoSImple, se puede asignar valor tal que nodo1.Siguiente = nodo2;
    // Al hacer eso es como almacenar todo el nodo 2 en el 1, aunque realmente se le da como un acceso remoto

    public NodoSimple(RatingRecord valor) // el constructor, basicamente es un metodo que permite asignar un numero inicial a Valor, a este metodo especial se le denomina constructor
    {
        Valor = valor; // Le asigna el número con el que nació
        siguiente = null; // Y arranca sin apuntar a nadie
    }
}

public class ListaSimple
{
    public NodoSimple Head;
    public NodoSimple Tail;

    public ListaSimple() //El constructor de ListaSimple
    {
        Head = null;
        Tail = null;
    }

    public void Count() //Metodo que cuenta los nodos en la lista
    {
        int contador = 0; //Se declara un contador
        NodoSimple actual = Head; //Se declara un nodo actual que apunta al Head
        while (actual != null) //Mientras el nodo actual no sea nulo, es decir mientras haya nodos en la lista
        {
            contador++; //Se incrementa el contador
            actual = actual.siguiente; //Se mueve al siguiente nodo
        }
        Console.WriteLine("Cantidad de nodos en la lista: " + contador); //Se imprime la cantidad de nodos en la lista
    }

    public void AddLast(RatingRecord valor) //Metodo en lista Simple que agrega Nodos
    {
        NodoSimple nuevo = new NodoSimple(valor);
        if (Head == null) //Si es el primer nodo en crearse lo asigna como Head
        {
            Head = nuevo;
            Tail = nuevo;
        }
        else //Si no es el primero nodo en crearse lo asigna como Tail
        {
            Tail.siguiente = nuevo; //Tail aqui sigue siendo el del vagon anterior, lo cual hace que apunte automaticamente al nuevo
            Tail = nuevo;           //El nodo recien agregado se convierte en tail con siguiente null
        }
    }

    public void AddFirst(RatingRecord valor) //Agrega un dato al inicio de la lista
    {
        NodoSimple anadido = new NodoSimple(valor);   //crea el nuevo nodo a anadir
        anadido.siguiente = Head;                     //Apunta al antiguo Head como el siguiente
        Head = anadido;                               //Pone al nuevo nodo como el Head
    }

    public void AddAtIndex(RatingRecord valor, int index) //  El valor del nuevo nodo y la posicion donde se quiere agregar el nodo
    {
        if (index == 0)
        {
            NodoSimple atindex = new NodoSimple(valor);   //crea el nuevo nodo a anadir
            atindex.siguiente = Head;                     //Apunta al antiguo Head como el siguiente
            Head = atindex;                               //Pone atindex como el Head
            if (Tail == null)
            {
                Tail = atindex;
            }

            return;
        }

        NodoSimple actual = Head;
        for (int i = 0;//declara i como indice
             i < index - 1; //procura que i indice sea 2 menor al que queremos agregar para que:
             i++          )//   anterior (el que queremos cambiar el .siguiente)-> agregado -> index(se desplaza 1 adelante)
        {
            if (actual == null)
            {
                Console.WriteLine("El índice está fuera de los límites de la lista.");
                return;
            }
            actual = actual.siguiente; //Sigue al siguiente nodo, actual al ser una variable de NodoSimple, no cambia nada dentro de la lista
            //Este "for" basicamente recorrio toda la lista hasta index-2 para verificar que existiera espacio antes de donde se va a agregar
            //de esta forma evitando errores sabiendo que va a tener un nodo que lo referencie anteiormente
        }
        //En este punto te encuentras aqui !
        //                                 v
        //                      actual<->nuevo<->siguiente(puede ser null)
        NodoSimple agregar = new NodoSimple(valor); //se usaria atindex pero a C# no les gustan 2 variables con el mismo nombre
        agregar.siguiente = actual.siguiente;//se agregar el siguiente del actual (el que esta antes del indice) al nuevo nodo
        actual.siguiente = agregar; //se referencia el actual al nuevo nodo (formalmente atindex)
        if (agregar.siguiente == null)
        {
            Tail = agregar;
        }
    }

    public void RemoveById(int index)
    {
        if (index == 0)
        {
            Head = Head.siguiente; //Remplaza el Head por su siguiente
            return;
        }
        NodoSimple elim = Head;
        for (int i = 0;
             i < index - 1;
             i++          )
        {
            if (elim == null)
            {
                Console.WriteLine("El índice está fuera de los límites de la lista.");
                return;
            }
            elim = elim.siguiente;
        }
        if (elim.siguiente == null)
        {
            Console.WriteLine("El nodo a eliminar no existe");
            return;
        }

        // Saltar un elemento: conecta el nodo actual directamente con el subsiguiente para sacar al nodo eliminado de la lista
        elim.siguiente = elim.siguiente.siguiente;
        if (elim.siguiente == null)
        {
            Tail = elim;
        }
    }

    public void FindById(int index)
    {
        NodoSimple actual = Head;
        for (int i = 0;
             i < index;
             i++          )
        {
            if (actual == null)
            {
                Console.WriteLine("El índice está fuera de los límites de la lista.");
                return;
            }
            actual = actual.siguiente;
        }
        if (actual != null)
        {
            Console.WriteLine("Nodo encontrado: " + actual.Valor);
        }
        else
        {
            Console.WriteLine("El nodo no existe.");
        }
    }

    public void GetAt(int index)
    {
        NodoSimple actual = Head;
        for (int i = 0;
             i < index;
             i++          )
        {
            if (actual == null)
            {
                Console.WriteLine("El índice está fuera de los límites de la lista.");
                return;
            }
            actual = actual.siguiente;
        }
        if (actual != null)
        {
            Console.WriteLine("Valor en el índice " + index + ": " + actual.Valor);
        }
        else
        {
            Console.WriteLine("El nodo no existe.");
        }
    }
}