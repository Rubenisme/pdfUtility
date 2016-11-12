using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace iTextTools
{
    public class PdfUtility
    {
        public void ExtractPages(string sourcePdfPath, string outputPdfPath, int[] extractThesePages)
        {
            try
            {
                // Intialize a new PdfReader instance with the 
                // contents of the source Pdf file:
                var reader = new PdfReader(sourcePdfPath);

                // For simplicity, I am assuming all the pages share the same size and rotation as the first page:
                var sourceDocument = new Document(reader.GetPageSizeWithRotation(extractThesePages[0]));

                // Initialize an instance of the PdfCopyClass with the source document and an output file stream:
                var pdfCopyProvider = new PdfCopy(sourceDocument, new FileStream(outputPdfPath, FileMode.Create));

                sourceDocument.Open();

                // Walk the array and add the page copies to the output file:
                foreach (var pageNumber in extractThesePages)
                {
                    var importedPage = pdfCopyProvider.GetImportedPage(reader, pageNumber);
                    pdfCopyProvider.AddPage(importedPage);
                }
                sourceDocument.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ExtractPages(string sourcePdfPath, string outputPdfPath, int startPage, int endPage)
        {
            try
            {
                // Intialize a new PdfReader instance with the contents of the source Pdf file:
                var reader = new PdfReader(sourcePdfPath);

                // For simplicity, I am assuming all the pages share the same size and rotation as the first page:
                var sourceDocument = new Document(reader.GetPageSizeWithRotation(startPage));

                // Initialize an instance of the PdfCopyClass with the source document and an output file stream:
                var pdfCopyProvider = new PdfCopy(sourceDocument, new FileStream(outputPdfPath, FileMode.Create));

                sourceDocument.Open();

                // Walk the specified range and add the page copies to the output file:
                for (int i = startPage; i <= endPage; i++)
                {
                    var importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }
                sourceDocument.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void ExtractPage(string sourcePdfPath, string outputPdfPath, int pageNumber)
        {
            try
            {
                // Intialize a new PdfReader instance with the contents of the source Pdf file:
                var reader = new PdfReader(sourcePdfPath);

                // Capture the correct size and orientation for the page:
                var document = new Document(reader.GetPageSizeWithRotation(pageNumber));

                // Initialize an instance of the PdfCopyClass with the source document and an output file stream:
                var pdfCopyProvider = new PdfCopy(document, new FileStream(outputPdfPath, FileMode.Create));

                document.Open();

                // Extract the desired page number:
                var importedPage = pdfCopyProvider.GetImportedPage(reader, pageNumber);
                pdfCopyProvider.AddPage(importedPage);
                document.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CombineExtractedPages()
        {
            throw new NotImplementedException();
        }

        public void CombinePdfFiles(string[] sourcePdfFiles, string outputPdfFile)
        {
            var sourceDocument = new Document();
            var pdfCopyProvider = new PdfCopy(sourceDocument, new FileStream(outputPdfFile, FileMode.Create));

            //Open the output file
            sourceDocument.Open();

            try
            {
                //Loop through the files list
                foreach (var pdfFile in sourcePdfFiles)
                {
                    var reader = new PdfReader(pdfFile);
                    
                    //Add pages of current file
                    for (var i = 1; i <= reader.NumberOfPages; i++)
                    {
                        var importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }

                    reader.Close();
                }
                //At the end save the output file
                sourceDocument.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}