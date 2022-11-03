namespace Talleres.API.Utilities
{
    public class CalcularFechaFinal
    {
        public DateTime Calcular(string [] diasClase, int sesiones, DateTime fechaInicial)
        {
            DateTime fechaInicio = fechaInicial;
            string[] diasSemana = new string[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

            //Invocación de método filtrarDias
            Dictionary<string, int> result = new Dictionary<string, int>();
            result = filtrarDias(diasClase);

            string[] dias = new string[result.Count];
            int[] fr = new int[result.Count];
            List<int> diasOrdenados = new List<int>();
            int[] frecuencia = new int[fr.Length];
            int indice;

            dias = result.Keys.ToArray();
            fr = result.Values.ToArray();

            //recuperamos indices
            foreach (var item in dias)
            {
                indice = Array.IndexOf(diasSemana, item);
                diasOrdenados.Add(indice);
            }

            //Ordenar Días
            diasOrdenados.Sort();

            //Retomamos valores string ahora ordenados: Dias de semana ordenados
            List<string> diasOrdenadosString = new List<string>();
            string dia;
            foreach (var item in diasOrdenados)
            {
                dia = diasSemana[item];
                diasOrdenadosString.Add(dia);
            }

            //Estableciendo dia de inicio y traduciéndolo al español
            int diaInicio = fechaInicio.Day;
            string diaInicString = String.Empty;
            //Traducir de inglés a español

            switch (diaInicio)
            {
                case 0:
                    diaInicString = "Lunes";
                    break;
                case 1:
                    diaInicString = "Martes";
                    break;
                case 2:
                    diaInicString = "Miércoles";
                    break;
                case 3:
                    diaInicString = "Jueves";
                    break;
                case 4:
                    diaInicString = "Viernes";
                    break;
                case 5:
                    diaInicString = "Sábado";
                    break;
                case 6:
                    diaInicString = "Domingo";
                    break;
                default:
                    break;
            }

            //Ordenar las frecuencias
            int i = 0;
            foreach (var item in diasOrdenadosString)
            {
                int p = Array.IndexOf(dias, item);
                frecuencia[i] = fr[p];
                i++;
            }

            //Creando array con los 7 dias de la semana asignando frecuencia n si la hay o 0 si no la hay
            int[] semanaCompleta = new int[7];
            int d = 0;
            for (int e = 0; e < 7; e++)
            {
                int index = Array.IndexOf(diasOrdenados.ToArray(), d);
                if (index != -1)
                {
                    semanaCompleta[e] = frecuencia[index];
                }
                else
                {
                    semanaCompleta[d] = 0;
                }
                d++;
            }

            //Identificar dia de inicio en array contando los días transcurridos con base en las sesiones
            int indexFechaInicial = Array.IndexOf(diasSemana, diaInicString);

            //Determinamos número de días transcurridos
            int t = 0;
            int suma = 0;
            while (suma < sesiones)
            {
                if (indexFechaInicial == 7)
                {
                    indexFechaInicial = 0;
                }
                suma = suma + semanaCompleta[indexFechaInicial];
                indexFechaInicial++;
                t++;
            }

            //Agregamos el número de dpias a la fecha inicial
            DateTime fecha = fechaInicio;
            fecha = fecha.AddDays(t - 1);

            return fecha;
        }

        private Dictionary<string, int> filtrarDias(string[] diasClase)
        {
            List<string> diasClaseSinRepetir = new List<string>();
            List<int> diasClaseSinRepetirSesiones = new List<int>();
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var item in diasClase)
            {
                int dia = diasClaseSinRepetir.IndexOf(item);
                if (dia == -1)
                {
                    diasClaseSinRepetir.Add(item);
                    diasClaseSinRepetirSesiones.Add(1);
                }
                else
                {//si se encuentra...
                    int y = diasClaseSinRepetirSesiones[dia];
                    y++;//
                    diasClaseSinRepetirSesiones[dia] = y;
                }
            }

            for (int i = 0; i < diasClaseSinRepetir.Count; i++)
            {
                result.Add(diasClaseSinRepetir[i], diasClaseSinRepetirSesiones[i]);
            }

            return result;
        }
    }
}
