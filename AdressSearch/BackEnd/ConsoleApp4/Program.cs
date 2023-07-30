using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using OfficeOpenXml;

string pdfFilePath = "C:\\Users\\mathe\\OneDrive\\Área de Trabalho\\teste.pdf";
string txtFilePath = "C:\\Users\\mathe\\OneDrive\\Área de Trabalho\\caminhodoarquivodesaida.txt";
string arquivoExcel = "C:\\Users\\mathe\\OneDrive\\Área de Trabalho\\teste.xlsx";
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

List<string[]> extractedData = ExtractPdfData(pdfFilePath);
GenerateTextFileFromData(txtFilePath, extractedData);
GenerateArquivo(txtFilePath, arquivoExcel);
void GenerateArquivo(string txtFilePath, string arquivoExcel)
{
    try
    {
        // Lê todas as linhas do arquivo de texto
        string[] linhas = File.ReadAllLines(txtFilePath);

        // Abre o arquivo Excel usando EPPlus
        using (var package = new ExcelPackage(new FileInfo(arquivoExcel)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Dados");

            int rowIndex = 1;
            foreach (string line in linhas)
            {
                // Split the line by spaces to get individual columns
                string[] columns = line.Split(' ');

                // Check if the line contains the required codes (003566 and 002599)
                if (columns.Length >= 4 && (columns[0] == "003566" || columns[0] == "003814") )
                {
                    // Get the values for the last three columns (Hora extra paga, RSR PAGO, BASE INSS PAGA)
                    double horaExtraPaga = double.Parse(columns[columns.Length - 1]);
                    //double rsrPAGO = double.Parse(columns[columns.Length - 1]);
                    //double baseInssPaga = double.Parse(columns[columns.Length - 1]);

                    // Adiciona os títulos das colunas
                    worksheet.Cells[1, 1].Value = "Hora extra paga";
                    //worksheet.Cells[1, 2].Value = "RSR PAGO";
                    //worksheet.Cells[1, 3].Value = "BASE INSS PAGA";

                    // Write the values to the Excel worksheet
                    worksheet.Cells[rowIndex, 1].Value = horaExtraPaga;
                    //worksheet.Cells[rowIndex, 2].Value = rsrPAGO;
                    //worksheet.Cells[rowIndex, 3].Value = baseInssPaga;

                    rowIndex++;
                }

                if (columns.Length >= 4 && (columns[0] == "003567"  || columns[0] == "003583" || columns[0] == "003843" || columns[0] == "003609" || columns[0] == "003815" || columns[0] == "003575"))
                {
                    // Get the values for the last three columns (Hora extra paga, RSR PAGO, BASE INSS PAGA)
                    //double horaExtraPaga = double.Parse(columns[columns.Length - 1]);
                    double rsrPAGO = double.Parse(columns[columns.Length - 1]);
                    //double baseInssPaga = double.Parse(columns[columns.Length - 1]);

                    // Adiciona os títulos das colunas
                    //worksheet.Cells[1, 1].Value = "Hora extra paga";
                    worksheet.Cells[1, 2].Value = "RSR PAGO";
                    //worksheet.Cells[1, 3].Value = "BASE INSS PAGA";

                    // Write the values to the Excel worksheet
                    //worksheet.Cells[rowIndex, 1].Value = horaExtraPaga;
                    worksheet.Cells[rowIndex, 2].Value = rsrPAGO;
                    //worksheet.Cells[rowIndex, 3].Value = baseInssPaga;

                    rowIndex++;
                }

                if (columns.Length >= 4 && (columns[0] == "002599" /*|| columns[0] == "002599") || columns[0] == "003567"*/))
                {
                    // Get the values for the last three columns (Hora extra paga, RSR PAGO, BASE INSS PAGA)
                    //double horaExtraPaga = double.Parse(columns[columns.Length - 1]);
                    //double rsrPAGO = double.Parse(columns[columns.Length - 1]);
                    double baseInssPaga = double.Parse(columns[columns.Length - 1]);

                    // Adiciona os títulos das colunas
                    //worksheet.Cells[1, 1].Value = "Hora extra paga";
                    //worksheet.Cells[1, 2].Value = "RSR PAGO";
                    worksheet.Cells[1, 3].Value = "BASE INSS PAGA";

                    // Write the values to the Excel worksheet
                    //worksheet.Cells[rowIndex, 1].Value = horaExtraPaga;
                    //worksheet.Cells[rowIndex, 2].Value = rsrPAGO;
                    worksheet.Cells[rowIndex, 3].Value = baseInssPaga;

                    rowIndex++;
                }

                

            }

            // Save the Excel package to the output file
            FileInfo outputFileInfo = new FileInfo(arquivoExcel);
            package.SaveAs(outputFileInfo);
        }


        Console.WriteLine("As informações foram escritas no arquivo Excel com sucesso!");
    }
    catch
    {
        Console.WriteLine("As io!");
    }
}


        void GenerateTextFileFromData(string filePath, List<string[]> data)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(txtFilePath))
                {
                    foreach (string[] lineData in data)
                    {
                        string line = string.Join("\t", lineData); // Reverter o processo de separação por tabulação
                        writer.WriteLine(line);
                    }
                }

                Console.WriteLine("Arquivo de texto gerado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao gerar o arquivo: " + ex.Message);
            }
        }




        static List<string[]> ExtractPdfData(string pdfFilePath)
        {
            List<string[]> extractedData = new List<string[]>();
            int mes = 1;
            int ano = 2015;
            int t = 0;
            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    string pageText = PdfTextExtractor.GetTextFromPage(reader, page);
                    string[] lines = pageText.Split('\n');
                    foreach (string line in lines)
                    {
                        //var ye = $"ITAU UNIBANCO S.A. Vigência 0{mes}/{ano}";
                        //if (mes >= 10)
                        //{
                        //    ye = $"ITAU UNIBANCO S.A. Vigência {mes}/{ano}";
                        //}

                        //if (mes == 4)
                        //{
                        //    mes = 5;
                        //    ye = $"ITAU UNIBANCO S.A. Vigência {mes}/{ano}";
                        //}

                        //// string textoSemZero = ye.Replace("09", "{");

                        //if (line.Contains(ye))
                        //    {
                        //        mes++;

                        //        if (mes > 12)
                        //        {
                        //            ano++;
                        //            mes = 1;
                        //        }
                        //    extractedData.Add(line.Split('\t', '\n')); // Assume que as informações estão separadas por tabulação ('\t')
                        //    }


                        // Verifica se a linha contém os códigos que você deseja extrair
                        if (line.Contains("003566") || line.Contains("003567") || line.Contains("002599")  || line.Contains("003832") || line.Contains("003843") || line.Contains("003583") || line.Contains("003609") || line.Contains("003814") || line.Contains("003815"))
                        {
                            extractedData.Add(line.Split('\t', '\n')); // Assume que as informações estão separadas por tabulação ('\t')
                        }


                    }
                }
            }
            return extractedData;
        }



    

  
