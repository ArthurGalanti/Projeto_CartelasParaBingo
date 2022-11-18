using System.Drawing;
using Projeto_CartelasParaBingo;

int quantidadeCartelas = 5;
var palavras = new List<string?>();
var posicoes = new posicao[8];
PrencherListaNomes();
PrencherPosicoes();
Bitmap newBitmap;

for (int i = 0; i < quantidadeCartelas; i++)
{
    using (var bitmap = (Bitmap)Image.FromFile("imagens/bingo.png"))//load the image file    
    {
        for (int j = 0; j < 8; j++)
        {
            var palavraSelecionada = palavras.PickRandom();
            palavras.Remove(palavraSelecionada);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
                {
                    Rectangle rect = new Rectangle(posicoes[j].a, posicoes[j].b, bitmap.Width, bitmap.Height);

                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    graphics.DrawString(palavraSelecionada, arialFont, Brushes.Black, rect, sf);
                }
            }

        }
        PrencherListaNomes();
        newBitmap = new Bitmap(bitmap);
        newBitmap.Save($"imagens/Cartela - {i + 1}.png");//save the image file    
        newBitmap.Dispose();

    }
}

void PrencherListaNomes()
{
    palavras.Clear();
    palavras.Add("Automation");
    palavras.Add("Cloud");
    palavras.Add("5G");
    palavras.Add("Edge" + Environment.NewLine + "Computing");
    palavras.Add("Extended" + Environment.NewLine + "Reality");
    palavras.Add("Quantum" + Environment.NewLine + "Computing");
    palavras.Add("Enterprise" + Environment.NewLine + "Plataform");
    palavras.Add("Metaverse");
    palavras.Add("Agile");
    palavras.Add("Teste1");
    palavras.Add("Teste2");
    palavras.Add("Teste3");
    palavras.Add("Teste4");

}
void PrencherPosicoes()
{
    posicoes[0].a = -110;
    posicoes[0].b = -110;
    posicoes[1].a = 0;
    posicoes[1].b = -110;
    posicoes[2].a = 110;
    posicoes[2].b = -110;
    posicoes[3].a = -110;
    posicoes[3].b = 0;
    posicoes[4].a = 110;
    posicoes[4].b = 0;
    posicoes[5].a = -110;
    posicoes[5].b = 110;
    posicoes[6].a = 0;
    posicoes[6].b = 110;
    posicoes[7].a = 110;
    posicoes[7].b = 110;
}
public struct posicao
{
    public int a;
    public int b;
}