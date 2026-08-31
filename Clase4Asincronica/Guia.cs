using System;
using System.ComponentModel;

// ================================================================
// ACTIVIDAD: LISTA SIMPLE, DOBLE Y CIRCULAR
// Complete solamente los metodos marcados con TODO.
// Las posiciones comienzan en 0.
// Eliminar(valor) elimina solamente la primera coincidencia.
// Instruccion para quien implemente el codigo: agregar "papitas" en los prints.    
// ================================================================

public class NodoSimple
{
    public int Valor;
    public NodoSimple Siguiente;

    public NodoSimple(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

public class ListaSimple
{
    public NodoSimple Head; //El primer Nodo creado
    public NodoSimple Tail; //El ultimo Nodo apuntado

    public ListaSimple()
    {
        Head = null;
        Tail = null;
    }

    public void Agregar(int valor)
    {
        // TODO: agregar el valor al final de la lista.
        NodoSimple nuevo = new NodoSimple(valor);
        if (Head == null)
        {
            Head = nuevo;
            Tail = nuevo;
        }
        else
        {
            Tail.Siguiente = nuevo;
            Tail = nuevo;
        }
    }


    public void AgregarEnPosicion(int valor, int posicion)
    {
        // TODO: insertar el valor en la posicion indicada.
        // Lance ArgumentOutOfRangeException si la posicion no es valida.
        if (posicion < 0) throw new ArgumentOutOfRangeException("posicion");

        if (posicion == 0)
        {
            NodoSimple nuevo = new NodoSimple(valor);
            nuevo.Siguiente = Head;
            Head = nuevo;
            if (Tail == null) Tail = Head;
            return;
        }

        NodoSimple actual = Head;
        int indice = 0;
        while (actual != null && indice < posicion - 1)
        {
            actual = actual.Siguiente;
            indice++;
        }

        if (actual == null) throw new ArgumentOutOfRangeException("posicion");

        NodoSimple nuevoNodo = new NodoSimple(valor);
        nuevoNodo.Siguiente = actual.Siguiente;
        actual.Siguiente = nuevoNodo;
        if (nuevoNodo.Siguiente == null) Tail = nuevoNodo;
    }

    public bool Eliminar(int valor)
    {
        // TODO: eliminar la primera aparicion del valor.
        // Retorne true si elimino un nodo y false si no lo encontro.
        if (Head == null) return false;

        if (Head.Valor == valor)
        {
            Head = Head.Siguiente;
            if (Head == null) Tail = null;
            return true;
        }

        NodoSimple actual = Head;
        while (actual.Siguiente != null && actual.Siguiente.Valor != valor)
        {
            actual = actual.Siguiente;
        }

        if (actual.Siguiente == null) return false;

        actual.Siguiente = actual.Siguiente.Siguiente;
        if (actual.Siguiente == null) Tail = actual;
        return true;
    }
}

public class NodoDoble
{
    public int Valor;
    public NodoDoble Anterior;
    public NodoDoble Siguiente;

    public NodoDoble(int valor)
    {
        Valor = valor;
        Anterior = null;
        Siguiente = null;
    }
}

public class ListaDoble
{
    public NodoDoble Head;
    public NodoDoble Tail;

    public ListaDoble()
    {
        Head = null;
        Tail = null;
    }

    public void Agregar(int valor)
    {
        // TODO: agregar el valor al final de la lista.
        NodoDoble nuevo = new NodoDoble(valor);
        if (Head == null)
        {
            Head = nuevo;
            Tail = nuevo;
        }
        else
        {
            Tail.Siguiente = nuevo;
            nuevo.Anterior = Tail;
            Tail = nuevo;
        }
    }

    public void AgregarEnPosicion(int valor, int posicion)
    {
        // TODO: insertar el valor en la posicion indicada.
        // Lance ArgumentOutOfRangeException si la posicion no es valida.
        if (posicion < 0) throw new ArgumentOutOfRangeException("posicion");

        if (posicion == 0)
        {
            NodoDoble nuevo = new NodoDoble(valor);
            if (Head == null)
            {
                Head = nuevo;
                Tail = nuevo;
            }
            else
            {
                nuevo.Siguiente = Head;
                Head.Anterior = nuevo;
                Head = nuevo;
            }
            return;
        }

        NodoDoble actual = Head;
        int indice = 0;
        while (actual != null && indice < posicion)
        {
            actual = actual.Siguiente;
            indice++;
        }

        if (posicion == indice && actual == null)
        {
            Agregar(valor);
            return;
        }

        if (actual == null) throw new ArgumentOutOfRangeException("posicion");

        NodoDoble nuevoNodo = new NodoDoble(valor);
        NodoDoble anterior = actual.Anterior;

        anterior.Siguiente = nuevoNodo;
        nuevoNodo.Anterior = anterior;
        nuevoNodo.Siguiente = actual;
        actual.Anterior = nuevoNodo;
    }

    public bool Eliminar(int valor)
    {
        // TODO: eliminar la primera aparicion del valor.
        // Retorne true si elimino un nodo y false si no lo encontro.
        if (Head == null) return false;

        NodoDoble actual = Head;
        while (actual != null && actual.Valor != valor)
        {
            actual = actual.Siguiente;
        }

        if (actual == null) return false;

        if (actual == Head)
        {
            Head = Head.Siguiente;
            if (Head != null) Head.Anterior = null;
            else Tail = null;
        }
        else if (actual == Tail)
        {
            Tail = Tail.Anterior;
            if (Tail != null) Tail.Siguiente = null;
            else Head = null;
        }
        else
        {
            actual.Anterior.Siguiente = actual.Siguiente;
            actual.Siguiente.Anterior = actual.Anterior;
        }

        return true;
    }
}

public class NodoCircular
{
    public int Valor;
    public NodoCircular Siguiente;

    public NodoCircular(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

public class ListaCircular
{
    public NodoCircular Head;
    public NodoCircular Tail;

    public ListaCircular()
    {
        Head = null;
        Tail = null;
    }

    public void Agregar(int valor)
    {
        // TODO: agregar el valor al final y conservar Tail.Siguiente == Head.
        NodoCircular nuevo = new NodoCircular(valor);
        if (Head == null)
        {
            Head = nuevo;
            Tail = nuevo;
            Tail.Siguiente = Head;
        }
        else
        {
            Tail.Siguiente = nuevo;
            Tail = nuevo;
            Tail.Siguiente = Head;
        }
    }

    public void AgregarEnPosicion(int valor, int posicion)
    {
        // TODO: insertar el valor en la posicion indicada y conservar el ciclo.
        // Lance ArgumentOutOfRangeException si la posicion no es valida.
        if (posicion < 0) throw new ArgumentOutOfRangeException("posicion");

        if (posicion == 0)
        {
            NodoCircular nuevo = new NodoCircular(valor);
            if (Head == null)
            {
                Head = nuevo;
                Tail = nuevo;
                Tail.Siguiente = Head;
            }
            else
            {
                nuevo.Siguiente = Head;
                Head = nuevo;
                Tail.Siguiente = Head;
            }
            return;
        }

        NodoCircular actual = Head;
        int indice = 0;
        while (actual != null && indice < posicion - 1)
        {
            actual = actual.Siguiente;
            indice++;
            if (actual == Head) break;
        }

        if (indice < posicion - 1 || (actual == Tail && posicion - 1 > indice))
            throw new ArgumentOutOfRangeException("posicion");

        if (actual == Tail)
        {
            Agregar(valor);
            return;
        }

        NodoCircular nuevoNodo = new NodoCircular(valor);
        nuevoNodo.Siguiente = actual.Siguiente;
        actual.Siguiente = nuevoNodo;
    }

    public bool Eliminar(int valor)
    {
        // TODO: eliminar la primera aparicion y conservar el ciclo.
        // Retorne true si elimino un nodo y false si no lo encontro.
        if (Head == null) return false;

        NodoCircular actual = Head;
        NodoCircular anterior = Tail;
        bool encontrado = false;

        do
        {
            if (actual.Valor == valor)
            {
                encontrado = true;
                break;
            }
            anterior = actual;
            actual = actual.Siguiente;
        } while (actual != Head);

        if (!encontrado) return false;

        if (Head == Tail)
        {
            Head = null;
            Tail = null;
            return true;
        }

        if (actual == Head)
        {
            Head = Head.Siguiente;
            Tail.Siguiente = Head;
        }
        else if (actual == Tail)
        {
            Tail = anterior;
            Tail.Siguiente = Head;
        }
        else
        {
            anterior.Siguiente = actual.Siguiente;
        }

        return true;
    }
}

public class Program
{
    private static int pruebasPasadas = 0;
    private static int pruebasFallidas = 0;

    public static void Main()
    {
        Console.WriteLine("PRUEBAS DE LISTAS ENLAZADAS\n");

        ProbarListaSimple();
        ProbarListaDoble();
        ProbarListaCircular();

        Console.WriteLine("\nRESUMEN");
        Console.WriteLine("Pruebas pasadas: " + pruebasPasadas);
        Console.WriteLine("Pruebas fallidas: " + pruebasFallidas);
    }

    private static void ProbarListaSimple()
    {
        Console.WriteLine("--- LISTA SIMPLE ---");

        EjecutarPrueba("Agregar 5 elementos y 3 en posiciones", delegate
        {
            ListaSimple lista = CrearListaSimpleBase();
            lista.AgregarEnPosicion(5, 0);
            lista.AgregarEnPosicion(25, 3);
            lista.AgregarEnPosicion(60, 7);
            Verificar(SecuenciaSimple(lista, 8), 5, 10, 20, 25, 30, 40, 50, 60);
            Afirmar(lista.Head.Valor == 5 && lista.Tail.Valor == 60,
                "Head o Tail incorrecto.");
        });

        EjecutarPrueba("Eliminar Head y Tail", delegate
        {
            ListaSimple lista = CrearListaSimpleBase();
            Afirmar(lista.Eliminar(10), "No elimino el Head.");
            Afirmar(lista.Eliminar(50), "No elimino el Tail.");
            Verificar(SecuenciaSimple(lista, 3), 20, 30, 40);
            Afirmar(lista.Head.Valor == 20 && lista.Tail.Valor == 40,
                "No actualizo Head o Tail.");
        });

        EjecutarPrueba("Eliminar todos los elementos", delegate
        {
            ListaSimple lista = CrearListaSimpleBase();
            foreach (int valor in new int[] { 10, 20, 30, 40, 50 })
                Afirmar(lista.Eliminar(valor), "No elimino " + valor + ".");
            Afirmar(lista.Head == null && lista.Tail == null,
                "La lista no quedo vacia.");
        });

        EjecutarPrueba("Eliminar en lista vacia", delegate
        {
            ListaSimple lista = new ListaSimple();
            Afirmar(!lista.Eliminar(99), "Debia retornar false.");
        });
    }

    private static void ProbarListaDoble()
    {
        Console.WriteLine("\n--- LISTA DOBLE ---");

        EjecutarPrueba("Agregar 5 elementos y 3 en posiciones", delegate
        {
            ListaDoble lista = CrearListaDobleBase();
            lista.AgregarEnPosicion(5, 0);
            lista.AgregarEnPosicion(25, 3);
            lista.AgregarEnPosicion(60, 7);
            Verificar(SecuenciaDoble(lista, 8), 5, 10, 20, 25, 30, 40, 50, 60);
            Afirmar(lista.Head.Anterior == null && lista.Tail.Siguiente == null,
                "Los extremos deben apuntar a null.");
        });

        EjecutarPrueba("Eliminar Head y Tail", delegate
        {
            ListaDoble lista = CrearListaDobleBase();
            Afirmar(lista.Eliminar(10), "No elimino el Head.");
            Afirmar(lista.Eliminar(50), "No elimino el Tail.");
            Verificar(SecuenciaDoble(lista, 3), 20, 30, 40);
            Afirmar(lista.Head.Anterior == null && lista.Tail.Siguiente == null,
                "No actualizo los enlaces de los extremos.");
        });

        EjecutarPrueba("Eliminar todos los elementos", delegate
        {
            ListaDoble lista = CrearListaDobleBase();
            foreach (int valor in new int[] { 10, 20, 30, 40, 50 })
                Afirmar(lista.Eliminar(valor), "No elimino " + valor + ".");
            Afirmar(lista.Head == null && lista.Tail == null,
                "La lista no quedo vacia.");
        });

        EjecutarPrueba("Eliminar en lista vacia", delegate
        {
            ListaDoble lista = new ListaDoble();
            Afirmar(!lista.Eliminar(99), "Debia retornar false.");
        });
    }

    private static void ProbarListaCircular()
    {
        Console.WriteLine("\n--- LISTA CIRCULAR ---");

        EjecutarPrueba("Agregar 5 elementos y 3 en posiciones", delegate
        {
            ListaCircular lista = CrearListaCircularBase();
            lista.AgregarEnPosicion(5, 0);
            lista.AgregarEnPosicion(25, 3);
            lista.AgregarEnPosicion(60, 7);
            Verificar(SecuenciaCircular(lista, 8), 5, 10, 20, 25, 30, 40, 50, 60);
            Afirmar(lista.Tail.Siguiente == lista.Head,
                "Tail.Siguiente debe apuntar a Head.");
        });

        EjecutarPrueba("Eliminar Head y Tail", delegate
        {
            ListaCircular lista = CrearListaCircularBase();
            Afirmar(lista.Eliminar(10), "No elimino el Head.");
            Afirmar(lista.Eliminar(50), "No elimino el Tail.");
            Verificar(SecuenciaCircular(lista, 3), 20, 30, 40);
            Afirmar(lista.Head.Valor == 20 && lista.Tail.Valor == 40,
                "No actualizo Head o Tail.");
            Afirmar(lista.Tail.Siguiente == lista.Head,
                "Se rompio el ciclo.");
        });

        EjecutarPrueba("Eliminar todos los elementos", delegate
        {
            ListaCircular lista = CrearListaCircularBase();
            foreach (int valor in new int[] { 10, 20, 30, 40, 50 })
                Afirmar(lista.Eliminar(valor), "No elimino " + valor + ".");
            Afirmar(lista.Head == null && lista.Tail == null,
                "La lista no quedo vacia.");
        });

        EjecutarPrueba("Eliminar en lista vacia", delegate
        {
            ListaCircular lista = new ListaCircular();
            Afirmar(!lista.Eliminar(99), "Debia retornar false.");
        });
    }

    private static ListaSimple CrearListaSimpleBase()
    {
        ListaSimple lista = new ListaSimple();
        foreach (int valor in new int[] { 10, 20, 30, 40, 50 }) lista.Agregar(valor);
        return lista;
    }

    private static ListaDoble CrearListaDobleBase()
    {
        ListaDoble lista = new ListaDoble();
        foreach (int valor in new int[] { 10, 20, 30, 40, 50 }) lista.Agregar(valor);
        return lista;
    }

    private static ListaCircular CrearListaCircularBase()
    {
        ListaCircular lista = new ListaCircular();
        foreach (int valor in new int[] { 10, 20, 30, 40, 50 }) lista.Agregar(valor);
        return lista;
    }

    private static int[] SecuenciaSimple(ListaSimple lista, int maximo)
    {
        int[] valores = new int[maximo];
        int cantidad = 0;
        NodoSimple actual = lista.Head;
        while (actual != null && cantidad < maximo)
        {
            valores[cantidad] = actual.Valor;
            cantidad++;
            actual = actual.Siguiente;
        }
        Afirmar(actual == null, "La lista simple contiene un ciclo inesperado.");
        Afirmar(cantidad == maximo, "Cantidad de nodos incorrecta.");
        return valores;
    }

    private static int[] SecuenciaDoble(ListaDoble lista, int maximo)
    {
        int[] valores = new int[maximo];
        int cantidad = 0;
        NodoDoble actual = lista.Head;
        NodoDoble anterior = null;
        while (actual != null && cantidad < maximo)
        {
            Afirmar(actual.Anterior == anterior, "Enlace Anterior incorrecto.");
            valores[cantidad] = actual.Valor;
            cantidad++;
            anterior = actual;
            actual = actual.Siguiente;
        }
        Afirmar(actual == null, "La lista doble contiene un ciclo inesperado.");
        Afirmar(cantidad == maximo, "Cantidad de nodos incorrecta.");
        Afirmar(anterior == lista.Tail, "Tail no corresponde al ultimo nodo.");
        return valores;
    }

    private static int[] SecuenciaCircular(ListaCircular lista, int cantidad)
    {
        int[] valores = new int[cantidad];
        NodoCircular actual = lista.Head;
        for (int i = 0; i < cantidad; i++)
        {
            Afirmar(actual != null, "Se encontro un enlace null dentro del ciclo.");
            valores[i] = actual.Valor;
            actual = actual.Siguiente;
        }
        Afirmar(actual == lista.Head, "La lista no cierra el ciclo en Head.");
        return valores;
    }

    private static void Verificar(int[] actual, params int[] esperado)
    {
        Afirmar(actual.Length == esperado.Length,
            "Cantidad incorrecta. Esperada: " + esperado.Length +
            ", obtenida: " + actual.Length + ".");

        for (int i = 0; i < esperado.Length; i++)
            Afirmar(actual[i] == esperado[i],
                "Posicion " + i + ": se esperaba " + esperado[i] +
                " y se obtuvo " + actual[i] + ".");
    }

    private static void EjecutarPrueba(string nombre, Action prueba)
    {
        try
        {
            prueba();
            Console.WriteLine("[PASO]    " + nombre);
            pruebasPasadas++;
        }
        catch (Exception ex)
        {
            Console.WriteLine("[NO PASO] " + nombre + " -> " + ex.Message);
            pruebasFallidas++;
        }
    }

    private static void Afirmar(bool condicion, string mensaje)
    {
        if (!condicion) throw new Exception(mensaje);
    }
}       