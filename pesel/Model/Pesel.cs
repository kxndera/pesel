using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pesel.Model
{
    class Pesel
    {
        private string numerPesel;
        private int liczbaMiesiac;
        private string liczbaMiesiaca;
        private int liczbaDzien;
        private string liczbaDnia;
        private string liczbaRok;
        private string liczbaRoku;
        private string cyfra;
        private int YearNumber;

        #region Plec
        public string Plec
        {
            get
            {
                char cyfraPlec = numerPesel[9];
                int liczbaPlec = int.Parse(cyfraPlec.ToString());
                if (liczbaPlec % 2 == 0)

                    return " Kobieta";

                else
                    return " Mężczyzna";

            }
        }

        #endregion

        #region Miesiac
        public string Miesiac
        {
            get
            {
                liczbaMiesiaca = numerPesel[2].ToString()+ numerPesel[3].ToString();

                int miesiac = int.Parse(liczbaMiesiaca);



                if (miesiac == 81 || miesiac == 01 || miesiac  == 21 || miesiac == 41 || miesiac == 61)
                {
                    return "Styczeń";
                }

              else if (miesiac == 82 || miesiac == 02 || miesiac == 22 || miesiac == 42 || miesiac == 62)
                {
                    return "Luty";
                }
                
                if (miesiac == 83 || miesiac == 03 || miesiac == 23 || miesiac == 43 || miesiac == 63)
                {
                    return "Marzec";
                }

                if (miesiac == 84 || miesiac == 04 || miesiac == 24 || miesiac == 44 || miesiac == 64)
                {
                    return "Kwiecień";
                }

                if (miesiac == 85 || miesiac == 05 || miesiac == 25 || miesiac == 45 || miesiac == 65)
                {
                    return "Maj";
                }

                if (miesiac == 86 || miesiac == 06 || miesiac == 26 || miesiac == 46 || miesiac == 66)
                {
                    return "Czerwiec";
                }

                if (miesiac == 87 || miesiac == 07 || miesiac == 27 || miesiac == 47 || miesiac == 67)
                {
                    return "Lipiec";
                }

                if (miesiac == 88 || miesiac == 08 || miesiac == 28 || miesiac == 48 || miesiac == 68)
                {
                    return "Sierpień";
                }

                if (miesiac == 89 || miesiac == 09 || miesiac == 29 || miesiac == 49 || miesiac == 69)
                {
                    return "Wrzesień";
                }

                if (miesiac == 90 || miesiac == 10 || miesiac == 30 || miesiac == 50 || miesiac == 70)
                {
                    return "Październik";
                }

                if (miesiac == 91 || miesiac == 11 || miesiac == 31 || miesiac == 51 || miesiac == 71)
                {
                    return "Listopad";
                }

                if (miesiac == 92 || miesiac == 12 || miesiac == 32 || miesiac == 52 || miesiac == 72)
                {
                    return "Grudzień";
                }


                else
                {
                    return "Błąd";
                }

            }

            
        }
        #endregion


        #region Dzien

       public string Dzien
        {
            get
            {
                liczbaDnia = numerPesel[4].ToString() + numerPesel[5].ToString();
                
                


                return liczbaDnia;

            }
        }







        #endregion

        #region Stulecia

        public string Rok
        {
            get
            {
        liczbaRoku = numerPesel[0].ToString() + numerPesel[1].ToString();
               int roku = int.Parse(liczbaRoku);



              

                if (liczbaMiesiac > 80 && liczbaMiesiac < 93)
                {
                    roku += 1800;
                }
                else if (liczbaMiesiac > 0 && liczbaMiesiac < 13)
                {
                    roku += 1900;
                }
                else if (liczbaMiesiac > 20 && liczbaMiesiac < 33)
                {
                    roku += 2000;
                }
                else if (liczbaMiesiac > 40 && liczbaMiesiac < 53)
                {
                    roku += 2100;
                }
                else if (liczbaMiesiac > 60 && liczbaMiesiac < 73)
                {
                    roku += 2200;
                }






                liczbaRok = roku.ToString();

                return liczbaRok;
            }
        }


        #endregion


        #region Cyfra

        public string Cyfra
        {
            get
            {
                cyfra = numerPesel[9].ToString();
            
                return cyfra;
            }
        }



        #endregion




        public Pesel(string numer)
        {

            numerPesel = numer;
            WalidacjaNumeruPesel();

           

        }

        private void WalidacjaPoprawnosciZnakow()
        {
            
            for (int i = 0; i < numerPesel.Length;i++)
            {
                if (numerPesel[i] < '0' || numerPesel[i] > '9')
                {

                    throw new Exception("Podano złe znaki");

                }
            }        


        
       

        }



        private void WalidacjaCyfryKontrolnej()
        {


            int cyfraKontrolna = int.Parse(numerPesel[10].ToString());
            int[] pesel = new int[10];
            for (int i = 0; i < 10; i++)
            {
                pesel[i] = int.Parse(numerPesel[i].ToString());
            }

            int[] wagaCyfr = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int wynik;
            int suma = 0;
            string wynikString;
            int ostatniaCyfra;
            string sumaString;
            int s;
            int m;

            for (int j = 0; j < 10; j++)
            {
                wynik = pesel[j] * wagaCyfr[j];
                if (wynik >= 10)
                {
                    wynikString = wynik.ToString();
                    ostatniaCyfra = int.Parse(wynikString[1].ToString());
                    suma = suma + ostatniaCyfra;
                }
                else
                {
                    suma = suma + wynik;
                }
            }
            sumaString = suma.ToString();
            s = int.Parse(sumaString[1].ToString());

            if (s == 0)
            {
                m = 0;
            }
            else
            {
                m = 10 - s;
            }

            if (cyfraKontrolna != m)
            {
               throw new Exception("Błędna Cyfra Kontrolna");
            }








        }








        private void WalidacjaMiesiaca()
        {
           

            liczbaMiesiac = int.Parse(numerPesel[2].ToString() + numerPesel[3].ToString());

            

            if (!(liczbaMiesiac < 92 && liczbaMiesiac > 81 || liczbaMiesiac < 12 && liczbaMiesiac > 01 || liczbaMiesiac < 32 && liczbaMiesiac > 21 
                || liczbaMiesiac < 52 && liczbaMiesiac > 41 || liczbaMiesiac < 72 && liczbaMiesiac > 61 ))
           {
              throw new Exception("Podano zły miesiąc");
            }


          }

          


        // do skonczenia Блять
        private void WalidacjaDnia()
        {
            

          
            
            liczbaDzien = int.Parse(numerPesel[4].ToString() + numerPesel[5].ToString());
            liczbaMiesiac = int.Parse(numerPesel[2].ToString() + numerPesel[3].ToString());


            liczbaRoku = numerPesel[0].ToString() + numerPesel[1].ToString();
            int roku = int.Parse(liczbaRoku);



            if (liczbaDzien > 31)
            {
                throw new Exception("Podano błędną liczbę dni");

            }
             if ( (liczbaMiesiac == 82 || liczbaMiesiac == 02 || liczbaMiesiac == 22 || 
                liczbaMiesiac == 42 || liczbaMiesiac == 62) && liczbaDzien > 28)
            {
                throw new Exception("Podano błędną liczbę dni");

            }

           

         else   if ( (liczbaMiesiac == 84 || liczbaMiesiac == 04 || liczbaMiesiac == 24 || liczbaMiesiac == 44 ||
                liczbaMiesiac == 64) && liczbaDzien > 30)
            {
                throw new Exception("Podano błędną liczbę dni");

            }

         else    if ( (liczbaMiesiac == 86 || liczbaMiesiac == 06 || liczbaMiesiac == 26 
                || liczbaMiesiac == 46 || liczbaMiesiac == 66) && liczbaDzien > 30)
            {
                throw new Exception("Podano błędną liczbę dni");

            }


           else  if ( (liczbaMiesiac == 89 || liczbaMiesiac == 09 || liczbaMiesiac == 29
                || liczbaMiesiac == 49 || liczbaMiesiac == 69) && liczbaDzien > 30)
            {
                throw new Exception("Podano błędną liczbę dni");

            }

         else    if ( (liczbaMiesiac == 91 || liczbaMiesiac == 11 || liczbaMiesiac == 31
                || liczbaMiesiac == 51 || liczbaMiesiac == 71) && liczbaDzien > 30)
            {
                throw new Exception("Podano błędną liczbę dni");

            }

            int year = int.Parse(Rok.ToString());
            

         if   ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
           {
              if ( (liczbaMiesiac == 82 || liczbaMiesiac == 02 || liczbaMiesiac == 22 || 
                    liczbaMiesiac == 42 || liczbaMiesiac == 62) && liczbaDzien > 29)
                {
                    throw new Exception("Podano błędną liczbę dni");

                }
              
            }
        }












        private void WalidacjaNumeruPesel()
        {
            WalidacjaIloscZnakow(); //done
            WalidacjaDnia(); //prawie done
            WalidacjaMiesiaca();//done
            WalidacjaCyfryKontrolnej(); 
            WalidacjaPoprawnosciZnakow(); //done
        }





        private void WalidacjaIloscZnakow()
        {
            if (numerPesel.Length != 11)
            {
                throw new Exception("Zła liczba znaków");
            }
        }
    }
}
