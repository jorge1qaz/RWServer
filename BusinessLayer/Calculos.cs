using System;

namespace BusinessLayer
{
    public class Calculos
    {
        //retorna un número con formato de string, completando hacía la derecha con ceros en caso de que sea menor a 4 decimales
        public string CompleteZeros(decimal number)
        {
            int lengthNumber;
            try
            {
                lengthNumber = Convert.ToString(number).Substring(Convert.ToString(number).IndexOf(".")).Length - 1;
            }
            catch
            {
                lengthNumber = 4;
            }
            string numberComplete = Convert.ToString(number);
            switch (lengthNumber.ToString())
            {
                case "1":
                    numberComplete = numberComplete + "000";
                    break;
                case "2":
                    numberComplete = numberComplete + "00";
                    break;
                case "3":
                    numberComplete = numberComplete + "0";
                    break;
                default:
                    break;
            }
            return numberComplete;
        }
    }
}
