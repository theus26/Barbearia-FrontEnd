using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NLTK;
using NLTK.Tokenize;

class Program
{
    static void Main()
    {
        // Texto do capítulo da Bíblia
        string bibleChapter = "No princípio, Deus criou os céus e a terra. A terra era sem forma e vazia; e havia trevas sobre a face do abismo, mas o Espírito de Deus pairava sobre a face das águas. E disse Deus: Haja luz. E houve luz.";

        // Remover pontuações e tokenizar o texto
        string[] sentences = Regex.Split(bibleChapter, @"(?<=[\.!\?])\s+");

        // Inicializar o tokenizador
        var tokenizer = new PunktSentenceTokenizer();
        var wordTokenizer = new TreebankWordTokenizer();

        // Formular perguntas para cada sentença
        foreach (var sentence in sentences)
        {
            // Tokenizar a sentença em palavras
            var words = wordTokenizer.Tokenize(sentence);

            // Formular a pergunta
            var question = FormulateQuestion(words);

            // Exibir a pergunta
            Console.WriteLine(question);
        }
    }

    static string FormulateQuestion(string[] words)
    {
        // Lógica simples para formular perguntas
        var questionWords = words.Take(words.Length - 1).ToArray(); // Remover a última palavra (geralmente um ponto final)
        var question = string.Join(" ", questionWords);

        return $"Qual é {question.ToLower()}?";
    }
}
