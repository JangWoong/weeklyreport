// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // create data file

    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = int.Parse(Console.ReadLine());
        // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    Console.WriteLine(dataDate);
    
    // random number generator
    Random rnd = new Random();

    // create file
    StreamWriter sw = new StreamWriter("data.txt");

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
          // generate random number of hours slept between 4-12 (inclusive)
          hours[i] = rnd.Next(4, 13);
        }

        /*
        Week of Sep, 06, 2020
        Su Mo Tu We Th Fr Sa Tot Avg
        -- -- -- -- -- -- -- --- ---
         7  4 10  6  9 11  7  48 6.9
        */

        //Console.WriteLine($"{string.Join("|", hours)} \n");

        Console.WriteLine($"Week of {dataDate:MM, dd, yyyy}");
        Console.WriteLine("Su Mo Tu We Th Fr Sa Tot Avg");
        Console.WriteLine("-- -- -- -- -- -- -- --- ---");

        string sleeptime = "";
        int tot = 0;

        for (int j = 0; j < hours.Length; j++)
        {
          if(hours[j] < 10)
            sleeptime += $" {hours[j].ToString()} ";
          else if(hours[j] >= 10)
            sleeptime += $"{hours[j].ToString()} ";

          tot += hours[j];
        }

        double avg = tot/7.0;

        Console.WriteLine($"{sleeptime} {tot.ToString()} {avg:0.#}");
        Console.WriteLine();
         
        sw.WriteLine($"Week of {dataDate:MM, dd, yyyy}");
        sw.WriteLine("Su Mo Tu We Th Fr Sa Tot Avg");
        sw.WriteLine("-- -- -- -- -- -- -- --- ---");
        sw.WriteLine($"{sleeptime} {tot.ToString()} {avg:0.#} \n");

        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    // TODO: parse data file

}
