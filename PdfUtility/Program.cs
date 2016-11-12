namespace iTextTools
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Split();
            Merge();
        }

        private static void Split()
        {
            var pdfSplitAndMerge = new PdfUtility();
            var source1 = @"C:\Downloads\source1.pdf";
            var destination = @"C:\Downloads\destination.pdf";

            pdfSplitAndMerge.ExtractPages(source1, destination, new []{1,3,4});
        }

        private static void Merge()
        {
            var pdfSplitAndMerge = new PdfUtility();
            var source1 = @"C:\Downloads\source1.pdf";
            var source2 = @"C:\Downloads\source2.pdf";
            var source3 = @"C:\Downloads\source3.pdf";
            var destination = @"C:\Downloads\destination.pdf";

            pdfSplitAndMerge.CombinePdfFiles(new[] {source1, source2, source3}, destination);
        }
    }
}
