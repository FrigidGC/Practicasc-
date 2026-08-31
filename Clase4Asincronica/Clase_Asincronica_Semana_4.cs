using System;
using System.ComponentModel;
using System.Diagnostics;




public class HelloWorld
{
    public static void Main(string[] args)
    {
        // 1. Get the starting timestamp
        long startTime = Stopwatch.GetTimestamp();
        // 2. Run the code you want to measure
        Thread.Sleep(0);


        Console.WriteLine ("");


        // 3. Calculate the elapsed time
        TimeSpan elapsed = Stopwatch.GetElapsedTime(startTime);
        Console.WriteLine($"Time taken: {elapsed.TotalMilliseconds} ms");
    }
}
public class NodoSimple
{
    public int Valor; //Valor que almacena el nodo, en este caso un int
    public NodoSimple siguiente; 
    // un objeto en NodoSImple, se puede asignar valor tal que nodo1.Siguiente = nodo2;
    // Al hacer eso es como almacenar todo el nodo 2 en el 1, aunque realmente se le da como un acceso remoto

    public NodoSimple(int valor) // el constructor, basicamente es un metodo que permite asignar un numero inicial a Valor, a este metodo especial se le denomina constructor
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

    public void Agregar(int valor) //Metodo en lista Simple que agrega Nodos
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

    public void AddFirst(int valor) //Agrega un dato al inicio de la lista
    {
        NodoSimple anadido = new NodoSimple(valor);   //crea el nuevo nodo a anadir
        anadido.siguiente = Head;                     //Apunta al antiguo Head como el siguiente
        Head = anadido;                               //Pone al nuevo nodo como el Head
    }

    public void AddAtIndex(int valor, int index) //  El valor del nuevo nodo y la posicion donde se quiere agregar el nodo
    {
        if (index == 0)
        {
        NodoSimple atindex = new NodoSimple(valor);   //crea el nuevo nodo a anadir
        atindex.siguiente = Head;                     //Apunta al antiguo Head como el siguiente
        Head = atindex;                               //Pone atindex como el Head 
        }
        NodoSimple actual = Head;
        for (int i = 0;//declara i como indice
             i < index -1; //procura que i indice sea 2 menor al que queremos agregar para que: 
             i++          )//   anterior (el que queremos cambiar el .siguiente)-> agregado -> index(se desplaza 1 adelante)
        {
            if (actual == null)
            {
                Console.WriteLine("El índice está fuera de los límites de la lista.");
                return;
            }
            actual = actual.Siguiente; //Sigue al siguiente nodo, actual al ser una variable de NodoSimple, no cambia nada dentro de la lista
            //Este "for" basicamente recorrio toda la lista hasta index-2 para verificar que existiera espacio antes de donde se va a agregar
            //de esta forma evitando errores sabiendo que va a tener un nodo que lo referencie anteiormente
        }

    }

}




// Count
// AddFirst(RatingRecord)
// AddAtIndex(RatingRecord, int)
// RemoveById(int)
// FindById(int)
// GetAt(int)