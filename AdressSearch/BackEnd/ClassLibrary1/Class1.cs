
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

static void Main(string[] args)
{
    string pdfFilePath = "C:\\Users\\mathe\\OneDrive\\Área de Trabalho\\teste.pdf";
   // string excelFilePath = "caminho/do/arquivo.xlsx";

    List<string[]> extractedData = ExtractPdfData(pdfFilePath);
   // GenerateExcelFile(excelFilePath, extractedData);

    Console.WriteLine("Extração e geração do Excel concluídas!");
}



 static List<string[]> ExtractPdfData(string pdfFilePath)
{
    List<string[]> extractedData = new List<string[]>();
    using (PdfReader reader = new PdfReader(pdfFilePath))
    {
        for (int page = 1; page <= reader.NumberOfPages; page++)
        {
            string pageText = PdfTextExtractor.GetTextFromPage(reader, page);
            string[] lines = pageText.Split('\n');
            foreach (string line in lines)
            {
                // Verifica se a linha contém os códigos que você deseja extrair
                if (line.Contains("003566") || line.Contains("003567") || line.Contains("002599"))
                {
                    extractedData.Add(line.Split('\t')); // Assume que as informações estão separadas por tabulação ('\t')
                }
            }
        }
    }
    return extractedData;
}

// static void GenerateExcelFile(string excelFilePath, List<string[]> data)
//{
//    using (var workbook = new XLWorkbook())
//    {
//        var worksheet = workbook.Worksheets.Add("Sheet1");

//        // Escreve os dados no arquivo Excel
//        for (int i = 0; i < data.Count; i++)
//        {
//            string[] rowData = data[i];
//            for (int j = 0; j < rowData.Length; j++)
//            {
//                worksheet.Cell(i + 1, j + 1).Value = rowData[j];
//            }
//        }

//        workbook.SaveAs(excelFilePath);
//    }

