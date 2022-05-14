string antal = "";                                      //antal besökare
string huvudmenyval = "";                               //val i huvudmeny
string agestring = "";                                  //inmatad ålder
bool avsluta = false;                                   //styr huvudloopen
uint uageinteger = 0;                                   //kontrollerat värde på åldern
bool isage = false;                                     //styr kontroll lopen för inmatning av ålder
int pris = 0;                                           //pris per biljett i fall 1 och 2
int enpris = 0;                                         //slutpris för en biljett
uint isinteger = 0;                                     //kontrollera värde för antal besökare
bool isnumbers = false;                                 //styr kontrol loopen för inmatning av antal besökare
int totalt = 0;                                         //totalpriset för flera besökare
string mening = "";                                     //mening som skall upprepas 10 ggr
string mening10 = "";                                   //sträng som kommer att innehålla 10 upprepningar av mening;
var mening2 = "";                                       //mening som skall delas i tre delar
string ord3 = "";                                       //tredje ordet i meningen
int ordantal = 0;                                       // styr kontroll loopen för minst tre ord     


while (avsluta == false)
{

    Console.WriteLine("Hej och välkommen till Huvudmenyn för BIO 22B");
    Console.WriteLine("För att testa olika funktioner skriv en siffra följt av enter");
    Console.WriteLine("För att stänga av programmet, tryck 0 och enter ");                      //huvudmeny
    Console.WriteLine("För att se biljettpris vid viss ålder, tryck 1 och enter");
    Console.WriteLine("För att se priset för en grupp besökare, tryck 2 och enter");
    Console.WriteLine("För att upprepa en mening 10 ggr, tryck 3 och enter");
    Console.WriteLine("För att dela upp en mening, tryck 4 och enter");


    huvudmenyval = Console.ReadLine();

    switch (huvudmenyval)
    {
        case "0":
            avsluta = true;
            break;

        case "1":
            enpris = 0;
            enpris = prislista();                                                                       //till if satsen som bestämmer pris
            if (enpris == 80)
                Console.WriteLine("Ungdomspris 80 Kr");
            else if (enpris == 90)
                Console.WriteLine("Pensionärspris 90 Kr");
            else if (enpris == 120)
                Console.WriteLine("Standardpris 120Kr");
            else
                Console.WriteLine("Småbarn under 5 år och Pensionärer över 100 år går gratis!");        //gjorde en gemensam utskrift för de som gick in gratis
            break;

        case "2":
            totalt = 0;
            isnumbers = false;
            Console.WriteLine("Ange antalet besökare och tryck enter");
            while (isnumbers == false)
            {
                antal = Console.ReadLine();
                isnumbers = uint.TryParse(antal, out isinteger);                                        //test av inmatning
                if (isnumbers == false)
                    Console.WriteLine("felaktig inmatning, pröva igen");
            }
            for (int i = 0; i < isinteger; i++)
            {
                Console.WriteLine($"mata in åldern på deltagare nummer {i + 1}");                         //addera priserna för de enskilda biljetterna 
                totalt += prislista();
            }
            Console.WriteLine($"Det totala priset  för {isinteger} deltagare blir {totalt} kr ");
            break;

        case "3":
            Console.WriteLine("Skriv in en mening och avsluta med enter");
            mening = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                mening10 += $" {mening}";                                                        //skapar låång mening   
            }                                                                                       
            Console.WriteLine($"{mening10}");                                                        //skriver ut samma inmatade mening 10ggr på samma rad  
            break;

        case "4":
            ordantal = 0;
            Console.WriteLine("Skriv in en mening med minst 3 ord");
            while (ordantal < 3)                                                                    //kontrollerar att meningen innehåller minst 3 ord
            {

                mening2 = Console.ReadLine();
                ordantal = (mening2.Split(" ")).Length;
                if (ordantal < 3)
                    Console.WriteLine("För få ord inmatade, prova igen");
            }
            ord3 = mening2.Split(" ")[2];                                                           // splittar ut 3e ordet men klarar ej extra mellanslag 

            Console.WriteLine($"meningen har har {ordantal} ord");
            Console.WriteLine($"Det tredje ordet i meningen är {ord3} ");
            break;

        default:
            Console.WriteLine("Felaktigt inmatning, försök igen");
            break;


    }
    Console.WriteLine("Tryck enter för att fortsätta");                                 //
    Console.ReadLine();                                                                 //ökar läsbarheten i huvudmenyn
    Console.Clear();                                                                    //    

}



int prislista()                                                                        //rätt pris för rätt åldersgrupp
{
    isage = false;
    Console.WriteLine("Ange ålder följt av enter");
    pris = 0;
    // uageinteger = inmatningmedkoll();
    while (isage == false)
    {
        agestring = Console.ReadLine();                                             //kontrolerar inmatning av ålder
        isage = uint.TryParse(agestring, out uageinteger);
        if (isage == false)
            Console.WriteLine("felaktig inmatning, pröva igen");

    }
    if (uageinteger > 5)
    {
        if (uageinteger >= 20)
        {
            if (uageinteger >= 64)
            {
                if (uageinteger >= 100)
                {
                    pris = 0;
                }
                else
                {
                    pris = 90;                                                      //bestämmer rätt pris för rätt ålder 
                }
            }
            else
            {
                pris = 120;
            }
        }
        else
        {
            pris = 80;
        }
    }
    else
    {
        pris = 0;
    }
    return (pris);                                                                //returnerar rätt pris
}


