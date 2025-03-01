namespace Task_Tracker {
    static class Program {
        private static void PrintData(string[] data) {
            for (int i = 0; i < data.Length; i++) {
                Console.Write(data[i]);
                if (i < data.Length - 1) {
                    Console.Write(" ");
                }
                else if (i == data.Length - 1) {
                    Console.Write("\n");
                }
            }
        }
        static void Main(string[] args) {
            if (args.Length > 0 && args[0] == "print-data") {
                if (args.Length > 1) {
                    PrintData(args[1..]);
                }
                else {
                    Console.WriteLine("No data provided to print.");
                }
            }
            else {
                Console.WriteLine("Usage: Task_Tracker print-data [data to print]");
            }
        }
    }
}